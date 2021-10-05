using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication_Mangement_Inventory.Models;

namespace WebApplication_Mangement_Inventory.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Account acc)
        {
            String SqlCon = ConfigurationManager.ConnectionStrings["DB_Acc"].ConnectionString;
            SqlConnection con = new SqlConnection(SqlCon);
            string sqlQuery = "select Email,Password from Accounts where Email=@Email and Password=@Password";
            con.Open();
            SqlCommand cmd = new SqlCommand(sqlQuery, con);
            cmd.Parameters.AddWithValue("@Email", acc.Email);
            cmd.Parameters.AddWithValue("@Password", acc.Password);
            SqlDataReader read = cmd.ExecuteReader();
            
			if (read.Read())
			{
                return RedirectToAction("Index", "Accounts");
			}
            else
            {
                ViewBag.haha = "User Login Details Failed!!";
            }
            con.Close();
            return View();
        }
    }
}