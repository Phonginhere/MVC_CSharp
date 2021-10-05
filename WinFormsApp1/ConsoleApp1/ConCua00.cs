using ImTools;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    //tính đóng gói: ẩn giấu trạng thái chức năng bên trong của một đối tượng và chỉ gọi thông qua một nhóm chức năng công khai 
    class ConCua00
    {
        private int _x;
        private int _y;
        private String name;
        public void InputXY()
        {
            Console.Write("Nhập ToaDo x= "); String sx = Console.ReadLine();
            try
            {
                this._x = Convert.ToInt32(sx);
            }
            catch (Exception x)
            {
            }
            Console.Write("Nhập ToaDo y= "); String sy = Console.ReadLine();
            try
            {
                this._y = Convert.ToInt32(sy);
            }
            catch (Exception x)
            {
            }
        }
        public void show()
        {
            Console.WriteLine("X= " + _x + ", Y= " + _y);
        }
      
    }
    public class TestConCua00
    {
       public void FunctionTestCua()
        {
            Console.OutputEncoding = Encoding.Unicode; Console.InputEncoding = Encoding.Unicode;
            List<ConCua00> List_Cua_00 = new List<ConCua00>();
            for(int i = 0; i < 5; i++)
            {
                ConCua00 c = new ConCua00();
                Console.WriteLine("Tọa độ thứ "+(i + 1));
                c.InputXY();
                List_Cua_00.Add(c);
            }
            foreach(ConCua00 clist in List_Cua_00)
            {
                clist.show();
            }
        }
    }
}
