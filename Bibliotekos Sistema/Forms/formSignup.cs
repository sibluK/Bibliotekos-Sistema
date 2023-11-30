using Bibliotekos_Sistema.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Bibliotekos_Sistema.Classes;
using Bibliotekos_Sistema.Interfaces;

namespace Bibliotekos_Sistema.Forms
{
    public partial class formSignup : Form
    {
        Font SmallFont = new Font("Microsoft Sans Serif", 8);
        Font MediumFont = new Font("Microsoft Sans Serif", 12);
        Font LargeFont = new Font("Microsoft Sans Serif", 28);


        private readonly IDatabaseOperations _databaseOperations;
        private readonly PageLoader _pageLoader;
        private readonly UserService _userService;

        public formSignup(IDatabaseOperations databaseOperations)
        {
            InitializeComponent();
            _pageLoader = new PageLoader();
            _databaseOperations = databaseOperations;
            _userService = new UserService(_databaseOperations);
            passwordCheckBox.Font = SmallFont;
            passwordCheckBox2.Font = SmallFont;
        }

        private void passwordCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (passwordCheckBox.Checked)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void passwordCheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (passwordCheckBox2.Checked)
            {
                txtPasswordConfirm.UseSystemPasswordChar = false;
            }
            else
            {
                txtPasswordConfirm.UseSystemPasswordChar = true;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            _pageLoader.loadLoginPage();
            this.Dispose();
        }

        private void btnSingup_Click(object sender, EventArgs e)
        {
            _userService.insertUserIntoDatabase(cboUserType, txtUsername, txtFullName, txtPassword, txtPasswordConfirm, cboDesignation);
        }

        private void fromSignup_Load(object sender, EventArgs e)
        {

        }
    }
}
