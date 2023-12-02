using Bibliotekos_Sistema.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bibliotekos_Sistema.Database
{
    public class PublisherDatabase : IPublisherDatabase
    {
        private readonly SqlCommand _command;
        private string sql;
        private readonly IDatabaseOperations _databaseOperations;

        public PublisherDatabase(IDatabaseOperations databaseOperations)
        {
            _databaseOperations = databaseOperations;
            _command = new SqlCommand();
        }
        public int GetTotalPublishers()
        {
            SqlDataReader DR;
            int counter = 0;
            try
            {
                SqlConnection sqlConnection = _databaseOperations.GetConnection();
                sqlConnection.Open();
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sql = "SELECT * FROM tblBindingDetail";
                    _command.Connection = sqlConnection;
                    _command.CommandText = sql;
                    DR = _command.ExecuteReader();
                    while (DR.Read())
                    {
                        counter++;
                    }
                    DR.Close();
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

            return counter;
        }
        public void LoadPublisherIntoComboBox(ComboBox ComboBox)
        {
            SqlDataReader DR;

            try
            {
                SqlConnection sqlConnection = _databaseOperations.GetConnection();
                sqlConnection.Open();
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sql = "SELECT * FROM tblBindingDetail";
                    _command.Connection = sqlConnection;
                    _command.CommandText = sql;
                    DR = _command.ExecuteReader();
                    while (DR.Read())
                    {
                        ComboBox.Items.Add(DR.GetValue(1).ToString());
                    }
                    DR.Close();
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

        public void LoadPublishersIntoTable(DataGridView dgvPublisher)
        {
            SqlDataAdapter DA = new SqlDataAdapter();
            DataTable DT = new DataTable();
            try
            {
                SqlConnection sqlConnection = _databaseOperations.GetConnection();
                sqlConnection.Open();
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sql = "SELECT * FROM tblBindingDetail";
                    _command.Connection = sqlConnection;
                    _command.CommandText = sql;
                    DA.SelectCommand = _command;
                    DA.Fill(DT);
                    dgvPublisher.DataSource = DT;
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

        public void SavePublisherInfo(DataGridView dgvPublisher, TextBox txtPublisherName, TextBox txtPublisherID)
        {
            SqlDataAdapter DA = new SqlDataAdapter();
            DataTable DT = new DataTable();

            try
            {
                SqlConnection sqlConnection = _databaseOperations.GetConnection();
                sqlConnection.Open();
                if (sqlConnection.State == ConnectionState.Open)
                {
                    if (txtPublisherName.Text.Length == 0)
                    {
                        MessageBox.Show("Įveskite leidėją!");
                    }
                    else
                    {
                        sql = $"INSERT INTO tblBindingDetail(Binding_Name)" +
                              $"VALUES('{txtPublisherName.Text}')";
                        _command.Connection = sqlConnection;
                        _command.CommandText = sql;
                        if (_command.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("Leidėjas sėkmingai pridėtas");
                            txtPublisherID.Clear();
                            txtPublisherName.Clear();
                            sql = "SELECT * FROM tblBindingDetail";
                            _command.CommandText = sql;
                            DA.SelectCommand = _command;
                            DA.Fill(DT);
                            dgvPublisher.DataSource = DT;
                        }
                        else
                        {
                            MessageBox.Show("Leidėjo pridėti nepavyko!");
                        }
                    }
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

        public void EditPublisherInfo(DataGridView dgvPublisher, TextBox txtPublisherName, TextBox txtPublisherID)
        {
            SqlDataAdapter DA = new SqlDataAdapter();
            DataTable DT = new DataTable();

            try
            {
                SqlConnection sqlConnection = _databaseOperations.GetConnection();
                sqlConnection.Open();
                if (sqlConnection.State == ConnectionState.Open)
                {

                    if (txtPublisherName.Text.Length == 0 || txtPublisherID.Text.Length == 0)
                    {
                        MessageBox.Show("Vienas ar daugiau laukų yra privalomi!");
                    }
                    else
                    {
                        sql = $"UPDATE tblBindingDetail SET Binding_Name='{txtPublisherName.Text}' WHERE Binding_ID='{int.Parse(txtPublisherID.Text)}'";
                        _command.Connection = sqlConnection;
                        _command.CommandText = sql;
                        if (_command.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("Leidėjas sėkmingai atnaujintas!");
                            txtPublisherID.Clear();
                            txtPublisherName.Clear();
                            sql = "SELECT * FROM tblBindingDetail";
                            _command.CommandText = sql;
                            DA.SelectCommand = _command;
                            DA.Fill(DT);
                            dgvPublisher.DataSource = DT;
                        }
                        else
                        {
                            MessageBox.Show("Nepavyko atnaujinti leidėjo!");
                        }
                    }
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

        public void DeletePublisherInfo(DataGridView dgvPublisher, TextBox txtPublisherName, TextBox txtPublisherID)
        {
            SqlDataAdapter DA = new SqlDataAdapter();
            DataTable DT = new DataTable();

            try
            {
                SqlConnection sqlConnection = _databaseOperations.GetConnection();
                sqlConnection.Open();
                if (sqlConnection.State == ConnectionState.Open)
                {
                    if (txtPublisherName.Text.Length == 0)
                    {
                        MessageBox.Show("Pasirinkite leidėją!");
                    }
                    else
                    {
                        sql = $"DELETE FROM tblBindingDetail WHERE Binding_ID='{int.Parse(txtPublisherID.Text)}'";
                        _command.Connection = sqlConnection;
                        _command.CommandText = sql;
                        if (_command.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("Leidėjas sėkmingai ištrintas");
                            txtPublisherID.Clear();
                            txtPublisherName.Clear();
                            sql = "SELECT * FROM tblBindingDetail";
                            _command.CommandText = sql;
                            DA.SelectCommand = _command;
                            DA.Fill(DT);
                            dgvPublisher.DataSource = DT;
                        }
                        else
                        {
                            MessageBox.Show("Nepavyko ištrinti leidėjo!");
                        }
                    }
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
