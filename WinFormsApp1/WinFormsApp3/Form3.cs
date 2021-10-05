using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp3
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();

           
           

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
           
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radio = sender as RadioButton;

            if (radio.Checked)
                textBox2.Enabled = false;
            textBox1.Enabled = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radio = sender as RadioButton;

            if (radio.Checked)
                textBox2.Enabled = true;
            textBox1.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double a = Convert.ToDouble(textBox3.Text);
            double b = Convert.ToDouble(textBox4.Text);
           
            if (radioButton1.Checked == true)
            {
               
                double ketqua = -b / a;
                textBox1.Text = "Pt có nghiệm: "+Convert.ToString(ketqua);
            }
            else if(radioButton2.Checked == true)
            {
                double c = Convert.ToDouble(textBox2.Text);

                double delta1 = Math.Pow(b, 2);
                double delta2 = 4 * a * c;
                double delta = delta1 - delta2;
                
                if(delta > 0)
                {
                    double x1 = (-b + Math.Sqrt(delta)) / (2 * a);
                    double x2 = (-b - Math.Sqrt(delta)) / (2 * a);
                    textBox1.Text = "Pt có 2 nghiệm: " + Convert.ToString(x1) + " và " + Convert.ToString(x2);
                }
                else if(delta == 0)
                {
                    double x = -b / (2 * a);
                    textBox1.Text = "Pt có nghiệm kép: " + Convert.ToString(x);
                }
                else
                {
                    textBox1.Text = "Pt vô nghiệm";
                }
            }
        }
    }
}
