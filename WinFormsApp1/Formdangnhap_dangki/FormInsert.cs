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

namespace Formdangnhap_dangki
{
    public partial class FormInsert : Form
    {
        public static String lb7 = null;
        public String Lb7 { get { return this.label7.Text;} set { this.label7.Text = value ;} }
        public FormInsert()
        {
            InitializeComponent();
            textBox4.MaxLength = 10;
            textBox2.MaxLength = 14;
            textBox2.PasswordChar = '*';
            Lb7 = label7.Text;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            String tb1 = textBox1.Text;
            String tb2 = textBox2.Text;
            String tb3 = textBox3.Text;
            String tb4 = textBox4.Text;

            int num = -1;

            if (tb1 == "" || tb2 == "" || tb3 == "" || tb4 == "")
            {
                MessageBox.Show("Không được để trống!!");
            }else if (!tb3.Contains('@'))
            {
                MessageBox.Show("Phải có @");
            }else if (!int.TryParse(tb4, out num))
            {
                MessageBox.Show("không phải là dạng số");
            }else if(tb4.Length != 10)
            {
                MessageBox.Show("chưa đầy đủ 10 số");
            }
            else {
                try
                {
                    String db_connect = @"Data Source=DESKTOP-FERTOLL\PHONGTRAN;Initial Catalog=QuanLySinhVien;User ID=sa;Password=1234567;";
                    SqlConnection con = new SqlConnection(db_connect);
                    con.Open();
                    string sql = "INSERT INTO SinhVien VALUES ('" + tb1 + "','" + tb4 + "','" + tb3 + "','" + tb2 + "')";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Thêm vào thành công!!!");
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("lỗi không thể thêm được!!Xin quí khách thông cảm vì sự cố trục trặc này.");
                }
                dataGridView1.CancelEdit();
                dataGridView1.Columns.Clear();
                dataGridView1.DataSource = null; //đặt dữ liệu của đối tượng bảng đó để trống(null)
                showTable();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormDangNhap fr2 = new FormDangNhap();
            this.Hide();
            fr2.Show();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

            switch (MessageBox.Show(this, "Are you sure?", "Do you still want ... ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                //Stay on this form
                case DialogResult.No:
                    e.Cancel = true;
                    break;
                case DialogResult.Yes:
                    e.Cancel = false;
                    break;
                default:
                    break;
            }
          
        }
        public void showTable()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM SinhVien", @"Data Source=DESKTOP-FERTOLL\PHONGTRAN;Initial Catalog=QuanLySinhVien;User ID=sa;Password=1234567"); //truy xuat du lieu
            DataSet ds = new DataSet();// tao doi tuong bo nho dem trong nguon du lieu
            da.Fill(ds, "SinhVien"); //doi tuong do lap day du lieu cua bang sinh vien
            dataGridView1.DataSource = ds.Tables["SinhVien"].DefaultView; //đặt nguồn dữ liệu của đối tượng dgv đó bằng dữ liệu trong bộ nhớ đệm của bảng đó được tùy chỉnh
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            showTable();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                string a = textBox2.Text;
                textBox2.PasswordChar = '\0';
            }
            else
            {
                textBox2.PasswordChar = '*';
            }
        }
    }
}
