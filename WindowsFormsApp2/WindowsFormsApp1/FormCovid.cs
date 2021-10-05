using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
	public partial class FormCovid : Form
	{
		SqlConnection con;
		SqlCommand exec;
		SqlDataAdapter read;
		String sql = @"Data Source=DESKTOP-FERTOLL\PHONGTRAN;Initial Catalog=QL_TiemChung;User ID=sa;Password=1234567";
		public FormCovid()
		{
			InitializeComponent();
			con = new SqlConnection(sql);
			showTable();
			dataGridView1.Columns[5].DefaultCellStyle.Format = "dd/MM/yyyy";


		}
		public void showTable()
		{
			DataSet1TableAdapters.covid_vaccineTableAdapter vaccine = new DataSet1TableAdapters.covid_vaccineTableAdapter();
			dataGridView1.DataSource = vaccine.GetDataVaccineCovid();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			dataGridView1.ClearSelection();
			textBox1.Text = "";
			textBox2.Text = "";
			textBox3.Text = "";
			textBox4.Text = "";
			textBox6.Text = "";

		}
		
		private void button2_Click(object sender, EventArgs e)
		{
			String maCode = textBox1.Text;
			String ten = textBox2.Text;
			String email = textBox3.Text;
			String cmnd = textBox4.Text;
			String diachi = textBox6.Text;
			String date = dateTimePicker1.Text;

			con.Open();
			String sql = "Insert into covid_vaccine  values (@code_patient, @name_patient, @email_patient, @CMND_patient, CONVERT(date, date_injection , 103), @district_patient";
			exec = new SqlCommand();
			exec.CommandText = sql;
			exec.Connection = con;

			exec.Parameters.Add("@code_patient", SqlDbType.VarChar).Value = maCode;
			exec.Parameters.Add("@name_patient", SqlDbType.NVarChar).Value = ten;
			exec.Parameters.Add("@email_patient", SqlDbType.VarChar).Value = email;
			exec.Parameters.Add("@CMND_patient", SqlDbType.VarChar).Value = cmnd;
			exec.Parameters.Add("@date_injection", SqlDbType.Date).Value = date;	
			exec.Parameters.Add("@district_patient", SqlDbType.NVarChar).Value = diachi;

			int read = exec.ExecuteNonQuery();

			if(read != -1)
			{
				toolStripStatusLabel1.ForeColor = Color.Red;
				toolStripStatusLabel1.Text = "Lỗi không thể thêm được";

			}
			else
			{
				toolStripStatusLabel1.ForeColor = Color.Green;
				toolStripStatusLabel1.Text = " thêm thành công";
			}
			con.Close();
			dataGridView1.CancelEdit();
			dataGridView1.Columns.Clear();
			dataGridView1.DataSource = null;
			showTable();

			textBox1.Text = "";
			textBox2.Text = "";
			textBox3.Text = "";
			textBox4.Text = "";
			textBox6.Text = "";
		}

		private void button3_Click(object sender, EventArgs e)
		{
			String maCode = textBox1.Text;
			String ten = textBox2.Text;
			String email = textBox3.Text;
			String cmnd = textBox4.Text;
			String diachi = textBox6.Text;
			String date = dateTimePicker1.Text;

			con.Open();
			String sql = "UPDATE UserTable";
		}
	}
}
