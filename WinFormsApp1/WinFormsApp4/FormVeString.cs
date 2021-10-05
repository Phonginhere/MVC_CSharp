using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp4
{
    public partial class FormVeString : Form
    {
        public FormVeString()
        {
            InitializeComponent();
            
            
        }

        private void PrintDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //throw new NotImplementedException();
            Graphics g = null;
            g = e.Graphics;
            g.Clear(Color.White);
            Font f = new Font("Arial", 23, FontStyle.Regular);
            Brush b = Brushes.Purple;
            String name = "Tuan.nv";
            int x = 30, y = 50;
            g.DrawString("Vẽ hàng ngang", f, b, x, y);
            for(int i = 0; i < 6; i++)
            {
                g.DrawString(name, f, b, x, y + 50);
                x = x + 120;
            }
            x = 50;
            g.DrawString("Vẽ hàng dọc", f, b, x, y + 100);
            for (int i = 0; i < 6; i++)
            {
                g.DrawString(name, f, b, x, y + 160);
                y = y + 50;
            }
            x = 50;
            g.DrawString("Vẽ hàng chéo", f, b, x, y + 180);
            
            for(int i = 0; i < 6; i++)
            {
                g.DrawString(name, f, b, x, y + 220);
                x = x + 30; y = y + 50;
            }
            x = 50;
            g.DrawString("Vẽ hình chữ nhật", f, b, x, y + 250);
            for (int i = 0; i < 6; i++)
            {
                g.DrawString("*********************", f, b, x, y + 280);
                 y = y + 25;
            }
        }

        private void btnClick_Click(object sender, EventArgs e)
        {
            printDocument1.PrintPage += PrintDocument1_PrintPage;
            printPreviewControl1.Document = printDocument1;
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();

        }
    }
}
