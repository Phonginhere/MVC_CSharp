using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication_EProject.Models;
using WebApplication_EProject.Models.Request;

namespace WebApplication_EProject.Controllers.RequestController
{
    [Authorize(Roles = "root, giamdoc")]
    public class LogsController : Controller
    {
        private ModelContext db = new ModelContext();

        public void Statuscheck()
        {
            var account = User.Identity.GetUserName();
            var Check_Email = db.NhanViens.FirstOrDefault(x => x.Email == account);
            if (Check_Email.Status == 0)
            {
                ViewBag.haha = "Account currently disabled";
                FormsAuthentication.SignOut();
            }
        }
        // GET: Logs
        public ActionResult Index(String Role_ID)
        {
            Statuscheck();
            var logs = from l in db.Logs select l;

			if (!(String.IsNullOrEmpty(Role_ID)))
			{
                int roleId = Convert.ToInt16(Role_ID);
                logs = from l in db.Logs where l.Role_ID == roleId select l;
			}

            ViewBag.Role_ID = new SelectList(db.Roles, "Role_ID", "RoleName");
            ViewBag.Employee_ID = new SelectList(db.NhanViens, "Employee_ID", "Ten");
            return View(logs);
        }

        //// GET: Logs/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Log log = db.Logs.Find(id);
        //    if (log == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(log);
        //}

        // GET: Logs/Create
        //public ActionResult Create()
        //{
        //    ViewBag.Employee_ID = new SelectList(db.NhanViens, "Employee_ID", "Ten");
        //    ViewBag.Request_Id = new SelectList(db.Requests, "Request_Id", "Unit");
        //    ViewBag.Role_ID = new SelectList(db.Roles, "Role_ID", "RoleName");
        //    return View();
        //}

        //// POST: Logs/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "LogId,Request_Id,Role_ID,Employee_ID,LogName")] Log log)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Logs.Add(log);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.Employee_ID = new SelectList(db.NhanViens, "Employee_ID", "Ten", log.Employee_ID);
        //    ViewBag.Request_Id = new SelectList(db.Requests, "Request_Id", "Unit", log.Request_Id);
        //    ViewBag.Role_ID = new SelectList(db.Roles, "Role_ID", "RoleName", log.Role_ID);
        //    return View(log);
        //}

        //// GET: Logs/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Log log = db.Logs.Find(id);
        //    if (log == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.Employee_ID = new SelectList(db.NhanViens, "Employee_ID", "Ten", log.Employee_ID);
        //    ViewBag.Request_Id = new SelectList(db.Requests, "Request_Id", "Unit", log.Request_Id);
        //    ViewBag.Role_ID = new SelectList(db.Roles, "Role_ID", "RoleName", log.Role_ID);
        //    return View(log);
        //}

        //// POST: Logs/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "LogId,Request_Id,Role_ID,Employee_ID,LogName")] Log log)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(log).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.Employee_ID = new SelectList(db.NhanViens, "Employee_ID", "Ten", log.Employee_ID);
        //    ViewBag.Request_Id = new SelectList(db.Requests, "Request_Id", "Unit", log.Request_Id);
        //    ViewBag.Role_ID = new SelectList(db.Roles, "Role_ID", "RoleName", log.Role_ID);
        //    return View(log);
        //}

        //// GET: Logs/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Log log = db.Logs.Find(id);
        //    if (log == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(log);
        //}

        //// POST: Logs/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Log log = db.Logs.Find(id);
        //    db.Logs.Remove(log);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

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
