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
using Bibliotekos_Sistema.Interfaces;

namespace Bibliotekos_Sistema.Forms
{
    public partial class formDashboard : Form
    {
        private readonly IDatabaseOperations _databaseOperations;
        private readonly Account _account;
        private readonly PageLoader _pageLoader;
        private readonly Book _book;
        private readonly Category _category;
        private readonly Publisher _publisher;
        private readonly Student _student;

        public formDashboard(IDatabaseOperations databaseOperations)
        {
            InitializeComponent();
            _databaseOperations = databaseOperations;
            _account = new Account(_databaseOperations);
            _book = new Book(_databaseOperations);
            _category = new Category(_databaseOperations);
            _publisher = new Publisher(_databaseOperations);
            _student = new Student(_databaseOperations);
            _pageLoader = new PageLoader();
        }

        private void formDashboard_Load(object sender, EventArgs e)
        {
            lblTotalStudent.Text += _student.totalStudents();
            lblTotalCategory.Text += _category.totalCategory();
            lblTotalPublisher.Text += _publisher.totalPublisher();
            lblTotalBooks.Text += _book.totalBook();
            lblTotalAccounts.Text += _account.totalAccount();
        }

        //// NAVIGATION ////
        private void btnLogout_Click(object sender, EventArgs e)
        {
            _pageLoader.loadLoginPage();
            this.Dispose();
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            _pageLoader.loadBookPage();
            this.Dispose();
        }

        private void btnStudent_Click(object sender, EventArgs e)
        {
            _pageLoader.loadStudentPage();
            this.Dispose();
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            _pageLoader.loadCategoryPage();
            this.Dispose();
        }

        private void btnPublisher_Click(object sender, EventArgs e)
        {
            _pageLoader.loadPublisherPage();
            this.Dispose();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            _pageLoader.loadDashboardPage();
            this.Dispose();
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            _pageLoader.loadAccountPage();
            this.Dispose();
        }
    }
}
