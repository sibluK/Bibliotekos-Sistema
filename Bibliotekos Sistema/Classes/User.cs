﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bibliotekos_Sistema.Database;
using System.Collections.Specialized;
using Bibliotekos_Sistema.Interfaces;

namespace Bibliotekos_Sistema.Classes
{
    public class User
    {
        private readonly IDatabaseOperations _databaseOperations;
        private readonly SqlCommand _command;
        private string sql;

        public int userType;
        public string Username;
        public string FullName;
        public string Password;
        public string Designation;

        public User(IDatabaseOperations databaseOperations)
        {
            _databaseOperations = databaseOperations;
            _command = new SqlCommand();    
        }
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
