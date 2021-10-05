using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using WebApplication_Blog_Ver2.Models;
using WebApplication_Blog_Ver2.Models.Admin;

namespace WebApplication_Blog_Ver2.Controllers.AccountController
{
    public class AccountsController : Controller
    {
        private Blog_Ctx db = new Blog_Ctx();

        // GET: Accounts
        public ActionResult Index()
        {
            return View(db.Accounts.ToList());
        }

        // GET: Accounts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Accounts.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // GET: Accounts/Create
        public ActionResult Create()
        {
            if(TempData["err_long"] != null)
			{
                ViewBag.err_l = TempData["err_long"];
                
            }
            return View();
        }

        // POST: Accounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeId,FullName,Password,Email")] Account account)
        {
            Account account1 = new Account();
            if (ModelState.IsValid)
            {
                if(account.Password.Length > 32)
				{
                    TempData["err_long"] = "Character string limited to 32 characters";
                    return RedirectToAction("Create");
                }

                string passwordHash = BCrypt.Net.BCrypt.HashPassword(account.Password);

                account1.FullName = account.FullName;
                account1.Password = passwordHash;
                account1.Email = account.Email;
                db.Accounts.Add(account1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(account);
        }

        // GET: Accounts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Accounts.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // POST: Accounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AccountId,FullName,Password,Email")] Account account)
        {
            int i = 0;
            i++;
            if (ModelState.IsValid)
            {
                if (account.Password.Length > 32)
                {
                    TempData["err_long"] = "Character string limited to 32 characters";
                    return RedirectToAction("Create");
                }
                string passwordHash = BCrypt.Net.BCrypt.HashPassword(account.Password);

                //Account account1 = new Account();

                //account1.FullName = account.FullName;
                //account1.Password = passwordHash;
                //account1.Email = account1.Email;
                //account1.AccountId = account.AccountId;
                account.Password = passwordHash;
               

                db.Entry(account).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(account);
        }

        // GET: Accounts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Accounts.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // POST: Accounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            Account account = db.Accounts.Find(id);
            db.Accounts.Remove(account);
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
