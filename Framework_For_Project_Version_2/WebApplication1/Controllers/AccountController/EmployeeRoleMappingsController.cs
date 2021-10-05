using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApps_Blogs.Models;
using WebApps_Blogs.Models.Admin;

namespace WebApps_Blogs.Controllers.AccountController
{
    [Authorize(Roles = "Admin")]
    public class EmployeeRoleMappingsController : Controller
    {
        private Blog_Ctx db = new Blog_Ctx();

        // GET: EmployeeRoleMappings
        public ActionResult Index()
        {
            var employeeRoleMappings = db.EmployeeRoleMappings.Include(e => e.Account).Include(e => e.Role);
            return View(employeeRoleMappings.ToList());
        }

        // GET: EmployeeRoleMappings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeRoleMapping employeeRoleMapping = db.EmployeeRoleMappings.Find(id);
            if (employeeRoleMapping == null)
            {
                return HttpNotFound();
            }
            return View(employeeRoleMapping);
        }

        // GET: EmployeeRoleMappings/Create
        public ActionResult Create()
        {
            ViewBag.AccountId = new SelectList(db.Accounts, "AccountId", "FullName");
            ViewBag.RoleId = new SelectList(db.Roles, "RoleId", "RoleName");
            return View();
        }

        // POST: EmployeeRoleMappings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MapId,AccountId,RoleId")] EmployeeRoleMapping employeeRoleMapping)
        {
            if (ModelState.IsValid)
            {
                db.EmployeeRoleMappings.Add(employeeRoleMapping);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AccountId = new SelectList(db.Accounts, "AccountId", "FullName", employeeRoleMapping.AccountId);
            ViewBag.RoleId = new SelectList(db.Roles, "RoleId", "RoleName", employeeRoleMapping.RoleId);
            return View(employeeRoleMapping);
        }

        // GET: EmployeeRoleMappings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeRoleMapping employeeRoleMapping = db.EmployeeRoleMappings.Find(id);
            if (employeeRoleMapping == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccountId = new SelectList(db.Accounts, "AccountId", "FullName", employeeRoleMapping.AccountId);
            ViewBag.RoleId = new SelectList(db.Roles, "RoleId", "RoleName", employeeRoleMapping.RoleId);
            return View(employeeRoleMapping);
        }

        // POST: EmployeeRoleMappings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MapId,AccountId,RoleId")] EmployeeRoleMapping employeeRoleMapping)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeRoleMapping).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AccountId = new SelectList(db.Accounts, "AccountId", "FullName", employeeRoleMapping.AccountId);
            ViewBag.RoleId = new SelectList(db.Roles, "RoleId", "RoleName", employeeRoleMapping.RoleId);
            return View(employeeRoleMapping);
        }

        // GET: EmployeeRoleMappings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeRoleMapping employeeRoleMapping = db.EmployeeRoleMappings.Find(id);
            if (employeeRoleMapping == null)
            {
                return HttpNotFound();
            }
            return View(employeeRoleMapping);
        }

        // POST: EmployeeRoleMappings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeRoleMapping employeeRoleMapping = db.EmployeeRoleMappings.Find(id);
            db.EmployeeRoleMappings.Remove(employeeRoleMapping);
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
