using Bibliotekos_Sistema.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bibliotekos_Sistema.Classes
{
    public class CategoryService
    {
        private readonly SqlCommand _command;
        private string sql;
        private readonly IDatabaseOperations _databaseOperations;

        private string categoryName;

        public CategoryService(IDatabaseOperations databaseOperations)
        {
            _databaseOperations = databaseOperations;
            _command = new SqlCommand();
        }

        public int totalCategory()
        {
            SqlDataReader DR;
            int counter = 0;
            try
            {
                SqlConnection sqlConnection = _databaseOperations.GetConnection();
                sqlConnection.Open();
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sql = "SELECT * FROM tblCategory";
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

        public void loadCategoriesIntoTable(DataGridView dgvCategory)
        {
            SqlDataAdapter DA = new SqlDataAdapter();
            DataTable DT = new DataTable();
            try
            {
                SqlConnection sqlConnection = _databaseOperations.GetConnection();
                sqlConnection.Open();
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sql = "SELECT * FROM tblCategory";
                    _command.Connection = sqlConnection;
                    _command.CommandText = sql;
                    DA.SelectCommand = _command;
                    DA.Fill(DT);
                    dgvCategory.DataSource = DT;
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

        public void loadCategoryIntoComboBox(ComboBox ComboBox)
        {
            SqlDataReader DR;

            try
            {
                SqlConnection sqlConnection = _databaseOperations.GetConnection();
                sqlConnection.Open();
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sql = "SELECT * FROM tblCategory";
                    _command.Connection = sqlConnection;
                    _command.CommandText = sql;
                    DR = _command.ExecuteReader();
                    while (DR.Read())
                    {
                        ComboBox.Items.Add(DR.GetValue(1).ToString());
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
        }

        public void saveCategoryInfo(DataGridView dgvCategory, TextBox txtCategoryName, TextBox txtCategoryID)
        {
            SqlDataAdapter DA = new SqlDataAdapter();
            DataTable DT = new DataTable();

            try
            {
                SqlConnection sqlConnection = _databaseOperations.GetConnection();
                sqlConnection.Open();
                if (sqlConnection.State == ConnectionState.Open)
                {
                    if (txtCategoryName.Text.Length == 0)
                    {
                        MessageBox.Show("Įveskite kategoriją!");
                    }
                    else
                    {
                        sql = $"INSERT INTO tblCategory(Category_Name)" +
                              $"VALUES('{txtCategoryName.Text}')";
                        _command.Connection = sqlConnection;
                        _command.CommandText = sql;
                        if (_command.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("Kategorija sėkmingai pridėta");
                            txtCategoryName.Clear();
                            txtCategoryID.Clear();
                            sql = "SELECT * FROM tblCategory";
                            _command.CommandText = sql;
                            DA.SelectCommand = _command;
                            DA.Fill(DT);
                            dgvCategory.DataSource = DT;
                        }
                        else
                        {
                            MessageBox.Show("Kategorijos pridėti nepavyko!");
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

        public void deleteCategoryInfo(DataGridView dgvCategory, TextBox txtCategoryName, TextBox txtCategoryID)
        {
            SqlDataAdapter DA = new SqlDataAdapter();
            DataTable DT = new DataTable();

            try
            {
                SqlConnection sqlConnection = _databaseOperations.GetConnection();
                sqlConnection.Open();
                if (sqlConnection.State == ConnectionState.Open)
                {
                    if (txtCategoryName.Text.Length == 0)
                    {
                        MessageBox.Show("Pasirinkite kategoriją!");
                    }
                    else
                    {
                        sql = $"DELETE FROM tblCategory WHERE Category_ID='{int.Parse(txtCategoryID.Text)}'";
                        _command.Connection = sqlConnection;
                        _command.CommandText = sql;
                        if (_command.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("Kategorija sėkmingai ištrinta");
                            txtCategoryID.Clear();
                            txtCategoryName.Clear();
                            sql = "SELECT * FROM tblCategory";
                            _command.CommandText = sql;
                            DA.SelectCommand = _command;
                            DA.Fill(DT);
                            dgvCategory.DataSource = DT;
                        }
                        else
                        {
                            MessageBox.Show("Nepavyko ištrinti kategorijos!");
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

        public void editCategoryInfo(DataGridView dgvCategory, TextBox txtCategoryName, TextBox txtCategoryID)
        {
            SqlDataAdapter DA = new SqlDataAdapter();
            DataTable DT = new DataTable();

            try
            {
                SqlConnection sqlConnection = _databaseOperations.GetConnection();
                sqlConnection.Open();
                if (sqlConnection.State == ConnectionState.Open)
                {

                    if (txtCategoryID.Text.Length == 0 || txtCategoryName.Text.Length == 0)
                    {
                        MessageBox.Show("Vienas ar daugiau laukų yra privalomi!");
                    }
                    else
                    {
                        sql = $"UPDATE tblCategory SET Category_Name='{txtCategoryName.Text}' WHERE Category_ID='{int.Parse(txtCategoryID.Text)}'";
                        _command.Connection = sqlConnection;
                        _command.CommandText = sql;
                        if (_command.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("Kategorija sėkmingai atnaujinta!");
                            txtCategoryID.Clear();
                            txtCategoryName.Clear();
                            sql = "SELECT * FROM tblCategory";
                            _command.CommandText = sql;
                            DA.SelectCommand = _command;
                            DA.Fill(DT);
                            dgvCategory.DataSource = DT;
                        }
                        else
                        {
                            MessageBox.Show("Nepavyko atnaujinti kategorijos!");
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
