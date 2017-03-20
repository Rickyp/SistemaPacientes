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
    public partial class ViewProfile : Form
    {
        //References to main form, used to show main form when this form is closed
        public ListPatients refToListPatients { get; set; }

        SqlConnection sqlConnection;

        //Located in connectionString name of app config, used to connect to data base
        string connectionString;

        public int patientId;
        public int genderInt;
        public int diseaseToRemoveId;
        public int diseaseToAddId;

        DataTable allDiseasesDataTable;

        DataTable patientDiseasesDataTable;

        //Used to check if the back button was pressed, different behavior then when closing the app or terminating process
        public bool pressedBack;

        //Used to store photo image as bytes
        public byte[] filebytes;

        //Current image being used
        public byte[] currentPhoto;

        private void ViewProfile_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && !pressedBack)
            {
                //If the form was closed or terminated, terminates the entire program by closing the main form
                //If the form was clsoed by clicking the return button, only ends current form
                this.refToListPatients.Close();
            }
        }

        void searchAllDiseases()
        {
            using (sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                //Give all diseases not present in this patient
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(@"SELECT Name FROM Disease 
                                                                            EXCEPT
                                                                                SELECT Name FROM Disease 
                                                                                INNER JOIN PatientDisease ON Disease.Id = PatientDisease.DiseaseId 
                                                                                WHERE PatientId = " + patientId, sqlConnection))

                {
                    allDiseasesDataTable = new DataTable();
                    sqlDataAdapter.Fill(allDiseasesDataTable);
                    dataGridView1.DataSource = allDiseasesDataTable;

                }
            }
        }

        void searchPatientDiseases()
        {
            using (sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(@"SELECT Name FROM Disease 
                                                                            INNER JOIN PatientDisease ON Disease.Id = PatientDisease.DiseaseId
                                                                            WHERE PatientId = " + patientId, sqlConnection))
                {
                    patientDiseasesDataTable = new DataTable();
                    sqlDataAdapter.Fill(patientDiseasesDataTable);
                    patientDiseasesDataGridView.DataSource = patientDiseasesDataTable;
                }
            }

        }

        void searchPatientData()
        {
            using (sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(@"SELECT FirstName, FirstSurname, SecondSurname, Gender, Photo, 
                DateRegistered, Street, Neighborhood, City, Telephone, BirthDate, BirthPlace, RecommendedBy, InsuranceNumber, InsuranceCompany
                                                                            FROM Patient WHERE Id = " + patientId, sqlConnection))
                {
                    DataTable patientDataTable = new DataTable();
                    sqlDataAdapter.Fill(patientDataTable);
                    DateTime birthDate = (DateTime)patientDataTable.Rows[0]["BirthDate"];
                    DateTime dateRegistered = (DateTime)patientDataTable.Rows[0]["DateRegistered"];

                    FirstNameTb.Text = patientDataTable.Rows[0]["FirstName"].ToString();
                    FirstSurnameTb.Text = patientDataTable.Rows[0]["FirstSurname"].ToString();
                    SecondSurnameTb.Text = patientDataTable.Rows[0]["SecondSurname"].ToString();
                    DateRegisteredDay.Text = dateRegistered.Day.ToString();
                    DateRegisteredMonth.Text = dateRegistered.Month.ToString();
                    DateRegisteredYear.Text = dateRegistered.Year.ToString();
                    StreetTb.Text = patientDataTable.Rows[0]["Street"].ToString();
                    NeighborhoodTb.Text = patientDataTable.Rows[0]["Neighborhood"].ToString();
                    CityTb.Text = patientDataTable.Rows[0]["City"].ToString();
                    TelephoneTb.Text = patientDataTable.Rows[0]["Telephone"].ToString();
                    BirthDateDay.Text = birthDate.Day.ToString();
                    BirthDateMonth.Text = birthDate.Month.ToString();
                    BirthDateYear.Text = birthDate.Year.ToString();
                    BirthPlaceTb.Text = patientDataTable.Rows[0]["BirthPlace"].ToString();
                    RecommendedByTb.Text = patientDataTable.Rows[0]["RecommendedBy"].ToString();
                    InsuranceNumberTb.Text = patientDataTable.Rows[0]["InsuranceNumber"].ToString();
                    InsuranceCompanyTb.Text = patientDataTable.Rows[0]["InsuranceCompany"].ToString();

                    if ((int) patientDataTable.Rows[0]["Gender"] == 1)
                    {
                        maleRadio.Checked = true;
                        genderInt = 1;
                    }
                    else
                    {
                        femaleRadio.Checked = true;
                        genderInt = 2;
                    }

                    object patientImage = patientDataTable.Rows[0]["Photo"];
                    if (patientImage == DBNull.Value)
                    {
                        pictureBox1.Image = Properties.Resources.NoImage;
                        currentPhoto = null;
                        filebytes = null;
                    }
                    else
                    {
                        MemoryStream ms = new MemoryStream((byte[])patientImage);
                        pictureBox1.Image = Image.FromStream(ms);
                        currentPhoto = (byte[]) patientImage;
                        filebytes = (byte[])patientImage;
                    }

                }
            }
        }

        public ViewProfile(int patientId)
        {
            InitializeComponent();
            pressedBack = false;
            filebytes = null;
            this.patientId = patientId;
            addNewDisease.Visible = false;

            connectionString = ConfigurationManager.ConnectionStrings["SistemaPacientes.Properties.Settings.DatabaseConnectionString"].ConnectionString;
            searchPatientDiseases();
            searchAllDiseases();
            searchPatientData();


        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            int totalHeight;
            int totalWidth;
            if (dataGridView1.RowCount < 6)
            {
                totalHeight = dataGridView1.Rows.GetRowsHeight(DataGridViewElementStates.None) + 3;
                totalWidth = dataGridView1.Columns.GetColumnsWidth(DataGridViewElementStates.None) + 3;
            }
            else
            {
                totalHeight = (dataGridView1.Rows[0].Height * 6) + 3;
                totalWidth = dataGridView1.Columns.GetColumnsWidth(DataGridViewElementStates.None) + 20;
            }


            dataGridView1.ClientSize = new Size(totalWidth, totalHeight);
            dataGridView1.ClearSelection();
            if (dataGridView1.RowCount == 0)
            {
                addNewDisease.Visible = true;
            }
            else
            {
                addNewDisease.Visible = false;
            }

        }

        //Could not use keydown and regex because text can also be copy pasted instead of typed
        private void textBox13_TextChanged(object sender, EventArgs e)
        {

            textBox13.Text = filterTextBox(textBox13.Text);
            dataGridView1.ClearSelection();
            DataView dv = allDiseasesDataTable.DefaultView;
            dv.RowFilter = string.Format("Name LIKE '%{0}%'", textBox13.Text);
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.refToListPatients.Show();
            pressedBack = true;
            this.Close();
        }

        private void searchPhoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Archivos de imágenes|*.jpeg; *.png; *.jpg";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                filebytes = File.ReadAllBytes(openFile.FileName);
                MemoryStream ms = new MemoryStream(filebytes);
                pictureBox1.Image = Image.FromStream(ms);
                
            }
        }

        private void removePhoto_Click(object sender, EventArgs e)
        {
            filebytes = null;
            pictureBox1.Image = Properties.Resources.NoImage;
        }

        private void createPatient_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            using (sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                //Give id of selected disease
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(@"SELECT Id FROM Disease WHERE Name = '" + dataGridView1.CurrentCell.Value.ToString() + "'", sqlConnection))
                {
                    DataTable diseaseToAddData = new DataTable();
                    sqlDataAdapter.Fill(diseaseToAddData);
                    diseaseToAddId = (int)diseaseToAddData.Rows[0]["Id"];

                }
            }
            addDiseaseToPatientBtn.Visible = true;
        }


        private void addNewDisease_Click(object sender, EventArgs e)
        {
            if (textBox13.Text == "")
            {
                MessageBox.Show("ERROR: No se pueden guardar enfermedades sin nombre. Se debe teclear el nombre completo de la enfermedad en el campo de Busqueda: para poder ser agregado");
            }
            else
            {
                var confirmResult = MessageBox.Show("¿Desea generar el nuevo antecedente '" + textBox13.Text + "'?",
                                         "Nuevo Antecedente",
                                         MessageBoxButtons.OKCancel);
                if (confirmResult == DialogResult.OK)
                {
                    string cmdString = "INSERT INTO Disease (Name, Type) VALUES (@val1, 2)";
                    using (sqlConnection = new SqlConnection(connectionString))
                    {
                        using (SqlCommand comm = new SqlCommand())
                        {
                            comm.Connection = sqlConnection;
                            comm.CommandText = cmdString;
                            comm.Parameters.AddWithValue("@val1", textBox13.Text);
                            try
                            {
                                sqlConnection.Open();
                                comm.ExecuteNonQuery();
                                MessageBox.Show("Se agregó un nuevo antecedente");
                                searchAllDiseases();
                                dataGridView1.ClearSelection();
                                DataView dv = allDiseasesDataTable.DefaultView;
                                dv.RowFilter = string.Format("Name LIKE '%{0}%'", textBox13.Text);

                            }
                            catch
                            {
                                MessageBox.Show("Ocurrió un error, antecedente no guardado");
                            }
                        }
                    }
                }
            }
        }

        private void patientDiseaseSearchTextBox_TextChanged(object sender, EventArgs e)
        {
            patientDiseaseSearchTextBox.Text = filterTextBox(patientDiseaseSearchTextBox.Text);
            patientDiseasesDataGridView.ClearSelection();
            DataView dv = patientDiseasesDataTable.DefaultView;
            dv.RowFilter = string.Format("Name LIKE '%{0}%'", patientDiseaseSearchTextBox.Text);
        }

        private void patientDiseasesDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            int totalHeight;
            int totalWidth;
            if (patientDiseasesDataGridView.RowCount < 6)
            {
                totalHeight = patientDiseasesDataGridView.Rows.GetRowsHeight(DataGridViewElementStates.None) + 3;
                totalWidth = patientDiseasesDataGridView.Columns.GetColumnsWidth(DataGridViewElementStates.None) + 3;
            }
            else
            {
                totalHeight = (patientDiseasesDataGridView.Rows[0].Height * 6) + 3;
                totalWidth = patientDiseasesDataGridView.Columns.GetColumnsWidth(DataGridViewElementStates.None) + 20;
            }


            patientDiseasesDataGridView.ClientSize = new Size(totalWidth, totalHeight);
            patientDiseasesDataGridView.ClearSelection();
        }

        private void patientDiseasesDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            removeDiseaseFromPatientBtn.Visible = true;
            using (sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                //Give id of selected disease
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(@"SELECT Id FROM Disease WHERE Name = '" + patientDiseasesDataGridView.CurrentCell.Value.ToString() + "'", sqlConnection))

                {
                    DataTable diseaseToRemoveData = new DataTable();
                    sqlDataAdapter.Fill(diseaseToRemoveData);
                    diseaseToRemoveId = (int) diseaseToRemoveData.Rows[0]["Id"];

                }
            }
        }

        private void removeDiseaseFromPatientBtn_Click(object sender, EventArgs e)
        {
            using (sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                using (SqlCommand comm = new SqlCommand())
                {
                    comm.Connection = sqlConnection;
                    comm.CommandText = @"DELETE FROM PatientDisease WHERE PatientId = " + patientId + " AND DiseaseId = " + diseaseToRemoveId;
                    comm.ExecuteNonQuery();
                }
            }
            searchAllDiseases();
            searchPatientDiseases();
            addDiseaseToPatientBtn.Visible = false;
            removeDiseaseFromPatientBtn.Visible = false;
            patientDiseasesDataGridView.ClearSelection();
            dataGridView1.ClearSelection();
        }

        private void addDiseaseToPatient_Click(object sender, EventArgs e)
        {
            using (sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                using (SqlCommand comm = new SqlCommand())
                {
                    comm.Connection = sqlConnection;
                    comm.CommandText = @"INSERT INTO PatientDisease (PatientId, DiseaseId) VALUES(" + patientId + ", " + diseaseToAddId + ")";
                    comm.ExecuteNonQuery();
                }
            }
            searchAllDiseases();
            searchPatientDiseases();
            addDiseaseToPatientBtn.Visible = false;
            removeDiseaseFromPatientBtn.Visible = false;
            patientDiseasesDataGridView.ClearSelection();
            dataGridView1.ClearSelection();
        }

        private void reestablishPhoto_Click(object sender, EventArgs e)
        {
            if (currentPhoto == null)
            {
                pictureBox1.Image = Properties.Resources.NoImage;
            }
            else
            {
                MemoryStream ms = new MemoryStream(currentPhoto);
                pictureBox1.Image = Image.FromStream(ms);
            }
            filebytes = currentPhoto;
        }

        private void updatePatient_Click(object sender, EventArgs e)
        {
            DateTime birthDate;
            DateTime dateRegistered;
            try
            {
                birthDate = new DateTime(int.Parse(BirthDateYear.Text), int.Parse(BirthDateMonth.Text), int.Parse(BirthDateDay.Text));
            }
            catch
            {
                MessageBox.Show("La fecha de nacimiento no es válida");
                return;
            }
            try
            {
                dateRegistered = new DateTime(int.Parse(DateRegisteredYear.Text), int.Parse(DateRegisteredMonth.Text), int.Parse(DateRegisteredDay.Text));
            }
            catch
            {
                MessageBox.Show("La fecha de registro no es válida");
                return;
            }

            string cmdString = @"UPDATE Patient 
                                 SET FirstName = @val1, FirstSurname = @val2, SecondSurname = @val3, Gender = @val4, Photo = @val5, 
                                 DateRegistered = @val6, Street = @val7, Neighborhood = @val8, City = @val9, Telephone = @val10, BirthDate = @val11, 
                                 BirthPlace = @val12, RecommendedBy = @val13, InsuranceNumber = @val14, InsuranceCompany = @val15
                                 WHERE Id = " + patientId;
            using (sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand comm = new SqlCommand())
                {
                    comm.Connection = sqlConnection;
                    comm.CommandText = cmdString;
                    comm.Parameters.AddWithValue("@val1", FirstNameTb.Text);
                    comm.Parameters.AddWithValue("@val2", FirstSurnameTb.Text);
                    comm.Parameters.AddWithValue("@val3", SecondSurnameTb.Text);
                    comm.Parameters.AddWithValue("@val4", genderInt);
                    //If no photo selected, add db null
                    if (filebytes == null)
                    {
                        comm.Parameters.Add("@val5", SqlDbType.VarBinary).Value = DBNull.Value;
                    }
                    else
                    {
                        comm.Parameters.Add("@val5", SqlDbType.VarBinary, filebytes.Length).Value = filebytes;
                    }

                    comm.Parameters.AddWithValue("@val6", dateRegistered);
                    comm.Parameters.AddWithValue("@val7", StreetTb.Text);
                    comm.Parameters.AddWithValue("@val8", NeighborhoodTb.Text);
                    comm.Parameters.AddWithValue("@val9", CityTb.Text);
                    comm.Parameters.AddWithValue("@val10", TelephoneTb.Text);
                    comm.Parameters.AddWithValue("@val11", birthDate);
                    comm.Parameters.AddWithValue("@val12", BirthPlaceTb.Text);
                    comm.Parameters.AddWithValue("@val13", RecommendedByTb.Text);
                    comm.Parameters.AddWithValue("@val14", InsuranceNumberTb.Text);
                    comm.Parameters.AddWithValue("@val15", InsuranceCompanyTb.Text);

                    sqlConnection.Open();
                    comm.ExecuteNonQuery();
                    MessageBox.Show("Se actualizó el paciente");


                }
            }
        }

        private void maleRadio_Click(object sender, EventArgs e)
        {
            genderInt = 1;
        }

        private void femaleRadio_Click(object sender, EventArgs e)
        {
            genderInt = 2;
        }
    }
}
