using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bibliotekos_Sistema.Interfaces
{
    public interface IStudentDatabase
    {
        int GetTotalStudents();
        void LoadStudentsIntoTable(DataGridView dgvStudent);
        void SaveStudentInfo(DataGridView dgvStudent, TextBox txtFullName, TextBox txtPhone, TextBox txtStudentID, ComboBox cboDepartment, ComboBox cboGender, MaskedTextBox mtbDateOfBirth);
        void DeleteStudentInfo(DataGridView dgvStudent, TextBox txtFullName, TextBox txtPhone, TextBox txtStudentID, ComboBox cboDepartment, ComboBox cboGender, MaskedTextBox mtbDateOfBirth);
        void EditStudentInfo(DataGridView dgvStudent, TextBox txtFullName, TextBox txtPhone, TextBox txtStudentID, ComboBox cboDepartment, ComboBox cboGender, MaskedTextBox mtbDateOfBirth);

    }
}
