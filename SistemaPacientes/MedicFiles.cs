﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;

namespace SistemaPacientes
{
    public partial class MedicFiles : Form
    {
        //Reference to ListPatients
        public ListPatients refToListPatients { get; set; }

        public ClinicRecordSummary refToClinicRecordSummary { get; set; }

        SqlConnection sqlConnection;

        //Located in connectionString name of app config, used to connect to data base
        string connectionString;

        //Used to check if the back button was pressed, different behavior then when closing the app or terminating process
        public bool pressedBack;

        //The patientId received from form ListPatients
        public int patientId;
        public int fileToDownloadId;

        //Used to store file as bytes
        public byte[] filebytes;
        public string fileExtension;

        //Indicate if it is surgery or regular appointment
        public int clinicRecordType;

        //Files data table
        public DataTable filesDataTable;
        public DataTable clinicRecordsDataTable;

        private void MedicFiles_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && !pressedBack)
            {
                //If the form was closed or terminated, terminates the entire program by closing the main form
                //If the form was clsoed by clicking the return button, only ends current form
                if (this.refToListPatients != null)
                {
                    this.refToListPatients.Close();
                }
                else
                {
                    this.refToClinicRecordSummary.Close();
                }
                
            }
        }


        public MedicFiles(int patientId)
        {
            InitializeComponent();
            noSurgeryRb.Checked = true;
            clinicRecordType = 0;
            pressedBack = false;
            filebytes = null;
            connectionString = ConfigurationManager.ConnectionStrings["SistemaPacientes.Properties.Settings.DatabaseConnectionString"].ConnectionString;
            this.patientId = patientId;
            groupBox2.Visible = false;
            deleteClinicalRecordBtn.Visible = false;
            clinicRecordDateDay.Text = DateTime.Today.Day.ToString();
            clinicRecordDateMonth.Text = DateTime.Today.Month.ToString();
            clinicRecordDateYear.Text = DateTime.Today.Year.ToString();
            showPatientFiles();
            showClinicRecords();
        }

        string filterTextBox(string textToFilter)
        {
            textToFilter = textToFilter.Replace("'", "");
            textToFilter = textToFilter.Replace("[", "");
            textToFilter = textToFilter.Replace("]", "");
            textToFilter = textToFilter.Replace("*", "");
            textToFilter = textToFilter.Replace("%", "");
            return textToFilter;
        }

        void showPatientFiles()
        {
            using (sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT Id, Name, UploadDate, Description FROM MedicFile WHERE PatientId = " + patientId, sqlConnection))
                {
                    filesDataTable = new DataTable();
                    sqlDataAdapter.Fill(filesDataTable);
                    filesDataGridView.DataSource = filesDataTable;
                    filesDataGridView.Columns[0].Visible = false;
                    filesDataGridView.Columns[1].HeaderText = "Nombre";
                    filesDataGridView.Columns[2].HeaderText = "Fecha";
                    filesDataGridView.Columns[3].Visible = false;


                }
            }
        }

        void showClinicRecords()
        {
            using (sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT Date, Description, RecordType, Id FROM ClinicRecord WHERE PatientId = " + patientId, sqlConnection))
                {
                    clinicRecordsDataTable = new DataTable();
                    sqlDataAdapter.Fill(clinicRecordsDataTable);
                    clinicRecordsDataTable.Columns.Add("Type", typeof(System.String)).SetOrdinal(0);
                    foreach (DataRow row in clinicRecordsDataTable.Rows)
                    {
                        if (row["RecordType"] == DBNull.Value)
                        {
                            row["Type"] = "Cita";
                        }
                        else
                        {
                            row["Type"] = "Cirugía";
                        }
                    }

                    clinicRecordsDataGridView.DataSource = clinicRecordsDataTable;
                    clinicRecordsDataGridView.Columns[0].HeaderText = "Tipo";
                    clinicRecordsDataGridView.Columns[1].HeaderText = "Fecha";
                    clinicRecordsDataGridView.Columns[2].HeaderText = "Descripción";
                    clinicRecordsDataGridView.Columns[3].Visible = false;
                    clinicRecordsDataGridView.Columns[4].Visible = false;
                }
            }
            clinicRecordsDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            clinicRecordsDataGridView.Columns[2].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        }

        private void filesDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            int totalHeight;
            int totalWidth = filesDataGridView.Columns[1].Width + filesDataGridView.Columns[2].Width;
            if (filesDataGridView.RowCount < 6)
            {
                totalHeight = filesDataGridView.Rows.GetRowsHeight(DataGridViewElementStates.None) + filesDataGridView.ColumnHeadersHeight + 3;
                totalWidth += 3;

            }
            else
            {
                totalHeight = (filesDataGridView.Rows[0].Height * 6) + filesDataGridView.ColumnHeadersHeight + 3;
                totalWidth += 20;
            }


            filesDataGridView.ClientSize = new Size(totalWidth, totalHeight);
            filesDataGridView.ClearSelection();
        }

        private void clinicRecordsDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            int totalHeight;
            int totalWidth = clinicRecordsDataGridView.Columns[0].Width + clinicRecordsDataGridView.Columns[1].Width + clinicRecordsDataGridView.Columns[2].Width;
            clinicRecordsDataGridView.Columns[2].Width = 600;
            clinicRecordsDataGridView.Columns[1].Width = 120;

            if (clinicRecordsDataGridView.Rows.GetRowsHeight(DataGridViewElementStates.None) + filesDataGridView.ColumnHeadersHeight + 3 < 350)
            {
                totalHeight = clinicRecordsDataGridView.Rows.GetRowsHeight(DataGridViewElementStates.None) + filesDataGridView.ColumnHeadersHeight + 12;
                totalWidth += 3;

            }
            else
            {
                totalHeight = 350;
                totalWidth += 20;
            }


            clinicRecordsDataGridView.ClientSize = new Size(totalWidth, totalHeight);
            clinicRecordsDataGridView.ClearSelection();
        }

        private void filesDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            fileDescriptionLabel.Text = filesDataTable.Select("Id = " + filesDataGridView.CurrentRow.Cells["Id"].Value)[0]["Description"].ToString();

            fileToDownloadId = (int)filesDataGridView.CurrentRow.Cells["Id"].Value;
            groupBox2.Visible = true;
        }

        private void fileSearchTextBox_TextChanged(object sender, EventArgs e)
        {
            fileSearchTextBox.Text = filterTextBox(fileSearchTextBox.Text);
            searchFiles();
        }

        public void searchFiles()
        {
            filesDataGridView.ClearSelection();
            DataView dv = filesDataTable.DefaultView;
            dv.RowFilter = string.Format("Name LIKE '%{0}%'", fileSearchTextBox.Text);
        }

        private void returnBtn_Click(object sender, EventArgs e)
        {
            if (this.refToListPatients != null)
            {
                this.refToListPatients.Show();
            }
            else
            {
                this.refToClinicRecordSummary.Show();
            }
            pressedBack = true;
            this.Close();
        }

        private void uploadBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                filebytes = File.ReadAllBytes(openFile.FileName);
                fileLabel.Text = "Archivo: " + openFile.SafeFileName;
                fileExtension = Path.GetExtension(openFile.SafeFileName);
            }
        }

        private void submitFileBtn_Click(object sender, EventArgs e)
        {
            if (filebytes == null || fileName.Text == "")
            {
                if (filebytes == null)
                {
                    MessageBox.Show("Se debe elegir un archivo", "Error");
                }
                else
                {
                    MessageBox.Show("El archivo debe tener un nombre", "Error");
                }
            }
            else
            { 
                string cmdString = "INSERT INTO MedicFile (Name, Description, FileAttached, UploadDate, PatientId, FileExtension)" +
                    " VALUES (@val1, @val2, @val3,  @val4,  @val5, @val6)";
                using (sqlConnection = new SqlConnection(connectionString))
                {
                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = sqlConnection;
                        comm.CommandText = cmdString;
                        comm.Parameters.AddWithValue("@val1", fileName.Text);
                        comm.Parameters.AddWithValue("@val2", fileDescription.Text);
                        comm.Parameters.Add("@val3", SqlDbType.VarBinary, filebytes.Length).Value = filebytes;
                        comm.Parameters.AddWithValue("@val4", DateTime.Today);
                        comm.Parameters.AddWithValue("@val5", patientId);
                        comm.Parameters.AddWithValue("@val6", fileExtension);
                        sqlConnection.Open();
                        comm.ExecuteNonQuery();
                        MessageBox.Show("Se agregó un nuevo archivo");

                    }
                }
                showPatientFiles();
                fileName.Text = "";
                fileDescription.Text = "";
                fileLabel.Text = "";
                filebytes = null;
            }

        }


        private void downloadFileButton_Click(object sender, EventArgs e)
        {
            using (sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT FileAttached, FileExtension FROM MedicFile WHERE Id = " + fileToDownloadId, sqlConnection))
                {
                    DataTable fileToDownload = new DataTable();
                    sqlDataAdapter.Fill(fileToDownload);
                    byte[] objData = (byte[])fileToDownload.Rows[0]["FileAttached"];

                    SaveFileDialog saveFile = new SaveFileDialog();
                    if (saveFile.ShowDialog() == DialogResult.OK)
                    {
                        string fileName = saveFile.FileName + fileToDownload.Rows[0]["FileExtension"].ToString();
                        FileStream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
                        stream.Write(objData, 0, objData.Length);
                        stream.Close();
                    }


                }
            }

        }

        private void deleteFileBtn_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("¿Desea borrar el archivo?", "Borrar Archivo", MessageBoxButtons.OKCancel);
            if (confirmResult == DialogResult.OK)
            {
                using (sqlConnection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("DELETE FROM MedicFile WHERE Id = " + fileToDownloadId, sqlConnection))
                    {
                        command.Connection = sqlConnection;
                        sqlConnection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("El archivo ha sido borrado");
                        groupBox2.Visible = false;
                    }
                }
            }
            showPatientFiles();
        }

        private void addClinicalRecordBtn_Click(object sender, EventArgs e)
        {
            DateTime clinicRecordDate;
            if (clinicRecordTextBox.Text == "")
            {
                MessageBox.Show("No se puede guardar el resumen de una cita sin una descripción");
            }
            else
            {
                try
                {
                    clinicRecordDate = new DateTime(int.Parse(clinicRecordDateYear.Text), int.Parse(clinicRecordDateMonth.Text), int.Parse(clinicRecordDateDay.Text));
                }
                catch
                {
                    MessageBox.Show("La fecha es inválida.");
                    return;
                } 
                using (sqlConnection = new SqlConnection(connectionString))
                {
                    string queryString = "INSERT INTO ClinicRecord (PatientId, Date, Description) VALUES (@val1, @val2, @val3)";
                    if (clinicRecordType == 1)
                    {
                        queryString = "INSERT INTO ClinicRecord (PatientId, Date, Description, RecordType) VALUES (@val1, @val2, @val3, 1)";
                    }
                    using (SqlCommand command = new SqlCommand(queryString, sqlConnection))
                    {
                        command.Connection = sqlConnection;
                        sqlConnection.Open();
                        command.Parameters.AddWithValue("@val1", patientId);
                        command.Parameters.AddWithValue("@val2", clinicRecordDate);
                        command.Parameters.AddWithValue("@val3", clinicRecordTextBox.Text);
                        command.ExecuteNonQuery();
                    }
                }
                showClinicRecords();
                deleteClinicalRecordBtn.Visible = false;
                clinicRecordTextBox.Text = "";
            }
        }

        private void clinicRecordsDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            deleteClinicalRecordBtn.Visible = true;
        }

        private void deleteClinicalRecordBtn_Click(object sender, EventArgs e)
        {

            var confirmResult = MessageBox.Show("¿Desea borrar La cita?", "Borrar Cita", MessageBoxButtons.OKCancel);
            if (confirmResult == DialogResult.OK)
            {
                using (sqlConnection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("DELETE FROM ClinicRecord WHERE Id = " + clinicRecordsDataGridView.CurrentRow.Cells["Id"].Value, sqlConnection))
                    {
                        command.Connection = sqlConnection;
                        sqlConnection.Open();
                        command.ExecuteNonQuery();
                    }
                }
                clinicRecordsDataGridView.ClearSelection();
                deleteClinicalRecordBtn.Visible = false;
                showClinicRecords();
            }
        }


        private void yesSurgeryRb_Click(object sender, EventArgs e)
        {
            clinicRecordType = 1;
            clinicRecordLabel.Text = "Agregar nueva cirugía";
            addClinicRecordBtn.Text = "Agregar Cirugía";
        }

        private void noSurgeryRb_Click(object sender, EventArgs e)
        {
            clinicRecordType = 0;
            clinicRecordLabel.Text = "Agregar nueva cita";
            addClinicRecordBtn.Text = "Agregar Cita";
        }
    }
}



