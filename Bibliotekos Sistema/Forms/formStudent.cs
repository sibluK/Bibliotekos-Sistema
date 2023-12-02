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
using System.Drawing.Text;
using System.Runtime.CompilerServices;
using Bibliotekos_Sistema.Classes;
using Bibliotekos_Sistema.Interfaces;
using System.Security.Principal;

namespace Bibliotekos_Sistema.Forms
{
    public partial class formStudent : Form
    {
        private readonly StudentService _studentService;
        private readonly PageLoader _pageLoader;
        private readonly IDatabaseOperations _databaseOperations;
        private readonly IAccountDatabase _accountDatabase;
        private readonly IBookDatabase _bookDatabase;
        private readonly IBorrowDatabase _borrowDatabase;
        private readonly ICategoryDatabase _categoryDatabase;
        private readonly IPublisherDatabase _publisherDatabase;
        private readonly IStudentDatabase _studentDatabase;
        private readonly IUserDatabase _userDatabase;


        public formStudent(IDatabaseOperations databaseOperations, IAccountDatabase accountDatabase, IBookDatabase bookDatabase, IBorrowDatabase borrowDatabase, ICategoryDatabase categoryDatabase, IPublisherDatabase publisherDatabase, IStudentDatabase studentDatabase , IUserDatabase userDatabase)
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
            _studentService = new StudentService(_studentDatabase);
            _pageLoader = new PageLoader(_accountDatabase, _bookDatabase, _borrowDatabase, _categoryDatabase, _publisherDatabase, _studentDatabase, _userDatabase);

        }

        private void formStudent_Load(object sender, EventArgs e)
        {
            _studentService.loadStudentsIntoTable(dgvStudent);
        }

        private void dgvStudent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                txtStudentID.Text = dgvStudent.CurrentRow.Cells[0].Value.ToString();
                txtFullName.Text = dgvStudent.CurrentRow.Cells[1].Value.ToString();
                cboGender.Text = dgvStudent.CurrentRow.Cells[2].Value.ToString();
                mtbDateOfBirth.Text = dgvStudent.CurrentRow.Cells[3].Value.ToString();
                cboDepartment.Text = dgvStudent.CurrentRow.Cells[4].Value.ToString();
                txtPhone.Text = dgvStudent.CurrentRow.Cells[5].Value.ToString();
            }
            txtStudentID.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _studentService.saveStudentInfo(dgvStudent, txtFullName, txtPhone, txtStudentID, cboDepartment, cboGender, mtbDateOfBirth);
            txtStudentID.Enabled = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            _studentService.deleteStudentInfo(dgvStudent, txtFullName, txtPhone, txtStudentID, cboDepartment, cboGender, mtbDateOfBirth);
            txtStudentID.Enabled = true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            _studentService.editStudentInfo(dgvStudent, txtFullName, txtPhone, txtStudentID, cboDepartment, cboGender, mtbDateOfBirth);
            txtStudentID.Enabled = true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtStudentID.Clear();
            txtFullName.Clear();
            txtPhone.Clear();
            cboDepartment.ResetText();
            cboGender.ResetText();
            mtbDateOfBirth.Clear();
            txtStudentID.Enabled = true;
        }

        //// NAVIGATION ////
        private void btnHome_Click_1(object sender, EventArgs e)
        {
            _pageLoader.loadDashboardPage();
            this.Dispose();
        }

        private void btnBook_Click_1(object sender, EventArgs e)
        {
            _pageLoader.loadBookPage();
            this.Dispose();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            _pageLoader.loadLoginPage();
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

        private void btnRent_Click(object sender, EventArgs e)
        {
            _pageLoader.loadBorrowPage();
            this.Dispose(true);
        }
    }
}
