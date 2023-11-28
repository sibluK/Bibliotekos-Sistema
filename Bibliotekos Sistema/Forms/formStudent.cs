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

namespace Bibliotekos_Sistema.Forms
{
    public partial class formStudent : Form
    {
        Book Book = new Book();
        Category Category = new Category();
        Publisher Publisher = new Publisher();
        Student Student = new Student();
        Account Account = new Account();

        public formStudent()
        {
            InitializeComponent();
        }

        private void formStudent_Load(object sender, EventArgs e)
        {
            Student.loadStudentsIntoTable(dgvStudent);
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
            Student.saveStudentInfo(dgvStudent, txtFullName, txtPhone, txtStudentID, cboDepartment, cboGender, mtbDateOfBirth);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Student.deleteStudentInfo(dgvStudent, txtFullName, txtPhone, txtStudentID, cboDepartment, cboGender, mtbDateOfBirth);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Student.editStudentInfo(dgvStudent, txtFullName, txtPhone, txtStudentID, cboDepartment, cboGender, mtbDateOfBirth);
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
            formDashboard home = new formDashboard();
            home.Show();
            this.Dispose();
        }

        private void btnBook_Click_1(object sender, EventArgs e)
        {
            Book.loadBookPage();
            this.Dispose();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
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

        private void btnAccount_Click(object sender, EventArgs e)
        {
            Account.loadAccountPage();
            this.Dispose();
        }
    }
}
