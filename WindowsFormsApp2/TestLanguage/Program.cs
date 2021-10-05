using System;
using System.Collections;
using System.Globalization;
using System.Data.SqlClient;

namespace TestLanguage
{
	
	public class Program
	{
		static void Main(string[] args)
		{

			SqlConnection conn = new SqlConnection(connString);


			Console.WriteLine("Hello World!");
			ArrayList cultureList = new ArrayList();
			CultureInfo[] cinfo = CultureInfo.GetCultures(CultureTypes.AllCultures);
			foreach(CultureInfo culture in cinfo)
			{
				cultureList.Add(String.Format("Culture Name {0}: Display Name {1}", culture.Name, culture.DisplayName));
			}
			int i = 0;
			foreach(var m in cultureList)
			{
				i++;
				Console.WriteLine(i + "## " + m.ToString());
				Console.In.Read();
			}
			
		}
	}
}
