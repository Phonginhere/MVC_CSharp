using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ShowColumnName
{
	public class Model
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public double Score { get; set; }
	}

	public class Program
	{
		static void Main(string[] args)
		{
			// This will search for each Attributes applied onto the property
			// to find out whether "Required" exists or not.
			var properties = typeof(Model).GetProperties().Select(p => p);

			// This will output the Name of the assigned public properties.
			
			foreach (var item in properties)
			{
				Console.WriteLine(item.Name);
			}
			Console.WriteLine("nhập đi"); String haha = Console.ReadLine();
		}
	}
}
