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
        private readonly AccountService _accountService;
        private readonly PageLoader _pageLoader;
        private readonly BookService _bookService;
        private readonly CategoryService _categoryService;
        private readonly PublisherService _publisherService;
        private readonly StudentService _studentService;

        public formDashboard(IDatabaseOperations databaseOperations)
        {
            InitializeComponent();
            _databaseOperations = databaseOperations;
            _accountService = new AccountService(_databaseOperations);
            _bookService = new BookService(_databaseOperations);
            _categoryService = new CategoryService(_databaseOperations);
            _publisherService = new PublisherService(_databaseOperations);
            _studentService = new StudentService(_databaseOperations);
            _pageLoader = new PageLoader();
        }

        private void formDashboard_Load(object sender, EventArgs e)
        {
            lblTotalStudent.Text += _studentService.totalStudents();
            lblTotalCategory.Text += _categoryService.totalCategory();
            lblTotalPublisher.Text += _publisherService.totalPublisher();
            lblTotalBooks.Text += _bookService.totalBook();
            lblTotalAccounts.Text += _accountService.totalAccount();
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
