using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp4
{
    public partial class Form4 : Form
    {
       
        String chuoiKetNoi = @"Data Source=DESKTOP-FERTOLL\PHONGTRAN;Initial Catalog=QuanLySinhVien;User ID=sa;Password=1234567";
        string sql;
        SqlConnection ketnoi;
        SqlCommand thuchien;
        SqlDataReader docdulieu;
        int i = 0;
        
        public Form4()
        {
            InitializeComponent();
            dateTimePicker1.CustomFormat = "yyyy/MM/dd";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            ketnoi = new SqlConnection(chuoiKetNoi);
            hienthi();
            dataGridView1.Columns[3].DefaultCellStyle.Format = "dd/MM/yyyy";
        }
        public void hienthi()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT MaSV, HoSV, TenSV,NgaySinh, Gender, MaKhoa FROM SinhVien", chuoiKetNoi); //truy xuat du lieu
            DataSet ds = new DataSet();// tao doi tuong bo nho dem trong nguon du lieu
            da.Fill(ds, "SinhVien"); //doi tuong do lap day du lieu cua bang sinh vien
            dataGridView1.DataSource = ds.Tables["SinhVien"].DefaultView;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string MaSV = textBox1.Text;
            string HoSV = textBox4.Text;
            string TenSV = textBox6.Text;
            string NgaySinh = dateTimePicker1.Text;
           
            string Gender = textBox3.Text;
            string MaKhoa = textBox5.Text;

            SqlConnection con = new SqlConnection(chuoiKetNoi);
            con.Open();
            string sql = "INSERT INTO SinhVien VALUES ('" + MaSV + "','" + HoSV + "','" + TenSV + "','" + NgaySinh + "',N'" + Gender + "','" + MaKhoa + "')";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Thêm vào thành công!!!");
            dataGridView1.CancelEdit();
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = null;
            hienthi();
             textBox1.Text = "";
              textBox4.Text = "";
            textBox6.Text = "";
             textBox3.Text = "";
            textBox5.Text = "";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
         
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string MaSV = textBox1.Text;
                string HoSV = textBox4.Text;
                string TenSV = textBox6.Text;
                string NgaySinh = dateTimePicker1.Text;
                string Gender = textBox3.Text;
                string MaKhoa = textBox5.Text;

                textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                textBox4.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                textBox6.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                dateTimePicker1.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                textBox3.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                textBox5.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string MaSV = textBox1.Text;
            string HoSV = textBox4.Text;
            string TenSV = textBox6.Text;
            string NgaySinh = dateTimePicker1.Text;
            string Gender = textBox3.Text;
            string MaKhoa = textBox5.Text;

            SqlConnection con = new SqlConnection(chuoiKetNoi);
            con.Open();
            string sql = "UPDATE  SinhVien SET MaSV ='" + MaSV + "',HoSV ='" + HoSV + "',TenSV ='" + TenSV + "',NgaySinh ='" + NgaySinh + "',Gender ='" + Gender + "',MaKhoa ='" + MaKhoa + "' WHERE MaSV ='" + MaSV + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Sửa thành công!!!");
            dataGridView1.CancelEdit();
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = null;
            hienthi();
            textBox1.Text = "";
            textBox4.Text = "";
            textBox6.Text = "";
            textBox3.Text = "";
            textBox5.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string MaSV = textBox1.Text;

            SqlConnection con = new SqlConnection(chuoiKetNoi);
            con.Open();
            string sql = "DELETE FROM SinhVien WHERE MaSV ='" + MaSV + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Xóa thành công!!!");
            dataGridView1.CancelEdit();
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = null;
            hienthi();
            textBox1.Text = "";
            textBox4.Text = "";
            textBox6.Text = "";
            textBox3.Text = "";
            textBox5.Text = "";
        }
    }
}
