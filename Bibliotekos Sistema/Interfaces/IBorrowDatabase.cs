using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bibliotekos_Sistema.Interfaces
{
    public interface IBorrowDatabase
    {
        void LoadBorrowsIntoTable(DataGridView dataGridView);
        void SaveBorrowInfo(DataGridView dgvBorrows, TextBox txtBorrowID, TextBox txtISBN, TextBox txtStudentID, MaskedTextBox mtbBorrowDate, MaskedTextBox mtbReturnDate, TextBox txtIssuerID);
        void DeleteBorrowInfo(DataGridView dgvBorrows, TextBox txtBorrowID, TextBox txtISBN, TextBox txtStudentID, MaskedTextBox mtbBorrowDate, MaskedTextBox mtbReturnDate, TextBox txtIssuerID);
        void EditBorrowInfo(DataGridView dgvBorrows, TextBox txtBorrowID, TextBox txtISBN, TextBox txtStudentID, MaskedTextBox mtbBorrowDate, MaskedTextBox mtbReturnDate, TextBox txtIssuerID);

    }
}
