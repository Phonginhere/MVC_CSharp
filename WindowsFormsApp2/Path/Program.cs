using System;
using System.IO;
using System.Text;

namespace Path
{
	class Program
	{
		static void Main(string[] args)
		{
			string fileName = @"C:\Users\Phong_learning\OneDrive\Documents\Visual Studio 2015\Projects\WebApplication1\UploadFile\UploadFiles\Podcast-Icon-1.png;";
			FileInfo fi = new FileInfo(fileName);
			string justFileName = fi.Name;
			Console.WriteLine("File Name: " + justFileName);
			Console.WriteLine("haha: "); justFileName = Console.ReadLine();
		}
	}
}
