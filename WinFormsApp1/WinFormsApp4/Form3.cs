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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }


        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        private void Form3_Load(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM LopHoc", @"Data Source=DESKTOP-FERTOLL\PHONGTRAN;Initial Catalog=QuanLySinhVien;User ID=sa;Password=1234567");
            DataSet ds = new DataSet();
            da.Fill(ds, "LopHoc");
            dataGridView1.DataSource = ds.Tables["LopHoc"].DefaultView;
        }

    }
}


