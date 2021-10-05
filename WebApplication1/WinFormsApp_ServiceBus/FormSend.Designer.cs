
namespace WinFormsApp_ServiceBus
{
	partial class FormSend
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
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.btn_Con = new System.Windows.Forms.Button();
			this.button_send_data = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(716, 239);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(783, 47);
			this.textBox1.TabIndex = 5;
			this.textBox1.Text = "Chao ban abc";
			// 
			// btn_Con
			// 
			this.btn_Con.Location = new System.Drawing.Point(-371, 76);
			this.btn_Con.Name = "btn_Con";
			this.btn_Con.Size = new System.Drawing.Size(258, 105);
			this.btn_Con.TabIndex = 4;
			this.btn_Con.Text = "Connect Server";
			this.btn_Con.UseVisualStyleBackColor = true;
			// 
			// button_send_data
			// 
			this.button_send_data.Location = new System.Drawing.Point(-371, 270);
			this.button_send_data.Name = "button_send_data";
			this.button_send_data.Size = new System.Drawing.Size(258, 105);
			this.button_send_data.TabIndex = 3;
			this.button_send_data.Text = "Publish Data";
			this.button_send_data.UseVisualStyleBackColor = true;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(19, 218);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(258, 105);
			this.button1.TabIndex = 7;
			this.button1.Text = "Connect Server";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(19, 412);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(258, 105);
			this.button2.TabIndex = 6;
			this.button2.Text = "Publish Data";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// FormSend
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(17F, 41F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1581, 734);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.btn_Con);
			this.Controls.Add(this.button_send_data);
			this.Name = "FormSend";
			this.Text = "FormSend";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button btn_Con;
		private System.Windows.Forms.Button button_send_data;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
	}
}