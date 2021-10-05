namespace WindowsFormsApp2
{
    partial class CovidManage
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CovidManage));
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.label6 = new System.Windows.Forms.Label();
			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.id_patient = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.code_patient = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.name_patient = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.email_patient = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Cmnd_patient = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.date_injection = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.district_patient = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.label7 = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.printDocument1 = new System.Drawing.Printing.PrintDocument();
			this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(205, 58);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(100, 22);
			this.textBox1.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(65, 58);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(109, 17);
			this.label1.TabIndex = 1;
			this.label1.Text = "Tên bệnh nhân:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(65, 97);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(103, 17);
			this.label2.TabIndex = 3;
			this.label2.Text = "Mã bệnh nhân:";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(205, 97);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(100, 22);
			this.textBox2.TabIndex = 2;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(65, 138);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(73, 17);
			this.label3.TabIndex = 5;
			this.label3.Text = "Số CMDN:";
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(205, 138);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(100, 22);
			this.textBox3.TabIndex = 4;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(65, 210);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(46, 17);
			this.label4.TabIndex = 7;
			this.label4.Text = "Email:";
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(205, 210);
			this.textBox4.Name = "textBox4";
			this.textBox4.Size = new System.Drawing.Size(258, 22);
			this.textBox4.TabIndex = 6;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(65, 255);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(55, 17);
			this.label5.TabIndex = 9;
			this.label5.Text = "Địa chỉ:";
			// 
			// textBox5
			// 
			this.textBox5.Location = new System.Drawing.Point(205, 255);
			this.textBox5.Name = "textBox5";
			this.textBox5.Size = new System.Drawing.Size(258, 22);
			this.textBox5.TabIndex = 8;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(25, 308);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(95, 29);
			this.button1.TabIndex = 10;
			this.button1.Text = "Insert";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(25, 355);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(95, 34);
			this.button2.TabIndex = 11;
			this.button2.Text = "Load dữ liệu";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(65, 175);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(114, 17);
			this.label6.TabIndex = 12;
			this.label6.Text = "Ngày tiêm vacxin";
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.Location = new System.Drawing.Point(205, 175);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.Size = new System.Drawing.Size(239, 22);
			this.dateTimePicker1.TabIndex = 13;
			// 
			// dataGridView1
			// 
			this.dataGridView1.AccessibleRole = System.Windows.Forms.AccessibleRole.DropList;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_patient,
            this.code_patient,
            this.name_patient,
            this.email_patient,
            this.Cmnd_patient,
            this.date_injection,
            this.district_patient});
			this.dataGridView1.Location = new System.Drawing.Point(483, 53);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowTemplate.Height = 24;
			this.dataGridView1.Size = new System.Drawing.Size(605, 392);
			this.dataGridView1.TabIndex = 14;
			this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
			this.dataGridView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseClick);
			this.dataGridView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseDoubleClick);
			// 
			// id_patient
			// 
			this.id_patient.DataPropertyName = "id_patient";
			this.id_patient.HeaderText = "Id bệnh nhân";
			this.id_patient.Name = "id_patient";
			// 
			// code_patient
			// 
			this.code_patient.DataPropertyName = "code_patient";
			this.code_patient.HeaderText = "Mã bệnh nhân";
			this.code_patient.Name = "code_patient";
			// 
			// name_patient
			// 
			this.name_patient.DataPropertyName = "name_patient";
			this.name_patient.HeaderText = "Tên bệnh nhân";
			this.name_patient.Name = "name_patient";
			// 
			// email_patient
			// 
			this.email_patient.DataPropertyName = "email_patient";
			this.email_patient.HeaderText = "Email bệnh nhân";
			this.email_patient.Name = "email_patient";
			// 
			// Cmnd_patient
			// 
			this.Cmnd_patient.DataPropertyName = "CMND_patient";
			this.Cmnd_patient.HeaderText = "Chứng Minh nhân dân";
			this.Cmnd_patient.Name = "Cmnd_patient";
			// 
			// date_injection
			// 
			this.date_injection.DataPropertyName = "date_injection";
			this.date_injection.HeaderText = "Lịch Tiêm";
			this.date_injection.Name = "date_injection";
			// 
			// district_patient
			// 
			this.district_patient.DataPropertyName = "district_patient";
			this.district_patient.HeaderText = "Địa Chỉ";
			this.district_patient.Name = "district_patient";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.ForeColor = System.Drawing.Color.Blue;
			this.label7.Location = new System.Drawing.Point(310, 18);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(442, 32);
			this.label7.TabIndex = 15;
			this.label7.Text = "Chương trình quản lí tiêm Covid";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(179, 298);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(284, 244);
			this.pictureBox1.TabIndex = 17;
			this.pictureBox1.TabStop = false;
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(25, 395);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(95, 34);
			this.button3.TabIndex = 18;
			this.button3.Text = "Gen mã Qr";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(25, 445);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(95, 34);
			this.button4.TabIndex = 19;
			this.button4.Text = "Print Giấy thông hành";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// printPreviewDialog1
			// 
			this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
			this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
			this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
			this.printPreviewDialog1.Enabled = true;
			this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
			this.printPreviewDialog1.Name = "printPreviewDialog1";
			this.printPreviewDialog1.Visible = false;
			// 
			// CovidManage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1090, 568);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.dateTimePicker1);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.textBox5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.textBox4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.textBox3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBox1);
			this.Name = "CovidManage";
			this.Text = "Quản lý tiêm chủng Vacin Covid";
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label7;
		private System.Windows.Forms.DataGridViewTextBoxColumn id_patient;
		private System.Windows.Forms.DataGridViewTextBoxColumn code_patient;
		private System.Windows.Forms.DataGridViewTextBoxColumn name_patient;
		private System.Windows.Forms.DataGridViewTextBoxColumn email_patient;
		private System.Windows.Forms.DataGridViewTextBoxColumn Cmnd_patient;
		private System.Windows.Forms.DataGridViewTextBoxColumn date_injection;
		private System.Windows.Forms.DataGridViewTextBoxColumn district_patient;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
		private System.Drawing.Printing.PrintDocument printDocument1;
		private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
	}
}