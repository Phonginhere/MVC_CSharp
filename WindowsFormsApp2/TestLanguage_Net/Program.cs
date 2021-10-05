using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Collections;
using System.Globalization;

namespace TestLanguage_Net
{
	class Program
	{
		static String sql_con = @"Data Source=DESKTOP-FERTOLL\PHONGTRAN;Initial Catalog=QL_Language_Religion;Integrated Security=True";

		static void Main(string[] args)
		{
			SqlConnection conn = new SqlConnection(sql_con);
			Console.WriteLine("Hello World!");
			ArrayList cultureList = new ArrayList();
			CultureInfo[] cinfo = CultureInfo.GetCultures(CultureTypes.AllCultures);
			foreach (CultureInfo culture in cinfo)
			{
				cultureList.Add(String.Format("Culture Name "+ culture.Name + ": Display Name "+culture.DisplayName));
			}
			int i = 0;
			foreach (var m in cultureList)
			{
				i++;
				String chuoi_language = (i + "## " + m.ToString());
				//String sql = "insert into Religion_Language values ('"+chuoi_language+"')";
				String query = "INSERT INTO dbo.Religion_Language VALUES (@name)";
				SqlCommand command = new SqlCommand(query, conn);
				
				command.Parameters.AddWithValue("@name", chuoi_language);
				//exec = new SqlCommand(sql, conn);
				conn.Open();
				int result = command.ExecuteNonQuery();
				conn.Close();
			}
			
		}
	}
}
