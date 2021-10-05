using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTest
{
	class Program
	{
		static void Main(string[] args)
		{
			int n = 0;
			do
			{
				Console.WriteLine("Input n rooms: "); n = Convert.ToInt32(Console.ReadLine());

			} while (!(n >= 1 && n <= 40000));
			List<DateTime> checkIn = new List<DateTime>();
			List<DateTime> checkOut = new List<DateTime>();
			List<TimeSpan> subtractdate = new List<TimeSpan>(); 
			DateTime checkInTime;
			DateTime checkOutTime;
			for (int i = 0; i < n; i++)
			{
				Console.WriteLine("Room " + (i + 1));
				
				Console.WriteLine("Input check in time: "); checkInTime = DateTime.Parse(Console.ReadLine());
				checkIn.Add(checkInTime);
				Console.WriteLine("Input check out time: "); checkOutTime = DateTime.Parse(Console.ReadLine());
				checkOut.Add(checkOutTime);

				System.TimeSpan ts = checkOutTime.Subtract(checkInTime);
				subtractdate.Add(ts);
			}
			foreach(var i in subtractdate)
			{
				Console.WriteLine("date sub: " +i);
				Console.ReadKey();
			}
		}
	}
}
