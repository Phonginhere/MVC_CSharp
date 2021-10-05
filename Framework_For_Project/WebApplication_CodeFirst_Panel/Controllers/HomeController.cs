using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication_CodeFirst_Panel.Models;
using Microsoft.AspNet.Identity;
using System.Data.Entity;

namespace WebApplication_CodeFirst_Panel.Controllers
{
    
    public class HomeController : Controller
	{
        private Model_Acc_Context db = new Model_Acc_Context();
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
		public ActionResult Account_Details()
		{
            string email = User.Identity.GetUserName();
            if (email == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var dbEntry = db.Employees.FirstOrDefault(acc => acc.Email == email);
            if (dbEntry == null)
            {
                return HttpNotFound();
            }
            return View(dbEntry);
		}

        // Get:
        public ActionResult Edit()
        {
            string email = User.Identity.GetUserName();
            if (email == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var dbEntry = db.Employees.FirstOrDefault(acc => acc.Email == email);
            if (dbEntry == null)
            {
                return HttpNotFound();
            }

            ViewBag.DeptId = new SelectList(db.Departments, "DeptId", "DepartName", dbEntry.DeptId);
            return View(dbEntry);
        }

        // POST: 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeId,FirstName,LastName,Password,Gender,Email,PhoneNumber,DOB,Salary,DeptId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DeptId = new SelectList(db.Departments, "DeptId", "DepartName", employee.DeptId);
            return View(employee);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Employee user)
        {

            String SqlCon = ConfigurationManager.ConnectionStrings["Db_Acc"].ConnectionString;
            SqlConnection con = new SqlConnection(SqlCon);
            string sqlQuery = "select Email,Password from Employees where Email=@Email and Password=@Password";
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

        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}