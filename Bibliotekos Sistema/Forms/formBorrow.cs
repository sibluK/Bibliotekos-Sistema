using Bibliotekos_Sistema.Classes;
using Bibliotekos_Sistema.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bibliotekos_Sistema.Forms
{
    public partial class formBorrow : Form
    {
        private readonly PageLoader _pageLoader;
        private readonly IDatabaseOperations _databaseOperations;
        private readonly BorrowService _borrowService;

        public formBorrow(IDatabaseOperations databaseOperations)
        {
            InitializeComponent();
            _databaseOperations = databaseOperations;
            _pageLoader = new PageLoader();
            _borrowService = new BorrowService(_databaseOperations);
        }

        private void formBorrow_Load(object sender, EventArgs e)
        {
            _borrowService.loadBorrowsIntoTable(dgvBorrows);
        }

        //NAVIGATION//
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

        private void btnPublisher_Click(object sender, EventArgs e)
        {
            _pageLoader.loadPublisherPage();
            this.Dispose();
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            _pageLoader.loadAccountPage();
            this.Dispose();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            _pageLoader.loadLoginPage();
            this.Dispose();
        }
    }
}
