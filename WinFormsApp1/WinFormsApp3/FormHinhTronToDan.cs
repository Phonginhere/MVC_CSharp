using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp3
{
    public partial class FormHinhTronToDan : Form
    {
        public FormHinhTronToDan()
        {
            InitializeComponent();
            g = panel1.CreateGraphics();
            timer1.Enabled = true;
        }
        Graphics g = null;
        int i = 0;
        Pen p = new Pen(Color.Red, 7);
        Brush b = Brushes.Pink;

        private void timer1_Tick(object sender, EventArgs e)
        {
            g.Clear(Color.Wheat);
            if(i > 100) { i = 0; g.Clear(Color.Wheat); }
            if(g != null)
            {
                g.DrawEllipse(p, panel1.Width / 2 - i / 2, panel1.Height / 2 - i / 2, i, i);
            }
            i += 4;
        }
    }
}
