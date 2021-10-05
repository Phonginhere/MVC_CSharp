
namespace WinFormsApp_Bus_2
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
			this.button_send_data = new System.Windows.Forms.Button();
			this.btn_Con = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// button_send_data
			// 
			this.button_send_data.Location = new System.Drawing.Point(84, 261);
			this.button_send_data.Name = "button_send_data";
			this.button_send_data.Size = new System.Drawing.Size(258, 105);
			this.button_send_data.TabIndex = 0;
			this.button_send_data.Text = "Publish Data";
			this.button_send_data.UseVisualStyleBackColor = true;
			this.button_send_data.Click += new System.EventHandler(this.button_send_data_Click);
			// 
			// btn_Con
			// 
			this.btn_Con.Location = new System.Drawing.Point(84, 67);
			this.btn_Con.Name = "btn_Con";
			this.btn_Con.Size = new System.Drawing.Size(258, 105);
			this.btn_Con.TabIndex = 1;
			this.btn_Con.Text = "Connect Server";
			this.btn_Con.UseVisualStyleBackColor = true;
			this.btn_Con.Click += new System.EventHandler(this.btn_Con_Click);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(844, 216);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(783, 47);
			this.textBox1.TabIndex = 2;
			this.textBox1.Text = "Chao ban abc";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(17F, 41F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1666, 754);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.btn_Con);
			this.Controls.Add(this.button_send_data);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button button_send_data;
		private System.Windows.Forms.Button btn_Con;
		private System.Windows.Forms.TextBox textBox1;
	}
}

