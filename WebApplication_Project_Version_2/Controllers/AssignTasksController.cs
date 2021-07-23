using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication_Project_Version_2.Models;

namespace WebApplication_Project_Version_2.Controllers
{
    public class AssignTasksController : Controller
    {
        private Model_Project_Context db = new Model_Project_Context();

        // GET: AssignTasks
        public ActionResult Index(string Sort_Order, string status, string dropdownDepartment, string dropdownCompany, string textname, int? Page_No)
        {
            var dropdown1 = db.Client.Select(c => c.ClientCompany).Distinct();

            SelectList sl = new SelectList(dropdown1);

            ViewBag.listcom = sl;

            var dropdown2 = db.Employee.Select(c => c.EmployeeDepartment).Distinct();

            SelectList sl1 = new SelectList(dropdown2);

            ViewBag.listdep = sl1;


            var assignTask = from a in db.AssignTask select a;

            ViewBag.Department = dropdownDepartment;
            ViewBag.Company = dropdownCompany;

            //dropdown only
            if (!(String.IsNullOrEmpty(dropdownDepartment)))
            {
                assignTask = from a in db.AssignTask where a.Employee.EmployeeDepartment.Contains(dropdownDepartment) select a;
            }
            if (!(String.IsNullOrEmpty(dropdownCompany)))
            {
                assignTask = from a in db.AssignTask where a.Client.ClientCompany.Contains(dropdownCompany) select a;
            }
            if (!(String.IsNullOrEmpty(dropdownCompany) && (String.IsNullOrEmpty(dropdownDepartment))))
            {
                assignTask = from a in db.AssignTask where a.Client.ClientCompany.Contains(dropdownCompany) select a;
            }

            if (!(String.IsNullOrEmpty(textname)))
            {
                assignTask = from a in db.AssignTask where a.Note.Contains(textname) select a;
                assignTask = from a in db.AssignTask where a.Task.Contains(textname) select a;
            }

            return View(assignTask.ToList());
        }

        // GET: AssignTasks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssignTask assignTask = db.AssignTask.Find(id);
            if (assignTask == null)
            {
                return HttpNotFound();
            }
            return View(assignTask);
        }

        // GET: AssignTasks/Create
        public ActionResult Create()
        {
            ViewBag.ClientId = new SelectList(db.Client, "ClientId", "ClientName");
            ViewBag.EmployeeId = new SelectList(db.Employee, "EmployeeId", "EmployeeName");
            ViewBag.ProjectId = new SelectList(db.Project, "ProjectId", "ProjectName");
            return View();
        }

        // POST: AssignTasks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AssignTaskId,EmployeeId,ClientId,ProjectId,Task,Note")] AssignTask assignTask)
        {
            if (ModelState.IsValid)
            {
                db.AssignTask.Add(assignTask);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClientId = new SelectList(db.Client, "ClientId", "ClientName", assignTask.ClientId);
            ViewBag.EmployeeId = new SelectList(db.Employee, "EmployeeId", "EmployeeName", assignTask.EmployeeId);
            ViewBag.ProjectId = new SelectList(db.Project, "ProjectId", "ProjectName", assignTask.ProjectId);
            return View(assignTask);
        }

        // GET: AssignTasks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssignTask assignTask = db.AssignTask.Find(id);
            if (assignTask == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientId = new SelectList(db.Client, "ClientId", "ClientName", assignTask.ClientId);
            ViewBag.EmployeeId = new SelectList(db.Employee, "EmployeeId", "EmployeeName", assignTask.EmployeeId);
            ViewBag.ProjectId = new SelectList(db.Project, "ProjectId", "ProjectName", assignTask.ProjectId);
            return View(assignTask);
        }

        // POST: AssignTasks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AssignTaskId,EmployeeId,ClientId,ProjectId,Task,Note")] AssignTask assignTask)
        {
            if (ModelState.IsValid)
            {
                db.Entry(assignTask).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClientId = new SelectList(db.Client, "ClientId", "ClientName", assignTask.ClientId);
            ViewBag.EmployeeId = new SelectList(db.Employee, "EmployeeId", "EmployeeName", assignTask.EmployeeId);
            ViewBag.ProjectId = new SelectList(db.Project, "ProjectId", "ProjectName", assignTask.ProjectId);
            return View(assignTask);
        }

        // GET: AssignTasks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssignTask assignTask = db.AssignTask.Find(id);
            if (assignTask == null)
            {
                return HttpNotFound();
            }
            return View(assignTask);
        }

        // POST: AssignTasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AssignTask assignTask = db.AssignTask.Find(id);
            db.AssignTask.Remove(assignTask);
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
