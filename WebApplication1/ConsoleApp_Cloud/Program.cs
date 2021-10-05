using System;
using Microsoft.Data.SqlClient;
namespace ConsoleApp_Cloud
{
	public class Program
	{
		static String con_String = "Data Source=c1908g00.database.windows.net;Initial Catalog=c1908gDB;User ID=c1908g;Password=1908g123@A;MultipleActiveResultSets=True;Application Name=EntityFramework";

		static SqlConnection cn = new SqlConnection(con_String);
		static void ShowTable()
		{
			String strgetTable = "select * from [LinhsTestTable2]";

			SqlCommand cmd = new SqlCommand(strgetTable, cn);
			cn.Open();
			SqlDataReader mm = cmd.ExecuteReader();
			Console.WriteLine("Day la du lieu cloud");
			while (mm.Read())
			{
				Console.WriteLine("{0} Teen {1}, {2}", mm.GetValue(0).ToString(), mm.GetValue(1).ToString(), mm.GetValue(2).ToString());
			}
			cn.Close();
		}
		static void InsertTable()
		{
			String insertTable = "Insert into [LinhsTestTable2] values (@LinhsComment, @feelings)";
			SqlCommand cmd = new SqlCommand(insertTable, cn);
			cn.Open();

			Console.WriteLine("Input cmt: "); String cmt = Console.ReadLine();
			Console.WriteLine("Input feelings: "); String feel = Console.ReadLine();

			cmd.Parameters.AddWithValue("@LinhsComment", cmt);
			cmd.Parameters.AddWithValue("@feelings", feel);

			int check = cmd.ExecuteNonQuery();

			if (check > 0)
			{
				Console.WriteLine("insert thanh cong");
			}
			else
			{
				Console.WriteLine("insert fail");
			}
			cn.Close();
		}
		static void UpdateTable(int id, string cmt, string feel)
		{
			String insertTable = "Update [LinhsTestTable2] Set LinhsComment = @LinhsComment, feelings = @feelings where TestId = @TestId";
			SqlCommand cmd = new SqlCommand(insertTable, cn);
			cn.Open();

			if (!(String.IsNullOrEmpty(feel)) && !(String.IsNullOrEmpty(cmt)))
			{
				cmd.Parameters.AddWithValue("@LinhsComment", cmt);
				cmd.Parameters.AddWithValue("@feelings", feel);
			}
			else if (!(String.IsNullOrEmpty(cmt)))
			{
				cmd.Parameters.AddWithValue("@feelings", feel);
			}
			else if (!(String.IsNullOrEmpty(feel)))
			{
				cmd.Parameters.AddWithValue("@LinhsComment", cmt);
			}

			cmd.Parameters.AddWithValue("@TestId", id);

			int check = cmd.ExecuteNonQuery();

			if (check > 0)
			{
				Console.WriteLine("update thanh cong");
			}
			else
			{
				Console.WriteLine("update fail");
			}
			cn.Close();
		}
		static void Main(string[] args)
		{
		Display:
			Console.WriteLine("=====================================================");
			Console.WriteLine("1. Show table");
			Console.WriteLine("2. Update table");
			Console.WriteLine("3. Insert table");
			Console.WriteLine("4. Stop");
			Console.WriteLine("=====================================================");
			Console.Write("Pls input number: "); String switch_number = Console.ReadLine();
			switch (switch_number)
			{

				case "1": Console.WriteLine("U are choosing " + switch_number); 
					ShowTable(); 
					goto Display;

				case "2":
					Console.WriteLine("U are choosing " + switch_number);
					InputAgain:
					Console.WriteLine("Input id: "); String id = Console.ReadLine();
					if ((String.IsNullOrEmpty(id)))
					{
						Console.WriteLine("Please input Id");
						goto InputAgain;

					}
					Console.WriteLine("Input cmt: "); String cmt = Console.ReadLine();
					Console.WriteLine("Input feelings: "); String feel = Console.ReadLine();
					
					UpdateTable(Convert.ToInt32(id), cmt, feel);
					goto Display;

				case "3": Console.WriteLine("U are choosing " + switch_number); InsertTable(); goto Display;
				case "4": Console.WriteLine("U are choosing " + switch_number); break;
				default:
					Console.WriteLine("U are choosing " + switch_number);
					Console.WriteLine("Wrong, pls try again");
					goto Display;
			}
		}
	}
}
