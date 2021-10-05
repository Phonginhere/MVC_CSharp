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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
            showTable();
            button4.Enabled = false;
            button5.Enabled = false;
        }
        String connectdb = @"Data Source=DESKTOP-FERTOLL\PHONGTRAN;Initial Catalog=QuanLyKhoa;User ID=sa;Password=1234567;";
        String sql = "SELECT * FROM Khoa";
        SqlConnection con = null;
        SqlCommand execute = null;
        SqlDataAdapter readdata = null;
        public void showTable()
        {
            readdata = new SqlDataAdapter(sql, connectdb);
            DataSet ds = new DataSet();
            readdata.Fill(ds, "Khoa");
            dataGridView1.DataSource = ds.Tables["Khoa"].DefaultView;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
             con = new SqlConnection(connectdb);
            con.Open();
            String maKhoa = textBox1.Text;
            String tenKhoa = textBox3.Text;
            String sqlUp = "UPDATE Khoa Set Khoa_Id = @Khoa_Id, Khoa_Ten = @Khoa_Ten WHERE Khoa_Id = @Khoa_Id";
            execute = new SqlCommand();
            execute.CommandText = sqlUp;
            execute.Connection = con;
            execute.Parameters.AddWithValue("@Khoa_Ten", tenKhoa);
            execute.ExecuteNonQuery();
            con.Close();
            dataGridView1.CancelEdit();
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = null;
            
            showTable();
            dataGridView1.Columns[0].Width = 250; dataGridView1.Columns[1].Width = 350;
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            String maKhoa = textBox1.Text;
            String tenKhoa = textBox3.Text;
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            readdata.Fill(ds, "Khoa");
            dataGridView1.DataSource = ds.Tables["Khoa"].DefaultView;
            int colCount = ds.Tables[0].Rows.Count;
            textBox2.Text = Convert.ToString(colCount);
        }
    }
}
