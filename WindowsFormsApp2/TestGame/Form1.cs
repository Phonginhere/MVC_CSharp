using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            btnMachine.Enabled = false;
            btnStop.Enabled = false;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            btnStop.Enabled = false;
            btnRun.Enabled = true;
            btnMachine.Enabled = false;
            btnMachine.Visible = false;
        }

        private void btnMachine_KeyDown(object sender, KeyEventArgs e)
        {
            this.Text = "Key Value" + e.KeyValue + ", key code: " + e.KeyCode + "key data: " + e.KeyData;
            // btnRun.Enabled = false;
            // if (btnRun.Enabled = false)
            // {
            if (e.KeyValue == 65)
            {
                if (picturebox.Left > 0) { picturebox.Left -= 4; }
            }
            if (e.KeyValue == 70 || e.KeyValue == 68)
            {
                Console.WriteLine(panel1.Width + "," + panel1.Left);
                if (picturebox.Left < panel1.Width) { picturebox.Left += 4; }
            }
            if (e.KeyValue == 87)
            {
                if (picturebox.Top > 0) { picturebox.Top -= 4; }
            }
            if (e.KeyValue == 83)
            {
                if (picturebox.Bottom > 0) { picturebox.Top += 4; }
            }
            //  }
        }
        private void btnRun_Click(object sender, EventArgs e)
        {
            
            btnRun.Enabled = false;
            btnStop.Enabled = true;
            btnMachine.Enabled = true;
            btnMachine.Visible = true;
        }

      
    }
}
