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
using Bibliotekos_Sistema.Classes;
using Bibliotekos_Sistema.Interfaces;
using System.Security.Principal;

namespace Bibliotekos_Sistema.Forms
{
    public partial class formBook : Form
    {
        private readonly BookService _bookService;
        private readonly CategoryService _categoryService;
        private readonly PublisherService _publisherService;
        private readonly PageLoader _pageLoader;
        private readonly IDatabaseOperations _databaseOperations;
        private readonly IAccountDatabase _accountDatabase;
        private readonly IBookDatabase _bookDatabase;
        private readonly IBorrowDatabase _borrowDatabase;
        private readonly ICategoryDatabase _categoryDatabase;
        private readonly IPublisherDatabase _publisherDatabase;
        private readonly IStudentDatabase _studentDatabase;
        private readonly IUserDatabase _userDatabase;

        public formBook(IDatabaseOperations databaseOperations, IAccountDatabase accountDatabase, IBookDatabase bookDatabase, IBorrowDatabase borrowDatabase, ICategoryDatabase categoryDatabase, IPublisherDatabase publisherDatabase, IStudentDatabase studentDatabase, IUserDatabase userDatabase)
        {
            InitializeComponent();
            _databaseOperations = databaseOperations;
            _accountDatabase = accountDatabase;
            _bookDatabase = bookDatabase;
            _borrowDatabase = borrowDatabase;
            _categoryDatabase = categoryDatabase;
            _publisherDatabase = publisherDatabase;
            _studentDatabase = studentDatabase;
            _userDatabase = userDatabase;
            _bookService = new BookService(_bookDatabase);
            _categoryService = new CategoryService(_categoryDatabase);
            _publisherService = new PublisherService(_publisherDatabase);
            _pageLoader = new PageLoader(_accountDatabase, _bookDatabase, _borrowDatabase, _categoryDatabase, _publisherDatabase, _studentDatabase, _userDatabase);

        }

        private void formBook_Load(object sender, EventArgs e)
        {
            _categoryService.loadCategoryIntoComboBox(cboCategory);
            _publisherService.loadPublisherIntoComboBox(cboPublisher);
            _bookService.loadBooksIntoTable(dgvBook);
        }

        private void dgvBook_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex > -1)
            { 
                txtISBN.Text = dgvBook.CurrentRow.Cells[0].Value.ToString();
                txtTitle.Text = dgvBook.CurrentRow.Cells[1].Value.ToString();
                cboCategory.Text = dgvBook.CurrentRow.Cells[2].Value.ToString();
                cboPublisher.Text = dgvBook.CurrentRow.Cells[3].Value.ToString();
                txtPubYear.Text = dgvBook.CurrentRow.Cells[4].Value.ToString();
                txtAcNumber.Text = dgvBook.CurrentRow.Cells[5].Value.ToString();
                txtCurrNumber.Text = dgvBook.CurrentRow.Cells[6].Value.ToString();
            }

            txtISBN.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _bookService.saveBookInfo(dgvBook, cboCategory, cboPublisher, txtISBN, txtTitle, txtPubYear, txtAcNumber, txtCurrNumber);
            txtISBN.Enabled = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            _bookService.deleteBookInfo(dgvBook, cboCategory, cboPublisher, txtISBN, txtTitle, txtPubYear, txtAcNumber, txtCurrNumber);
            txtISBN.Enabled = true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            _bookService.editBookInfo(dgvBook, cboCategory, cboPublisher, txtISBN, txtTitle, txtPubYear, txtAcNumber, txtCurrNumber);
            txtISBN.Enabled = true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtISBN.Clear();
            txtTitle.Clear();
            txtPubYear.Clear();
            txtAcNumber.Clear();
            txtCurrNumber.Clear();
            cboPublisher.ResetText();
            cboCategory.ResetText();
            txtISBN.Enabled = true;
        }

        //// NAVIGATION ////
        private void btnHome_Click(object sender, EventArgs e)
        {
            _pageLoader.loadDashboardPage();
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

        private void btnLogout_Click(object sender, EventArgs e)
        {
            _pageLoader.loadLoginPage();
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
