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
        public Main()
        {
            InitializeComponent();
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
            string currentDbPath = Environment.CurrentDirectory + @"\Database.mdf";
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
            string restorePath = Environment.CurrentDirectory + @"\Database.mdf";
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string restoreFile = ofd.FileName;
                File.Move(restorePath, restorePath + ".bak");
                File.Copy(restoreFile, restorePath, true);
            }
        }
    }
}
