using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp4
{
    public partial class FormDichVuKhamBenh : Form
    {
        public FormDichVuKhamBenh()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            for (int i = listBox1.SelectedIndices.Count - 1; i >= 0; i--)
            {
                String a = listBox1.SelectedItem.ToString();
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                //listBox1.Items.RemoveAt(listBox1.SelectedIndices[i]); //neu cai nay dung thay cho dong ben tren thì cx đc
                listBox2.Items.Add(a);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String fullname = textBox5.Text;
            String day =( textBox2.Text);
            String month = (textBox3.Text);
            String year = (textBox4.Text);

            //if (textBox1.TextLength == 0 || textBox2.TextLength == 0 || textBox3.TextLength == 0 || textBox4.TextLength == 0 || textBox5.TextLength == 0 || listBox2.Items.Count == 0)
            //{
            //    MessageBox.Show("không được để trống");
            //}
             if (Convert.ToInt32(day) > 31 || Convert.ToInt32(day) < 1)
            {
                MessageBox.Show("nhập sai ngày, xin mời nhập lại");
            }else if(Convert.ToInt32(month) > 12 || Convert.ToInt32(month) < 1)
            {
                MessageBox.Show("nhập sai tháng, xin mời nhập lại");
            }
            else
            {
                string text = "";
                foreach (var item in listBox2.Items)
                {
                    text += item.ToString() + ", "; // /n to print each item on new line or you omit /n to print text on same line
                }
                textBox1.Text = "Họ tên: " + fullname+ Environment.NewLine + "Ngày sinh: " + (day) + "/" + month + "/" + year + Environment.NewLine + "Dịch vụ đã chọn: " + text;
            }
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            for (int i = 0; i < listBox2.Items.Count; i++)
            {
                listBox1.Items.Add(listBox2.Items[i].ToString());
            }
            listBox2.Items.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        String caution = "Hãy nhập số!!";
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if(System.Text.RegularExpressions.Regex.IsMatch(textBox2.Text, "[^0-9]"))
    {
                MessageBox.Show(caution);
                textBox2.Text = textBox2.Text.Remove(textBox2.Text.Length - 1);
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox3.Text, "[^0-9]"))
            {
                MessageBox.Show(caution);
                textBox3.Text = textBox3.Text.Remove(textBox3.Text.Length - 1);
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox4.Text, "[^0-9]"))
            {
                MessageBox.Show(caution);
                textBox4.Text = textBox4.Text.Remove(textBox4.Text.Length - 1);
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = listBox2.SelectedIndices.Count - 1; i >= 0; i--)
            {
                String a = listBox2.SelectedItem.ToString();
                listBox2.Items.RemoveAt(listBox2.SelectedIndex);
                //listBox1.Items.RemoveAt(listBox2.SelectedIndices[i]); //neu cai nay dung thay cho dong ben tren thì cx đc
                listBox1.Items.Add(a);
            }
        }
    }
}
