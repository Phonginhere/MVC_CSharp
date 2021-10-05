using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp4
{
    public delegate bool checkLogin();
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }
        int _numLogin = 0;
        public int NumberOfLog { get {return _numLogin ;} }
        public event checkLogin checklogin;
        private void UserControl1_Load(object sender, EventArgs e)
        {

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox1.Focus();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (checklogin != null)
            { MessageBox.Show("gọi sự kiên: "); checklogin.Invoke(); }
            else { MessageBox.Show("begin sự kiện là null"); }
            _numLogin++;
        }
    }
}
