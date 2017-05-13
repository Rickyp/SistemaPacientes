namespace SistemaPacientes
{
    partial class MedicFiles
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.filesDataGridView = new System.Windows.Forms.DataGridView();
            this.fileSearchTextBox = new System.Windows.Forms.TextBox();
            this.returnBtn = new System.Windows.Forms.Button();
            this.uploadBtn = new System.Windows.Forms.Button();
            this.fileDescription = new System.Windows.Forms.TextBox();
            this.fileName = new System.Windows.Forms.TextBox();
            this.fileLabel = new System.Windows.Forms.Label();
            this.submitFileBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.deleteFileBtn = new System.Windows.Forms.Button();
            this.downloadFileButton = new System.Windows.Forms.Button();
            this.fileDescriptionLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.clinicRecordsDataGridView = new System.Windows.Forms.DataGridView();
            this.clinicRecordTextBox = new System.Windows.Forms.TextBox();
            this.clinicRecordLabel = new System.Windows.Forms.Label();
            this.addClinicRecordBtn = new System.Windows.Forms.Button();
            this.deleteClinicalRecordBtn = new System.Windows.Forms.Button();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.clinicRecordDateYear = new System.Windows.Forms.TextBox();
            this.clinicRecordDateMonth = new System.Windows.Forms.TextBox();
            this.clinicRecordDateDay = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.yesSurgeryRb = new System.Windows.Forms.RadioButton();
            this.noSurgeryRb = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.filesDataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clinicRecordsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // filesDataGridView
            // 
            this.filesDataGridView.AllowUserToAddRows = false;
            this.filesDataGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.filesDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.filesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.filesDataGridView.Location = new System.Drawing.Point(622, 161);
            this.filesDataGridView.MultiSelect = false;
            this.filesDataGridView.Name = "filesDataGridView";
            this.filesDataGridView.ReadOnly = true;
            this.filesDataGridView.RowHeadersVisible = false;
            this.filesDataGridView.RowTemplate.Height = 40;
            this.filesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.filesDataGridView.Size = new System.Drawing.Size(240, 65);
            this.filesDataGridView.TabIndex = 36;
            this.filesDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.filesDataGridView_CellClick);
            this.filesDataGridView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.filesDataGridView_DataBindingComplete);
            // 
            // fileSearchTextBox
            // 
            this.fileSearchTextBox.Location = new System.Drawing.Point(622, 87);
            this.fileSearchTextBox.Name = "fileSearchTextBox";
            this.fileSearchTextBox.Size = new System.Drawing.Size(572, 38);
            this.fileSearchTextBox.TabIndex = 37;
            this.fileSearchTextBox.TextChanged += new System.EventHandler(this.fileSearchTextBox_TextChanged);
            // 
            // returnBtn
            // 
            this.returnBtn.Location = new System.Drawing.Point(34, 1492);
            this.returnBtn.Name = "returnBtn";
            this.returnBtn.Size = new System.Drawing.Size(173, 69);
            this.returnBtn.TabIndex = 38;
            this.returnBtn.Text = "Regresar";
            this.returnBtn.UseVisualStyleBackColor = true;
            this.returnBtn.Click += new System.EventHandler(this.returnBtn_Click);
            // 
            // uploadBtn
            // 
            this.uploadBtn.Location = new System.Drawing.Point(38, 435);
            this.uploadBtn.Name = "uploadBtn";
            this.uploadBtn.Size = new System.Drawing.Size(305, 75);
            this.uploadBtn.TabIndex = 39;
            this.uploadBtn.Text = "Buscar Archivo";
            this.uploadBtn.UseVisualStyleBackColor = true;
            this.uploadBtn.Click += new System.EventHandler(this.uploadBtn_Click);
            // 
            // fileDescription
            // 
            this.fileDescription.Location = new System.Drawing.Point(38, 251);
            this.fileDescription.Multiline = true;
            this.fileDescription.Name = "fileDescription";
            this.fileDescription.Size = new System.Drawing.Size(488, 178);
            this.fileDescription.TabIndex = 40;
            // 
            // fileName
            // 
            this.fileName.Location = new System.Drawing.Point(38, 153);
            this.fileName.Name = "fileName";
            this.fileName.Size = new System.Drawing.Size(303, 38);
            this.fileName.TabIndex = 41;
            // 
            // fileLabel
            // 
            this.fileLabel.AutoSize = true;
            this.fileLabel.Location = new System.Drawing.Point(10, 521);
            this.fileLabel.MaximumSize = new System.Drawing.Size(600, 0);
            this.fileLabel.Name = "fileLabel";
            this.fileLabel.Size = new System.Drawing.Size(0, 32);
            this.fileLabel.TabIndex = 42;
            // 
            // submitFileBtn
            // 
            this.submitFileBtn.Location = new System.Drawing.Point(38, 598);
            this.submitFileBtn.Name = "submitFileBtn";
            this.submitFileBtn.Size = new System.Drawing.Size(305, 75);
            this.submitFileBtn.TabIndex = 43;
            this.submitFileBtn.Text = "Subir Archivo";
            this.submitFileBtn.UseVisualStyleBackColor = true;
            this.submitFileBtn.Click += new System.EventHandler(this.submitFileBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(616, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 32);
            this.label1.TabIndex = 44;
            this.label1.Text = "Buscar";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(260, 32);
            this.label2.TabIndex = 45;
            this.label2.Text = "Nombre del archivo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 205);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(309, 32);
            this.label3.TabIndex = 46;
            this.label3.Text = "Descripción del archivo";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.fileDescription);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.uploadBtn);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.fileName);
            this.groupBox1.Controls.Add(this.fileLabel);
            this.groupBox1.Controls.Add(this.submitFileBtn);
            this.groupBox1.Location = new System.Drawing.Point(34, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(547, 688);
            this.groupBox1.TabIndex = 47;
            this.groupBox1.TabStop = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(22, 34);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(480, 58);
            this.label15.TabIndex = 48;
            this.label15.Text = "Subir Archivo Nuevo";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.deleteFileBtn);
            this.groupBox2.Controls.Add(this.downloadFileButton);
            this.groupBox2.Controls.Add(this.fileDescriptionLabel);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(34, 726);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(547, 714);
            this.groupBox2.TabIndex = 48;
            this.groupBox2.TabStop = false;
            this.groupBox2.Visible = false;
            // 
            // deleteFileBtn
            // 
            this.deleteFileBtn.Location = new System.Drawing.Point(27, 616);
            this.deleteFileBtn.Name = "deleteFileBtn";
            this.deleteFileBtn.Size = new System.Drawing.Size(305, 75);
            this.deleteFileBtn.TabIndex = 50;
            this.deleteFileBtn.Text = "Borrar Archivo";
            this.deleteFileBtn.UseVisualStyleBackColor = true;
            this.deleteFileBtn.Click += new System.EventHandler(this.deleteFileBtn_Click);
            // 
            // downloadFileButton
            // 
            this.downloadFileButton.Location = new System.Drawing.Point(27, 535);
            this.downloadFileButton.Name = "downloadFileButton";
            this.downloadFileButton.Size = new System.Drawing.Size(305, 75);
            this.downloadFileButton.TabIndex = 49;
            this.downloadFileButton.Text = "Descargar Archivo";
            this.downloadFileButton.UseVisualStyleBackColor = true;
            this.downloadFileButton.Click += new System.EventHandler(this.downloadFileButton_Click);
            // 
            // fileDescriptionLabel
            // 
            this.fileDescriptionLabel.AutoSize = true;
            this.fileDescriptionLabel.Location = new System.Drawing.Point(21, 113);
            this.fileDescriptionLabel.MaximumSize = new System.Drawing.Size(500, 0);
            this.fileDescriptionLabel.Name = "fileDescriptionLabel";
            this.fileDescriptionLabel.Size = new System.Drawing.Size(0, 32);
            this.fileDescriptionLabel.TabIndex = 49;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(467, 58);
            this.label4.TabIndex = 49;
            this.label4.Text = "Descripción Archivo";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(1307, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(327, 58);
            this.label5.TabIndex = 49;
            this.label5.Text = "Lista de Citas";
            // 
            // clinicRecordsDataGridView
            // 
            this.clinicRecordsDataGridView.AllowUserToAddRows = false;
            this.clinicRecordsDataGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.clinicRecordsDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle8;
            this.clinicRecordsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.clinicRecordsDataGridView.DefaultCellStyle = dataGridViewCellStyle9;
            this.clinicRecordsDataGridView.Location = new System.Drawing.Point(1317, 161);
            this.clinicRecordsDataGridView.MultiSelect = false;
            this.clinicRecordsDataGridView.Name = "clinicRecordsDataGridView";
            this.clinicRecordsDataGridView.ReadOnly = true;
            this.clinicRecordsDataGridView.RowHeadersVisible = false;
            this.clinicRecordsDataGridView.RowTemplate.Height = 40;
            this.clinicRecordsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.clinicRecordsDataGridView.Size = new System.Drawing.Size(240, 65);
            this.clinicRecordsDataGridView.TabIndex = 36;
            this.clinicRecordsDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.clinicRecordsDataGridView_CellClick);
            this.clinicRecordsDataGridView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.clinicRecordsDataGridView_DataBindingComplete);
            // 
            // clinicRecordTextBox
            // 
            this.clinicRecordTextBox.Location = new System.Drawing.Point(1317, 1224);
            this.clinicRecordTextBox.Multiline = true;
            this.clinicRecordTextBox.Name = "clinicRecordTextBox";
            this.clinicRecordTextBox.Size = new System.Drawing.Size(1367, 430);
            this.clinicRecordTextBox.TabIndex = 51;
            // 
            // clinicRecordLabel
            // 
            this.clinicRecordLabel.AutoSize = true;
            this.clinicRecordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clinicRecordLabel.Location = new System.Drawing.Point(1307, 1028);
            this.clinicRecordLabel.Name = "clinicRecordLabel";
            this.clinicRecordLabel.Size = new System.Drawing.Size(445, 58);
            this.clinicRecordLabel.TabIndex = 53;
            this.clinicRecordLabel.Text = "Agregar nueva cita";
            // 
            // addClinicRecordBtn
            // 
            this.addClinicRecordBtn.Location = new System.Drawing.Point(2746, 1579);
            this.addClinicRecordBtn.Name = "addClinicRecordBtn";
            this.addClinicRecordBtn.Size = new System.Drawing.Size(305, 75);
            this.addClinicRecordBtn.TabIndex = 51;
            this.addClinicRecordBtn.Text = "Agregar Cita";
            this.addClinicRecordBtn.UseVisualStyleBackColor = true;
            this.addClinicRecordBtn.Click += new System.EventHandler(this.addClinicalRecordBtn_Click);
            // 
            // deleteClinicalRecordBtn
            // 
            this.deleteClinicalRecordBtn.Location = new System.Drawing.Point(1849, 1028);
            this.deleteClinicalRecordBtn.Name = "deleteClinicalRecordBtn";
            this.deleteClinicalRecordBtn.Size = new System.Drawing.Size(305, 75);
            this.deleteClinicalRecordBtn.TabIndex = 54;
            this.deleteClinicalRecordBtn.Text = "Borrar Cita";
            this.deleteClinicalRecordBtn.UseVisualStyleBackColor = true;
            this.deleteClinicalRecordBtn.Click += new System.EventHandler(this.deleteClinicalRecordBtn_Click);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(1538, 1118);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(66, 32);
            this.label20.TabIndex = 64;
            this.label20.Text = "Año";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(1418, 1118);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(68, 32);
            this.label21.TabIndex = 63;
            this.label21.Text = "Mes";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(1325, 1118);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(58, 32);
            this.label22.TabIndex = 62;
            this.label22.Text = "Día";
            // 
            // clinicRecordDateYear
            // 
            this.clinicRecordDateYear.Location = new System.Drawing.Point(1524, 1157);
            this.clinicRecordDateYear.Name = "clinicRecordDateYear";
            this.clinicRecordDateYear.Size = new System.Drawing.Size(96, 38);
            this.clinicRecordDateYear.TabIndex = 61;
            // 
            // clinicRecordDateMonth
            // 
            this.clinicRecordDateMonth.Location = new System.Drawing.Point(1420, 1157);
            this.clinicRecordDateMonth.Name = "clinicRecordDateMonth";
            this.clinicRecordDateMonth.Size = new System.Drawing.Size(66, 38);
            this.clinicRecordDateMonth.TabIndex = 60;
            // 
            // clinicRecordDateDay
            // 
            this.clinicRecordDateDay.Location = new System.Drawing.Point(1317, 1157);
            this.clinicRecordDateDay.Name = "clinicRecordDateDay";
            this.clinicRecordDateDay.Size = new System.Drawing.Size(66, 38);
            this.clinicRecordDateDay.TabIndex = 59;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(2785, 1227);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(227, 32);
            this.label7.TabIndex = 65;
            this.label7.Text = "¿Es una cirugía?";
            // 
            // yesSurgeryRb
            // 
            this.yesSurgeryRb.AutoSize = true;
            this.yesSurgeryRb.Location = new System.Drawing.Point(2833, 1303);
            this.yesSurgeryRb.Name = "yesSurgeryRb";
            this.yesSurgeryRb.Size = new System.Drawing.Size(78, 36);
            this.yesSurgeryRb.TabIndex = 66;
            this.yesSurgeryRb.TabStop = true;
            this.yesSurgeryRb.Text = "Si";
            this.yesSurgeryRb.UseVisualStyleBackColor = true;
            this.yesSurgeryRb.Click += new System.EventHandler(this.yesSurgeryRb_Click);
            // 
            // noSurgeryRb
            // 
            this.noSurgeryRb.AutoSize = true;
            this.noSurgeryRb.Location = new System.Drawing.Point(2833, 1394);
            this.noSurgeryRb.Name = "noSurgeryRb";
            this.noSurgeryRb.Size = new System.Drawing.Size(88, 36);
            this.noSurgeryRb.TabIndex = 67;
            this.noSurgeryRb.TabStop = true;
            this.noSurgeryRb.Text = "No";
            this.noSurgeryRb.UseVisualStyleBackColor = true;
            this.noSurgeryRb.Click += new System.EventHandler(this.noSurgeryRb_Click);
            // 
            // MedicFiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(3399, 1848);
            this.Controls.Add(this.noSurgeryRb);
            this.Controls.Add(this.yesSurgeryRb);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.clinicRecordDateYear);
            this.Controls.Add(this.clinicRecordDateMonth);
            this.Controls.Add(this.clinicRecordDateDay);
            this.Controls.Add(this.deleteClinicalRecordBtn);
            this.Controls.Add(this.addClinicRecordBtn);
            this.Controls.Add(this.clinicRecordLabel);
            this.Controls.Add(this.clinicRecordTextBox);
            this.Controls.Add(this.clinicRecordsDataGridView);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.returnBtn);
            this.Controls.Add(this.fileSearchTextBox);
            this.Controls.Add(this.filesDataGridView);
            this.Name = "MedicFiles";
            this.Text = "Historia Clínica";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MedicFiles_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.filesDataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clinicRecordsDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView filesDataGridView;
        private System.Windows.Forms.TextBox fileSearchTextBox;
        private System.Windows.Forms.Button returnBtn;
        private System.Windows.Forms.Button uploadBtn;
        private System.Windows.Forms.TextBox fileDescription;
        private System.Windows.Forms.TextBox fileName;
        private System.Windows.Forms.Label fileLabel;
        private System.Windows.Forms.Button submitFileBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label fileDescriptionLabel;
        private System.Windows.Forms.Button downloadFileButton;
        private System.Windows.Forms.Button deleteFileBtn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView clinicRecordsDataGridView;
        private System.Windows.Forms.TextBox clinicRecordTextBox;
        private System.Windows.Forms.Label clinicRecordLabel;
        private System.Windows.Forms.Button addClinicRecordBtn;
        private System.Windows.Forms.Button deleteClinicalRecordBtn;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox clinicRecordDateYear;
        private System.Windows.Forms.TextBox clinicRecordDateMonth;
        private System.Windows.Forms.TextBox clinicRecordDateDay;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton yesSurgeryRb;
        private System.Windows.Forms.RadioButton noSurgeryRb;
    }
}