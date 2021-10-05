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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int chiSoCu = Convert.ToInt32(textBox3.Text);
            int chiSoMoi = Convert.ToInt32(textBox4.Text);
            int chSoVuotMuc;
            int chSoTrongMuc;

            int Tong;
            Tong = chiSoMoi - chiSoCu;
            if (Tong < 0)
            {
                MessageBox.Show("Chỉ số cũ ko đc hơn chỉ số mới");

            }
            else
            {
                textBox5.Text = Convert.ToString(Tong);
            }
            
            
            if (Tong <= 50 && Tong >= 0)
            {
                int total = Convert.ToInt32(textBox5.Text) * 500;
                textBox1.Text = Convert.ToString(total);
            }
            else if (Tong > 50)
            {
                chSoTrongMuc = 50;
                textBox6.Text = Convert.ToString(chSoTrongMuc);
                chSoVuotMuc = Tong - 50;
                textBox7.Text = Convert.ToString(chSoVuotMuc);
                int a = chSoTrongMuc * 500;
                int b = chSoVuotMuc * 1000;
                int Total = a + b;
                textBox1.Text = Convert.ToString(Total);
            } 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String sokwtieuthu = textBox5.Text;
            String tongtien = textBox1.Text;
            textBox2.Text = comboBox1.Text;
            textBox2.Text = textBox2.Text + Environment.NewLine + "Số kw tiêu thụ:" + sokwtieuthu + Environment.NewLine + "Tổng tiền:" + tongtien;
        }
    }
}
