using Bibliotekos_Sistema.Forms;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bibliotekos_Sistema.Database;
using Bibliotekos_Sistema.Interfaces;

namespace Bibliotekos_Sistema.Classes
{
    public class Book
    {
        private readonly SqlCommand _command;
        private string sql;
        private readonly IDatabaseOperations _databaseOperations;

        public Book(IDatabaseOperations databaseOperations)
        {
            _databaseOperations = databaseOperations;
            _command = new SqlCommand();
        }

        public int totalBook()
        {
            SqlDataReader DR;
            int counter = 0;
            try
            {
                SqlConnection sqlConnection = _databaseOperations.GetConnection();
                sqlConnection.Open();
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sql = "SELECT * FROM tblBookDetail";
                    _command.Connection = sqlConnection;
                    _command.CommandText = sql;
                    DR = _command.ExecuteReader();
                    while (DR.Read())
                    {
                        counter++;
                    }
                    DR.Close();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                _databaseOperations.GetConnection().Close();
            }

            return counter;
        }

        public void loadBooksIntoTable(DataGridView DataGridView)
        {
            SqlDataAdapter DA = new SqlDataAdapter();
            DataTable DT = new DataTable();

            try
            {
                SqlConnection sqlConnection = _databaseOperations.GetConnection();
                sqlConnection.Open();
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sql = "SELECT * FROM tblBookDetail";
                    _command.Connection = sqlConnection;
                    _command.CommandText = sql;
                    DA.SelectCommand = _command;
                    DA.Fill(DT);
                    DataGridView.DataSource = DT;

                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                _databaseOperations.GetConnection().Close();
            }
        }

