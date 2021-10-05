using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Formdangnhap_dangki
{
    public partial class FormDangNhap : Form
    {
        public FormDangNhap()
        {
            InitializeComponent();
            textBox2.PasswordChar = '*';
            textBox2.MaxLength = 14;
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String tb1 = textBox1.Text;
            String tb2 = textBox2.Text;
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-FERTOLL\PHONGTRAN;Initial Catalog=QuanLySinhVien;User ID=sa;Password=1234567;"); // making connection   
            SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM SinhVien WHERE Email='" + tb1 + "' AND Pass='" + tb2 + "'", con);
            DataTable dt = new DataTable(); 
            sda.Fill(dt);
            if (tb1 == "" || tb2 == "")
            {
                MessageBox.Show("Không được để trống!!");
            }
            else if (!tb1.Contains('@'))
            {
                MessageBox.Show("Phải có @");
            }
            else if(dt.Rows[0][0].ToString() == "0")
            {
                MessageBox.Show("Sai mật khẩu hoặc email, nhập lại");
            }
            else
            {
                FormInsert f1 = new FormInsert();
                string query = "Select Name from SinhVien where Email ='" + tb1 + "'";
                SqlCommand com = new SqlCommand(query, con);
                DataSet ds = new DataSet();
                con.Open();
                
                f1.Lb7 = Convert.ToString(com.ExecuteScalar());
                con.Close();
                MessageBox.Show("Đăng nhập thành công");
               
                this.Hide();
                f1.Show();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
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



        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.WindowsShutDown) return;

          
        }
    }
}
