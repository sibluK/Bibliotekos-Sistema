using Bibliotekos_Sistema.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bibliotekos_Sistema.Classes
{
    public class AccountService
    {
        private readonly IAccountDatabase _accountDatabase;

        public AccountService(IAccountDatabase accountDatabase)
        {
            _accountDatabase = accountDatabase;
        }

        public int totalAccount()
        {
            return _accountDatabase.GetTotalAccounts();
        }
        public void loadAccountsIntoTable(DataGridView DataGridView)
        {
            _accountDatabase.LoadAccountsIntoTable(DataGridView);
        }

        public void saveAccountInfo(DataGridView dgvAccount, TextBox txtID, TextBox txtUsername, TextBox txtFullName, TextBox txtPassword, TextBox txtPasswordConfirm, ComboBox cboUserType, ComboBox cboDesignation)
        {
            _accountDatabase.SaveAccountInfo(dgvAccount, txtID, txtUsername, txtFullName, txtPassword, txtPasswordConfirm, cboUserType, cboDesignation);
        }

        public void deleteAccountInfo(DataGridView dgvAccount, TextBox txtID, TextBox txtUsername, TextBox txtFullName, TextBox txtPassword, TextBox txtPasswordConfirm, ComboBox cboUserType, ComboBox cboDesignation)
        {
            _accountDatabase.DeleteAccountInfo(dgvAccount, txtID, txtUsername, txtFullName, txtPassword, txtPasswordConfirm, cboUserType, cboDesignation);
        }

        public void editAccountInfo(DataGridView dgvAccount, TextBox txtID, TextBox txtUsername, TextBox txtFullName, TextBox txtPassword, TextBox txtPasswordConfirm, ComboBox cboUserType, ComboBox cboDesignation)
        {
            _accountDatabase.EditAccountInfo(dgvAccount, txtID, txtUsername, txtFullName, txtPassword, txtPasswordConfirm, cboUserType, cboDesignation);
        }

    }
}
