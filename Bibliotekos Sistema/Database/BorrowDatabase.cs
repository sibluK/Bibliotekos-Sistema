using Bibliotekos_Sistema.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bibliotekos_Sistema.Database
{
    public class BorrowDatabase : IBorrowDatabase
    {
        private readonly SqlCommand _command;
        private string sql;
        private readonly IDatabaseOperations _databaseOperations;

        public BorrowDatabase(IDatabaseOperations databaseOperations)
        {
            _databaseOperations = databaseOperations;
            _command = new SqlCommand();
        }

        public void LoadBorrowsIntoTable(DataGridView DataGridView)
        {
            SqlDataAdapter DA = new SqlDataAdapter();
            DataTable DT = new DataTable();

            try
            {
                SqlConnection sqlConnection = _databaseOperations.GetConnection();
                sqlConnection.Open();
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sql = "SELECT * FROM tblBorrowDetail";
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

        public void SaveBorrowInfo(DataGridView dgvBorrows, TextBox txtBorrowID, TextBox txtISBN, TextBox txtStudentID, MaskedTextBox mtbBorrowDate, MaskedTextBox mtbReturnDate, TextBox txtIssuerID)
        {
            SqlDataAdapter DA = new SqlDataAdapter();
            DataTable DT = new DataTable();

            try
            {
                SqlConnection sqlConnection = _databaseOperations.GetConnection();
                sqlConnection.Open();
                if (sqlConnection.State == ConnectionState.Open)
                {
                    if (txtISBN.Text.Length == 0
                        || txtStudentID.Text.Length == 0
                        || mtbBorrowDate.Text.Length == 0
                        || mtbReturnDate.Text.Length == 0
                        || txtIssuerID.Text.Length == 0)
                    {
                        MessageBox.Show("Įveskite vieną ar daugiau laukų!");
                    }
                    else
                    {
                        sql = $"INSERT INTO tblBorrowDetail(ISBN,Stud_ID,BorrowDate,Actual_Return_Date,Issued_By)" +
                              $" VALUES('{txtISBN.Text}','{txtStudentID.Text}','{mtbBorrowDate.Text}','{mtbReturnDate.Text}','{txtIssuerID.Text}')";
                        _command.Connection = sqlConnection;
                        _command.CommandText = sql;
                        if (_command.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("Knyga išduoda sėkmingai!");
                            txtBorrowID.Clear();
                            txtISBN.Clear();
                            txtStudentID.Clear();
                            mtbBorrowDate.Clear();
                            mtbReturnDate.Clear();
                            txtIssuerID.Clear();
                            sql = "SELECT * FROM tblBorrowDetail";
                            _command.CommandText = sql;
                            DA.SelectCommand = _command;
                            DA.Fill(DT);
                            dgvBorrows.DataSource = DT;
                        }
                        else
                        {
                            MessageBox.Show("Nepavyko išduoti knygos!");
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

        public void DeleteBorrowInfo(DataGridView dgvBorrows, TextBox txtBorrowID, TextBox txtISBN, TextBox txtStudentID, MaskedTextBox mtbBorrowDate, MaskedTextBox mtbReturnDate, TextBox txtIssuerID)
        {
            SqlDataAdapter DA = new SqlDataAdapter();
            DataTable DT = new DataTable();
            try
            {
                SqlConnection sqlConnection = _databaseOperations.GetConnection();
                sqlConnection.Open();
                if (sqlConnection.State == ConnectionState.Open)
                {
                    if (txtBorrowID.Text.Length == 0)
                    {
                        MessageBox.Show("Pasirinkite išdavimą!");
                    }
                    else
                    {
                        sql = $"DELETE FROM tblBorrowDetail WHERE Borrow_ID='{int.Parse(txtBorrowID.Text)}'";
                        _command.Connection = sqlConnection;
                        _command.CommandText = sql;
                        if (_command.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("Išdavimas sėkmingai panaikintas");
                            txtBorrowID.Clear();
                            txtISBN.Clear();
                            txtStudentID.Clear();
                            mtbBorrowDate.Clear();
                            mtbReturnDate.Clear();
                            txtIssuerID.Clear();
                            sql = "SELECT * FROM tblBorrowDetail";
                            _command.CommandText = sql;
                            DA.SelectCommand = _command;
                            DA.Fill(DT);
                            dgvBorrows.DataSource = DT;
                        }
                        else
                        {
                            MessageBox.Show("Nepavyko ištrinto išdavimo!");
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

        public void EditBorrowInfo(DataGridView dgvBorrows, TextBox txtBorrowID, TextBox txtISBN, TextBox txtStudentID, MaskedTextBox mtbBorrowDate, MaskedTextBox mtbReturnDate, TextBox txtIssuerID)
        {
            SqlDataAdapter DA = new SqlDataAdapter();
            DataTable DT = new DataTable();

            try
            {
                SqlConnection sqlConnection = _databaseOperations.GetConnection();
                sqlConnection.Open();
                if (sqlConnection.State == ConnectionState.Open)
                {
                    if (txtISBN.Text.Length == 0
                        || txtStudentID.Text.Length == 0
                        || mtbBorrowDate.Text.Length == 0
                        || mtbReturnDate.Text.Length == 0
                        || txtIssuerID.Text.Length == 0)
                    {
                        MessageBox.Show("Įveskite vieną ar daugiau laukų!");
                    }
                    else
                    {
                        sql = $"UPDATE tblBorrowDetail SET ISBN='{txtISBN.Text}', Stud_ID='{txtStudentID.Text}'," +
                              $" Borrow_Date='{mtbBorrowDate.Text}', Actual_Return_Date='{mtbReturnDate.Text}', Issued_By='{txtIssuerID.Text}' WHERE Borrow_ID={int.Parse(txtBorrowID.Text)}";
                        _command.Connection = sqlConnection;
                        _command.CommandText = sql;
                        if (_command.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("Išdavimas sėkmingai atnaujintas!");
                            txtBorrowID.Clear();
                            txtISBN.Clear();
                            txtStudentID.Clear();
                            mtbBorrowDate.Clear();
                            mtbReturnDate.Clear();
                            txtIssuerID.Clear();
                            sql = "SELECT * FROM tblBorrowDetail";
                            _command.CommandText = sql;
                            DA.SelectCommand = _command;
                            DA.Fill(DT);
                            dgvBorrows.DataSource = DT;
                        }
                        else
                        {
                            MessageBox.Show("Nepavyko atnaujinto išdavimo!");
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
