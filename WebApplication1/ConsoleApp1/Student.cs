using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
	public class Student : TableEntity
	{
		public string name { get; set; }
		public string email { get; set; }
		public string mark { get; set; }
		public string comment { get; set; }
	}
}
