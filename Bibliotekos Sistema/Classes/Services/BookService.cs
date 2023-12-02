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
    public class BookService
    {
        private readonly IBookDatabase _bookDatabase;

        public BookService(IBookDatabase bookDatabase)
        {
            _bookDatabase = bookDatabase;
        }

        public int totalBook()
        {
            return _bookDatabase.GetTotalBooks();
        }

        public void loadBooksIntoTable(DataGridView DataGridView)
        {
            _bookDatabase.LoadBooksIntoTable(DataGridView);
        }

        public void saveBookInfo(DataGridView dgvBook, ComboBox cboCategory, ComboBox cboPublisher, TextBox txtISBN, TextBox txtTitle, TextBox txtPubYear, TextBox txtAcNumber, TextBox txtCurrNumber)
        {
            _bookDatabase.SaveBookInfo(dgvBook, cboCategory, cboPublisher, txtISBN, txtTitle, txtPubYear, txtAcNumber, txtCurrNumber);
        }

        public void deleteBookInfo(DataGridView dgvBook, ComboBox cboCategory, ComboBox cboPublisher, TextBox txtISBN, TextBox txtTitle, TextBox txtPubYear, TextBox txtAcNumber, TextBox txtCurrNumber)
        {
            _bookDatabase.DeleteBookInfo(dgvBook, cboCategory, cboPublisher, txtISBN, txtTitle, txtPubYear, txtAcNumber, txtCurrNumber);
        }

        public void editBookInfo(DataGridView dgvBook, ComboBox cboCategory, ComboBox cboPublisher, TextBox txtISBN, TextBox txtTitle, TextBox txtPubYear, TextBox txtAcNumber, TextBox txtCurrNumber)
        {
            _bookDatabase.EditBookInfo(dgvBook, cboCategory, cboPublisher, txtISBN, txtTitle, txtPubYear, txtAcNumber, txtCurrNumber);
        }
    }
}
