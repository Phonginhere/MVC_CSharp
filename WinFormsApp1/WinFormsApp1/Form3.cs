using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form3 : Form
    {
        Graphics g = null;
        public Form3()
        {
            InitializeComponent();
        }
        Pen p = new Pen(Color.Red, 3);
        Pen p2 = new Pen(Color.Blue, 4);
        Font f = new Font("Tahoma", 11);
        Font f2 = new Font("Tahoma", 15, FontStyle.Bold);
        Brush b = Brushes.Pink;

        List<Product> listProduct = new List<Product>();
        private void button1_Click(object sender, EventArgs e)
        {
            printPreviewControl1.Document = printDocument1;
            printDocument1.PrintPage += PrintDocument1_PrintPage;
            createOrder();
            PrintPreviewDialog ppd = new PrintPreviewDialog();
            ppd.Document = printDocument1;
            ppd.ShowDialog();
        }
        int i = 0, k = 40, IL = 200;
        private void PrintDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            g = e.Graphics;
            i = i + k;
            g.DrawString("Hóa đơn bán hàng", f2, b, 50, i);
           foreach(Product p in listProduct)
            {
                i = i + k;
                g.DrawString(p.Name, f, b, 50, i);
                g.DrawString(p.Price.ToString(), f, b, 100 + IL, i);
                g.DrawString(p.Quality.ToString(), f, b, 75 + IL + IL, i);
                g.DrawString(""+ (p.Price*p.Quality), f, b, 50 + IL + IL + IL, i);
                g.DrawString("\n.....................................................................................................................................................", f, b, 50, i);
            }
        }
        void createOrder()
        {
            Product p1 = new Product() { Name = "Mì Gấu Đỏ chua cay", Price = 2500, Quality = 3 };
            Product p2 = new Product() { Name = "Mì Gà Sợi Phở Gấu đỏ", Price = 3500, Quality = 4 };
            Product p3 = new Product() { Name = "Gội Rejoice thái mềm mượt 600g", Price = 65000, Quality = 1 };
            listProduct.Add(p1);
            listProduct.Add(p2);
            listProduct.Add(p3);
        }
    }
}
