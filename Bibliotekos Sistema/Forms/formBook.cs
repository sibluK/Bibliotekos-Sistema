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
        private readonly IDatabaseOperations _databaseOperations;
        private readonly Book _book;
        private readonly Category _category;
        private readonly Publisher _publisher;
        private readonly PageLoader _pageLoader;

        public formBook(IDatabaseOperations databaseOperations)
        {
            InitializeComponent();
            _databaseOperations = databaseOperations;
            _book = new Book(_databaseOperations);
            _category = new Category(_databaseOperations);
            _publisher = new Publisher(_databaseOperations);
            _pageLoader = new PageLoader();
        }

        private void formBook_Load(object sender, EventArgs e)
        {
            _category.loadCategoryIntoComboBox(cboCategory);
            _publisher.loadPublisherIntoComboBox(cboPublisher);
            _book.loadBooksIntoTable(dgvBook);
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
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _book.saveBookInfo(dgvBook, cboCategory, cboPublisher, txtISBN, txtTitle, txtPubYear, txtAcNumber, txtCurrNumber);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            _book.deleteBookInfo(dgvBook, cboCategory, cboPublisher, txtISBN, txtTitle, txtPubYear, txtAcNumber, txtCurrNumber);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            _book.editBookInfo(dgvBook, cboCategory, cboPublisher, txtISBN, txtTitle, txtPubYear, txtAcNumber, txtCurrNumber);
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
    }
}
