using Bibliotekos_Sistema.Database;
using Bibliotekos_Sistema.Forms;
using Bibliotekos_Sistema.Interfaces;

namespace Bibliotekos_Sistema.Classes
{
    public class PageLoader
    {
        IDatabaseOperations databaseOperations = new DBConnection();
        public void loadPublisherPage()
        {
            formPublisher publisher = new formPublisher(databaseOperations);
            publisher.Show();
        }
        public void loadAccountPage()
        {
            formAccount account = new formAccount(databaseOperations);
            account.Show();
        }
        public void loadBookPage()
        {
            formBook book = new formBook(databaseOperations);
            book.Show();
        }
        public void loadCategoryPage()
        {
            formCategory category = new formCategory(databaseOperations);
            category.Show();
        }
        public void loadStudentPage()
        {
            formStudent student = new formStudent(databaseOperations);
            student.Show();
        }
        public void loadLoginPage()
        {
            formLogin login = new formLogin(databaseOperations);
            login.Show();
        }
        public void loadSignupPage()
        {
            formSignup signup = new formSignup(databaseOperations);
            signup.Show();
        }
        public void loadDashboardPage()
        {
            formDashboard dashboard = new formDashboard(databaseOperations);
            dashboard.Show();
        }
    }
}
