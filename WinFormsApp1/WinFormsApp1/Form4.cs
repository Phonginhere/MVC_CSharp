using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WinFormsApp1
{
    
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String cs = @"Data Source=DESKTOP-FERTOLL\SQLEXPRESS;Initial Catalog=DEMO_BLOG;Integrated Security=True";
            SqlConnection conn = new SqlConnection(cs);
        }
    }
