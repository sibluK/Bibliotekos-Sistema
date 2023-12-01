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
        private readonly SqlCommand _command;
        private string sql;
        private readonly IDatabaseOperations _databaseOperations;

        public BorrowService(IDatabaseOperations databaseOperations)
        {
            _databaseOperations = databaseOperations;
            _command = new SqlCommand();
        }

        public void loadBorrowsIntoTable(DataGridView DataGridView)
        {
            SqlDataAdapter DA = new SqlDataAdapter();
            DataTable DT = new DataTable();

            try
            {
                SqlConnection sqlConnection = _databaseOperations.GetConnection();
                sqlConnection.Open();
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sql = "SELECT * FROM tblBorrowDetail";
                    _command.Connection = sqlConnection;
                    _command.CommandText = sql;
                    DA.SelectCommand = _command;
                    DA.Fill(DT);
                    DataGridView.DataSource = DT;

                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                _databaseOperations.GetConnection().Close();
            }
        }
    }
}
