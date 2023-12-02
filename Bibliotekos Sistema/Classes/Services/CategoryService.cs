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
    public class CategoryService
    {
        private readonly ICategoryDatabase _categoryDatabase;

        public CategoryService(ICategoryDatabase categoryDatabase)
        {
            _categoryDatabase = categoryDatabase;
        }

        public int totalCategory()
        {
            return _categoryDatabase.GetTotalCategories();
        }

        public void loadCategoriesIntoTable(DataGridView dgvCategory)
        {
            _categoryDatabase.LoadCategoriesIntoTable(dgvCategory);
        }

        public void loadCategoryIntoComboBox(ComboBox ComboBox)
        {
            _categoryDatabase.LoadCategoryIntoComboBox(ComboBox);
        }

        public void saveCategoryInfo(DataGridView dgvCategory, TextBox txtCategoryName, TextBox txtCategoryID)
        {
            _categoryDatabase.SaveCategoryInfo(dgvCategory, txtCategoryName, txtCategoryID);
        }

        public void deleteCategoryInfo(DataGridView dgvCategory, TextBox txtCategoryName, TextBox txtCategoryID)
        {
            _categoryDatabase.DeleteCategoryInfo(dgvCategory, txtCategoryName, txtCategoryID);
        }

        public void editCategoryInfo(DataGridView dgvCategory, TextBox txtCategoryName, TextBox txtCategoryID)
        {
            _categoryDatabase.EditCategoryInfo(dgvCategory, txtCategoryName, txtCategoryID);
        }
    }
}
