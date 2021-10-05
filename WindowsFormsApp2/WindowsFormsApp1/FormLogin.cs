using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
	public partial class FormLogin : Form
	{
		String sql_con = @"Data Source=DESKTOP-FERTOLL\PHONGTRAN;Initial Catalog=UserDB;User ID=sa;Password=1234567;";
		SqlConnection con;
		SqlCommand exec;
		SqlDataReader read;

		public static string SetValueText1 = "";


		public static String getMd5(String input)
		{
			StringBuilder builder = new StringBuilder();
			try
			{
				HashAlgorithm md = MD5.Create();
				byte[] result = md.ComputeHash(Encoding.UTF8.GetBytes(input));

				for (int i = 0; i < result.Length; i++)
				{
					builder.Append(result[i].ToString("x2"));
				}

			}
			catch (IOException e)
			{
				Console.WriteLine($"I/O Exception: {e.Message}");
			}
			catch (UnauthorizedAccessException e)
			{
				Console.WriteLine($"Access Exception: {e.Message}");
			}
			return builder.ToString();
		}

		public FormLogin()
		{
			InitializeComponent();
			con = new SqlConnection(sql_con);
			textBox2.PasswordChar = '*';
			toolStripStatusLabel1.Text = "";
		}

		private void button1_Click(object sender, EventArgs e)
		{
			textBox1.Text = "";
			textBox2.Text = "";

		}

		private void button2_Click(object sender, EventArgs e)
		{
			String ma = textBox1.Text;
			String pass = textBox2.Text;
			SetValueText1 = textBox1.Text;
			try
			{
				con.Open();
				String sql = "Select * From UserTable where UserName = '" + ma + "' AND UserPass = '" +getMd5(pass) + "'";
				exec = new SqlCommand(sql, con);
				read = exec.ExecuteReader();

				if (read.Read())
				{
					toolStripStatusLabel1.Text = "";
					MessageBox.Show("Thành công");
					FormUser f2 = new FormUser();
					f2.Show();
					this.Hide();


				}
				else { toolStripStatusLabel1.ForeColor = Color.Red; toolStripStatusLabel1.Text = "Không trùng với mật khẩu hoặc tên user!"; }

				con.Close();
			}
			catch(SqlException se)
			{
				toolStripStatusLabel1.ForeColor = Color.Red; toolStripStatusLabel1.Text = "Lỗi";
			}
				
				
		}

		private void button3_Click(object sender, EventArgs e)
		{
			FormLostAcc fl = new FormLostAcc();
			fl.Show();
			this.Hide();

		}
	}
}
