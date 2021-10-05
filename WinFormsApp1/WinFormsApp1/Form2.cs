using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
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
            Graphics g = null;
            g = e.Graphics;
            g.Clear(Color.White);
            Brush b = Brushes.Black;

            Font f = new Font("Arial", 23, FontStyle.Bold);
            Font f1 = new Font("Arial", 23, FontStyle.Regular);
            Pen pp = new Pen(Color.Blue, 3);
            String texttop1 = "HELLOVIMART";
            String texttop2 = "392 ĐƯỜNG MỸ ĐÌNH";
            String texttop3 = "0977638566";

            g.DrawString(texttop1, f, b, 50, 20);
            g.DrawString(texttop2, f1, b, 50, 60);
            g.DrawString(texttop3, f1, b, 50, 100);

            String main = "Đơn Hàng";

            g.DrawString(main, f, b, 350, 150);

            String info = "Số: " + "SON258896";
            String info1 = "Ngày: " + "01-01-2021";
            String info2 = "Khách Hàng: " + "Khách lẻ";

            g.DrawString(info, f, b, 40, 200);
            g.DrawString(info1, f, b, 400, 200);
            g.DrawString(info2, f, b, 40, 240);

            String line = "....................................................................................";

            g.DrawString(line, f, b, 40, 300);

            String headertable = "Tên sản phẩm";
            String headertable2 = "SL";
            String headertable3 = "Đơn Giá";
            String headertable4 = "Thành Tiền";

            g.DrawString(headertable, f1, b, 40, 360);
            g.DrawString(headertable2, f1, b, 300, 360);
            g.DrawString(headertable3, f1, b, 450, 360);
            g.DrawString(headertable4, f1, b, 600, 360);

            String line2 = "....................................................................................";

            g.DrawString(line2, f, b, 40, 400);

            String maintableline1_1 = "Mì gấu đỏ chua"+"\ncay";
            String maintableline1_2 = "6";
            String maintableline1_3 = "2,500";
            String maintableline1_4= "15,000";

            g.DrawString(maintableline1_1, f, b, 40, 450);
            g.DrawString(maintableline1_2, f, b, 300, 450);
            g.DrawString(maintableline1_3, f, b, 450, 450);
            g.DrawString(maintableline1_4, f, b, 600, 450);

            String line3 = "....................................................................................";

            g.DrawString(line3, f, b, 40, 500);

            String maintableline2_1 = "Mì gà sợi phở" + "\n Gấu Đỏ";
            String maintableline2_2 = "2";
            String maintableline2_3 = "2,500";
            String maintableline2_4 = "5,000";

            g.DrawString(maintableline2_1, f, b, 40, 550);
            g.DrawString(maintableline2_2, f, b, 300, 550);
            g.DrawString(maintableline2_3, f, b, 450, 550);
            g.DrawString(maintableline2_4, f, b, 600, 550);

            String line4 = "....................................................................................";

            g.DrawString(line4, f, b, 40, 600);

            String maintableline3_1 = "gội rejoice thái " + "\nmềm mượt 600g";
            String maintableline3_2 = "1";
            String maintableline3_3 = "89,000";
            String maintableline3_4 = "89,000";

            g.DrawString(maintableline3_1, f, b, 40, 650);
            g.DrawString(maintableline3_2, f, b, 300, 650);
            g.DrawString(maintableline3_3, f, b, 450, 650);
            g.DrawString(maintableline3_4, f, b, 600, 650);

            String line5 = "....................................................................................";

            g.DrawString(line5, f, b, 40, 700);

            String TotalName = "Cộng Tiền Hàng";
            String discountName = "Chiết Khấu";
            String payMoneyName = "Khách Phải Trả";
            String payMoney2Name = "Tiền Khách Đưa";
            String refundsName = "Trả Lại";

            g.DrawString(TotalName, f, b, 40, 750);
            g.DrawString(discountName, f, b, 40, 800);
            g.DrawString(payMoneyName, f1, b, 40, 850);
            g.DrawString(payMoney2Name, f, b, 40, 900);
            g.DrawString(refundsName, f, b, 40, 950);

            String Total = "109,000";
            String discount = "0";
            String payMoney = "109,000";
            String payMoney2 = "109,000";
            String refunds = "0";

            g.DrawString(Total, f, b, 600, 750);
            g.DrawString(discount, f, b, 600, 800);
            g.DrawString(payMoney, f, b, 600, 850);
            g.DrawString(payMoney2, f, b, 600, 900);
            g.DrawString(refunds, f, b, 600, 950);


            String wish = "Xin cảm ơn quý khách. Hẹn Gặp Lại!!!";
        }
    }
}
