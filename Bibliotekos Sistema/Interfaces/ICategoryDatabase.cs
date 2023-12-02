using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bibliotekos_Sistema.Interfaces
{
    public interface ICategoryDatabase
    {
        int GetTotalCategories();
        void LoadCategoriesIntoTable(DataGridView dgvCategory);
        void LoadCategoryIntoComboBox(ComboBox ComboBox);
        void SaveCategoryInfo(DataGridView dgvCategory, TextBox txtCategoryName, TextBox txtCategoryID);
        void DeleteCategoryInfo(DataGridView dgvCategory, TextBox txtCategoryName, TextBox txtCategoryID);
        void EditCategoryInfo(DataGridView dgvCategory, TextBox txtCategoryName, TextBox txtCategoryID);
    }
}
