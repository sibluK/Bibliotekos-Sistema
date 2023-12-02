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
        private readonly AccountService _accountService;
        private readonly PageLoader _pageLoader;
        private readonly BookService _bookService;
        private readonly CategoryService _categoryService;
        private readonly PublisherService _publisherService;
        private readonly StudentService _studentService;
        private readonly IAccountDatabase _accountDatabase;
        private readonly IBookDatabase _bookDatabase;
        private readonly IBorrowDatabase _borrowDatabase;
        private readonly ICategoryDatabase _categoryDatabase;
        private readonly IPublisherDatabase _publisherDatabase;
        private readonly IStudentDatabase _studentDatabase;
        private readonly IUserDatabase _userDatabase;


        public formDashboard(IAccountDatabase accountDatabase, IBookDatabase bookDatabase, IBorrowDatabase borrowDatabase, ICategoryDatabase categoryDatabase, IPublisherDatabase publisherDatabase, IStudentDatabase studentDatabase, IUserDatabase userDatabase)
        {
            InitializeComponent();
            _accountDatabase = accountDatabase;
            _bookDatabase = bookDatabase;
            _borrowDatabase = borrowDatabase;
            _categoryDatabase = categoryDatabase;
            _publisherDatabase = publisherDatabase;
            _studentDatabase = studentDatabase;
            _userDatabase = userDatabase;
            _accountService = new AccountService(_accountDatabase);
            _bookService = new BookService(_bookDatabase);
            _categoryService = new CategoryService(_categoryDatabase);
            _publisherService = new PublisherService(_publisherDatabase);
            _studentService = new StudentService(_studentDatabase);
            _pageLoader = new PageLoader(_accountDatabase, _bookDatabase, _borrowDatabase, _categoryDatabase, _publisherDatabase, _studentDatabase, _userDatabase);

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

        private void btnRent_Click(object sender, EventArgs e)
        {
            _pageLoader.loadBorrowPage();
            this.Dispose();
        }
    }
}
