using Bibliotekos_Sistema.Database;
using Bibliotekos_Sistema.Forms;
using Bibliotekos_Sistema.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bibliotekos_Sistema.Classes
{
    public class Student
    {
        public int studentID;
        public string fullName;
        public char gender;
        public DateTime DateOfBirth;
        public string department;
        public string phoneNumber;
    }
}
