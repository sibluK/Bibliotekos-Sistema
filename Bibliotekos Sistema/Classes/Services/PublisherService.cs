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
    public class PublisherService
    {
        private readonly IPublisherDatabase _publisherDatabase;

        public PublisherService(IPublisherDatabase publisherDatabase)
        {
            _publisherDatabase = publisherDatabase;
        }

        public int totalPublisher()
        {
            return _publisherDatabase.GetTotalPublishers();
        }
        public void loadPublisherIntoComboBox(ComboBox ComboBox)
        {
           _publisherDatabase.LoadPublisherIntoComboBox(ComboBox);
        }

        public void loadPublishersIntoTable(DataGridView dgvPublisher)
        {
            _publisherDatabase.LoadPublishersIntoTable(dgvPublisher);
        }

        public void savePublisherInfo(DataGridView dgvPublisher, TextBox txtPublisherName, TextBox txtPublisherID)
        {
            _publisherDatabase.SavePublisherInfo(dgvPublisher, txtPublisherName, txtPublisherID);
        }

        public void editPublisherInfo(DataGridView dgvPublisher, TextBox txtPublisherName, TextBox txtPublisherID)
        {
            _publisherDatabase.EditPublisherInfo(dgvPublisher, txtPublisherName, txtPublisherID);
        }

        public void deletePublisherInfo(DataGridView dgvPublisher, TextBox txtPublisherName, TextBox txtPublisherID)
        {
            _publisherDatabase.DeletePublisherInfo(dgvPublisher, txtPublisherName, txtPublisherID);
        }
    }
}
