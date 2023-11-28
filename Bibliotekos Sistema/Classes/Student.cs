using Bibliotekos_Sistema.Database;
using Bibliotekos_Sistema.Forms;
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
    internal class Student
    {
        SqlCommand _command = new SqlCommand();
        private string sql;
        DBConnection _connection = new DBConnection();

        public void loadStudentPage()
        {
            formStudent student = new formStudent();
            student.Show();
        }

        public int totalStudents()
        {
            SqlDataReader DR;
            int counter = 0;
            try
            {
                _connection.connection().Open();
                if (_connection.connection().State == ConnectionState.Open)
                {
                    sql = "SELECT * FROM tblStudentDetail";
                    _command.Connection = _connection.connection();
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
                _connection.connection().Close();
            }

            return counter;
        }

        public void loadStudentsIntoTable(DataGridView dgvStudent)
        {
            SqlDataAdapter DA = new SqlDataAdapter();
            DataTable DT = new DataTable();
            try
            {
                _connection.connection().Open();
                if (_connection.connection().State == ConnectionState.Open)
                {
                    sql = "SELECT * FROM tblStudentDetail";
                    _command.Connection = _connection.connection();
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
                _connection.connection().Close();
            }
        }

        public void saveStudentInfo(DataGridView dgvStudent, TextBox txtFullName, TextBox txtPhone, TextBox txtStudentID, ComboBox cboDepartment, ComboBox cboGender, MaskedTextBox mtbDateOfBirth)
        {
            SqlDataAdapter DA = new SqlDataAdapter();
            DataTable DT = new DataTable();

            try
            {
                _connection.connection().Open();
                if (_connection.connection().State == ConnectionState.Open)
                {
                    if (txtFullName.Text.Length == 0 || txtPhone.Text.Length == 0)
                    {
                        MessageBox.Show("Vienas ar daugiau laukų yra tušti!");
                    }
                    else
                    {
                        sql = $"INSERT INTO tblStudentDetail(Stud_ID,Full_Name,Gender,Date_Of_Birth,Department,Phone_Number)" +
                              $"VALUES('{txtStudentID.Text}','{txtFullName.Text}','{cboGender.Text}','{mtbDateOfBirth.Text}','{cboDepartment.Text}','{txtPhone.Text}')";
                        _command.Connection = _connection.connection();
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
                _connection.connection().Close();
            }
        }

        public void deleteStudentInfo(DataGridView dgvStudent, TextBox txtFullName, TextBox txtPhone, TextBox txtStudentID, ComboBox cboDepartment, ComboBox cboGender, MaskedTextBox mtbDateOfBirth)
        {
            SqlDataAdapter DA = new SqlDataAdapter();
            DataTable DT = new DataTable();

            try
            {
                _connection.connection().Open();
                if (_connection.connection().State == ConnectionState.Open)
                {
                    if (txtStudentID.Text.Length == 0)
                    {
                        MessageBox.Show("Pasirinkite studentą!");
                    }
                    else
                    {
                        sql = $"DELETE FROM tblStudentDetail WHERE Stud_ID='{txtStudentID.Text}'";
                        _command.Connection = _connection.connection();
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
                _connection.connection().Close();
            }
        }
    
        public void editStudentInfo(DataGridView dgvStudent, TextBox txtFullName, TextBox txtPhone, TextBox txtStudentID, ComboBox cboDepartment, ComboBox cboGender, MaskedTextBox mtbDateOfBirth)
        {
            SqlDataAdapter DA = new SqlDataAdapter();
            DataTable DT = new DataTable();

            try
            {
                _connection.connection().Open();
                if (_connection.connection().State == ConnectionState.Open)
                {
                    sql = $"UPDATE tblStudentDetail SET" +
                          $" Full_Name='{txtFullName.Text}'," +
                          $"Gender='{cboGender.Text}'," +
                          $"Date_Of_Birth='{mtbDateOfBirth.Text}'," +
                          $"Department='{cboDepartment.Text}'," +
                          $"Phone_Number='{txtPhone.Text}'" +
                          $" WHERE Stud_ID='{txtStudentID.Text}'";
                    _command.Connection = _connection.connection();
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
                _connection.connection().Close();
            }
        }
    }
}
