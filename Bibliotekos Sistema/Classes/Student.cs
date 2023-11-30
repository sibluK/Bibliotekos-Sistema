using Bibliotekos_Sistema.Database;
using Bibliotekos_Sistema.Forms;
using Bibliotekos_Sistema.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bibliotekos_Sistema.Classes
{
    public class Student
    {
        private readonly SqlCommand _command;
        private string sql;
        private readonly IDatabaseOperations _databaseOperations;

        public Student(IDatabaseOperations databaseOperations)
        {
            _databaseOperations = databaseOperations;
            _command = new SqlCommand();
        }

        public int totalStudents()
        {
            SqlDataReader DR;
            int counter = 0;
            try
            {
                SqlConnection sqlConnection = _databaseOperations.GetConnection();
                sqlConnection.Open();
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sql = "SELECT * FROM tblStudentDetail";
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

        public void loadStudentsIntoTable(DataGridView dgvStudent)
        {
            SqlDataAdapter DA = new SqlDataAdapter();
            DataTable DT = new DataTable();
            try
            {
                SqlConnection sqlConnection = _databaseOperations.GetConnection();
                sqlConnection.Open();
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sql = "SELECT * FROM tblStudentDetail";
                    _command.Connection = sqlConnection;
                    _command.CommandText = sql;
                    DA.SelectCommand = _command;
                    DA.Fill(DT);
                    dgvStudent.DataSource = DT;
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

        public void saveStudentInfo(DataGridView dgvStudent, TextBox txtFullName, TextBox txtPhone, TextBox txtStudentID, ComboBox cboDepartment, ComboBox cboGender, MaskedTextBox mtbDateOfBirth)
        {
            SqlDataAdapter DA = new SqlDataAdapter();
            DataTable DT = new DataTable();

            try
            {
                SqlConnection sqlConnection = _databaseOperations.GetConnection();
                sqlConnection.Open();
                if (sqlConnection.State == ConnectionState.Open)
                {
                    if (txtFullName.Text.Length == 0 || txtPhone.Text.Length == 0)
                    {
                        MessageBox.Show("Vienas ar daugiau laukų yra tušti!");
                    }
                    else
                    {
                        sql = $"INSERT INTO tblStudentDetail(Stud_ID,Full_Name,Gender,Date_Of_Birth,Department,Phone_Number)" +
                              $"VALUES('{txtStudentID.Text}','{txtFullName.Text}','{cboGender.Text}','{mtbDateOfBirth.Text}','{cboDepartment.Text}','{txtPhone.Text}')";
                        _command.Connection = sqlConnection;
                        _command.CommandText = sql;
                        if (_command.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("Studentas sėkmingai pridėtas");
                            txtStudentID.Clear();
                            txtFullName.Clear();
                            txtPhone.Clear();
                            cboDepartment.ResetText();
                            cboGender.ResetText();
                            mtbDateOfBirth.Clear();
                            sql = "SELECT * FROM tblStudentDetail";
                            _command.CommandText = sql;
                            DA.SelectCommand = _command;
                            DA.Fill(DT);
                            dgvStudent.DataSource = DT;
                        }
                        else
                        {
                            MessageBox.Show("Studento pridėti nepavyko!");
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

        public void deleteStudentInfo(DataGridView dgvStudent, TextBox txtFullName, TextBox txtPhone, TextBox txtStudentID, ComboBox cboDepartment, ComboBox cboGender, MaskedTextBox mtbDateOfBirth)
        {
            SqlDataAdapter DA = new SqlDataAdapter();
            DataTable DT = new DataTable();

            try
            {
                SqlConnection sqlConnection = _databaseOperations.GetConnection();
                sqlConnection.Open();
                if (sqlConnection.State == ConnectionState.Open)
                {
                    if (txtStudentID.Text.Length == 0)
                    {
                        MessageBox.Show("Pasirinkite studentą!");
                    }
                    else
                    {
                        sql = $"DELETE FROM tblStudentDetail WHERE Stud_ID='{txtStudentID.Text}'";
                        _command.Connection = sqlConnection;
                        _command.CommandText = sql;
                        if (_command.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("Studentas sėkmingai ištrintas");
                            txtStudentID.Clear();
                            txtFullName.Clear();
                            txtPhone.Clear();
                            cboDepartment.ResetText();
                            cboGender.ResetText();
                            mtbDateOfBirth.Clear();
                            sql = "SELECT * FROM tblStudentDetail";
                            _command.CommandText = sql;
                            DA.SelectCommand = _command;
                            DA.Fill(DT);
                            dgvStudent.DataSource = DT;
                        }
                        else
                        {
                            MessageBox.Show("Nepavyko ištrinto studento!");
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
    
        public void editStudentInfo(DataGridView dgvStudent, TextBox txtFullName, TextBox txtPhone, TextBox txtStudentID, ComboBox cboDepartment, ComboBox cboGender, MaskedTextBox mtbDateOfBirth)
        {
            SqlDataAdapter DA = new SqlDataAdapter();
            DataTable DT = new DataTable();

            try
            {
                SqlConnection sqlConnection = _databaseOperations.GetConnection();
                sqlConnection.Open();
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sql = $"UPDATE tblStudentDetail SET" +
                          $" Full_Name='{txtFullName.Text}'," +
                          $"Gender='{cboGender.Text}'," +
                          $"Date_Of_Birth='{mtbDateOfBirth.Text}'," +
                          $"Department='{cboDepartment.Text}'," +
                          $"Phone_Number='{txtPhone.Text}'" +
                          $" WHERE Stud_ID='{txtStudentID.Text}'";
                    _command.Connection = sqlConnection;
                    _command.CommandText = sql;
                    if (_command.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Studentas sėkmingai atnaujintas!");
                        txtStudentID.Clear();
                        txtFullName.Clear();
                        txtPhone.Clear();
                        cboDepartment.ResetText();
                        cboGender.ResetText();
                        mtbDateOfBirth.Clear();
                        sql = "SELECT * FROM tblStudentDetail";
                        _command.CommandText = sql;
                        DA.SelectCommand = _command;
                        DA.Fill(DT);
                        dgvStudent.DataSource = DT;
                    }
                    else
                    {
                        MessageBox.Show("Nepavyko atnaujinti studento!");
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
