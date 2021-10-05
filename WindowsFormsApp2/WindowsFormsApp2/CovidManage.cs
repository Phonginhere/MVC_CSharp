using QRCoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class CovidManage : Form
    {
		SqlConnection con;
		String sql_ketnoi = @"Data Source=DESKTOP-FERTOLL\PHONGTRAN;Initial Catalog=QL_TiemChung;User ID=sa;Password=1234567";
		SqlCommand exec;
		SqlDataReader read;

		public CovidManage()
        {
            InitializeComponent();
			con = new SqlConnection(sql_ketnoi);
			showTable();
			dataGridView1.Columns[5].DefaultCellStyle.Format = "dd/MM/yyyy";
			textBox3.MaxLength = 12;
			button4.Enabled = false;
			button3.Enabled = false;
			
		}
		public void showTable()
		{
			SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM covid_vaccine", sql_ketnoi);
			DataSet ds = new DataSet();
			da.Fill(ds, "covid_vaccine");
			//dataGridView1.DataSource = ds.Tables["covid_vaccine"].Columns[0].DataType.GetDefaultMembers();
			dataGridView1.DataSource = ds.Tables["covid_vaccine"].DefaultView;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			String ten = textBox1.Text;
			String ma = textBox2.Text;
			String cmnd = textBox3.Text;
			String lich_tiem = dateTimePicker1.Value.ToString("dd/MM/yyyy");
			MessageBox.Show(lich_tiem);
			String email = textBox4.Text;
			String district = textBox5.Text;
			try
			{

			}catch(Exception ex){
				if(ex is SqlException)
				{
					MessageBox.Show("Lỗi");
					TextWriter errorWriter = Console.Error;
					errorWriter.WriteLine(ex);
				}
				TextWriter errorWriter2 = Console.Error;
				errorWriter2.WriteLine(ex);
			}
			con.Open();
			String sql = "INSERT INTO  values ('"+ma+"',N'"+ten+"','"+email+"','"+cmnd+ "', CONVERT(date, '" +lich_tiem+"' , 103), N'"+district+"')";
			SqlCommand exec = new SqlCommand(sql, con);
			exec.ExecuteReader();
			con.Close();
			MessageBox.Show("Thành công!!");
			textBox1.Text = "";
			textBox2.Text = "";
			textBox3.Text = "";
			textBox4.Text = "";
			textBox5.Text = "";

		}

		private void button2_Click(object sender, EventArgs e)
		{
			dataGridView1.CancelEdit();
			dataGridView1.Columns.Clear();
			dataGridView1.DataSource = null;
			showTable();
			textBox1.Text = "";
			textBox2.Text = "";
			textBox3.Text = "";
			textBox4.Text = "";
			textBox5.Text = "";
			textBox1.Enabled = true;
			textBox2.Enabled = true;
			textBox3.Enabled = true;
			textBox4.Enabled = true;
			textBox5.Enabled = true;
			dateTimePicker1.Enabled = true;
			button4.Enabled = false;
			button3.Enabled = false; ;
		}

		private void button3_Click(object sender, EventArgs e)
		{
			String info = "Thông tin người dân: "+ "Tên: "+ textBox1.Text + Environment.NewLine + "Mã: " + textBox2.Text + Environment.NewLine+ "Số chứng minh nhân dân: " + textBox3.Text + Environment.NewLine+"Email: " + textBox4.Text + Environment.NewLine+"Địa chỉ: " + textBox5.Text+Environment.NewLine+"Lịch: "+dateTimePicker1.Text;
			QRCodeGenerator qr = new QRCodeGenerator();
			QRCodeData data = qr.CreateQrCode(info, QRCodeGenerator.ECCLevel.Q);
			QRCode code = new QRCode(data);
			pictureBox1.Image = code.GetGraphic(2);
			button4.Enabled = true;
		}

		private void button4_Click(object sender, EventArgs e)
		{

			printDocument1.PrintPage += PrintDocument1_PrintPage;
			printPreviewDialog1.Document = printDocument1;
			printPreviewDialog1.ShowDialog();
		}

		private void PrintDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			//throw new NotImplementedException();
			Graphics g = null;
			g = e.Graphics;
			g.Clear(Color.White);
			Font f = new Font("Arial", 23, FontStyle.Regular);
			Font f1 = new Font("Arial", 40, FontStyle.Regular);
			Brush b = Brushes.Purple;
			Brush b1 = Brushes.Red;

			String ten = textBox1.Text;
			String ma = textBox2.Text;
			String cmnd = textBox3.Text;
			String lich_tiem = dateTimePicker1.Value.ToString("dd/MM/yyyy");
			String email = textBox4.Text;
			String district = textBox5.Text;
			int x = 30, y = 50;
			float x1 = 100.0F;
			float y1 = 600.0F;
			RectangleF srcRect = new RectangleF(0F, 10.7F, 250.8F, 250.9F);
			GraphicsUnit units = GraphicsUnit.Pixel;

			g.DrawString("Hộ Chiếu vacxine", f1, b1, x + 150, y);//
			g.DrawString("Mã: "+ma, f, b, x, y + 100);
			g.DrawString("Tên: "+ten, f, b, x, y + 150);
			g.DrawString("Chứng Minh nhân dân: "+cmnd, f, b, x, y + 200);
			g.DrawString("Email: "+email, f, b, x, y + 250);
			g.DrawString("Lịch tiêm: "+lich_tiem, f, b, x, y + 300);
			g.DrawString("Địa Chỉ: "+district, f, b, x, y + 350);
			g.DrawImage(pictureBox1.Image, x1, y1 , srcRect, units);
			g.DrawString("Lưu ý, nên sử dụng khi đi vào quán bar, nhà hàng, vũ đài," + Environment.NewLine+" những nơi tụ tập khách đông người, nhà nghỉ, khách sạn", f, b1, x, y + 850);
			g.DrawString("Được tạo bởi cơ quan có thẩm quyền "+Environment.NewLine+"      và cùng hợp tác với Aptech", f, b1, x + 100, y + 950);

		}

		private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			dataGridView1.ClearSelection();
			textBox1.Text = "";
			textBox2.Text = "";
			textBox3.Text = "";
			textBox4.Text = "";
			textBox5.Text = "";
			textBox1.Enabled = true;
			textBox2.Enabled = true;
			textBox3.Enabled = true;
			textBox4.Enabled = true;
			textBox5.Enabled = true;
			dateTimePicker1.Enabled = true;
			button4.Enabled = false;
			button3.Enabled = false;
			pictureBox1.Image = null;
		}

		private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
		{
			//button4.Enabled = true;
			//textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
			//textBox1.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
			//textBox3.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
			//dateTimePicker1.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
			//textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
			//textBox5.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
			//textBox1.Enabled = false;
			//textBox2.Enabled = false;
			//textBox3.Enabled = false;
			//textBox4.Enabled = false;
			//textBox5.Enabled = false;
			//dateTimePicker1.Enabled = false;
			//button3.Enabled = true;
		}

		private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			int rowmouse = e.RowIndex;
			DataGridViewRow rr = dataGridView1.Rows[rowmouse];
			String id = rr.Cells[0].Value.ToString();
			String ma = rr.Cells[1].Value.ToString();
			String ten = rr.Cells[2].Value.ToString();
			String email = rr.Cells[3].Value.ToString();
			String cmnd = rr.Cells[4].Value.ToString();
			String lich = rr.Cells[5].Value.ToString();
			String diachi = rr.Cells[6].Value.ToString();
			textBox2.Text = ma;
			textBox1.Text = ten;
			textBox3.Text = cmnd;
			textBox4.Text = email;
			textBox5.Text = diachi;
			dateTimePicker1.Text = lich;
			textBox1.Enabled = false;
			textBox2.Enabled = false;
			textBox3.Enabled = false;
			textBox4.Enabled = false;
			textBox5.Enabled = false;
			dateTimePicker1.Enabled = false;
			button3.Enabled = true;
		}
	}
}
