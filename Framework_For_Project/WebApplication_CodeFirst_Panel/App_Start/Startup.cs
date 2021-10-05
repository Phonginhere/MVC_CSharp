using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using WebApplication_CodeFirst_Panel.Models;

[assembly: OwinStartupAttribute(typeof(WebApplication_CodeFirst_Panel.Startup))]
namespace WebApplication_CodeFirst_Panel
{
	public partial class Startup
	{
		public void ConfigureAuth()
		{
			createRolesandUsers();
		}
		private void createRolesandUsers()
		{
			Model_Acc_Context context = new Model_Acc_Context();

			var email_admin = from f in context.Employees where f.Email == "admin@gmail.com" select f;
			if(email_admin == null)
			{
                String SqlCon = ConfigurationManager.ConnectionStrings["DB_Acc"].ConnectionString;
                SqlConnection con = new SqlConnection(SqlCon);
                string sqlQuery = "insert into Employees values(@FirstName, @LastName, @Password, @Gender, @Email, @PhoneNumber, @DOB)";
                con.Open();
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                cmd.Parameters.AddWithValue("@FirstName", "Admin");
                cmd.Parameters.AddWithValue("@LastName", "User");
                cmd.Parameters.AddWithValue("@Password", "A@a123456");
                cmd.Parameters.AddWithValue("@Gender", "Male");
                cmd.Parameters.AddWithValue("@Email", "admin@gmail.com");
                cmd.Parameters.AddWithValue("@PhoneNumber", "0123456789");
                cmd.Parameters.AddWithValue("@DOB", "03/12/2020");
                int check = cmd.ExecuteNonQuery();
                con.Close();
            }
		}
	}
}