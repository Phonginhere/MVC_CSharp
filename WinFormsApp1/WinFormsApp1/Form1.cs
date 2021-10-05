using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            printDocument1.PrintPage += PrintDocument1_PrintPage;
            printPreviewControl1.Document = printDocument1;
            PrintPreviewDialog pp = new PrintPreviewDialog();
            pp.Document = printDocument1;
            pp.ShowDialog();
        }
        private void PrintDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            //throw new NotImplementedException();
            Graphics g = null;
            g = null;
            g = e.Graphics;
            g.Clear(Color.White);
            Brush b = Brushes.Blue;
            Brush b3 = Brushes.Red;
            Brush b1 = Brushes.DarkSeaGreen;

            Font f1 = new Font("Helvetica", 24, FontStyle.Underline);
            Pen p = Pens.Purple;
            Pen pp = new Pen(Color.Blue, 3);
            String textToDra = textBox1.Text;

            g.DrawString(textToDra, f1, b3, 70, 20);


            Font f = new Font("Tahoma", 24);
          
            Brush b4 = Brushes.Black;
          
            Font f2 = new Font(f, FontStyle.Regular);
            String s2 = textBox2.Text;
            g.DrawString(s2, f2, b4, 70, 115);


            g.DrawEllipse(new Pen(Color.Red, 10), 100, 200, 100, 150);
        }
    }
}
