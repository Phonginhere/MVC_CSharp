using System;

namespace ConsoleApp_WCF_Student
{
	class Program
	{
		static void Main(string[] args)
		{
			ServiceReference1.Service1Client mc = new ServiceReference1.Service1Client();
			var list = mc.getStudentsAsync();
			foreach(var s in list.Result) {
				Console.WriteLine("Id: " + s.StudentId + " Name: " + s.StudentName + " Cmt: " + s.StudentCmt);
			}
			Console.ReadLine();
		}
	}
}
