using Bibliotekos_Sistema.Classes;
using Bibliotekos_Sistema.Database;
using Bibliotekos_Sistema.Interfaces;
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
        private readonly CategoryService _categoryService;
        private readonly PageLoader _pageLoader;
        private readonly IAccountDatabase _accountDatabase;
        private readonly IBookDatabase _bookDatabase;
        private readonly IBorrowDatabase _borrowDatabase;
        private readonly ICategoryDatabase _categoryDatabase;
        private readonly IPublisherDatabase _publisherDatabase;
        private readonly IStudentDatabase _studentDatabase;
        private readonly IUserDatabase _userDatabase;


        public formCategory(IAccountDatabase accountDatabase, IBookDatabase bookDatabase, IBorrowDatabase borrowDatabase, ICategoryDatabase categoryDatabase, IPublisherDatabase publisherDatabase, IStudentDatabase studentDatabase, IUserDatabase userDatabase)
        {
            InitializeComponent();
            _accountDatabase = accountDatabase;
            _bookDatabase = bookDatabase;
            _borrowDatabase = borrowDatabase;
            _categoryDatabase = categoryDatabase;
            _publisherDatabase = publisherDatabase;
            _studentDatabase = studentDatabase;
            _userDatabase = userDatabase;
            _categoryService = new CategoryService(_categoryDatabase);
            _pageLoader = new PageLoader(_accountDatabase, _bookDatabase, _borrowDatabase, _categoryDatabase, _publisherDatabase, _studentDatabase, _userDatabase);

        }


        private void formCategory_Load(object sender, EventArgs e)
        {
            _categoryService.loadCategoriesIntoTable(dgvCategory);
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
            _categoryService.saveCategoryInfo(dgvCategory, txtCategoryName, txtCategoryID);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            _categoryService.deleteCategoryInfo(dgvCategory, txtCategoryName, txtCategoryID);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            _categoryService.editCategoryInfo(dgvCategory, txtCategoryName, txtCategoryID);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtCategoryID.Clear();
            txtCategoryName.Clear();
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

        private void btnPublisher_Click(object sender, EventArgs e)
        {
            _pageLoader.loadPublisherPage();
            this.Dispose();
        }

        private void btnStudent_Click(object sender, EventArgs e)
        {
            _pageLoader.loadStudentPage();
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
