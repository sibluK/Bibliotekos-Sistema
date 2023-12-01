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
    public partial class formPublisher : Form
    {
        private readonly IDatabaseOperations _databaseOperations;
        private readonly PublisherService _publisherService;
        private readonly PageLoader _pageLoader;
        public formPublisher(IDatabaseOperations databaseOperations)
        {
            InitializeComponent();
            _databaseOperations = databaseOperations;
            _publisherService = new PublisherService(_databaseOperations);
            _pageLoader = new PageLoader();
        }

        private void formPublisher_Load(object sender, EventArgs e)
        {
            _publisherService.loadPublishersIntoTable(dgvPublisher);
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
            _publisherService.savePublisherInfo(dgvPublisher, txtPublisherName, txtPublisherID);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            _publisherService.editPublisherInfo(dgvPublisher, txtPublisherName, txtPublisherID);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            _publisherService.deletePublisherInfo(dgvPublisher, txtPublisherName, txtPublisherID);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtPublisherID.Clear();
            txtPublisherName.Clear();
        }


        //// NAVIGATION ////
        private void btnHome_Click(object sender, EventArgs e)
        {
            _pageLoader.loadDashboardPage();
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
