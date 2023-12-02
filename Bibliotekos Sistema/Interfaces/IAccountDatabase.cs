using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bibliotekos_Sistema.Interfaces
{
    public interface IAccountDatabase
    {
        int GetTotalAccounts();
        void LoadAccountsIntoTable(DataGridView dataGridView);
        void SaveAccountInfo(DataGridView dgvAccount, TextBox txtID, TextBox txtUsername, TextBox txtFullName, TextBox txtPassword, TextBox txtPasswordConfirm, ComboBox cboUserType, ComboBox cboDesignation);
        void DeleteAccountInfo(DataGridView dgvAccount, TextBox txtID, TextBox txtUsername, TextBox txtFullName, TextBox txtPassword, TextBox txtPasswordConfirm, ComboBox cboUserType, ComboBox cboDesignation);
        void EditAccountInfo(DataGridView dgvAccount, TextBox txtID, TextBox txtUsername, TextBox txtFullName, TextBox txtPassword, TextBox txtPasswordConfirm, ComboBox cboUserType, ComboBox cboDesignation);
    }
}
