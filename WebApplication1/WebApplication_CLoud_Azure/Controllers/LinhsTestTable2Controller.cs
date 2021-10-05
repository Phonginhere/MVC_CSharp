using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication_CLoud_Azure.Models;

namespace WebApplication_CLoud_Azure.Controllers
{
    public class LinhsTestTable2Controller : Controller
    {
        private Model_cloud db = new Model_cloud();

        // GET: LinhsTestTable2
        public ActionResult Index()
        {
            return View(db.LinhsTestTable2.ToList());
        }

        // GET: LinhsTestTable2/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LinhsTestTable2 linhsTestTable2 = db.LinhsTestTable2.Find(id);
            if (linhsTestTable2 == null)
            {
                return HttpNotFound();
            }
            return View(linhsTestTable2);
        }

        // GET: LinhsTestTable2/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LinhsTestTable2/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TestId,LinhsComment,feelings")] LinhsTestTable2 linhsTestTable2)
        {
            if (ModelState.IsValid)
            {
                db.LinhsTestTable2.Add(linhsTestTable2);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(linhsTestTable2);
        }

        // GET: LinhsTestTable2/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LinhsTestTable2 linhsTestTable2 = db.LinhsTestTable2.Find(id);
            if (linhsTestTable2 == null)
            {
                return HttpNotFound();
            }
            return View(linhsTestTable2);
        }

        // POST: LinhsTestTable2/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TestId,LinhsComment,feelings")] LinhsTestTable2 linhsTestTable2)
        {
            if (ModelState.IsValid)
            {
                db.Entry(linhsTestTable2).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(linhsTestTable2);
        }

        // GET: LinhsTestTable2/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LinhsTestTable2 linhsTestTable2 = db.LinhsTestTable2.Find(id);
            if (linhsTestTable2 == null)
            {
                return HttpNotFound();
            }
            return View(linhsTestTable2);
        }

        // POST: LinhsTestTable2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LinhsTestTable2 linhsTestTable2 = db.LinhsTestTable2.Find(id);
            db.LinhsTestTable2.Remove(linhsTestTable2);
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
