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
	public partial class FormUser : Form
	{
		public FormUser()
		{
			InitializeComponent();
			con = new SqlConnection(sql_con);
			textBox2.PasswordChar = '*';
			showTable();
			for(int i = 1; i < 5; i++)
			{
				comboBox1.Items.Add(i);
			}
			toolStripStatusLabel1.Text = "";
			printToolStripMenuItem.Enabled = false;
			button4.Enabled = false;
			button1.Enabled = false;
			
		}

		

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

		String sql_con = @"Data Source=DESKTOP-FERTOLL\PHONGTRAN;Initial Catalog=UserDB;User ID=sa;Password=1234567;";
		SqlConnection con;
		SqlCommand exec;
		SqlDataReader read;
		DataSet1TableAdapters.UserTableTableAdapter user = new DataSet1TableAdapters.UserTableTableAdapter();
		public void showTable()
		{
			dataGridView1.DataSource = user.GetDataBy();
		}
		private void button1_Click(object sender, EventArgs e)
		{
			textBox1.Text = "";
			textBox2.Text = "";
		}

		private void button3_Click(object sender, EventArgs e)
		{
		
		}

		private void button2_Click(object sender, EventArgs e)
		{
			
			String ma = textBox1.Text;
			String pass = textBox2.Text;
			byte type = Convert.ToByte(comboBox1.Items[comboBox1.SelectedIndex].ToString());
			

			con.Open();
			//String sql = "INSERT INTO UserTable values('"+ma+"', '"+getMd5(pass)+"', '"+type+"')";
			String sqlpm = "INSERT INTO UserTable (UserName, UserPass, UserRole) values(@UserName, @UserPass, @UserRole)";
			exec = new SqlCommand();
			exec.CommandText = sqlpm;
			exec.Connection = con;
			exec.Parameters.AddWithValue("@UserName",ma);
			exec.Parameters.AddWithValue("@UserPass",getMd5(pass));
			exec.Parameters.AddWithValue("@UserRole", Convert.ToString(type));
			int read = exec.ExecuteNonQuery();

			if (read == -1)
			{
				toolStripStatusLabel1.ForeColor = Color.Red;
				toolStripStatusLabel1.Text = "Lỗi không thể thêm được";
			}
			else
			{
				MessageBox.Show("THành Công");
			}
			con.Close();

			dataGridView1.CancelEdit();
			dataGridView1.Columns.Clear();
			dataGridView1.DataSource = null;
			showTable();

			textBox1.Text = "";
			textBox2.Text = "";
		}

		private void button4_Click(object sender, EventArgs e)
		{
			String id = label5.Text;
			con.Open();
			String sql = "Delete from UserTable Where UserID = @UserID";
			exec = new SqlCommand();
			exec.CommandText = sql;
			exec.Connection = con;
			exec.Parameters.AddWithValue("@UserID", id);
			int read = exec.ExecuteNonQuery();
			if (read == -1)
			{
				toolStripStatusLabel1.ForeColor = Color.Red;
				toolStripStatusLabel1.Text = "Lỗi không thể xóa được";
			}
			else
			{
				toolStripStatusLabel1.ForeColor = Color.Green;
				toolStripStatusLabel1.Text = "Xóa thành công";
			}
			con.Close();
			dataGridView1.CancelEdit();
			dataGridView1.Columns.Clear();
			dataGridView1.DataSource = null;
			showTable();

			textBox1.Text = "";
			textBox2.Text = "";
		}

		private void button1_Click_1(object sender, EventArgs e)
		{
			String id = label5.Text;
			String ma = textBox1.Text;
			String pass = textBox2.Text;
			byte type = Convert.ToByte(comboBox1.Items[comboBox1.SelectedIndex].ToString());

			con.Open();
			String sqlUp = "UPDATE UserTable Set UserName = @UserName, UserPass = @UserPass, UserRole= @UserRole  WHERE UserID = @UserID";
			exec = new SqlCommand();
			exec.CommandText = sqlUp;
			exec.Connection = con;
			exec.Parameters.AddWithValue("@UserName", ma);
			exec.Parameters.AddWithValue("@UserPass", getMd5(pass));
			exec.Parameters.AddWithValue("@UserRole", type);
			exec.Parameters.AddWithValue("@UserID", id);

			int read = exec.ExecuteNonQuery();
			if(read == -1)
			{
				toolStripStatusLabel1.ForeColor = Color.Red;
				toolStripStatusLabel1.Text = "Lỗi không thể sửa được";
			}
			else
			{
				toolStripStatusLabel1.ForeColor = Color.Green;
				toolStripStatusLabel1.Text = "Sửa thành công";
			}
			con.Close();
			dataGridView1.CancelEdit();
			dataGridView1.Columns.Clear();
			dataGridView1.DataSource = null;
			showTable();

			textBox1.Text = "";
			textBox2.Text = "";
		}

		private void button5_Click(object sender, EventArgs e)
		{
			
			
		}

		private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			int rowclick = e.RowIndex;
			DataGridViewRow rr = dataGridView1.Rows[rowclick];
			label5.Text = rr.Cells[0].Value.ToString();
			textBox1.Text = rr.Cells[1].Value.ToString();
			//textBox2.Text = rr.Cells[2].Value.ToString();
			comboBox1.Text = rr.Cells[3].Value.ToString();
			printToolStripMenuItem.Enabled = true;
			button4.Enabled = true;
			button1.Enabled = true;
			textBox1.Enabled = false;
			comboBox1.Enabled = false;
			buttonClear.Enabled = false;
			button2.Enabled = false;
		}

		private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			Graphics g = null;
			g = e.Graphics;
			g.Clear(Color.White);
			Font f = new Font("Arial", 23, FontStyle.Regular);
			Brush b = Brushes.Blue;
			String a = label5.Text;
			String bb = textBox1.Text;
			String c = textBox2.Text;
			String d = comboBox1.Text;
			int x = 30, y = 50;

			g.DrawString("id: " + a, f, b, x, y);
			g.DrawString("user name: " + bb, f, b, x, y+100);
			g.DrawString("pass: " + c, f, b, x, y+ 200);
			g.DrawString("type: " + d, f, b, x, y+ 300);


		}

		private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			dataGridView1.ClearSelection();
			label5.Text = "";
			textBox1.Text = "";
			textBox2.Text = "";
			printToolStripMenuItem.Enabled = false;
			button4.Enabled = false;
			button1.Enabled = false;
			textBox1.Enabled = true;
			comboBox1.Enabled = true;
			buttonClear.Enabled = true;
			button2.Enabled = true;
		}

		private void Form2_Load(object sender, EventArgs e)
		{
			label7.Text  = FormLogin.SetValueText1;
			
		}

		private void Form2_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason == CloseReason.UserClosing)
			{
				switch (MessageBox.Show(this, "Are you sure?", "Do you still want ...?", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
				{
					case DialogResult.No: e.Cancel = true; break;
					case DialogResult.Yes: Application.ExitThread(); e.Cancel = false; break;
					default: break;
				}
			}
			if (e.CloseReason == CloseReason.WindowsShutDown)
			{

			}
		}

		private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			DialogResult dr = MessageBox.Show("Do you want to logout or not", "Cảnh Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (dr == DialogResult.Yes)
			{
				FormLogin f1 = new FormLogin();
				f1.Show();
				this.Hide();
			}
		}

		private void printToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (String.IsNullOrEmpty(textBox2.Text))
			{
				toolStripStatusLabel1.ForeColor = Color.Red;
				toolStripStatusLabel1.Text = "Không đc phép để trống";
			}
			else
			{
				printDocument1.PrintPage += printDocument1_PrintPage;
				printPreviewDialog1.Document = printDocument1;
				printPreviewDialog1.ShowDialog();
			}
		}

		private void formCovidToolStripMenuItem_Click(object sender, EventArgs e)
		{
			FormCovid fc = new FormCovid();
			fc.Show();
		}
	}
}
