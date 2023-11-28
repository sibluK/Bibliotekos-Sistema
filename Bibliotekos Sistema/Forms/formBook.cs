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

namespace Bibliotekos_Sistema.Forms
{
    public partial class formBook : Form
    {
        Book Book = new Book();
        Category Category = new Category();
        Publisher Publisher = new Publisher();
        Student Student = new Student();
        Account Account = new Account();

        public formBook()
        {
            InitializeComponent();
        }

        private void formBook_Load(object sender, EventArgs e)
        {
            Category.loadCategoryIntoComboBox(cboCategory);
            Publisher.loadPublisherIntoComboBox(cboPublisher);
            Book.loadBooksIntoTable(dgvBook);
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
            Book.saveBookInfo(dgvBook, cboCategory, cboPublisher, txtISBN, txtTitle, txtPubYear, txtAcNumber, txtCurrNumber);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Book.deleteBookInfo(dgvBook, cboCategory, cboPublisher, txtISBN, txtTitle, txtPubYear, txtAcNumber, txtCurrNumber);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Book.editBookInfo(dgvBook, cboCategory, cboPublisher, txtISBN, txtTitle, txtPubYear, txtAcNumber, txtCurrNumber);
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
            formDashboard home = new formDashboard();
            home.Show();
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

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Dispose();
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            Account.loadAccountPage();
            this.Dispose();
        }
    }
}
