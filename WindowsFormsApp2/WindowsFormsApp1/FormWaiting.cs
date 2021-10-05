using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
	public partial class FormWaiting : Form
	{
		int progress = 0;

		public FormWaiting()
		{
			InitializeComponent();
			timer1.Enabled = true;
			timer1.Interval = 100;
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			progress += 1;
			if(progress >= 100)
			{
				timer1.Enabled = false;
				timer1.Stop();
				FormLogin f1 = new FormLogin();
				f1.Show();
				this.Hide();
			}
			progressBar1.Value = progress;
			label3.Text = progress.ToString()+ " %";
		}

		private void FormWaiting_FormClosing(object sender, FormClosingEventArgs e)
		{
			if(e.CloseReason == CloseReason.UserClosing)
			{
				switch(MessageBox.Show(this, "Are you sure", "Do you still want it...", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
				{
					case DialogResult.No: e.Cancel = true; break;
					case DialogResult.Yes: e.Cancel = false; break;
					default: break;
				}
			}
		}
	}
}
