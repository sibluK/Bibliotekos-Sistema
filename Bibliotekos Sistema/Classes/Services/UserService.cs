using Bibliotekos_Sistema.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bibliotekos_Sistema.Classes
{
    public class UserService
    {
        private readonly IUserDatabase _userDatabase;

        public UserService(IUserDatabase userDatabase)
        {
            _userDatabase = userDatabase;
        }
  
        public bool authenticateUser(string username, string password)
        {
            return _userDatabase.AuthenticateUser(username, password);
        }

        public void insertUserIntoDatabase(ComboBox cboUserType, TextBox txtUsername, TextBox txtFullName, TextBox txtPassword, TextBox txtPasswordConfirm, ComboBox cboDesignation)
        {
            _userDatabase.InsertUserIntoDatabase(cboUserType, txtUsername, txtFullName, txtPassword, txtPasswordConfirm, cboDesignation);
        }
    }
}
