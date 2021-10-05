using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication_Blog_Ver2.Models;
using WebApplication_Blog_Ver2.Models.Admin;

namespace WebApplication_Blog_Ver2.Controllers
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

			var account = db.Accounts.SingleOrDefault(x => x.Email == user.Email);
			if (user.Password == null || user.Email == null)
			{
				ViewBag.haha = "Missing Email or Password";
			}
			else
			{
				if (account == null || !BCrypt.Net.BCrypt.Verify(user.Password, account.Password))
				{
					ViewBag.haha = "User Login Details Failed!!";
				}
				else
				{
					FormsAuthentication.SetAuthCookie(user.Email, true);
					return Redirect("Index");
				}
				return View();
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