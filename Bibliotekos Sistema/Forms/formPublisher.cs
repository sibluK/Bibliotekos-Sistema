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
    public partial class formPublisher : Form
    {
        public formPublisher()
        {
            InitializeComponent();
        }

        Book Book = new Book();
        Category Category = new Category();
        Publisher Publisher = new Publisher();
        Student Student = new Student();
        Account Account = new Account();

        private void formPublisher_Load(object sender, EventArgs e)
        {
            Publisher.loadPublishersIntoTable(dgvPublisher);
        }

        private void dgvPublisher_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                txtPublisherID.Text = dgvPublisher.CurrentRow.Cells[0].Value.ToString();
                txtPublisherName.Text = dgvPublisher.CurrentRow.Cells[1].Value.ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Publisher.savePublisherInfo(dgvPublisher, txtPublisherName, txtPublisherID);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Publisher.editPublisherInfo(dgvPublisher, txtPublisherName, txtPublisherID);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Publisher.deletePublisherInfo(dgvPublisher, txtPublisherName, txtPublisherID);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtPublisherID.Clear();
            txtPublisherName.Clear();
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
