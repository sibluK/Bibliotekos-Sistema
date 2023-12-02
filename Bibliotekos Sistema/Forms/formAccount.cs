using Bibliotekos_Sistema.Classes;
using Bibliotekos_Sistema.Database;
using Bibliotekos_Sistema.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bibliotekos_Sistema.Forms
{
    public partial class formAccount : Form
    {
        private readonly AccountService _accountService;
        private readonly PageLoader _pageLoader;
        private readonly IAccountDatabase _accountDatabase;
        private readonly IBookDatabase _bookDatabase;
        private readonly IBorrowDatabase _borrowDatabase;
        private readonly ICategoryDatabase _categoryDatabase;
        private readonly IPublisherDatabase _publisherDatabase;
        private readonly IStudentDatabase _studentDatabase;
        private readonly IUserDatabase _userDatabase;


        public formAccount(IAccountDatabase accountDatabase, IBookDatabase bookDatabase, IBorrowDatabase borrowDatabase, ICategoryDatabase categoryDatabase, IPublisherDatabase publisherDatabase, IStudentDatabase studentDatabase, IUserDatabase userDatabase)    
        {
            InitializeComponent();
            _accountDatabase = accountDatabase;
            _bookDatabase = bookDatabase;
            _borrowDatabase = borrowDatabase;
            _categoryDatabase = categoryDatabase;
            _publisherDatabase = publisherDatabase;
            _studentDatabase = studentDatabase;
            _userDatabase = userDatabase;
            _accountService = new AccountService(_accountDatabase);
            _pageLoader = new PageLoader(_accountDatabase, _bookDatabase, _borrowDatabase, _categoryDatabase, _publisherDatabase, _studentDatabase, _userDatabase);

        }

        private void formAccount_Load(object sender, EventArgs e)
        {
            _accountService.loadAccountsIntoTable(dgvAccount);
        }


        private void dgvAccount_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                txtID.Text = dgvAccount.CurrentRow.Cells[0].Value.ToString();
                txtUsername.Text = dgvAccount.CurrentRow.Cells[2].Value.ToString();
                txtFullName.Text = dgvAccount.CurrentRow.Cells[1].Value.ToString();
                txtPassword.Text = dgvAccount.CurrentRow.Cells[3].Value.ToString();
                txtPasswordConfirm.Text = dgvAccount.CurrentRow.Cells[3].Value.ToString();
                cboUserType.Text = dgvAccount.CurrentRow.Cells[4].Value.ToString();
                cboDesignation.Text = dgvAccount.CurrentRow.Cells[5].Value.ToString();
            }
            txtID.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _accountService.saveAccountInfo(dgvAccount, txtID, txtUsername, txtFullName, txtPassword, txtPasswordConfirm, cboUserType, cboDesignation);
            txtID.Enabled = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            _accountService.deleteAccountInfo(dgvAccount, txtID, txtUsername, txtFullName, txtPassword, txtPasswordConfirm, cboUserType, cboDesignation);
            txtID.Enabled = true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            _accountService.editAccountInfo(dgvAccount, txtID, txtUsername, txtFullName, txtPassword, txtPasswordConfirm, cboUserType, cboDesignation);
            txtID.Enabled = true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtID.Clear();
            txtUsername.Clear();
            txtFullName.Clear();
            txtPassword.Clear();
            txtPasswordConfirm.Clear();
            cboUserType.ResetText();
            cboDesignation.ResetText();
            txtID.Enabled = true;
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

        //// NAVIGATION ////
        private void btnHome_Click(object sender, EventArgs e)
        {
            _pageLoader.loadDashboardPage();
            this.Dispose();
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            _pageLoader.loadBookPage();
            this.Dispose();
        }

        private void btnStudent_Click(object sender, EventArgs e)
        {
            _pageLoader.loadStudentPage();
            this.Dispose();
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            _pageLoader.loadCategoryPage();
            this.Dispose();
        }

        private void btnPublisher_Click(object sender, EventArgs e)
        {
            _pageLoader.loadPublisherPage();
            this.Dispose();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            _pageLoader.loadLoginPage();
            this.Dispose();
        }

        private void btnRent_Click(object sender, EventArgs e)
        {
            _pageLoader.loadBorrowPage();
            this.Dispose();
        }
    }
}
