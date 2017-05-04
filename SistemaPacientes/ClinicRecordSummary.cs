using System;
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
    public partial class ClinicRecordSummary : Form
    {
        public Main refToMain { get; set; }

        SqlConnection sqlConnection;

        //Located in connectionString name of app config, used to connect to data base
        string connectionString;

        //Used to check if the back button was pressed, different behavior then when closing the app or terminating process
        public bool pressedBack;

        public DataTable patientDataTable;
        public DataTable countsDataTable;
        public DataTable datesDataTable;

        private void ClinicRecordSummary_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && !pressedBack)
            {
                //If the form was closed or terminated, terminates the entire program by closing the main form
                //If the form was clsoed by clicking the return button, only ends current form
                this.refToMain.Close();
            }
        }
        public ClinicRecordSummary()
        {
            InitializeComponent();
            pressedBack = false;
            connectionString = ConfigurationManager.ConnectionStrings["SistemaPacientes.Properties.Settings.DatabaseConnectionString"].ConnectionString;
            secondDay.Text = DateTime.Now.Day.ToString();
            secondMonth.Text = DateTime.Now.Month.ToString();
            secondYear.Text = DateTime.Now.Year.ToString();
        }

        private void returnBtn_Click(object sender, EventArgs e)
        {
            this.refToMain.Show();
            pressedBack = true;
            this.Close();
        }

        private void calculateSummaryBtn_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            DateTime firstDate;
            DateTime secondDate;
            int firstTimeDates = 0;
            int recurrentDates = 0;
            int surgeries = 0;
            patientDataTable = new DataTable();
            datesDataTable = new DataTable();
            countsDataTable = new DataTable();
            try
            {
                firstDate = new DateTime(int.Parse(firstYear.Text), int.Parse(firstMonth.Text), int.Parse(firstDay.Text));
            }
            catch
            {
                MessageBox.Show("La fecha inicial no es válida");
                return;
            }
            try
            {
                secondDate = new DateTime(int.Parse(secondYear.Text), int.Parse(secondMonth.Text), int.Parse(secondDay.Text));
            }
            catch
            {
                MessageBox.Show("La fecha final no es válida");
                return;
            }

            if (firstDate > secondDate)
            {
                MessageBox.Show("La fecha inicial debe ser igual o menor a la fecha final");
                return;
            }

            if (int.Parse(firstYear.Text) < 1800 || int.Parse(secondYear.Text) < 1800)
            {
                MessageBox.Show("Los años ingresados deben ser mayor a 1800");
                return;
            }

            using (sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                //Get all patients that had a clinicRecord (an appointment or a surgery) in between the user input dates
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(@"SELECT DISTINCT Patient.Id, FirstName, FirstSurname, SecondSurname FROM Patient 
                                                                                INNER JOIN ClinicRecord ON Patient.Id = ClinicRecord.PatientId
                                                                                WHERE ClinicRecord.Date >= @first AND ClinicRecord.Date <= @second", sqlConnection))
                {
                    sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@first", firstDate);
                    sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@second", secondDate);
                    sqlDataAdapter.Fill(patientDataTable);
                    patientsDataGridView.DataSource = patientDataTable;
                }
                if (patientDataTable.Rows.Count == 0)
                {
                    MessageBox.Show("No hay actividad en el rango de fechas ingresadas");
                    return;
                }
                patientsDataGridView.Visible = true;
                //String concatenation of each patient id
                string patientIds = "";
                foreach (DataRow row in patientDataTable.Rows)
                {
                    patientIds += row["Id"].ToString();
                    patientIds += ", ";
                }
                patientIds = patientIds.Remove(patientIds.Length - 2, 2);

                //Get the earliest clinicRecord date that is type appointment for each of those patients
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(@"SELECT PatientId, MIN(Date) AS MinDate FROM ClinicRecord 
                                                                        WHERE PatientId IN (" + patientIds + ") AND RecordType IS NULL GROUP BY PatientId", sqlConnection))
                {
                    sqlDataAdapter.Fill(datesDataTable);
                }

                //Compare each earliest date to user input of firstDate, calculate amount of firstTime appointments
                foreach (DataRow row in datesDataTable.Rows)
                {
                    if (Convert.ToDateTime(row["MinDate"]) >= firstDate)
                    {
                        firstTimeDates += 1;
                    }
                }
                //Get count of surgeries and of appointments
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(@"SELECT RecordType, Count(Id) AS RecordCount FROM ClinicRecord
                                                                                 WHERE ClinicRecord.Date >= @first AND ClinicRecord.Date <= @second 
                                                                                 GROUP BY RecordType", sqlConnection))
                {
                    sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@first", firstDate);
                    sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@second", secondDate);

                    sqlDataAdapter.Fill(countsDataTable);
                }
            }
            //subtract the amount of firstTime appointments from appointments
            foreach (DataRow row in countsDataTable.Rows)
            {
                if (row["RecordType"] == DBNull.Value)
                {
                    recurrentDates = (int)row["RecordCount"] - firstTimeDates;
                }
                else
                {
                    surgeries = (int)row["RecordCount"];
                }
            }
            groupBox1.Visible = true;
            firstTimeLabel.Text = "Citas de primera vez: " + firstTimeDates;
            recurrentLabel.Text = "Citas recurrentes: " + recurrentDates;
            surgeriesLabel.Text = "Cirugías: " + surgeries;
        }



        private void patientsDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            patientsDataGridView.Columns[0].Visible = false;
            patientsDataGridView.Columns[1].HeaderText = "Nombre";
            patientsDataGridView.Columns[2].HeaderText = "Primer Apellido";
            patientsDataGridView.Columns[3].HeaderText = "Segundo Apellido";

            int totalHeight;
            int totalWidth = patientsDataGridView.Columns[1].Width + patientsDataGridView.Columns[2].Width + patientsDataGridView.Columns[3].Width;

            if (patientsDataGridView.RowCount < 6)
            {
                totalHeight = patientsDataGridView.Rows.GetRowsHeight(DataGridViewElementStates.None) + patientsDataGridView.ColumnHeadersHeight + 3;
                totalWidth += 3;

            }
            else
            {
                totalHeight = (patientsDataGridView.Rows[0].Height * 6) + patientsDataGridView.ColumnHeadersHeight + 3;
                totalWidth += 20;
            }
            patientsDataGridView.ClientSize = new Size(totalWidth, totalHeight);
            patientsDataGridView.ClearSelection();
        }

        private void patientsDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Debug.WriteLine(patientsDataGridView.CurrentRow.Cells["Id"].Value);
            MedicFiles medicFilesForm = new MedicFiles((int) patientsDataGridView.CurrentRow.Cells["Id"].Value);
            medicFilesForm.refToClinicRecordSummary = this;
            medicFilesForm.Show();
            this.Hide();
        }
    }
}
