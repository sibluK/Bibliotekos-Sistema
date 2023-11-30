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
        private readonly IDatabaseOperations _databaseOperations;
        private readonly StudentService _studentService;
        private readonly PageLoader _pageLoader;

        public formStudent(IDatabaseOperations databaseOperations)
        {
            InitializeComponent();
            _databaseOperations = databaseOperations;
            _studentService = new StudentService(_databaseOperations);
            _pageLoader = new PageLoader();
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
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _studentService.saveStudentInfo(dgvStudent, txtFullName, txtPhone, txtStudentID, cboDepartment, cboGender, mtbDateOfBirth);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            _studentService.deleteStudentInfo(dgvStudent, txtFullName, txtPhone, txtStudentID, cboDepartment, cboGender, mtbDateOfBirth);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            _studentService.editStudentInfo(dgvStudent, txtFullName, txtPhone, txtStudentID, cboDepartment, cboGender, mtbDateOfBirth);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtStudentID.Clear();
            txtFullName.Clear();
            txtPhone.Clear();
            cboDepartment.ResetText();
            cboGender.ResetText();
            mtbDateOfBirth.Clear();
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
    }
}
