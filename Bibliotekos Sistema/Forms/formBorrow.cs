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

        private void dgvBorrows_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                txtBorrowID.Text = dgvBorrows.CurrentRow.Cells[0].Value.ToString();
                txtISBN.Text = dgvBorrows.CurrentRow.Cells[1].Value.ToString();
                txtStudentID.Text = dgvBorrows.CurrentRow.Cells[2].Value.ToString();
                mtbBorrowDate.Text = dgvBorrows.CurrentRow.Cells[3].Value.ToString();
                mtbReturnDate.Text = dgvBorrows.CurrentRow.Cells[4].Value.ToString();
                txtIssuerID.Text = dgvBorrows.CurrentRow.Cells[5].Value.ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _borrowService.saveBorrowInfo(dgvBorrows, txtBorrowID, txtISBN, txtStudentID, mtbBorrowDate, mtbReturnDate, txtIssuerID);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            _borrowService.DeleteBorrowInfo(dgvBorrows, txtBorrowID, txtISBN, txtStudentID, mtbBorrowDate, mtbReturnDate, txtIssuerID);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            _borrowService.EditBorrowInfo(dgvBorrows, txtBorrowID, txtISBN, txtStudentID, mtbBorrowDate, mtbReturnDate, txtIssuerID);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtBorrowID.Clear();
            txtISBN.Clear();
            txtStudentID.Clear();
            mtbBorrowDate.Clear();
            mtbReturnDate.Clear();
            txtIssuerID.Clear();
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
