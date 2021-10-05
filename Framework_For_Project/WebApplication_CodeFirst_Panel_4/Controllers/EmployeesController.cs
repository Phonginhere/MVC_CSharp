using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication_CodeFirst_Panel_4.Models;

namespace WebApplication_CodeFirst_Panel_4.Controllers
{
	public class EmployeesController : Controller
	{
		private Model_Acc_Context db = new Model_Acc_Context();

		// GET: Employees
		public ActionResult Index()
		{
			return View(db.Employees.ToList());
		}

		// GET: Employees/Details/5
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Employee employee = db.Employees.Find(id);
			if (employee == null)
			{
				return HttpNotFound();
			}
			return PartialView(employee);
		}

		// GET: Employees/Create
		public ActionResult Create()
		{
			if (TempData.ContainsKey("Fail"))
			{
				String notify = TempData["Fail"].ToString();
				ViewBag.Notify = notify;
			}
			if (TempData.ContainsKey("Fail_Image"))
			{
				String notify_img = TempData["Fail_Image"].ToString();
				ViewBag.Imgnotify = notify_img;
			}
			return View();
		}

		// POST: Employees/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(HttpPostedFileBase Employee_Image, String FullName, String Password, String Gender, String Email, String PhoneNumber, String DOB, String Salary)
		{
			Employee employee = null;
			if (ModelState.IsValid)
			{

				var query = from c in db.Employees select c;

				if (query.Any(c => c.Email.Equals(Email)))
				{
					TempData["Fail"] = "There is an email which created before, please use another email";
					int a = 0;
					a++;
					return RedirectToAction("Create");
				}

				if (Employee_Image == null)
				{
					string path = Path.Combine(Server.MapPath("~/ImageUpload/150.png"));
					string nameFile = Path.GetFileName(path);

					String SqlCon = ConfigurationManager.ConnectionStrings["DB_Acc"].ConnectionString;
					SqlConnection con = new SqlConnection(SqlCon);
					string sqlQuery = "insert into Employees values(@Employee_Image, @FullName, @Password, @Gender, @Email, @PhoneNumber, @DOB, @Salary, @Date_Added, @Date_Edited)";
					con.Open();
					SqlCommand cmd = new SqlCommand(sqlQuery, con);
					cmd.Parameters.AddWithValue("@Employee_Image", "~/ImageUpload/" + nameFile);
					cmd.Parameters.AddWithValue("@FullName", FullName);
					cmd.Parameters.AddWithValue("@Password", Password);
					cmd.Parameters.AddWithValue("@Gender", Gender);
					cmd.Parameters.AddWithValue("@Email", Email);
					cmd.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
					cmd.Parameters.AddWithValue("@DOB", DOB);
					cmd.Parameters.AddWithValue("@Salary", Salary);
					cmd.Parameters.AddWithValue("@Date_Added", DateTime.Now);
					cmd.Parameters.AddWithValue("@Date_Edited", DateTime.Now);
					int check = cmd.ExecuteNonQuery();
					con.Close();
					if (check == 1)
					{
						TempData["Notify"] = "Insert Succesful";
						return RedirectToAction("Index");
					}
					return View(employee);
				}

				int image_capacity = Employee_Image.ContentLength; //check img length

				if (image_capacity > 1000000)
				{
					TempData["Fail_Image"] = image_capacity;
					return RedirectToAction("Create");
				}
				else
				{

					//save file
					string path = Path.Combine(Server.MapPath("~/ImageUpload"), Path.GetFileName(Employee_Image.FileName));
					Employee_Image.SaveAs(path);


					String SqlCon = ConfigurationManager.ConnectionStrings["DB_Acc"].ConnectionString;
					SqlConnection con = new SqlConnection(SqlCon);
					string sqlQuery = "insert into Employees values(@Employee_Image, @FullName, @Password, @Gender, @Email, @PhoneNumber, @DOB, @Salary, @Date_Added, @Date_Edited)";
					con.Open();
					SqlCommand cmd = new SqlCommand(sqlQuery, con);
					cmd.Parameters.AddWithValue("@Employee_Image", "~/ImageUpload/" + Employee_Image.FileName);
					cmd.Parameters.AddWithValue("@FullName", FullName);
					cmd.Parameters.AddWithValue("@Password", Password);
					cmd.Parameters.AddWithValue("@Gender", Gender);
					cmd.Parameters.AddWithValue("@Email", Email);
					cmd.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
					cmd.Parameters.AddWithValue("@DOB", DOB);
					cmd.Parameters.AddWithValue("@Salary", Salary);
					cmd.Parameters.AddWithValue("@Date_Added", DateTime.Now);
					cmd.Parameters.AddWithValue("@Date_Edited", DateTime.Now);
					int check = cmd.ExecuteNonQuery();
					con.Close();
					//if (check != 1)
					//{
					//    TempData["Fail"] = "Insert Succesful";
					//    return RedirectToAction("Index");
					//}
					return RedirectToAction("Index");
				}
			}
			return View(employee);
		}

