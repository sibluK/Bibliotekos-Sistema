using Bibliotekos_Sistema.Forms;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bibliotekos_Sistema.Database;
using Bibliotekos_Sistema.Interfaces;
using Microsoft.Win32;
using System.Runtime.InteropServices;

namespace Bibliotekos_Sistema.Classes
{
    public class Book
    {
        public string ISBN;
        public string title;
        public string category;
        public string publisher;
        public DateTime releaseYear;
        public int numberOfBooks;
        public int currentNumberOfBooks;

    }
}
