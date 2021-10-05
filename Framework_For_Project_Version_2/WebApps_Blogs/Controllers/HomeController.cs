using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApps_Blogs.Models;
using WebApps_Blogs.Models.Admin;

namespace WebApps_Blogs.Controllers
{
	public class HomeController : Controller
	{
        Blog_Ctx db = new Blog_Ctx();
		public ActionResult Index()
		{
			return View();
		}
		public ActionResult Error_Nothing()
		{
			return View();
		}

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Account user)
        {
			try
			{
                var account = db.Accounts.SingleOrDefault(x => x.Email == user.Email);

                if (account == null || !BCrypt.Net.BCrypt.Verify(user.Password, account.Password))
                {
                    ViewBag.haha = "User Login Details Failed!!";
                }
                else
                {
                    FormsAuthentication.SetAuthCookie(user.Email, true);
                    return Redirect("Index");
                }
			}
			catch
			{
                ViewBag.haha = "Please input email or password to Login";

            }
            return View();

        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }

        //public ActionResult About()
        //{
        //	ViewBag.Message = "Your application description page.";

        //	return View();
        //}

        //public ActionResult Contact()
        //{
        //	ViewBag.Message = "Your contact page.";

        //	return View();
        //}
    }
}