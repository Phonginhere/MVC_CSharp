using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    //tính ko đóng gói là hiện trạng thái và chức năng bên trong của một đối tượng khi truy cập trực tiếp công khai chúng
    class ConCua_11
    {
        public int x;
        public int y;
        public String name;
    }
    public class Test_Cua_11
    {
        public void FunctionTestCua()
        {
            Console.OutputEncoding = Encoding.Unicode; Console.InputEncoding = Encoding.Unicode;
            List<ConCua_11> List_Cua_11 = new List<ConCua_11>();
            for(int i = 0; i < 5; i++)
            {
                Console.WriteLine("tọa độ thứ: "+(i + 1));
                ConCua_11 c = new ConCua_11();
                Console.Write("Nhập tọa độ x= "); String sx = Console.ReadLine();
                try
                {
                    c.x = Convert.ToInt32(sx);
                }catch(Exception x) { }
                Console.Write("Nhập tọa độ y= "); String sy = Console.ReadLine();
                try
                {
                    c.y = Convert.ToInt32(sy);
                }
                catch (Exception x) { }
                List_Cua_11.Add(c);

            }
            foreach(ConCua_11 clist in List_Cua_11)
            {
                Console.WriteLine("X= " + clist.x + " Y= " +clist.y);
            }
            
        }
    }
}
