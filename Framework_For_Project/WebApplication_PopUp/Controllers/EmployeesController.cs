using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication_PopUp.Models;

namespace WebApplication_PopUp.Controllers
{
    public class EmployeesController : Controller
    {
        private Model_Employee_Context db = new Model_Employee_Context();

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
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Employee_Id,Employee_Name,Employee_Comment")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
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
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee employee)
        {
            String SqlCon = ConfigurationManager.ConnectionStrings["Db_Employee"].ConnectionString;
            SqlConnection con = new SqlConnection(SqlCon);
            if (ModelState.IsValid)
			{

                if (employee.Employee_Name != null && employee.Employee_Comment != null) //if 2 datatypes  null value
				{
                    string sqlQuery = "Update Employees SET Employee_Name = @Employee_Name, Employee_Comment = @Employee_Comment where Employee_Id = @Employee_Id";
                    con.Open();
                    SqlCommand cmd = new SqlCommand(sqlQuery, con);
                    cmd.Parameters.AddWithValue("@Employee_Name", employee.Employee_Name);
                    cmd.Parameters.AddWithValue("@Employee_Comment", employee.Employee_Comment);
                    cmd.Parameters.AddWithValue("@Employee_Id", employee.Employee_Id);
                    int check = cmd.ExecuteNonQuery();
                    con.Close();
                    if (check == 1)
                    {
                        TempData["Notify"] = "Insert Succesful";
                        return RedirectToAction("Index");
                    }

                    return View(employee);
				}
                else
                {
                    return RedirectToAction("Index");
                }


				if (employee.Employee_Name == null) //if name null values
				{
					string sqlQuery = "Update Employees SET Employee_Comment = @Employee_Comment where Employee_Id = @Employee_Id";
					con.Open();
                    SqlCommand cmd = new SqlCommand(sqlQuery, con);
                    cmd.Parameters.AddWithValue("@Employee_Comment", employee.Employee_Comment);
                    cmd.Parameters.AddWithValue("@Employee_Id", employee.Employee_Id);
                    int check = cmd.ExecuteNonQuery();
                    con.Close();
                    if (check == 1)
                    {
                        TempData["Notify"] = "Insert Succesful";
                        return RedirectToAction("Index");
                    }

                    return View(employee);
                }else if (employee.Employee_Comment == null) //if comment null values
                {
                    string sqlQuery = "Update Employees SET Employee_Name = @Employee_Name where Employee_Id = @Employee_Id";
                    con.Open();
                    SqlCommand cmd = new SqlCommand(sqlQuery, con);
                    cmd.Parameters.AddWithValue("@Employee_Name", employee.Employee_Name);
                    cmd.Parameters.AddWithValue("@Employee_Id", employee.Employee_Id);
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
            return View(employee);
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
