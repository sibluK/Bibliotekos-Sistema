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
    public partial class formLogin : Form
    {
        Font SmallFont = new Font("Microsoft Sans Serif", 8);
        Font MediumFont = new Font("Microsoft Sans Serif", 12);
        Font LargeFont = new Font("Microsoft Sans Serif", 28);

        private readonly PageLoader _pageLoader;
        private readonly UserService _userService;
        private readonly IAccountDatabase _accountDatabase;
        private readonly IBookDatabase _bookDatabase;
        private readonly IBorrowDatabase _borrowDatabase;
        private readonly ICategoryDatabase _categoryDatabase;
        private readonly IPublisherDatabase _publisherDatabase;
        private readonly IStudentDatabase _studentDatabase;
        private readonly IUserDatabase _userDatabase;


        public formLogin(IAccountDatabase accountDatabase, IBookDatabase bookDatabase, IBorrowDatabase borrowDatabase, ICategoryDatabase categoryDatabase, IPublisherDatabase publisherDatabase, IStudentDatabase studentDatabase, IUserDatabase userDatabase)
        {
            InitializeComponent();
            _accountDatabase = accountDatabase;
            _bookDatabase = bookDatabase;
            _borrowDatabase = borrowDatabase;
            _categoryDatabase = categoryDatabase;
            _publisherDatabase = publisherDatabase;
            _studentDatabase = studentDatabase;
            _userDatabase = userDatabase;
            _pageLoader = new PageLoader(_accountDatabase, _bookDatabase, _borrowDatabase, _categoryDatabase, _publisherDatabase, _studentDatabase, _userDatabase);
            _userService = new UserService(_userDatabase);

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
            
            if(_userService.authenticateUser(txtUserName.Text, txtPassword.Text))
            {
                _pageLoader.loadDashboardPage();
                this.Hide();
            }
        }

        private void btnSingup_Click(object sender, EventArgs e)
        {
            _pageLoader.loadSignupPage();
            this.Hide();
        }

    }
}
