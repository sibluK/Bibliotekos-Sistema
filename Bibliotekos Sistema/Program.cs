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
        private static IAccountDatabase _accountDatabase = new AccountDatabase(_databaseOperations);
        private static IBookDatabase _bookDatabase = new BookDatabase(_databaseOperations);
        private static IBorrowDatabase _borrowDatabase = new BorrowDatabase(_databaseOperations);
        private static ICategoryDatabase _categoryDatabase = new CategoryDatabase(_databaseOperations);
        private static IPublisherDatabase _publisherDatabase = new PublisherDatabase(_databaseOperations);
        private static IStudentDatabase _studentDatabase = new StudentDatabase(_databaseOperations);
        private static IUserDatabase _userDatabase = new UserDatabase(_databaseOperations);

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new formLogin(_databaseOperations, _accountDatabase, _bookDatabase, _borrowDatabase, _categoryDatabase, _publisherDatabase, _studentDatabase, _userDatabase));
        }
    }
}
