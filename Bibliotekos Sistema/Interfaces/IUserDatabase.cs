using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bibliotekos_Sistema.Interfaces
{
    public interface IUserDatabase
    {
        bool AuthenticateUser(string username, string password);
        void InsertUserIntoDatabase(ComboBox cboUserType, TextBox txtUsername, TextBox txtFullName, TextBox txtPassword, TextBox txtPasswordConfirm, ComboBox cboDesignation);
    }
}
