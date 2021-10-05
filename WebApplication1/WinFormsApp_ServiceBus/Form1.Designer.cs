
namespace WinFormsApp_ServiceBus
{
	partial class Form1
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnCon = new System.Windows.Forms.Button();
			this.btnSub = new System.Windows.Forms.Button();
			this.richText_Info = new System.Windows.Forms.RichTextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.btn_open = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnCon
			// 
			this.btnCon.Location = new System.Drawing.Point(118, 117);
			this.btnCon.Name = "btnCon";
			this.btnCon.Size = new System.Drawing.Size(188, 58);
			this.btnCon.TabIndex = 0;
			this.btnCon.Text = "Connect Service (150.95.112.175)";
			this.btnCon.UseVisualStyleBackColor = true;
			this.btnCon.Click += new System.EventHandler(this.btnCon_Click);
			// 
			// btnSub
			// 
			this.btnSub.Location = new System.Drawing.Point(118, 248);
			this.btnSub.Name = "btnSub";
			this.btnSub.Size = new System.Drawing.Size(188, 58);
			this.btnSub.TabIndex = 1;
			this.btnSub.Text = "Subscribe";
			this.btnSub.UseVisualStyleBackColor = true;
			this.btnSub.Click += new System.EventHandler(this.btnSub_Click);
			// 
			// richText_Info
			// 
			this.richText_Info.Location = new System.Drawing.Point(106, 430);
			this.richText_Info.Name = "richText_Info";
			this.richText_Info.Size = new System.Drawing.Size(1278, 337);
			this.richText_Info.TabIndex = 2;
			this.richText_Info.Text = "";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(1027, 248);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(224, 41);
			this.label1.TabIndex = 3;
			this.label1.Text = "Dữ liệu nhận về";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(1027, 94);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(250, 47);
			this.textBox1.TabIndex = 4;
			this.textBox1.Text = "a1908g";
			// 
			// btn_open
			// 
			this.btn_open.Location = new System.Drawing.Point(1027, 183);
			this.btn_open.Name = "btn_open";
			this.btn_open.Size = new System.Drawing.Size(357, 58);
			this.btn_open.TabIndex = 5;
			this.btn_open.Text = "Open form publish data";
			this.btn_open.UseVisualStyleBackColor = true;
			this.btn_open.Click += new System.EventHandler(this.btn_open_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(17F, 41F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1552, 837);
			this.Controls.Add(this.btn_open);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.richText_Info);
			this.Controls.Add(this.btnSub);
			this.Controls.Add(this.btnCon);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnCon;
		private System.Windows.Forms.Button btnSub;
		private System.Windows.Forms.RichTextBox richText_Info;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button btn_open;
	}
}

