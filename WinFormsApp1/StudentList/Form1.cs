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

namespace StudentList
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        String dbConnect = @"data Source=DESKTOP-FERTOLL\PHONGTRAN;Initial Catalog=QuanLySinhVien;User ID=sa";
      

        public void showTable()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM LopHoc", @"Data Source=DESKTOP-FERTOLL\PHONGTRAN;Initial Catalog=QuanLySinhVien;User ID=sa;Password=1234567"); //truy xuat du lieu
            DataSet ds = new DataSet();// tao doi tuong bo nho dem trong nguon du lieu
            da.Fill(ds, "LopHoc"); //doi tuong do lap day du lieu cua bang sinh vien
            dataGridView1.DataSource = ds.Tables["LopHoc"].DefaultView;
        }
        SqlCommand cmd;
        SqlDataReader dr;
        SqlConnection con;
        private void Form1_Load(object sender, EventArgs e)
        {
            showTable();
            con = new SqlConnection(@"Data Source=DESKTOP-FERTOLL\PHONGTRAN;Initial Catalog=QuanLySinhVien;User ID=sa;Password=1234567");
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM LopHoc";
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox2.Items.Add(dr["className"]);
                comboBox3.Items.Add(dr["comment"]);
            }

            con.Close();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            String tb2 = comboBox2.Text;
            String tb3 = comboBox3.Text;
            String db_connect = @"Data Source=DESKTOP-FERTOLL\PHONGTRAN;Initial Catalog=QuanLySinhVien;User ID=sa;Password=1234567;";
            SqlConnection con = new SqlConnection(db_connect);
            con.Open();
            string sql = "INSERT INTO LopHoc VALUES ('" + tb2 + "','" + tb3 + "')";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Thêm vào thành công!!!");
            dataGridView1.CancelEdit();
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = null;
            showTable();
            
        }
    }
}
