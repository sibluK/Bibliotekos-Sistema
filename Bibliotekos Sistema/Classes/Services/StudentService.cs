using Bibliotekos_Sistema.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bibliotekos_Sistema.Classes
{
    public class StudentService
    {
        private readonly IStudentDatabase _studentDatabase;

        public StudentService(IStudentDatabase studentDatabase)
        {
            _studentDatabase = studentDatabase; 
        }

        public int totalStudents()
        {
            return _studentDatabase.GetTotalStudents();
        }

        public void loadStudentsIntoTable(DataGridView dgvStudent)
        {
            _studentDatabase.LoadStudentsIntoTable(dgvStudent);
        }

        public void saveStudentInfo(DataGridView dgvStudent, TextBox txtFullName, TextBox txtPhone, TextBox txtStudentID, ComboBox cboDepartment, ComboBox cboGender, MaskedTextBox mtbDateOfBirth)
        {
            _studentDatabase.SaveStudentInfo(dgvStudent, txtFullName, txtPhone, txtStudentID, cboDepartment, cboGender, mtbDateOfBirth);
        }

        public void deleteStudentInfo(DataGridView dgvStudent, TextBox txtFullName, TextBox txtPhone, TextBox txtStudentID, ComboBox cboDepartment, ComboBox cboGender, MaskedTextBox mtbDateOfBirth)
        {
            _studentDatabase.DeleteStudentInfo(dgvStudent, txtFullName, txtPhone, txtStudentID, cboDepartment, cboGender, mtbDateOfBirth);
        }

        public void editStudentInfo(DataGridView dgvStudent, TextBox txtFullName, TextBox txtPhone, TextBox txtStudentID, ComboBox cboDepartment, ComboBox cboGender, MaskedTextBox mtbDateOfBirth)
        {
            _studentDatabase.EditStudentInfo(dgvStudent, txtFullName, txtPhone, txtStudentID, cboDepartment, cboGender, mtbDateOfBirth);
        }
    }
}
