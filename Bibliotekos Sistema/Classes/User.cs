using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bibliotekos_Sistema.Database;
using System.Collections.Specialized;
using Bibliotekos_Sistema.Interfaces;

namespace Bibliotekos_Sistema.Classes
{
    public class User
    {
        public int userType;
        public string Username;
        public string FullName;
        public string Password;
        public string Designation;
    }
}
