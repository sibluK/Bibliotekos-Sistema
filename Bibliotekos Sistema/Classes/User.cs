using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bibliotekos_Sistema.Database;
using System.Collections.Specialized;

namespace Bibliotekos_Sistema.Classes
{
    internal class User
    {
        private DBConnection _connection = new DBConnection();
        private SqlCommand _command = new SqlCommand();
        private string sql;

        public int userType;
        public string Username;
        public string FullName;
        public string Password;
        public string Designation;

        public User() { }
        public User(ComboBox cboUserType, TextBox txtUsername, TextBox txtFullName, TextBox txtPassword, TextBox txtPasswordConfirm, ComboBox cboDesignation)
        {
            
            Username = txtUsername.Text;
            FullName = txtFullName.Text;
            Password = txtPassword.Text;
            Designation = cboDesignation.Text;

            userType = 0;
            if (cboUserType.Text == "Administratorius")
            {
                userType = 1;
            }
            else
            {
                userType = 0;
            }

            insertUserIntoDatabase(cboUserType, txtUsername, txtFullName, txtPassword, txtPasswordConfirm, cboDesignation);
        }

        public void insertUserIntoDatabase(ComboBox cboUserType, TextBox txtUsername, TextBox txtFullName, TextBox txtPassword, TextBox txtPasswordConfirm, ComboBox cboDesignation)
        {
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
                // MessageBox.Show("Įvestas naudotojo vardas jau egzistuoja");
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


        public void loadUser(string username, string password)
        {
            //gauti naudotojo duomenis is duomenu bazes pagal jo username ir password ir priskirti jas naudotojui

            SqlDataReader DR;

            try
            {
                _connection.connection().Open();
                if (_connection.connection().State == ConnectionState.Open)
                {
                    sql = $"SELECT * FROM tblStaff WHERE Username='{username}' AND SPassword='{password}'";
                    _command.Connection = _connection.connection();
                    _command.CommandText = sql;
                    DR = _command.ExecuteReader();
                    while (DR.Read())
                    {
                        userType = DR.GetInt32(4);
                        Username = DR.GetString(2);
                        FullName = DR.GetString(1);
                        Password = DR.GetString(3);
                        Designation = DR.GetString(5);
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


        public bool IsAdmin()
        {
            if (userType == 1)
            {
                return true;
            }
            else { return false; }
        }

    }
}
