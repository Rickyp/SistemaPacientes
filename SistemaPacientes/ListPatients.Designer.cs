namespace SistemaPacientes
{
    partial class ListPatients
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.returnBtn = new System.Windows.Forms.Button();
            this.databaseDataSet = new SistemaPacientes.DatabaseDataSet();
            this.databaseDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.patientsDataGridView = new System.Windows.Forms.DataGridView();
            this.databaseDataSetBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.removeDiseases = new System.Windows.Forms.Button();
            this.diseaseDataGridView = new System.Windows.Forms.DataGridView();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.viewProfileBtn = new System.Windows.Forms.Button();
            this.patientDiseaseDataGridView = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.patientFilesButton = new System.Windows.Forms.Button();
            this.ageLabel = new System.Windows.Forms.Label();
            this.surnameLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.databaseDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.databaseDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.patientsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.databaseDataSetBindingSource1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.diseaseDataGridView)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.patientDiseaseDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // returnBtn
            // 
            this.returnBtn.Location = new System.Drawing.Point(35, 1244);
            this.returnBtn.Name = "returnBtn";
            this.returnBtn.Size = new System.Drawing.Size(223, 68);
            this.returnBtn.TabIndex = 1;
            this.returnBtn.Text = "Regresar";
            this.returnBtn.UseVisualStyleBackColor = true;
            this.returnBtn.Click += new System.EventHandler(this.returnBtn_Click);
            // 
            // databaseDataSet
            // 
            this.databaseDataSet.DataSetName = "DatabaseDataSet";
            this.databaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // databaseDataSetBindingSource
            // 
            this.databaseDataSetBindingSource.DataSource = this.databaseDataSet;
            this.databaseDataSetBindingSource.Position = 0;
            // 
            // patientsDataGridView
            // 
            this.patientsDataGridView.AllowUserToAddRows = false;
            this.patientsDataGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.patientsDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.patientsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.patientsDataGridView.Location = new System.Drawing.Point(35, 133);
            this.patientsDataGridView.MultiSelect = false;
            this.patientsDataGridView.Name = "patientsDataGridView";
            this.patientsDataGridView.ReadOnly = true;
            this.patientsDataGridView.RowHeadersVisible = false;
            this.patientsDataGridView.RowTemplate.Height = 40;
            this.patientsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.patientsDataGridView.Size = new System.Drawing.Size(230, 201);
            this.patientsDataGridView.TabIndex = 2;
            this.patientsDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.patientsDataGridView_CellClick);
            this.patientsDataGridView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.patientsDataGridView_DataBindingComplete);
            // 
            // databaseDataSetBindingSource1
            // 
            this.databaseDataSetBindingSource1.DataSource = this.databaseDataSet;
            this.databaseDataSetBindingSource1.Position = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 32);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nombre:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(146, 56);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(372, 38);
            this.textBox1.TabIndex = 4;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(734, 56);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(372, 38);
            this.textBox2.TabIndex = 7;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(524, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(217, 32);
            this.label2.TabIndex = 6;
            this.label2.Text = "Primer Apellido:";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(1370, 56);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(372, 38);
            this.textBox3.TabIndex = 9;
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1124, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(249, 32);
            this.label3.TabIndex = 8;
            this.label3.Text = "Segundo Apellido:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.listView1);
            this.groupBox1.Controls.Add(this.removeDiseases);
            this.groupBox1.Controls.Add(this.diseaseDataGridView);
            this.groupBox1.Controls.Add(this.textBox4);
            this.groupBox1.Location = new System.Drawing.Point(1179, 115);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1121, 980);
            this.groupBox1.TabIndex = 42;
            this.groupBox1.TabStop = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(10, 102);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(167, 36);
            this.label16.TabIndex = 42;
            this.label16.Text = "Búsqueda:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(6, 22);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(299, 58);
            this.label15.TabIndex = 42;
            this.label15.Text = "Enfermedad";
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(516, 141);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(573, 363);
            this.listView1.TabIndex = 39;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // removeDiseases
            // 
            this.removeDiseases.Location = new System.Drawing.Point(516, 519);
            this.removeDiseases.Name = "removeDiseases";
            this.removeDiseases.Size = new System.Drawing.Size(200, 82);
            this.removeDiseases.TabIndex = 40;
            this.removeDiseases.Text = "Quitar enfermedad";
            this.removeDiseases.UseVisualStyleBackColor = true;
            this.removeDiseases.Click += new System.EventHandler(this.removeDiseases_Click);
            // 
            // diseaseDataGridView
            // 
            this.diseaseDataGridView.AllowUserToAddRows = false;
            this.diseaseDataGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.diseaseDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.diseaseDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.diseaseDataGridView.ColumnHeadersVisible = false;
            this.diseaseDataGridView.Location = new System.Drawing.Point(102, 200);
            this.diseaseDataGridView.MultiSelect = false;
            this.diseaseDataGridView.Name = "diseaseDataGridView";
            this.diseaseDataGridView.ReadOnly = true;
            this.diseaseDataGridView.RowHeadersVisible = false;
            this.diseaseDataGridView.RowTemplate.Height = 40;
            this.diseaseDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.diseaseDataGridView.Size = new System.Drawing.Size(240, 65);
            this.diseaseDataGridView.TabIndex = 35;
            this.diseaseDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.diseaseDataGridView_CellClick);
            this.diseaseDataGridView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.diseaseDataGridView_DataBindingComplete);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(5, 141);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(487, 38);
            this.textBox4.TabIndex = 37;
            this.textBox4.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.viewProfileBtn);
            this.groupBox2.Controls.Add(this.patientDiseaseDataGridView);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.patientFilesButton);
            this.groupBox2.Controls.Add(this.ageLabel);
            this.groupBox2.Controls.Add(this.surnameLabel);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.nameLabel);
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Location = new System.Drawing.Point(2508, 33);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1276, 1685);
            this.groupBox2.TabIndex = 45;
            this.groupBox2.TabStop = false;
            // 
            // viewProfileBtn
            // 
            this.viewProfileBtn.Location = new System.Drawing.Point(389, 1559);
            this.viewProfileBtn.Name = "viewProfileBtn";
            this.viewProfileBtn.Size = new System.Drawing.Size(225, 65);
            this.viewProfileBtn.TabIndex = 49;
            this.viewProfileBtn.Text = "Ver Perfil";
            this.viewProfileBtn.UseVisualStyleBackColor = true;
            this.viewProfileBtn.Click += new System.EventHandler(this.viewProfileBtn_Click);
            // 
            // patientDiseaseDataGridView
            // 
            this.patientDiseaseDataGridView.AllowUserToAddRows = false;
            this.patientDiseaseDataGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.patientDiseaseDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.patientDiseaseDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.patientDiseaseDataGridView.ColumnHeadersVisible = false;
            this.patientDiseaseDataGridView.Location = new System.Drawing.Point(528, 938);
            this.patientDiseaseDataGridView.Name = "patientDiseaseDataGridView";
            this.patientDiseaseDataGridView.ReadOnly = true;
            this.patientDiseaseDataGridView.RowHeadersVisible = false;
            this.patientDiseaseDataGridView.RowTemplate.Height = 40;
            this.patientDiseaseDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.patientDiseaseDataGridView.Size = new System.Drawing.Size(240, 65);
            this.patientDiseaseDataGridView.TabIndex = 50;
            this.patientDiseaseDataGridView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.patientDiseaseDataGridView_DataBindingComplete);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(518, 858);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(299, 58);
            this.label5.TabIndex = 49;
            this.label5.Text = "Enfermedad";
            // 
            // patientFilesButton
            // 
            this.patientFilesButton.Location = new System.Drawing.Point(53, 1559);
            this.patientFilesButton.Name = "patientFilesButton";
            this.patientFilesButton.Size = new System.Drawing.Size(248, 95);
            this.patientFilesButton.TabIndex = 48;
            this.patientFilesButton.Text = "Ver Historia Clínica";
            this.patientFilesButton.UseVisualStyleBackColor = true;
            this.patientFilesButton.Click += new System.EventHandler(this.patientFilesButton_Click);
            // 
            // ageLabel
            // 
            this.ageLabel.AutoSize = true;
            this.ageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ageLabel.Location = new System.Drawing.Point(200, 858);
            this.ageLabel.Name = "ageLabel";
            this.ageLabel.Size = new System.Drawing.Size(169, 58);
            this.ageLabel.TabIndex = 47;
            this.ageLabel.Text = "Edad: ";
            // 
            // surnameLabel
            // 
            this.surnameLabel.AutoSize = true;
            this.surnameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.surnameLabel.Location = new System.Drawing.Point(6, 104);
            this.surnameLabel.Name = "surnameLabel";
            this.surnameLabel.Size = new System.Drawing.Size(152, 61);
            this.surnameLabel.TabIndex = 46;
            this.surnameLabel.Text = "Perfil";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(43, 858);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(169, 58);
            this.label4.TabIndex = 45;
            this.label4.Text = "Edad: ";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLabel.Location = new System.Drawing.Point(6, 34);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(152, 61);
            this.nameLabel.TabIndex = 43;
            this.nameLabel.Text = "Perfil";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(401, 223);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(499, 519);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 44;
            this.pictureBox1.TabStop = false;
            // 
            // ListPatients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(3824, 2088);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.patientsDataGridView);
            this.Controls.Add(this.returnBtn);
            this.Name = "ListPatients";
            this.Text = "Mostrar Pacientes";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ListPatients_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.databaseDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.databaseDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.patientsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.databaseDataSetBindingSource1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.diseaseDataGridView)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.patientDiseaseDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button returnBtn;
        private DatabaseDataSet databaseDataSet;
        private System.Windows.Forms.BindingSource databaseDataSetBindingSource;
        private System.Windows.Forms.DataGridView patientsDataGridView;
        private System.Windows.Forms.BindingSource databaseDataSetBindingSource1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button removeDiseases;
        private System.Windows.Forms.DataGridView diseaseDataGridView;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label surnameLabel;
        private System.Windows.Forms.Label ageLabel;
        private System.Windows.Forms.Button patientFilesButton;
        private System.Windows.Forms.DataGridView patientDiseaseDataGridView;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button viewProfileBtn;
    }
}