        public void saveBookInfo(DataGridView dgvBook, ComboBox cboCategory, ComboBox cboPublisher, TextBox txtISBN, TextBox txtTitle, TextBox txtPubYear, TextBox txtAcNumber, TextBox txtCurrNumber)
        {
            SqlDataAdapter DA = new SqlDataAdapter();
            DataTable DT = new DataTable();
            SqlDataReader DR;
            int categoryID = 0, publisherID = 0;
            try
            {
                SqlConnection sqlConnection = _databaseOperations.GetConnection();
                sqlConnection.Open();
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sql = $"SELECT Category_ID FROM tblCategory WHERE Category_Name='{cboCategory.Text}'";
                    _command.Connection = sqlConnection;
                    _command.CommandText = sql;
                    DR = _command.ExecuteReader();
                    while (DR.Read())
                    {
                        categoryID = DR.GetInt32(0);
                    }
                    DR.Close();
                    sql = $"SELECT Binding_ID FROM tblBindingDetail WHERE Binding_Name='{cboPublisher.Text}'";
                    DR = _command.ExecuteReader();
                    while (DR.Read())
                    {
                        publisherID = DR.GetInt32(0);
                    }
                    DR.Close();
                    if (txtISBN.Text.Length == 0 || txtTitle.Text.Length == 0 || txtPubYear.Text.Length == 0)
                    {
                        MessageBox.Show("Vienas ar daugiau laukų yra privalomi!");
                    }
                    else
                    {
                        sql = "INSERT INTO tblBookDetail(ISBN,Book_Title,Category,Binding_ID,Publication_Year,Actual_No_Of_Copy,Current_No_Of_Copy)" +
                            "VALUES('" + txtISBN.Text + "','" + txtTitle.Text + "'," + categoryID + "," + publisherID + "," + int.Parse(txtPubYear.Text) + "," + int.Parse(txtAcNumber.Text) + "," + txtCurrNumber.Text + ")";
                        _command.CommandText = sql;
                        if (_command.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("Knyga sėkmingai pridėta!");

                            txtISBN.Clear();
                            txtTitle.Clear();
                            txtPubYear.Clear();
                            txtAcNumber.Clear();
                            txtCurrNumber.Clear();
                            cboPublisher.ResetText();
                            cboCategory.ResetText();

                            sql = "SELECT * FROM tblBookDetail";
                            _command.CommandText = sql;
                            DA.SelectCommand = _command;
                            DA.Fill(DT);
                            dgvBook.DataSource = DT;
                        }
                        else
                        {
                            MessageBox.Show("Klaida: Nėra galimybės pridėti knygą!");
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                _databaseOperations.GetConnection().Close();
            }
        }

        public void deleteBookInfo(DataGridView dgvBook, ComboBox cboCategory, ComboBox cboPublisher, TextBox txtISBN, TextBox txtTitle, TextBox txtPubYear, TextBox txtAcNumber, TextBox txtCurrNumber)
        {
            SqlDataAdapter DA = new SqlDataAdapter();
            DataTable DT = new DataTable();

            try
            {
                SqlConnection sqlConnection = _databaseOperations.GetConnection();
                sqlConnection.Open();
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sql = $"DELETE FROM tblBookDetail WHERE ISBN='{txtISBN.Text}'";
                    _command.Connection = sqlConnection;
                    _command.CommandText = sql;
                    if (_command.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Knyga sėkmingai ištrinta!");
                        txtISBN.Clear();
                        txtTitle.Clear();
                        txtPubYear.Clear();
                        txtAcNumber.Clear();
                        txtCurrNumber.Clear();
                        cboPublisher.ResetText();
                        cboCategory.ResetText();
                        sql = "SELECT * FROM tblBookDetail";
                        _command.CommandText = sql;
                        DA.SelectCommand = _command;
                        DA.Fill(DT);
                        dgvBook.DataSource = DT;
                    }
                    else
                    {
                        MessageBox.Show("Klaida: Nėra galimybės ištrinti knygą!");
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                _databaseOperations.GetConnection().Close();
            }
        }

        public void editBookInfo(DataGridView dgvBook, ComboBox cboCategory, ComboBox cboPublisher, TextBox txtISBN, TextBox txtTitle, TextBox txtPubYear, TextBox txtAcNumber, TextBox txtCurrNumber)
        {
            SqlDataAdapter DA = new SqlDataAdapter();
            DataTable DT = new DataTable();
            SqlDataReader DR;
            int publisherID = 0, categoryID = 0;

            try
            {
                SqlConnection sqlConnection = _databaseOperations.GetConnection();
                sqlConnection.Open();
                if (sqlConnection.State == ConnectionState.Open)
                {
                    Console.WriteLine("Connected!");
                    sql = $"SELECT Category_ID FROM tblCategory WHERE Category_Name='{cboCategory.Text}'";
                    _command.Connection = sqlConnection;
                    _command.CommandText = sql;
                    DR = _command.ExecuteReader();
                    while (DR.Read())
                    {
                        categoryID = DR.GetInt32(0);
                    }
                    DR.Close();

                    sql = $"SELECT Binding_ID FROM tblBindingDetail WHERE Binding_Name='{cboPublisher.Text}'";
                    DR = _command.ExecuteReader();
                    while (DR.Read())
                    {
                        publisherID = DR.GetInt32(0);
                    }
                    DR.Close();
                    if (txtISBN.Text.Length == 0 || txtTitle.Text.Length == 0 || txtPubYear.Text.Length == 0)
                    {
                        MessageBox.Show("Vienas ar daugiau laukų yra privalomi!");
                    }
                    else
                    {
                        sql = $"UPDATE tblBookDetail SET Book_Title='{txtTitle.Text}'," +
                            $"Category='{categoryID}'," +
                            $"Binding_ID='{publisherID}'," +
                            $"Publication_Year='{int.Parse(txtPubYear.Text)}'," +
                            $"Actual_No_Of_Copy='{int.Parse(txtAcNumber.Text)}'," +
                            $"Current_No_Of_Copy='{int.Parse(txtCurrNumber.Text)}'" +
                            $"WHERE ISBN='{txtISBN.Text}'";
                        _command.CommandText = sql;
                        if (_command.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("Knyga sėkmingai atnaujinta!");
                            txtISBN.Clear();
                            txtTitle.Clear();
                            txtPubYear.Clear();
                            txtAcNumber.Clear();
                            txtCurrNumber.Clear();
                            cboPublisher.ResetText();
                            cboCategory.ResetText();
                            sql = "SELECT * FROM tblBookDetail";
                            _command.CommandText = sql;
                            DA.SelectCommand = _command;
                            DA.Fill(DT);
                            dgvBook.DataSource = DT;
                        }
                        else
                        {
                            MessageBox.Show("Klaida: Nėra galimybės atnaujinti knygos duomenų!");
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                _databaseOperations.GetConnection().Close();
            }
        }
    }
}
