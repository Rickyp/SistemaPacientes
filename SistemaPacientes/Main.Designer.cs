namespace SistemaPacientes
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.createBackupBtn = new System.Windows.Forms.Button();
            this.restoreBackupBtn = new System.Windows.Forms.Button();
            this.ClinicRecordSummaryBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(371, 103);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(290, 54);
            this.button1.TabIndex = 0;
            this.button1.Text = "Agregar Paciente";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(371, 237);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(290, 54);
            this.button2.TabIndex = 1;
            this.button2.Text = "Mostrar Pacientes";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // createBackupBtn
            // 
            this.createBackupBtn.Location = new System.Drawing.Point(371, 605);
            this.createBackupBtn.Name = "createBackupBtn";
            this.createBackupBtn.Size = new System.Drawing.Size(290, 54);
            this.createBackupBtn.TabIndex = 2;
            this.createBackupBtn.Text = "Crear respaldo";
            this.createBackupBtn.UseVisualStyleBackColor = true;
            this.createBackupBtn.Click += new System.EventHandler(this.createBackupBtn_Click);
            // 
            // restoreBackupBtn
            // 
            this.restoreBackupBtn.Location = new System.Drawing.Point(371, 707);
            this.restoreBackupBtn.Name = "restoreBackupBtn";
            this.restoreBackupBtn.Size = new System.Drawing.Size(290, 54);
            this.restoreBackupBtn.TabIndex = 3;
            this.restoreBackupBtn.Text = "Usar respaldo";
            this.restoreBackupBtn.UseVisualStyleBackColor = true;
            this.restoreBackupBtn.Click += new System.EventHandler(this.restoreBackupBtn_Click);
            // 
            // ClinicRecordSummaryBtn
            // 
            this.ClinicRecordSummaryBtn.Location = new System.Drawing.Point(371, 366);
            this.ClinicRecordSummaryBtn.Name = "ClinicRecordSummaryBtn";
            this.ClinicRecordSummaryBtn.Size = new System.Drawing.Size(290, 54);
            this.ClinicRecordSummaryBtn.TabIndex = 4;
            this.ClinicRecordSummaryBtn.Text = "Resumen de Citas";
            this.ClinicRecordSummaryBtn.UseVisualStyleBackColor = true;
            this.ClinicRecordSummaryBtn.Click += new System.EventHandler(this.ClinicRecordSummaryBtn_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(1071, 963);
            this.Controls.Add(this.ClinicRecordSummaryBtn);
            this.Controls.Add(this.restoreBackupBtn);
            this.Controls.Add(this.createBackupBtn);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Main";
            this.Text = "Sistema Pacientes";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button createBackupBtn;
        private System.Windows.Forms.Button restoreBackupBtn;
        private System.Windows.Forms.Button ClinicRecordSummaryBtn;
    }
}

