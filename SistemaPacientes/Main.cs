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
            connectionString = ConfigurationManager.ConnectionStrings["SistemaPacientes.Properties.Settings.DatabaseConnectionString"].ConnectionString;
            InitializeComponent();
            
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT DB_NAME(db_id()) AS Name", sqlConnection))
                {
                    DataTable dat = new DataTable();
                    adapter.Fill(dat);
                    dbName = (string)dat.Rows[0]["Name"];
                }
            }
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
            string currentDbPath = dbName;
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                string backUpPath = fbd.SelectedPath.ToString();
                File.Copy(currentDbPath, backUpPath + @"\BackUp.mdf", true);
                MessageBox.Show("Se generó el respaldo.");
            }
        }

        private void restoreBackupBtn_Click(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlConnection.ClearAllPools();
            string restorePath = dbName;
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string restoreFile = ofd.FileName;
                File.Delete(restorePath + ".bak");
                File.Move(restorePath, restorePath + ".bak");
                File.Copy(restoreFile, restorePath, true);
            }
        }
    }
}
