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
	public partial class Form3 : Form
	{
		public Form3()
		{
			InitializeComponent();
		}
		DataSet1TableAdapters.covid_vaccineTableAdapter person = new DataSet1TableAdapters.covid_vaccineTableAdapter();

		private void Form3_Load(object sender, EventArgs e)
		{
			dataGridView1.DataSource = person.GetDataBy();

		}

		private void button1_Click(object sender, EventArgs e)
		{
			DataSet ds = new DataSet();
			
		}
	}
}
