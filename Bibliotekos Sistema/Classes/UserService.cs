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
    public class UserService
    {
        private readonly IDatabaseOperations _databaseOperations;
        private readonly SqlCommand _command;
        private string sql;
        private int userType;
        private readonly PageLoader _pageLoader;

        public UserService(IDatabaseOperations databaseOperations)
        {
            _databaseOperations = databaseOperations;
            _command = new SqlCommand();
            _pageLoader = new PageLoader();
        }
  
        public void authenticateUser(string username, string password)
        {
            SqlDataReader DR;

            try
            {
                SqlConnection sqlConnection = _databaseOperations.GetConnection();
                sqlConnection.Open();
                if (sqlConnection.State == ConnectionState.Open)
                {
                    int counter = 0;

                    if (username.Length == 0 || password.Length == 0)
                    {
                        MessageBox.Show("Įveskite vieną ar daugiau laukų!");
                    }
                    else
                    {
                        sql = $"SELECT Username,SPassword FROM tblStaff WHERE Username='{username}' AND SPassword='{password}'";
                        _command.Connection = sqlConnection;
                        _command.CommandText = sql;
                        DR = _command.ExecuteReader();
                        while (DR.Read())
                        {
                            counter++;
                        }
                        DR.Close();
                        if (counter == 1)
                        {
                            MessageBox.Show("Sėkmingai prisijungėte!");
                        }
                        else
                        {
                            MessageBox.Show("Netinkamas įvedimas! Pažiūrėkite ar teisingai įvedėte prisijungimo vardą ir slaptažodį!");
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
                SqlConnection sqlConnection = _databaseOperations.GetConnection();
                sqlConnection.Close();
            }
        }

        public void insertUserIntoDatabase(ComboBox cboUserType, TextBox txtUsername, TextBox txtFullName, TextBox txtPassword, TextBox txtPasswordConfirm, ComboBox cboDesignation)
        {
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
                            MessageBox.Show("Paskyra sėkmingai sukurta!");
                            txtFullName.Clear();
                            txtUsername.Clear();
                            txtPassword.Clear();
                            txtPasswordConfirm.Clear();
                            cboDesignation.ResetText();
                            cboUserType.ResetText();
                        }
                        else
                        {
                            MessageBox.Show("Nepavyko sukurti paskyros!");
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
