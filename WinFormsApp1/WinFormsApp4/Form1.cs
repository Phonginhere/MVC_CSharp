using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp4
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

        private void PrintDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //throw new NotImplementedException();
            Graphics g = null;
            g = e.Graphics;
            g.Clear(Color.White);
            Brush b = Brushes.Black;
            Font f = new Font("Arial", 23, FontStyle.Regular);
            Pen p = new Pen(Color.Blue, 3);
            String text = textBox1.Text;

            g.DrawString(text, f, b, 50, 20);
        }
    }
}
