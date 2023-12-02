using Bibliotekos_Sistema.Database;
using Bibliotekos_Sistema.Forms;
using Bibliotekos_Sistema.Interfaces;

namespace Bibliotekos_Sistema.Classes
{
    public class PageLoader
    {
        IDatabaseOperations databaseOperations = new DBConnection();
        private readonly IAccountDatabase _accountDatabase;
        private readonly IBookDatabase _bookDatabase;
        private readonly IBorrowDatabase _borrowDatabase;
        private readonly ICategoryDatabase _categoryDatabase;
        private readonly IPublisherDatabase _publisherDatabase;
        private readonly IStudentDatabase _studentDatabase;
        private readonly IUserDatabase _userDatabase;

        public PageLoader(IAccountDatabase accountDatabase, IBookDatabase bookDatabase, IBorrowDatabase borrowDatabase, ICategoryDatabase categoryDatabase, IPublisherDatabase publisherDatabase, IStudentDatabase studentDatabase, IUserDatabase userDatabase)
        {
            _accountDatabase = accountDatabase;
            _bookDatabase = bookDatabase;
            _borrowDatabase = borrowDatabase;
            _categoryDatabase = categoryDatabase;
            _publisherDatabase = publisherDatabase;
            _studentDatabase = studentDatabase;
            _userDatabase = userDatabase;
        }

        public void loadPublisherPage()
        {
            formPublisher publisher = new formPublisher(databaseOperations, _accountDatabase, _bookDatabase, _borrowDatabase, _categoryDatabase, _publisherDatabase, _studentDatabase, _userDatabase);
            publisher.Show();
        }
        public void loadAccountPage()
        {
            formAccount account = new formAccount(_accountDatabase, _bookDatabase, _borrowDatabase, _categoryDatabase, _publisherDatabase, _studentDatabase, _userDatabase);
            account.Show();
        }
        public void loadBookPage()
        {
            formBook book = new formBook(databaseOperations, _accountDatabase, _bookDatabase, _borrowDatabase, _categoryDatabase, _publisherDatabase, _studentDatabase, _userDatabase);
            book.Show();
        }
        public void loadCategoryPage()
        {
            formCategory category = new formCategory(databaseOperations, _accountDatabase, _bookDatabase, _borrowDatabase, _categoryDatabase, _publisherDatabase, _studentDatabase, _userDatabase);
            category.Show();
        }
        public void loadStudentPage()
        {
            formStudent student = new formStudent(databaseOperations, _accountDatabase, _bookDatabase, _borrowDatabase, _categoryDatabase, _publisherDatabase, _studentDatabase, _userDatabase);
            student.Show();
        }
        public void loadLoginPage()
        {
            formLogin login = new formLogin(databaseOperations, _accountDatabase, _bookDatabase, _borrowDatabase, _categoryDatabase, _publisherDatabase, _studentDatabase, _userDatabase);
            login.Show();
        }
        public void loadSignupPage()
        {
            formSignup signup = new formSignup(databaseOperations, _accountDatabase, _bookDatabase, _borrowDatabase, _categoryDatabase, _publisherDatabase, _studentDatabase, _userDatabase);
            signup.Show();
        }
        public void loadDashboardPage()
        {
            formDashboard dashboard = new formDashboard(databaseOperations, _accountDatabase, _bookDatabase, _borrowDatabase, _categoryDatabase, _publisherDatabase, _studentDatabase, _userDatabase);
            dashboard.Show();
        }
        public void loadBorrowPage()
        {
            formBorrow borrow = new formBorrow(databaseOperations, _accountDatabase, _bookDatabase, _borrowDatabase, _categoryDatabase, _publisherDatabase, _studentDatabase, _userDatabase);
            borrow.Show();
        }
    }
}
