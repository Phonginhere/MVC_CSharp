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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
       
        SqlConnection connect = null;

        private void comboBox1_DisplayMemberChanged(object sender, EventArgs e)
        {
            
        }
    }
}
