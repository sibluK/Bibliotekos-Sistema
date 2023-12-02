using Bibliotekos_Sistema.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bibliotekos_Sistema.Classes
{
    public class BorrowService
    {
        private readonly IBorrowDatabase _borrowDatabase;

        public BorrowService(IBorrowDatabase borrowDatabase)
        {
            _borrowDatabase = borrowDatabase;
        }

        public void loadBorrowsIntoTable(DataGridView DataGridView)
        {
            _borrowDatabase.LoadBorrowsIntoTable(DataGridView);
        }

        public void saveBorrowInfo(DataGridView dgvBorrows, TextBox txtBorrowID, TextBox txtISBN, TextBox txtStudentID, MaskedTextBox mtbBorrowDate, MaskedTextBox mtbReturnDate, TextBox txtIssuerID)
        {
            _borrowDatabase.SaveBorrowInfo(dgvBorrows, txtBorrowID, txtISBN, txtStudentID, mtbBorrowDate, mtbReturnDate, txtIssuerID);
        }

        public void DeleteBorrowInfo(DataGridView dgvBorrows, TextBox txtBorrowID, TextBox txtISBN, TextBox txtStudentID, MaskedTextBox mtbBorrowDate, MaskedTextBox mtbReturnDate, TextBox txtIssuerID)
        {
            _borrowDatabase.DeleteBorrowInfo(dgvBorrows, txtBorrowID, txtISBN, txtStudentID, mtbBorrowDate, mtbReturnDate, txtIssuerID);
        }

        public void EditBorrowInfo(DataGridView dgvBorrows, TextBox txtBorrowID, TextBox txtISBN, TextBox txtStudentID, MaskedTextBox mtbBorrowDate, MaskedTextBox mtbReturnDate, TextBox txtIssuerID)
        {
            _borrowDatabase.EditBorrowInfo(dgvBorrows, txtBorrowID, txtISBN, txtStudentID, mtbBorrowDate, mtbReturnDate, txtIssuerID);
        }
    }
}
