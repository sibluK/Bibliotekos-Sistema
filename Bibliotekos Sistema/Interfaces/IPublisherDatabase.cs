using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bibliotekos_Sistema.Interfaces
{
    public interface IPublisherDatabase
    {
        int GetTotalPublishers();
        void LoadPublisherIntoComboBox(ComboBox ComboBox);
        void LoadPublishersIntoTable(DataGridView dgvPublisher);
        void SavePublisherInfo(DataGridView dgvPublisher, TextBox txtPublisherName, TextBox txtPublisherID);
        void EditPublisherInfo(DataGridView dgvPublisher, TextBox txtPublisherName, TextBox txtPublisherID);
        void DeletePublisherInfo(DataGridView dgvPublisher, TextBox txtPublisherName, TextBox txtPublisherID);
    }
}
