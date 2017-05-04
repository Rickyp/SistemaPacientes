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
    public partial class AddPatient : Form
    {
        //References to main form, used to show main form when this form is closed
        public Main refToMain { get; set; }

        SqlConnection sqlConnection;

        //Located in connectionString name of app config, used to connect to data base
        string connectionString;

        DataTable dataTable;

        //Used to check if the back button was pressed, different behavior then when closing the app or terminating process
        public bool pressedBack;

        //Used to store photo image as bytes
        public byte[] filebytes;
        public int genderInt;

        private void AddPatient_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && !pressedBack)
            {
                //If the form was closed or terminated, terminates the entire program by closing the main form
                //If the form was clsoed by clicking the return button, only ends current form
                this.refToMain.Close();
            }
        }

        public AddPatient()
        {
            InitializeComponent();
            pressedBack = false;
            filebytes = null;
            genderInt = 1;
            maleRadio.Checked = true;
            addNewDisease.Visible = false;
            currentDateDay.Text = DateTime.Now.Day.ToString();
            currentDateMonth.Text = DateTime.Now.Month.ToString();
            currentDateYear.Text = DateTime.Now.Year.ToString();

            connectionString = ConfigurationManager.ConnectionStrings["SistemaPacientes.Properties.Settings.DatabaseConnectionString"].ConnectionString;
            using (sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT Name FROM Disease WHERE Type = 2", sqlConnection))
                {
                    dataTable = new DataTable();
                    sqlDataAdapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;
                    dataGridView1.Columns[0].HeaderText = "Antecedente";

                }
            }
            listView1.View = View.List;
            pictureBox1.Image = Properties.Resources.NoImage;

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
            DataView dv = dataTable.DefaultView;
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
            this.refToMain.Show();
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
                photoLabel.Text = "Se seleccionó el archivo " + openFile.SafeFileName;
                MemoryStream ms = new MemoryStream(filebytes);
                pictureBox1.Image = Image.FromStream(ms);
            }
        }

        private void removePhoto_Click(object sender, EventArgs e)
        {
            filebytes = null;
            photoLabel.Text = "";
            pictureBox1.Image = Properties.Resources.NoImage;
        }

        private void createPatient_Click(object sender, EventArgs e)
        {
            DateTime birthDate;
            DateTime currentDate;
            try
            {
                birthDate = new DateTime(int.Parse(birthDateYear.Text), int.Parse(birthDateMonth.Text), int.Parse(birthDateDay.Text));
            }
            catch
            {
                MessageBox.Show("La fecha de nacimiento no es válida");
                return;
            }
            try
            {
                currentDate = new DateTime(int.Parse(currentDateYear.Text), int.Parse(currentDateMonth.Text), int.Parse(currentDateDay.Text));
            }
            catch
            {
                MessageBox.Show("La fecha de registro no es válida");
                return;
            }
            Int32 newPatientId;
            string cmdString = @"INSERT INTO Patient (FirstName, FirstSurname, SecondSurname, Gender, Photo,
                DateRegistered, Street, Neighborhood, City, Telephone, BirthDate, BirthPlace, RecommendedBy, InsuranceNumber, InsuranceCompany)
                OUTPUT INSERTED.ID
                 VALUES (@val1, @val2, @val3,  @val4,  @val5,  @val6,  @val7,  @val8,  @val9,  @val10,  @val11,  @val12,  @val13,  @val14, @val15)";
            using (sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand comm = new SqlCommand())
                {
                    comm.Connection = sqlConnection;
                    comm.CommandText = cmdString;
                    comm.Parameters.AddWithValue("@val1", textBox1.Text);
                    comm.Parameters.AddWithValue("@val2", textBox2.Text);
                    comm.Parameters.AddWithValue("@val3", textBox3.Text);
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

                    comm.Parameters.AddWithValue("@val6", currentDate);
                    comm.Parameters.AddWithValue("@val7", textBox5.Text);
                    comm.Parameters.AddWithValue("@val8", textBox6.Text);
                    comm.Parameters.AddWithValue("@val9", textBox7.Text);
                    comm.Parameters.AddWithValue("@val10", textBox8.Text);
                    comm.Parameters.AddWithValue("@val11", birthDate);
                    comm.Parameters.AddWithValue("@val12", textBox9.Text);
                    comm.Parameters.AddWithValue("@val13", textBox10.Text);
                    comm.Parameters.AddWithValue("@val14", textBox11.Text);
                    comm.Parameters.AddWithValue("@val15", textBox12.Text);

                    sqlConnection.Open();
                    newPatientId = (Int32)comm.ExecuteScalar();
                    MessageBox.Show("Se agregó un nuevo paciente");

                    //Checking ids of diseases to add to PatientDisease for this new created patient
                    string diseaseNames = "";
                    foreach (ListViewItem item in listView1.Items)
                    {
                        diseaseNames += "'";
                        diseaseNames += item.Text;
                        diseaseNames += "'";
                        diseaseNames += ", ";
                    }
                    //If one or more diseases, insert query
                    if (diseaseNames != "")
                    {
                        diseaseNames = diseaseNames.Remove(diseaseNames.Length - 2, 2);
                        using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT Id FROM Disease WHERE Name IN (" + diseaseNames + ")", sqlConnection))
                        {
                            dataTable = new DataTable();

                            sqlDataAdapter.Fill(dataTable);
                            cmdString = "INSERT INTO PatientDisease (PatientId, DiseaseId) VALUES(@val1, @val2)";
                            comm.CommandText = cmdString;
                            comm.Parameters["@val1"].Value = newPatientId;
                            foreach (DataRow row in dataTable.Rows)
                            {
                                comm.Parameters["@val2"].Value = row["Id"];
                                comm.ExecuteNonQuery();
                            }
                        }
                    }

                    //Clear form fields
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    genderInt = 1;
                    maleRadio.Checked = true;
                    femaleRadio.Checked = false;
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox7.Text = "";
                    textBox8.Text = "";
                    textBox9.Text = "";
                    textBox10.Text = "";
                    textBox11.Text = "";
                    textBox12.Text = "";
                    filebytes = null;
                    photoLabel.Text = "";
                    birthDateDay.Text = "";
                    birthDateMonth.Text = "";
                    birthDateYear.Text = "";
                    listView1.Items.Clear();
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (listView1.Items.Count == 0 || listView1.FindItemWithText(dataGridView1.CurrentCell.Value.ToString(), true, 0, false) == null)
            {
                listView1.Items.Add(dataGridView1.CurrentCell.Value.ToString());
            }
            dataGridView1.ClearSelection();
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        private void removeDiseases_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem v in listView1.SelectedItems)
            {
                listView1.Items.Remove(v);
            }
        }

        private void addNewDisease_Click(object sender, EventArgs e)
        {
            if (textBox13.Text == "")
            {
                MessageBox.Show("ERROR: No se pueden guardar enfermedades sin nombre. Se debe teclear el nombre completo de la enfermedad en el campo de Busqueda: para poder ser agregado");
            }
            else { 
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
                                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT Name FROM Disease", sqlConnection))
                                {
                                    dataTable = new DataTable();
                                    sqlDataAdapter.Fill(dataTable);
                                    dataGridView1.DataSource = dataTable;
                                    dataGridView1.Columns[0].HeaderText = "Antecedente";
                                }
                                dataGridView1.ClearSelection();
                                DataView dv = dataTable.DefaultView;
                                dv.RowFilter = string.Format("Name LIKE '%{0}%'", textBox13.Text);
                                listView1.Items.Add(textBox13.Text);

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
