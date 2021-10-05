using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
	public partial class StripStatus : Form
	{
		public StripStatus()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			toolStripStatusLabel1.ForeColor = Color.Red;
			toolStripStatusLabel1.Text = "Đã Update";
			
		}

		private void button2_Click(object sender, EventArgs e)
		{
			toolStripStatusLabel1.ForeColor = Color.Blue;
			toolStripStatusLabel1.Text = "Đã Gen QrCode";
			
		}
	}
}
