using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp3
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            for(int i = 1; i <= 31; i++)
            {
                comboBox1.Items.Add(i);
            }
            for (int i = 1; i <= 12; i++)
            {
                comboBox2.Items.Add(i);
                
            }
            for (int i = 1960; i <= 2021; i++)
            {
                comboBox3.Items.Add(i);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            String text_name = textBox1.Text;
            String day = (comboBox1.SelectedItem.ToString());
            String month = (comboBox2.SelectedItem.ToString());
            String year = (comboBox3.SelectedItem.ToString());
            String desc = textBox2.Text;
            String combineday = day + "/" + month + "/" + year;
            listBox1.Items.Add(text_name);

            listBox1.Items.Add(day);
            listBox1.Items.Add(month);
            listBox1.Items.Add(combineday);
            listBox1.Items.Add(desc);
        }
    }
}
