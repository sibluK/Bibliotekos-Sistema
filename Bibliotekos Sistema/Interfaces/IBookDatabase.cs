using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bibliotekos_Sistema.Interfaces
{
    public interface IBookDatabase
    {
        int GetTotalBooks();
        void LoadBooksIntoTable(DataGridView DataGridView);
        void SaveBookInfo(DataGridView dgvBook, ComboBox cboCategory, ComboBox cboPublisher, TextBox txtISBN, TextBox txtTitle, TextBox txtPubYear, TextBox txtAcNumber, TextBox txtCurrNumber);
        void DeleteBookInfo(DataGridView dgvBook, ComboBox cboCategory, ComboBox cboPublisher, TextBox txtISBN, TextBox txtTitle, TextBox txtPubYear, TextBox txtAcNumber, TextBox txtCurrNumber);
        void EditBookInfo(DataGridView dgvBook, ComboBox cboCategory, ComboBox cboPublisher, TextBox txtISBN, TextBox txtTitle, TextBox txtPubYear, TextBox txtAcNumber, TextBox txtCurrNumber);

    }
}