		// GET: Employees/Edit/5
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Employee employee = db.Employees.Find(id);
			if (employee == null)
			{
				return HttpNotFound();
			}
			return PartialView(employee);
		}

		// POST: Employees/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int EmployeeId, HttpPostedFileBase Employee_Image, String FullName, String Password, String Gender, String PhoneNumber, String DOB, int Salary)
		{
			Employee employee = null;
			if (ModelState.IsValid)
			{

				//if no image => default image will upload 
				if (Employee_Image == null)
				{
					String SqlCon = ConfigurationManager.ConnectionStrings["DB_Acc"].ConnectionString;
					SqlConnection con = new SqlConnection(SqlCon);
					string sqlQuery = "Update Employees SET FullName = @FullName,Password = @Password,Gender = @Gender,PhoneNumber = @PhoneNumber,DOB = @DOB,Salary = @Salary, Date_Edited = @Date_Edited where EmployeeId = @EmployeeId";
					con.Open();
					SqlCommand cmd = new SqlCommand(sqlQuery, con);
					cmd.Parameters.AddWithValue("@FullName", FullName);
					cmd.Parameters.AddWithValue("@Password", Password);
					cmd.Parameters.AddWithValue("@Gender", Gender);
					cmd.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
					cmd.Parameters.AddWithValue("@DOB", DOB);
					cmd.Parameters.AddWithValue("@Salary", Salary);
					cmd.Parameters.AddWithValue("@Date_Edited", DateTime.Now);
					cmd.Parameters.AddWithValue("@EmployeeId", EmployeeId);
					int check = cmd.ExecuteNonQuery();
					con.Close();
					if (check > 0)
					{
						TempData["Notify"] = "Insert Succesful";
						return RedirectToAction("Index");
					}
					return View(employee);
				}

				int image_capacity = Employee_Image.ContentLength;
				if (image_capacity > 1000000)
				{
					TempData["Fail_Image"] = image_capacity;
					return RedirectToAction("Edit");
				}
				else
				{
					//save file
					string path = Path.Combine(Server.MapPath("~/ImageUpload"), Path.GetFileName(Employee_Image.FileName));
					Employee_Image.SaveAs(path);

					String SqlCon = ConfigurationManager.ConnectionStrings["DB_Acc"].ConnectionString;
					SqlConnection con = new SqlConnection(SqlCon);
					string sqlQuery = "Update Employees SET Employee_Image = @Employee_Image,FullName = @FullName,Password = @Password,Gender = @Gender,PhoneNumber = @PhoneNumber,DOB = @DOB,Salary = @Salary, Date_Edited = @Date_Edited where EmployeeId = @EmployeeId)";
					con.Open();
					SqlCommand cmd = new SqlCommand(sqlQuery, con);
					cmd.Parameters.AddWithValue("@Employee_Image", "~/ImageUpload/" + Employee_Image.FileName);
					cmd.Parameters.AddWithValue("@FullName", FullName);
					cmd.Parameters.AddWithValue("@Password", Password);
					cmd.Parameters.AddWithValue("@Gender", Gender);
					cmd.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
					cmd.Parameters.AddWithValue("@DOB", DOB);
					cmd.Parameters.AddWithValue("@Salary", Salary);
					cmd.Parameters.AddWithValue("@Date_Edited", DateTime.Now);
					cmd.Parameters.AddWithValue("@EmployeeId", EmployeeId);
					int check = cmd.ExecuteNonQuery();
					con.Close();
					if (check == 1)
					{
						TempData["Notify"] = "Insert Succesful";
						return RedirectToAction("Index");
					}
					return View(employee);
				}


			}
			return View(employee);
		}

		// GET: Employees/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Employee employee = db.Employees.Find(id);
			if (employee == null)
			{
				return HttpNotFound();
			}
			return PartialView(employee);
		}

		// POST: Employees/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			Employee employee = db.Employees.Find(id);
			db.Employees.Remove(employee);
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				db.Dispose();
			}
			base.Dispose(disposing);
		}
	}
}
