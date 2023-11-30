using Bibliotekos_Sistema.Database;
using Bibliotekos_Sistema.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bibliotekos_Sistema
{
    internal static class Program
    {
        private static IDatabaseOperations _databaseOperations = new DBConnection();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login(_databaseOperations));
        }
    }
}
