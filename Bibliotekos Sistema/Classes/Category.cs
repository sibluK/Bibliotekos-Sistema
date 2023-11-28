using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bibliotekos_Sistema.Database;
using Bibliotekos_Sistema.Forms;

namespace Bibliotekos_Sistema.Classes
{
    internal class Category
    {
        SqlCommand _command = new SqlCommand();
        private string sql;
        DBConnection _connection = new DBConnection();

        public void loadCategoryPage()
        {
            formCategory category = new formCategory();
            category.Show();
        }

        public int totalCategory()
        {
            SqlDataReader DR;
            int counter = 0;
            try
            {
                _connection.connection().Open();
                if (_connection.connection().State == ConnectionState.Open)
                {
                    sql = "SELECT * FROM tblCategory";
                    _command.Connection = _connection.connection();
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
                _connection.connection().Close();
            }

            return counter;
        }

        public void loadCategoriesIntoTable(DataGridView dgvCategory)
        {
            SqlDataAdapter DA = new SqlDataAdapter();
            DataTable DT = new DataTable();
            try
            {
                _connection.connection().Open();
                if (_connection.connection().State == ConnectionState.Open)
                {
                    sql = "SELECT * FROM tblCategory";
                    _command.Connection = _connection.connection();
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
                _connection.connection().Close();
            }
        }

        public void loadCategoryIntoComboBox(ComboBox ComboBox)
        {
            SqlDataReader DR;

            try
            {
                _connection.connection().Open();
                if (_connection.connection().State == ConnectionState.Open)
                {
                    sql = "SELECT * FROM tblCategory";
                    _command.Connection = _connection.connection();
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
                _connection.connection().Close();
            }
        }

        public void saveCategoryInfo(DataGridView dgvCategory, TextBox txtCategoryName, TextBox txtCategoryID)
        {
            SqlDataAdapter DA = new SqlDataAdapter();
            DataTable DT = new DataTable();

            try
            {
                _connection.connection().Open();
                if (_connection.connection().State == ConnectionState.Open)
                {
                    if (txtCategoryName.Text.Length == 0)
                    {
                        MessageBox.Show("Įveskite kategoriją!");
                    }
                    else
                    {
                        sql = $"INSERT INTO tblCategory(Category_Name)" +
                              $"VALUES('{txtCategoryName.Text}')";
                        _command.Connection = _connection.connection();
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
                _connection.connection().Close();
            }
        }

        public void deleteCategoryInfo(DataGridView dgvCategory, TextBox txtCategoryName, TextBox txtCategoryID)
        {
            SqlDataAdapter DA = new SqlDataAdapter();
            DataTable DT = new DataTable();

            try
            {
                _connection.connection().Open();
                if (_connection.connection().State == ConnectionState.Open)
                {
                    if (txtCategoryName.Text.Length == 0)
                    {
                        MessageBox.Show("Pasirinkite kategoriją!");
                    }
                    else
                    {
                        sql = $"DELETE FROM tblCategory WHERE Category_ID='{int.Parse(txtCategoryID.Text)}'";
                        _command.Connection = _connection.connection();
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
                _connection.connection().Close();
            }
        }

        public void editCategoryInfo(DataGridView dgvCategory, TextBox txtCategoryName, TextBox txtCategoryID)
        {
            SqlDataAdapter DA = new SqlDataAdapter();
            DataTable DT = new DataTable();

            try
            {
                _connection.connection().Open();
                if (_connection.connection().State == ConnectionState.Open)
                {

                    if (txtCategoryID.Text.Length == 0 || txtCategoryName.Text.Length == 0)
                    {
                        MessageBox.Show("Vienas ar daugiau laukų yra privalomi!");
                    }
                    else
                    {
                        sql = $"UPDATE tblCategory SET Category_Name='{txtCategoryName.Text}' WHERE Category_ID='{int.Parse(txtCategoryID.Text)}'";
                        _command.Connection = _connection.connection();
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
                _connection.connection().Close();
            }
        }

    }
}
