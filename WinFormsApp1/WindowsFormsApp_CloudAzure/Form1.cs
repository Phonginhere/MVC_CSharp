using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp_CloudAzure
{
	public partial class Form1 : Form
	{
		static String con_String = "Data Source=c1908g00.database.windows.net;Initial Catalog=c1908gDB;User ID=c1908g;Password=1908g123@A;MultipleActiveResultSets=True;Application Name=EntityFramework";
		static SqlConnection cn = new SqlConnection(con_String);
		public Form1()
		{
			InitializeComponent();
		}
		 void showTable()
		{
			SqlDataAdapter da = new SqlDataAdapter("select * from [LinhsTestTable2]", cn);
			DataSet ds = new DataSet();
			da.Fill(ds, "[LinhsTestTable2]");
			dataGridView1.DataSource = ds.Tables["[LinhsTestTable2]"].DefaultView;
		}
		private void Form1_Load(object sender, EventArgs e)
		{
			showTable();
		}

		private void btnInsert_Click(object sender, EventArgs e)
		{
			String insertTable = "Insert into [LinhsTestTable2] values (@LinhsComment, @feelings)";
			SqlCommand cmd = new SqlCommand(insertTable, cn);
			cn.Open();

			String cmt = textBoxCmt.Text;
			String feel = textBoxFeel.Text;

			cmd.Parameters.AddWithValue("@LinhsComment", cmt);
			cmd.Parameters.AddWithValue("@feelings", feel);

			int check = cmd.ExecuteNonQuery();

			if (check > 0)
			{
				MessageBox.Show("insert thanh cong");
			}
			else
			{
				MessageBox.Show("insert fail");
			}
			cn.Close();
			showTable();
		}

		private void btnUpdate_Click(object sender, EventArgs e)
		{
			String updateTable = "Update [LinhsTestTable2] Set LinhsComment = @LinhsComment, feelings = @feelings where TestId = @TestId";
			SqlCommand cmd = new SqlCommand(updateTable, cn);
			cn.Open();

			String cmt = textBoxCmt.Text;
			String feel = textBoxFeel.Text;
			int id = Convert.ToInt32(textBoxId.Text);

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
				MessageBox.Show("update thanh cong");
			}
			else
			{
				MessageBox.Show("update fail");
			}
			cn.Close();
			showTable();
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			int id = Convert.ToInt32(textBoxId.Text);
			String deleteTable = "Delete from [LinhsTestTable2] where TestId = @TestId";
			SqlCommand cmd = new SqlCommand(deleteTable, cn);
			cn.Open();
			cmd.Parameters.AddWithValue("@TestId", id);
			int check = cmd.ExecuteNonQuery();

			if (check > 0)
			{
				MessageBox.Show("delete thanh cong");
			}
			else
			{
				MessageBox.Show("delete fail");
			}
			cn.Close();
			showTable();
		}
	}
}
