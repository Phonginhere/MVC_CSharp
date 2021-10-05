using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp4
{
    public partial class findSinhVien : Form
    {
        public findSinhVien()
        {
            InitializeComponent();
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            dateTimePicker1.Enabled = false;
        }
        String sqlcon = @"Data Source=DESKTOP-FERTOLL\PHONGTRAN;Initial Catalog=QuanLyKhoa;User ID=sa;Password=1234567";
        SqlConnection con;
        SqlCommand exec;
        SqlDataReader redata;
        SqlDataAdapter sda;
 
        private void button1_Click(object sender, EventArgs e)
        {

            dataGridView1.DataSource = getInfoList();
        }
       
        private DataTable getInfoList()
        {
            Object selectedItem = comboBox1.SelectedItem;
            String sql = "SELECT Khoa_Id, Socre_id_MonThi,Score_num FROM DiemThi AS dt LEFT JOIN Khoa AS k ON dt.Score_id_Khoa = k.Khoa_Id  where Score_id_SinhVien = '" + selectedItem + "'";

            DataTable dtInfo = new DataTable();
            
            using (SqlConnection con = new SqlConnection(sqlcon))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    dtInfo.Load(reader);
                }
            }
            return dtInfo;
        }
        
        private void t(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Object selectedItem = comboBox1.SelectedItem;
            con = new SqlConnection(sqlcon);
            exec = new SqlCommand();
            con.Open();
            exec.Connection = con;
            exec.CommandText = "select * from SinhVien as sv LEFT JOIN DiemThi AS dt ON dt.Score_id_SinhVien = sv.SinhVien_id  where SinhVien_id = '" + selectedItem+"'";
            redata = exec.ExecuteReader();
            while (redata.Read())
            {
                textBox1.Text = redata["SinhVien_fullName"].ToString();
                dateTimePicker1.Text = redata["SinhVien_DOB"].ToString();
                textBox3.Text = redata["SinhVien_Gender"].ToString();
                textBox2.Text = redata["Score_id_Khoa"].ToString();
            }
            
        }

        private void findSinhVien_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(sqlcon);
            exec = new SqlCommand();
            con.Open();
            exec.Connection = con;
            exec.CommandText = "Select SinhVien_id from SinhVien";
            redata = exec.ExecuteReader();
            while (redata.Read())
            {
                comboBox1.Items.Add(redata["SinhVien_id"]);

            }
            con.Close();
           
        }
    }
}
