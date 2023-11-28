using Bibliotekos_Sistema.Classes;
using Bibliotekos_Sistema.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bibliotekos_Sistema.Forms
{
    public partial class formCategory : Form
    {
        Book Book = new Book();
        Category Category = new Category();
        Publisher Publisher = new Publisher();
        Student Student = new Student();
        Account Account = new Account();

        public formCategory()
        {
            InitializeComponent();
        }


        private void formCategory_Load(object sender, EventArgs e)
        {
            Category.loadCategoriesIntoTable(dgvCategory);
        }

        private void dgvCategory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                txtCategoryID.Text = dgvCategory.CurrentRow.Cells[0].Value.ToString();
                txtCategoryName.Text = dgvCategory.CurrentRow.Cells[1].Value.ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Category.saveCategoryInfo(dgvCategory, txtCategoryName, txtCategoryID);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Category.deleteCategoryInfo(dgvCategory, txtCategoryName, txtCategoryID);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Category.editCategoryInfo(dgvCategory, txtCategoryName, txtCategoryID);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtCategoryID.Clear();
            txtCategoryName.Clear();
        }

        //// NAVIGATION ////
        private void btnHome_Click(object sender, EventArgs e)
        {
            formDashboard home = new formDashboard();
            home.Show();
            this.Dispose();
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            Book.loadBookPage();
            this.Dispose();
        }

        private void btnPublisher_Click(object sender, EventArgs e)
        {
            Publisher.loadPublisherPage();
            this.Dispose();
        }

        private void btnStudent_Click(object sender, EventArgs e)
        {
            Student.loadStudentPage();
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
