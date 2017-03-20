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
    public partial class Main : Form
    {

        public string connectionString;

        public string dbName;

        public Main()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["SistemaPacientes.Properties.Settings.DatabaseConnectionString"].ConnectionString;
            dbName = System.Windows.Forms.Application.StartupPath + "\\Database.mdf";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddPatient addPatientForm = new AddPatient();
            addPatientForm.refToMain = this;
            addPatientForm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ListPatients listPatientsForm = new ListPatients();
            listPatientsForm.refToMain = this;
            listPatientsForm.Show();
            this.Hide();
        }

        private void createBackupBtn_Click(object sender, EventArgs e)
        {

            System.Data.SqlClient.SqlConnection.ClearAllPools();
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("backup database @db to disk=@path with format", con);
                    cmd.Parameters.AddWithValue("@db", dbName);
                    cmd.Parameters.AddWithValue("@path", fbd.SelectedPath.ToString() + "\\Database.bak");
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                MessageBox.Show("Se generó el respaldo.");
            }
        }

        private void restoreBackupBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Respaldo de base de datos|*.bak";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = "USE [master]; RESTORE DATABASE @db FROM DISK = N'" +
                                    ofd.FileName + " ' WITH FILE = 1, NOUNLOAD, REPLACE, STATS = 10";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@db", dbName);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                MessageBox.Show("Se recuperó la base de datos del remplazo.");
            }
        }
    }
}
