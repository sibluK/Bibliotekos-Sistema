using Bibliotekos_Sistema.Interfaces;
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
    public class AccountService
    {
        private readonly IDatabaseOperations _databaseOperations;
        private readonly SqlCommand _command;
        private string sql;
        private int userType = 0;

        public AccountService(IDatabaseOperations databaseOperations)
        {
            _databaseOperations = databaseOperations;
            _command = new SqlCommand();
        }

        public int totalAccount()
        {
            SqlDataReader DR;
            int counter = 0;
            try
            {
                SqlConnection sqlConnection = _databaseOperations.GetConnection();
                sqlConnection.Open();
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sql = "SELECT * FROM tblStaff";
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
        public void loadAccountsIntoTable(DataGridView DataGridView)
        {
            SqlDataAdapter DA = new SqlDataAdapter();
            DataTable DT = new DataTable();

            try
            {
                SqlConnection sqlConnection = _databaseOperations.GetConnection();
                sqlConnection.Open();
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sql = "SELECT * FROM tblStaff";
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

        public void saveAccountInfo(DataGridView dgvAccount, TextBox txtID, TextBox txtUsername, TextBox txtFullName, TextBox txtPassword, TextBox txtPasswordConfirm, ComboBox cboUserType, ComboBox cboDesignation)
        {
            SqlDataAdapter DA = new SqlDataAdapter();
            DataTable DT = new DataTable();

            userType = cboUserType.Text == "Administratorius" ? 1 : 0;


            try
            {
                SqlConnection sqlConnection = _databaseOperations.GetConnection();
                sqlConnection.Open();
                if (sqlConnection.State == ConnectionState.Open)
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
                        _command.Connection = sqlConnection;
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
                _databaseOperations.GetConnection().Close();
            }
        }

        public void deleteAccountInfo(DataGridView dgvAccount, TextBox txtID, TextBox txtUsername, TextBox txtFullName, TextBox txtPassword, TextBox txtPasswordConfirm, ComboBox cboUserType, ComboBox cboDesignation)
        {
            SqlDataAdapter DA = new SqlDataAdapter();
            DataTable DT = new DataTable();

            try
            {
                SqlConnection sqlConnection = _databaseOperations.GetConnection();
                sqlConnection.Open();
                if (sqlConnection.State == ConnectionState.Open)
                {
                    if (txtID.Text.Length == 0)
                    {
                        MessageBox.Show("Pasirinkite naudotoją!");
                    }
                    else
                    {
                        sql = $"DELETE FROM tblStaff WHERE Staff_Member_ID='{txtID.Text}'";
                        _command.Connection = sqlConnection;
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
                _databaseOperations.GetConnection().Close();
            }
        }

        public void editAccountInfo(DataGridView dgvAccount, TextBox txtID, TextBox txtUsername, TextBox txtFullName, TextBox txtPassword, TextBox txtPasswordConfirm, ComboBox cboUserType, ComboBox cboDesignation)
        {
            SqlDataAdapter DA = new SqlDataAdapter();
            DataTable DT = new DataTable();

            try
            {
                SqlConnection sqlConnection = _databaseOperations.GetConnection();
                sqlConnection.Open();
                if (sqlConnection.State == ConnectionState.Open)
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
                        _command.Connection = sqlConnection;
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
