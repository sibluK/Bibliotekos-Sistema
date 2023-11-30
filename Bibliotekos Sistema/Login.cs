using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Data.Common;
using Bibliotekos_Sistema.Database;
using Bibliotekos_Sistema.Forms;
using Bibliotekos_Sistema.Classes;
using Bibliotekos_Sistema.Interfaces;

namespace Bibliotekos_Sistema
{
    public partial class Login : Form
    {
        Font SmallFont = new Font("Microsoft Sans Serif", 8);
        Font MediumFont = new Font("Microsoft Sans Serif", 12);
        Font LargeFont = new Font("Microsoft Sans Serif", 28);

        private string sql;
        private readonly SqlCommand _command;
        private readonly IDatabaseOperations _databaseOperations;
        private readonly PageLoader _pageLoader;

        public Login(IDatabaseOperations databaseOperations)
        {
            InitializeComponent();
            _databaseOperations = databaseOperations;
            _pageLoader = new PageLoader();
            _command = new SqlCommand();

        }
        private void Login_Load(object sender, EventArgs e)
        {
            passwordCheckBox.Font = SmallFont;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void passwordCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if(passwordCheckBox.Checked)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlDataReader DR;

            try
            {
                SqlConnection sqlConnection = _databaseOperations.GetConnection();
                sqlConnection.Open();
                if (sqlConnection.State == ConnectionState.Open)
                {
                    string user_name = txtUserName.Text;
                    string password = txtPassword.Text;
                    int counter = 0;

                    if(user_name.Length == 0 || password.Length == 0)
                    {
                        MessageBox.Show("Įveskite vieną ar daugiau laukų!");
                    }
                    else
                    {
                        sql = $"SELECT Username,SPassword FROM tblStaff WHERE Username='{user_name}' AND SPassword='{password}'";
                        _command.Connection = sqlConnection;
                        _command.CommandText = sql;
                        DR = _command.ExecuteReader();
                        while(DR.Read())
                        {
                            counter++;
                        }
                        DR.Close();
                        if(counter == 1)
                        {
                            MessageBox.Show("Sėkmingai prisijungėte!");
                            _pageLoader.loadDashboardPage();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Netinkamas įvedimas! Pažiūrėkite ar teisingai įvedėte prisijungimo vardą ir slaptažodį!");
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
                SqlConnection sqlConnection = _databaseOperations.GetConnection();
                sqlConnection.Close();
            }
        }

        private void btnSingup_Click(object sender, EventArgs e)
        {
            _pageLoader.loadSignupPage();
            this.Hide();
        }

    }
}
