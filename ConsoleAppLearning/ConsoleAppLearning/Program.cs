using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppLearning
{
	public class User
	{
		public int UserID { get; set; }
		public String UserName { get; set; }
		public String UserAddress { get; set; }
		public String UserPhone { get; set; }
		public void input()
		{
			
			Console.WriteLine("Nhập tên: "); UserName = Console.ReadLine();
			Console.WriteLine("Nhập địa chỉ: "); UserAddress = Console.ReadLine();
			Console.WriteLine("Nhập số điện thoại: "); UserPhone = Console.ReadLine();

		}
		public void show()
		{
			Console.WriteLine( "ID: " + UserID + "Tên: " + UserName + "Địa chỉ: " + UserAddress + "Số điện thoại: " + UserPhone);
		}
	}
	public class Program
	{
		static List<User> userList = new List<User>();
		static void Main(string[] args)
		{
			Console.OutputEncoding = Encoding.Unicode;
			Console.InputEncoding = Encoding.Unicode;
			Console.WriteLine("Hello World!");

			while (true)
			{
				Console.WriteLine("Nhập số: "); int a = Convert.ToInt32(Console.ReadLine());
				switch (a)
				{
					case 1:
						User u = new User();
						u.input();
						userList.Add(u);
						break;
					case 2:
						foreach (var i in userList)
						{
							i.show();
						}
						break;
					case 3: break;
				}
			}
			

		}
	}
}
