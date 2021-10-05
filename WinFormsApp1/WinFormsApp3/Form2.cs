using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp3
{
    public partial class Form2 : Form
    {
        Dictionary<String, String[]> listTuDien = new Dictionary<string, string[]>();
        public Form2()
        {
            InitializeComponent();
            listBox2.Items.Clear();
            String[] web1 = {"www.tamga.tk","www.tamga.us","www.tamga.vn","www.tamga.com","www.tamga.ak"};
            String[] web2 = { "www.c10mt.tk", "www.c10mt.us", "www.c10mt.zn", "www.c10mt.vn", "www.c10mt.com", "www.c10mt.ak" };
            String[] web3 = { "www.c10maytinh.us", "www.c10maytinh.vn", "www.c10maytinh.com"};
            String[] web = { "tamga", "c10mt", "c10maytinh" };
            listTuDien.Add(web[0], web1);
            listTuDien.Add(web[1], web2);
            listTuDien.Add(web[2], web3);
            listBox1.Items.Clear();
            for(int i = 0; i < web.Length; i++)
            {
                listBox1.Items.Add(web[i]);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            listBox2.Items.Add("Bạn đã chọn site");
            string text = listBox1.GetItemText(listBox1.SelectedItem);
            if (listTuDien.ContainsKey(text))
            {
              

                    string[] value2;
                    if(listTuDien.TryGetValue(text, out value2))
                    {
                    for(int i = 0; i < value2.Length; i++)
                    {
                        listBox2.Items.Add(value2[i]);
                    }
                    
                }
                   
                }
                

            }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    }