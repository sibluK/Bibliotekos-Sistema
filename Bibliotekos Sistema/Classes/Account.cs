using Bibliotekos_Sistema.Database;
using Bibliotekos_Sistema.Forms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bibliotekos_Sistema.Classes
{
    internal class Account
    {
        SqlCommand _command = new SqlCommand();
        private string sql;
        DBConnection _connection = new DBConnection();
        public int userType = 0;

        public void loadAccountPage()
        {
            formAccount account = new formAccount();
            account.Show();
        }

        public int totalAccount()
        {
            SqlDataReader DR;
            int counter = 0;
            try
            {
                _connection.connection().Open();
                if (_connection.connection().State == ConnectionState.Open)
                {
                    sql = "SELECT * FROM tblStaff";
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
        public void loadAccountsIntoTable(DataGridView DataGridView)
        {
            SqlDataAdapter DA = new SqlDataAdapter();
            DataTable DT = new DataTable();

            try
            {
                _connection.connection().Open();
                if (_connection.connection().State == ConnectionState.Open)
                {
                    sql = "SELECT * FROM tblStaff";
                    _command.Connection = _connection.connection();
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
                _connection.connection().Close();
            }
        }
        public void saveAccountInfo(DataGridView dgvAccount, TextBox txtID, TextBox txtUsername, TextBox txtFullName, TextBox txtPassword, TextBox txtPasswordConfirm, ComboBox cboUserType, ComboBox cboDesignation)
        {
            SqlDataAdapter DA = new SqlDataAdapter();
            DataTable DT = new DataTable();


            if (cboUserType.Text == "Administratorius")
            {
                userType = 1;
            }
            else
            {
                userType = 0;
            }


            try
            {
                _connection.connection().Open();
                if (_connection.connection().State == ConnectionState.Open)
                {
                    if (txtUsername.Text.Length == 0
                        || txtFullName.Text.Length == 0
                        || txtPassword.Text.Length == 0
                        || txtPasswordConfirm.Text.Length == 0)
                    {
                        MessageBox.Show("Įveskite vieną ar daugiau laukų!");
                    }
                    else if (txtUsername.Text.Length < 3
                            || txtPassword.Text.Length < 3
                            || txtPasswordConfirm.Text.Length < 3)
                    {
                        MessageBox.Show("Netinkamai įvesti duomenys. Prisijungimo vardas ir slaptažodis turi būti bent 3 raidžių!");
                    }
                    else if (txtPassword.Text != txtPasswordConfirm.Text)
                    {
                        MessageBox.Show("Slaptažodžiai nesutampa. Pažiurėkite ar gerai įvedėte slaptažodį!");
                    }
                    else
                    {
                        sql = $"INSERT INTO tblStaff(FullName,Username,SPassword,is_Admin,Designation)" +
                              $" VALUES('{txtFullName.Text}','{txtUsername.Text}','{txtPassword.Text}','{userType}','{cboDesignation.Text}')";
                        _command.Connection = _connection.connection();
                        _command.CommandText = sql;
                        if (_command.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("Naudotojas sėkmingai pridetėtas");
                            txtID.Clear();
                            txtFullName.Clear();
                            txtUsername.Clear();
                            txtPassword.Clear();
                            txtPasswordConfirm.Clear();
                            cboDesignation.ResetText();
                            cboUserType.ResetText();
                            sql = "SELECT * FROM tblStaff";
                            _command.CommandText = sql;
                            DA.SelectCommand = _command;
                            DA.Fill(DT);
                            dgvAccount.DataSource = DT;
                        }
                        else
                        {
                            MessageBox.Show("Nepavyko pridėti naudotojo!");
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
        public void deleteAccountInfo(DataGridView dgvAccount, TextBox txtID, TextBox txtUsername, TextBox txtFullName, TextBox txtPassword, TextBox txtPasswordConfirm, ComboBox cboUserType, ComboBox cboDesignation)
        {
            SqlDataAdapter DA = new SqlDataAdapter();
            DataTable DT = new DataTable();

            try
            {
                _connection.connection().Open();
                if (_connection.connection().State == ConnectionState.Open)
                {
                    if (txtID.Text.Length == 0)
                    {
                        MessageBox.Show("Pasirinkite naudotoją!");
                    }
                    else
                    {
                        sql = $"DELETE FROM tblStaff WHERE Staff_Member_ID='{txtID.Text}'";
                        _command.Connection = _connection.connection();
                        _command.CommandText = sql;
                        if (_command.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("Naudotojas sėkmingai ištrintas");
                            txtID.Clear();
                            txtUsername.Clear();
                            txtFullName.Clear();
                            txtPassword.Clear();
                            txtPasswordConfirm.Clear();
                            cboUserType.ResetText();
                            cboDesignation.ResetText();
                            sql = "SELECT * FROM tblStaff";
                            _command.CommandText = sql;
                            DA.SelectCommand = _command;
                            DA.Fill(DT);
                            dgvAccount.DataSource = DT;
                        }
                        else
                        {
                            MessageBox.Show("Nepavyko ištrinto naudotojo!");
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
        public void editAccountInfo(DataGridView dgvAccount, TextBox txtID, TextBox txtUsername, TextBox txtFullName, TextBox txtPassword, TextBox txtPasswordConfirm, ComboBox cboUserType, ComboBox cboDesignation)
        {
            SqlDataAdapter DA = new SqlDataAdapter();
            DataTable DT = new DataTable();

            try
            {
                _connection.connection().Open();
                if(_connection.connection().State == ConnectionState.Open)
                {
                    if (txtUsername.Text.Length == 0
                        || txtFullName.Text.Length == 0
                        || txtPassword.Text.Length == 0
                        || txtPasswordConfirm.Text.Length == 0)
                    {
                        MessageBox.Show("Įveskite vieną ar daugiau laukų!");
                    }
                    else if (txtUsername.Text.Length < 3
                            || txtPassword.Text.Length < 3
                            || txtPasswordConfirm.Text.Length < 3)
                    {
                        MessageBox.Show("Netinkamai įvesti duomenys. Prisijungimo vardas ir slaptažodis turi būti bent 3 raidžių!");
                    }
                    else if (txtPassword.Text != txtPasswordConfirm.Text)
                    {
                        MessageBox.Show("Slaptažodžiai nesutampa. Pažiurėkite ar gerai įvedėte slaptažodį!");
                    }
                    else
                    {
                        sql = $"UPDATE tblStaff SET FullName='{txtFullName.Text}', Username='{txtUsername.Text}'," +
                              $" SPassword='{txtPassword.Text}', Designation='{cboDesignation.Text}' WHERE Staff_Member_ID={int.Parse(txtID.Text)}";
                        _command.Connection = _connection.connection();
                        _command.CommandText = sql;
                        if (_command.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("Naudotojas sėkmingai atnaujintas!");
                            txtID.Clear();
                            txtFullName.Clear();
                            txtUsername.Clear();
                            txtPassword.Clear();
                            txtPasswordConfirm.Clear();
                            cboDesignation.ResetText();
                            cboUserType.ResetText();
                            sql = "SELECT * FROM tblStaff";
                            _command.CommandText = sql;
                            DA.SelectCommand = _command;
                            DA.Fill(DT);
                            dgvAccount.DataSource = DT;
                        }
                        else
                        {
                            MessageBox.Show("Nepavyko atnaujinto naudotojo!");
                        }
                    }
                }
            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            catch(Exception ex)
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
