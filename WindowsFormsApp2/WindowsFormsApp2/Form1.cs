using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string result;

            int num = Convert.ToInt32(textBox1.Text);
            result = "";
            while (num > 1)
            {
                int remainder = num % 2;
                Console.WriteLine(remainder);
                result = Convert.ToString(remainder) + result;
                Console.WriteLine("haha: " + result);
                num /= 2;
            }
            result = Convert.ToString(num) + result;
            textBox2.Text = "So trong he nhi phan tuong ung la: "+result;
        }
    }
}
