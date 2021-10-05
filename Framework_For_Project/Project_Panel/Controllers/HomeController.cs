using Project_Panel.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Project_Panel.Controllers
{
	public class HomeController : Controller
	{
        Account_Context _dbContext = new Account_Context();
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Employee user)
        {

            String SqlCon = ConfigurationManager.ConnectionStrings["Account_Login"].ConnectionString;
            SqlConnection con = new SqlConnection(SqlCon);
            string sqlQuery = "select Email,Password from Employee where Email=@Email and Password=@Password";
            con.Open();
            SqlCommand cmd = new SqlCommand(sqlQuery, con);
            cmd.Parameters.AddWithValue("@Email", user.Email);
            cmd.Parameters.AddWithValue("@Password", user.Password);
            SqlDataReader read = cmd.ExecuteReader();

            if (read.Read())
            {
                FormsAuthentication.SetAuthCookie(user.Email, false);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.haha = "User Login Details Failed!!";
            }
            con.Close();
            return View();


            //if (ModelState.IsValid)
            //{
            //    bool IsValidUser = _dbContext.Employees
            //   .Any(u => u.Email.ToLower() == user
            //   .Email.ToLower() && user
            //   .Password == user.Password);

            //    if (IsValidUser)
            //    {
            //        FormsAuthentication.SetAuthCookie(user.Email, false);
            //        return RedirectToAction("Index", "Employees");
            //    }
            //}
            //ModelState.AddModelError("", "invalid Username or Password");
            //return View();
        }

        //public ActionResult Register()
        //{
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Register(Employee registerUser)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _dbContext.Employees.Add(registerUser);
        //        _dbContext.SaveChanges();
        //        return RedirectToAction("Login");

        //    }
        //    return View();
        //}

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}