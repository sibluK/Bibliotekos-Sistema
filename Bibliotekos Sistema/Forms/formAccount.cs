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
        private readonly IDatabaseOperations _databaseOperations;
        private readonly Account _account;
        private readonly PageLoader _pageLoader;

        public formAccount(IDatabaseOperations databaseOperations)
        {
            InitializeComponent();
            _databaseOperations = databaseOperations;
            _account = new Account(_databaseOperations);
            _pageLoader = new PageLoader();
        }

        private void formAccount_Load(object sender, EventArgs e)
        {
            _account.loadAccountsIntoTable(dgvAccount);
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
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _account.saveAccountInfo(dgvAccount, txtID, txtUsername, txtFullName, txtPassword, txtPasswordConfirm, cboUserType, cboDesignation);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            _account.deleteAccountInfo(dgvAccount, txtID, txtUsername, txtFullName, txtPassword, txtPasswordConfirm, cboUserType, cboDesignation);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            _account.editAccountInfo(dgvAccount, txtID, txtUsername, txtFullName, txtPassword, txtPasswordConfirm, cboUserType, cboDesignation);
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


    }
}
