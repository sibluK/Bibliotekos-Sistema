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

namespace Bibliotekos_Sistema
{
    public partial class Login : Form
    {
        Font SmallFont = new Font("Microsoft Sans Serif", 8);
        Font MediumFont = new Font("Microsoft Sans Serif", 12);
        Font LargeFont = new Font("Microsoft Sans Serif", 28);

        private string sql;
        private SqlCommand command = new SqlCommand();
        DBConnection _connection = new DBConnection();

        public Login()
        {
            InitializeComponent();

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
                _connection.connection().Open();

                if(_connection.connection().State == ConnectionState.Open)
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
                        command.Connection = _connection.connection();
                        command.CommandText = sql;
                        DR = command.ExecuteReader();
                        while(DR.Read())
                        {
                            counter++;
                        }
                        DR.Close();
                        if(counter == 1)
                        {
                            //User User = new User();
                            //User.loadUser(user_name, password);

                            MessageBox.Show("Sėkmingai prisijungėte!");
                            formDashboard home = new formDashboard();
                            home.Show();
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
                _connection.connection().Close();
            }
        }

        private void btnSingup_Click(object sender, EventArgs e)
        {
            fromSignup signup = new fromSignup();
            signup.Show();
            this.Hide();
        }

    }
}
