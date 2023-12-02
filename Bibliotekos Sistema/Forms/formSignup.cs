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

        private readonly PageLoader _pageLoader;
        private readonly UserService _userService;
        private readonly IDatabaseOperations _databaseOperations;
        private readonly IAccountDatabase _accountDatabase;
        private readonly IBookDatabase _bookDatabase;
        private readonly IBorrowDatabase _borrowDatabase;
        private readonly ICategoryDatabase _categoryDatabase;
        private readonly IPublisherDatabase _publisherDatabase;
        private readonly IStudentDatabase _studentDatabase;
        private readonly IUserDatabase _userDatabase;


        public formSignup(IDatabaseOperations databaseOperations, IAccountDatabase accountDatabase, IBookDatabase bookDatabase, IBorrowDatabase borrowDatabase, ICategoryDatabase categoryDatabase, IPublisherDatabase publisherDatabase, IStudentDatabase studentDatabase, IUserDatabase userDatabase)
        {
            InitializeComponent();
            passwordCheckBox.Font = SmallFont;
            passwordCheckBox2.Font = SmallFont;
            _databaseOperations = databaseOperations;
            _accountDatabase = accountDatabase;
            _bookDatabase = bookDatabase;
            _borrowDatabase = borrowDatabase;
            _categoryDatabase = categoryDatabase;
            _publisherDatabase = publisherDatabase;
            _studentDatabase = studentDatabase;
            _userDatabase = userDatabase;
            _userService = new UserService(_userDatabase);
            _pageLoader = new PageLoader(_accountDatabase, _bookDatabase, _borrowDatabase, _categoryDatabase, _publisherDatabase, _studentDatabase, _userDatabase);
 
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
