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
    public partial class ListPatients : Form
    {
        //References to main form, used to show main form when this form is closed
        public Main refToMain { get; set; }

        SqlConnection sqlConnection;

        //Located in connectionString name of app config, used to connect to data base
        string connectionString;

        //Used to check is the back button was pressed, different behavior then when closign the app or terminating process
        public bool pressedBack;

        //Id of patient that is being shown with details;
        public int patientDataId;

        //Used to get the data and display in datagridview
        public DataTable patientDataTable;
        public DataTable diseaseDataTable;
        public DataTable idDataTable;

        private void ListPatients_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && !pressedBack)
            {
                //If the form was closed or terminated, terminates the entire program by closing the main form
                //If the form was clsoed by clicking the return button, only ends current form
                this.refToMain.Close();
            }
        }

        public ListPatients()
        {
            InitializeComponent();
            pressedBack = false;
            groupBox2.Visible = false;

            connectionString = ConfigurationManager.ConnectionStrings["SistemaPacientes.Properties.Settings.DatabaseConnectionString"].ConnectionString;

            using (sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT Id, FirstName, FirstSurname, SecondSurname FROM Patient", sqlConnection))
                {
                    patientDataTable = new DataTable();
                    sqlDataAdapter.Fill(patientDataTable);
                    patientsDataGridView.DataSource = patientDataTable;
                    patientsDataGridView.Columns[1].HeaderText = "Nombre";
                    patientsDataGridView.Columns[2].HeaderText = "Primer Apellido";
                    patientsDataGridView.Columns[3].HeaderText = "Segundo Apellido";
                }

                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT Name FROM Disease", sqlConnection))
                {
                    diseaseDataTable = new DataTable();
                    sqlDataAdapter.Fill(diseaseDataTable);
                    diseaseDataGridView.DataSource = diseaseDataTable;

                }


            }
            listView1.View = View.List;
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


        private void returnBtn_Click(object sender, EventArgs e)
        {
            this.refToMain.Show();
            pressedBack = true;
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = filterTextBox(textBox1.Text);
            searchPatients();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.Text = filterTextBox(textBox2.Text);
            searchPatients();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox3.Text = filterTextBox(textBox3.Text);
            searchPatients();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            textBox4.Text = filterTextBox(textBox4.Text);
            diseaseDataGridView.ClearSelection();
            DataView dv = diseaseDataTable.DefaultView;
            dv.RowFilter = string.Format("Name LIKE '%{0}%'", textBox4.Text);
        }





        private void removeDiseases_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem v in listView1.SelectedItems)
            {
                listView1.Items.Remove(v);
            }
            searchPatients();
        }

        //Get patients that match the name and surnames and that includes all the diseases inserted in the search box
        public void searchPatients()
        {
            patientsDataGridView.ClearSelection();
            DataView dv = patientDataTable.DefaultView;


            string diseaseNames = "";
            int diseaseQuantity = 0;
            foreach (ListViewItem item in listView1.Items)
            {
                diseaseNames += "'";
                diseaseNames += item.Text;
                diseaseNames += "'";
                diseaseNames += ", ";
                diseaseQuantity++;
            }
            if (diseaseNames != "")
            {
                diseaseNames = diseaseNames.Remove(diseaseNames.Length - 2, 2);
                using (sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(@"SELECT Id FROM (SELECT Patient.Id, COUNT(*) AS Quantity FROM Patient
                                                                                                INNER JOIN PatientDisease ON Patient.Id = PatientDisease.PatientId  
                                                                                                INNER JOIN Disease ON PatientDisease.DiseaseId = Disease.Id 
                                                                                                WHERE Name IN (" + diseaseNames + @") 
                                                                                                GROUP BY Patient.Id) AS T 
                                                                                WHERE Quantity = " + diseaseQuantity, sqlConnection))
                    {
                        idDataTable = new DataTable();
                        sqlDataAdapter.Fill(idDataTable);
                        string patientIds = "";
                        foreach (DataRow row in idDataTable.Rows)
                        {
                            patientIds += "'";
                            patientIds += row["Id"];
                            patientIds += "'";
                            patientIds += ", ";

                        }
                        if (patientIds != "")
                        {
                            patientIds = patientIds.Remove(patientIds.Length - 2, 2);
                            dv.RowFilter = string.Format("FirstName LIKE '%{0}%' AND FirstSurname LIKE '%{1}%' AND SecondSurname LIKE '%{2}%' AND Id IN (" + patientIds + ")", textBox1.Text, textBox2.Text, textBox3.Text);
                        }
                        else
                        {
                            dv.RowFilter = string.Format("Id = -1");
                        }

                    }
                }
            }

            else
            {
                dv.RowFilter = string.Format("FirstName LIKE '%{0}%' AND FirstSurname LIKE '%{1}%' AND SecondSurname LIKE '%{2}%'", textBox1.Text, textBox2.Text, textBox3.Text);
            }

            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

        }

        private void patientFilesButton_Click(object sender, EventArgs e)
        {
            MedicFiles medicFilesForm = new MedicFiles(patientDataId);
            medicFilesForm.refToListPatients = this;
            medicFilesForm.Show();
            this.Hide();
        }

        private void diseaseDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (listView1.Items.Count == 0 || listView1.FindItemWithText(diseaseDataGridView.CurrentCell.Value.ToString(), true, 0, false) == null)
            {
                listView1.Items.Add(diseaseDataGridView.CurrentCell.Value.ToString());
                searchPatients();
            }
            diseaseDataGridView.ClearSelection();
        }

        private void diseaseDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            int totalHeight;
            int totalWidth;
            if (diseaseDataGridView.RowCount < 6)
            {
                totalHeight = diseaseDataGridView.Rows.GetRowsHeight(DataGridViewElementStates.None) + 3;
                totalWidth = diseaseDataGridView.Columns.GetColumnsWidth(DataGridViewElementStates.None) + 3;
            }
            else
            {
                totalHeight = (diseaseDataGridView.Rows[0].Height * 6) + 3;
                totalWidth = diseaseDataGridView.Columns.GetColumnsWidth(DataGridViewElementStates.None) + 20;
            }


            diseaseDataGridView.ClientSize = new Size(totalWidth, totalHeight);
            diseaseDataGridView.ClearSelection();
        }

        private void patientsDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            groupBox2.Visible = true;
            using (sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT Photo, FirstName, FirstSurname, SecondSurname, BirthDate FROM Patient WHERE Id = " + patientsDataGridView.CurrentRow.Cells["Id"].Value, sqlConnection))
                {
                    DataTable patientData = new DataTable();
                    sqlDataAdapter.Fill(patientData);

                    object patientImage = patientData.Rows[0]["Photo"];
                    if (patientImage == DBNull.Value)
                    {
                        pictureBox1.Image = Properties.Resources.NoImage;
                    }
                    else
                    {
                        MemoryStream ms = new MemoryStream((byte[])patientImage);
                        pictureBox1.Image = Image.FromStream(ms);
                    }

                    nameLabel.Text = patientData.Rows[0]["FirstName"].ToString();

                    surnameLabel.Text = patientData.Rows[0]["FirstSurname"].ToString() +
                        " " + patientData.Rows[0]["SecondSurname"].ToString();

                    DateTime currentDate = DateTime.Today;
                    DateTime birthDate = (DateTime)patientData.Rows[0]["BirthDate"];
                    int age = currentDate.Year - birthDate.Year;
                    if (currentDate < birthDate.AddYears(age)) age--;

                    ageLabel.Text = age.ToString();

                    patientDataId = (int)patientsDataGridView.CurrentRow.Cells["Id"].Value;
                }
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(@"SELECT Name FROM Disease 
                                                                            INNER JOIN PatientDisease ON Disease.Id = PatientDisease.DiseaseId
                                                                            INNER JOIN Patient ON PatientDisease.PatientId = Patient.Id
                                                                            WHERE Patient.Id = " + patientDataId, sqlConnection))
                {
                    DataTable patientDiseaseData = new DataTable();
                    sqlDataAdapter.Fill(patientDiseaseData);
                    patientDiseaseDataGridView.DataSource = patientDiseaseData;
                }
            }
            
            
            
        }

        private void patientsDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            int totalHeight;
            int totalWidth;
            if (patientsDataGridView.RowCount < 6)
            {
                totalHeight = patientsDataGridView.Rows.GetRowsHeight(DataGridViewElementStates.None) + patientsDataGridView.ColumnHeadersHeight + 3;
                totalWidth = patientsDataGridView.Columns.GetColumnsWidth(DataGridViewElementStates.None) + 3;
            }
            else
            {
                totalHeight = (patientsDataGridView.Rows[0].Height * 6) + patientsDataGridView.ColumnHeadersHeight + 3;
                totalWidth = patientsDataGridView.Columns.GetColumnsWidth(DataGridViewElementStates.None) + 20;
            }


            patientsDataGridView.ClientSize = new Size(totalWidth, totalHeight);
            patientsDataGridView.ClearSelection();
        }

        private void patientDiseaseDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            int totalHeight;
            int totalWidth;
            if (patientDiseaseDataGridView.RowCount < 6)
            {
                totalHeight = patientDiseaseDataGridView.Rows.GetRowsHeight(DataGridViewElementStates.None) + 3;
                totalWidth = patientDiseaseDataGridView.Columns.GetColumnsWidth(DataGridViewElementStates.None) + 3;
            }
            else
            {
                totalHeight = (patientDiseaseDataGridView.Rows[0].Height * 6) + 3;
                totalWidth = patientDiseaseDataGridView.Columns.GetColumnsWidth(DataGridViewElementStates.None) + 20;
            }


            patientDiseaseDataGridView.ClientSize = new Size(totalWidth, totalHeight);
            patientDiseaseDataGridView.ClearSelection();
        }

        private void viewProfileBtn_Click(object sender, EventArgs e)
        {
            ViewProfile viewProfileForm = new ViewProfile(patientDataId);
            viewProfileForm.refToListPatients = this;
            viewProfileForm.Show();
            groupBox2.Visible = false;
            patientsDataGridView.ClearSelection();
            this.Hide();
        }
    }
}
