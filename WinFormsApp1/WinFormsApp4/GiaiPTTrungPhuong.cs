using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp4
{
    public partial class GiaiPTTrungPhuong : Form
    {
        public GiaiPTTrungPhuong()
        {
            InitializeComponent();
            label7.Visible = false;
            label10.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label7.Visible = true;
            label10.Visible = true;
            double a = Convert.ToDouble(textBox1.Text);
            double b = Convert.ToDouble(textBox2.Text);
            double c = Convert.ToDouble(textBox3.Text);
            double delta = Math.Pow(b, 2) - (4 * a * c);
            if (delta > 0)
            {
                label7.Text = "Phương trình có 4 nghiệm";
                double t1_tu = -b + Math.Sqrt(delta);
                double t1_mau = 2 * a;
                double t1 = t1_tu / t1_mau;

                double t2_tu = -b - Math.Sqrt(delta);
                double t2_mau = 2 * a;
                double t2 = t2_tu / t2_mau;
                if (t1 > 0)
                {
                    t1 = Math.Sqrt(t1);
                    label10.Text = ("x1 = " + t1 + " và " + "x2 = " + -t1);
                }
                else if (t1 == 0)
                {
                    label10.Text = ("x1 = 0");
                }
                else
                {
                    label10.Text = "cả 2 nghiệm x1 x2 đặt ẩn của nó không thỏa mãn";
                }
                

                if (t2 > 0)
                {
                    t2 = Math.Sqrt(t2);
                   label10.Text = label10.Text + "\n" + ("x3 = " + t2 + " và " + "x4 = " + -t2);
                }
                else if (t2 == 0)
                {
                    label10.Text = label10.Text + "\n" + (" x3 = 0");
                }
                else
                {
                    label10.Text = label10.Text + "\n" + "cả 2 nghiệm x3 x4 đặt ẩn của nó không thỏa mãn";
                }

            }
            else if(delta == 0)
            {
                double t = -b / (2 * a);
                label7.Text = ("Phương trình có nghiệm kép");
                if(t > 0)
                {
                    t = Math.Sqrt(t);
                    label10.Text =   ("x1 = " + t + " và " + "x2 = " + -t);
                }
                else if(t == 0)
                {
                    label10.Text = "x = 0";
                }
                else
                {
                    label10.Text = "Phương trình ko có nghiệm";
                }
            }
            else
            {
                label7.Text = ("phương trình vô nghiệm");
                label10.Visible = false;
            }
           
        }
    }
}
