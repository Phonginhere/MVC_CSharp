using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication_Panel.Models;

namespace WebApplication_Panel.Controllers
{
    public class HomeController : Controller
    {
        private Account_Context _dbContext = new Account_Context();
        // GET: Home
        public ActionResult Index()
        {
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
            if (ModelState.IsValid)
            {
                bool IsValidUser = _dbContext.Employees
               .Any(u => u.Email.ToLower() == user
               .Email.ToLower() && user
               .Password == user.Password);

                if (IsValidUser)
                {
                    FormsAuthentication.SetAuthCookie(user.Email, false);
                    return RedirectToAction("Index", "Employee");
                }
            }
            ModelState.AddModelError("", "invalid Username or Password");
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Employee registerUser)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Employees.Add(registerUser);
                _dbContext.SaveChanges();
                return RedirectToAction("Login");

            }
            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}