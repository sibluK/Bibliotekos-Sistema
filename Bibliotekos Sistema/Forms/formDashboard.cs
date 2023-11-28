using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Bibliotekos_Sistema.Database;
using System.Runtime.Remoting.Messaging;
using Bibliotekos_Sistema.Classes;

namespace Bibliotekos_Sistema.Forms
{
    public partial class formDashboard : Form
    {
        Book Book = new Book();
        Category Category = new Category();
        Publisher Publisher = new Publisher();
        Student Student = new Student();
        Account Account = new Account();

        public formDashboard()
        {
            InitializeComponent();
        }

        private void formDashboard_Load(object sender, EventArgs e)
        {
            lblTotalStudent.Text += Student.totalStudents();
            lblTotalCategory.Text += Category.totalCategory();
            lblTotalPublisher.Text += Publisher.totalPublisher();
            lblTotalBooks.Text += Book.totalBook();
            lblTotalAccounts.Text += Account.totalAccount();
        }

        //// NAVIGATION ////
        private void btnLogout_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Dispose();
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            Book.loadBookPage();
            this.Dispose();
        }

        private void btnStudent_Click(object sender, EventArgs e)
        {
            Student.loadStudentPage();
            this.Dispose();
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            Category.loadCategoryPage();
            this.Dispose();
        }

        private void btnPublisher_Click(object sender, EventArgs e)
        {
            Publisher.loadPublisherPage();
            this.Dispose();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {

        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            Account.loadAccountPage();
            this.Dispose();
        }
    }
}
