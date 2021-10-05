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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
	public partial class FormLostAcc : Form
	{
		String sql_con = @"Data Source=DESKTOP-FERTOLL\PHONGTRAN;Initial Catalog=UserDB;User ID=sa;Password=1234567;";
		SqlConnection con;
		SqlCommand exec;
		SqlDataReader read;
		public static string getMd5(String input)
		{
			StringBuilder builder = new StringBuilder();
			try
			{
				HashAlgorithm md = MD5.Create();
				byte[] result = md.ComputeHash(Encoding.UTF8.GetBytes(input));

				for(int i = 0; i < result.Length; i++)
				{
					builder.Append(result[i].ToString("x2"));

				}
			}catch(IOException ex)
			{
				Console.WriteLine($"I/O Exception: "+ ex.Message);
			}catch(UnauthorizedAccessException e)
			{
				Console.WriteLine("Unathorized error: " + e.Message);
			}
			return builder.ToString();
		}

		public FormLostAcc()
		{
			InitializeComponent();
			label2.Visible = false;
			textBox2.Visible = false;
			button2.Visible = false;
			toolStripStatusLabel1.Visible = false;
			con = new SqlConnection(sql_con);
			textBox2.PasswordChar = '*';
			toolStripStatusLabel1.Visible = false;
			button4.Enabled = false;
		}

		private void button3_Click(object sender, EventArgs e)
		{
			FormLogin f1 = new FormLogin();
			f1.Show();
			this.Hide();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			String name_user = textBox1.Text;
			try
			{
				con.Open();
				String sql = "Select * From UserTable Where UserName = '" + name_user + "'";
				exec = new SqlCommand(sql, con);
				read = exec.ExecuteReader();

				if (read.Read())
				{
					toolStripStatusLabel1.Visible = true;
					toolStripStatusLabel1.ForeColor = Color.Green;
					toolStripStatusLabel1.Text = "Đã tìm thành công";
					button1.Enabled = false;
					textBox1.Enabled = false;
					textBox2.Visible = true;
					button2.Visible = true;
					label2.Visible = true;
					button4.Enabled = true;
				}
				else
				{
					toolStripStatusLabel1.Visible = true;
					toolStripStatusLabel1.ForeColor = Color.Red;
					toolStripStatusLabel1.Text = "Thất bại";
				}
				con.Close();
			}
			catch(Exception exx)
			{
				toolStripStatusLabel1.Visible = true;
				toolStripStatusLabel1.ForeColor = Color.Red;
				toolStripStatusLabel1.Text = "Lỗi" +exx;
			}
			
		}

		private void button2_Click(object sender, EventArgs e)
		{
			String name_user = textBox1.Text;
			String pass = textBox2.Text;

			try
			{
				con.Open();
				MessageBox.Show("pass: "+getMd5(pass)+ "usern"+ name_user);
				//String sql1 = "UPDATE UserTable SET UserPass = '"+getMd5(pass)+ "' WHERE UserName = '"+name_user+"'";
				String sqlUp = "UPDATE UserTable Set UserPass = @UserPass WHERE UserName = @UserName";
				exec = new SqlCommand();
				exec.CommandText = sqlUp;
				exec.Connection = con;
				exec.Parameters.AddWithValue("@UserPass", getMd5(pass));
				exec.Parameters.AddWithValue("@UserName", name_user);
			 int read =	exec.ExecuteNonQuery();
				if (String.IsNullOrEmpty(textBox2.Text))
				{
					toolStripStatusLabel1.ForeColor = Color.Red;
					toolStripStatusLabel1.Text = "Lỗi để trống";
				}
				else
				{
					if (read == -1)
					{
						MessageBox.Show("Thất bại");
					}
					else
					{
						MessageBox.Show("Thành công, đang quay trở lại trang");
						FormLogin f1 = new FormLogin();
						f1.Show();
						this.Hide();
					}
				}
				



				//exec = new SqlCommand(sql1, con);
				//read = exec.ExecuteReader();
				//if (read.Read())
				//{
				
				//}else {
				//	MessageBox.Show("Lỗi :)");
				//}
				con.Close();
			}catch(SqlException se)
			{
				toolStripStatusLabel1.ForeColor = Color.Red;
				toolStripStatusLabel1.Text = "Lỗi sql";
			}
		}

		private void button4_Click(object sender, EventArgs e)
		{
			textBox1.Text = "";
			button1.Enabled = true;
			textBox1.Enabled = true;
			textBox2.Visible = false;
			button2.Visible = false;
			label2.Visible = false;
			toolStripStatusLabel1.Visible = false;
		}
	}
}
