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
using WebApplication_EProject.Models.QvA;

namespace WebApplication_EProject.Controllers.QvAController
{
    [Authorize]
    public class QuestionsController : Controller
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
        public ActionResult Question_Index()
        {
            Statuscheck();
            return View(db.Question.ToList());
        }

        [AllowAnonymous]
        public ActionResult Question_Details(int? id)
        {
            Statuscheck();
            if (id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                return RedirectToAction("Error_Nothing", "Home");
            }
            Question question = db.Question.Find(id);
            if (question == null)
            {
                //return HttpNotFound();
                return RedirectToAction("Error_Nothing", "Home");
            }
            var check_username = User.Identity.GetUserName();
            var check_user = db.NhanViens.Where(c => c.Email == check_username);
            int employ_check = (int)check_user.Select(r => r.Employee_ID).First();

            var list = db.Answers.Include(a => a.NhanVien).Where(b => b.QuestionId == id);
            ViewBag.employeeData = list; 
            return View(question);
        }

        // GET: Questions
        [Authorize(Roles = "root, giamdoc")]
        public ActionResult Index()
        {
            Statuscheck();
            var question = db.Question.Include(q => q.NhanVien).Include(q => q.Role);
            return View(question.ToList());
        }

        // GET: Questions/Details/5
        [Authorize(Roles = "root, giamdoc")]
        public ActionResult Details(int? id)
        {
            Statuscheck();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.Question.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        // GET: Questions/Create
        public ActionResult Create()
        {
            Statuscheck();
            ViewBag.Employee_ID = new SelectList(db.NhanViens, "Employee_ID", "Ten");
            ViewBag.Role_ID = new SelectList(db.Roles, "Role_ID", "RoleName");
            return View();
        }

        // POST: Questions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "QuestionId,question_name,question_desc,Role_ID,question_date,question_edited,Employee_ID")] Question question)
        {
            Statuscheck();
            if (ModelState.IsValid)
            {
                var check_username = User.Identity.GetUserName();
                var check_user = db.NhanViens.Where(c => c.Email == check_username);
                int employ_check = (int)check_user.Select(r => r.Employee_ID).First();

                question.Employee_ID = employ_check;
                question.question_date = DateTime.Now;
                question.question_edited = DateTime.Now;
                db.Question.Add(question);
                db.SaveChanges();
                return RedirectToAction("Question_Index");
            }

            ViewBag.Employee_ID = new SelectList(db.NhanViens, "Employee_ID", "Ten", question.Employee_ID);
            ViewBag.Role_ID = new SelectList(db.Roles, "Role_ID", "RoleName", question.Role_ID);
            return View(question);
        }

        // GET: Questions/Edit/5
        [Authorize(Roles = "root, giamdoc")]
        public ActionResult Edit(int? id)
        {
            Statuscheck();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.Question.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            ViewBag.Employee_ID = new SelectList(db.NhanViens, "Employee_ID", "Ten", question.Employee_ID);
            ViewBag.Role_ID = new SelectList(db.Roles, "Role_ID", "RoleName", question.Role_ID);
            return View(question);
        }

        // POST: Questions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "root, giamdoc")]
        public ActionResult Edit([Bind(Include = "QuestionId,question_name,question_desc,Role_ID,question_date,question_edited,Employee_ID")] Question question)
        {
            Statuscheck();
            if (ModelState.IsValid)
            {
                var check_username = User.Identity.GetUserName();

                var check_user = db.NhanViens.Where(c => c.Email == check_username);

                int employ_check = (int)check_user.Select(r => r.Employee_ID).First();

                question.Employee_ID = employ_check;            
                question.question_edited = DateTime.Now;
                db.Entry(question).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Employee_ID = new SelectList(db.NhanViens, "Employee_ID", "Ten", question.Employee_ID);
            ViewBag.Role_ID = new SelectList(db.Roles, "Role_ID", "RoleName", question.Role_ID);
            return View(question);
        }

        // GET: Questions/Delete/5
        [Authorize(Roles = "root, giamdoc")]
        public ActionResult Delete(int? id)
        {
            Statuscheck();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.Question.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        // POST: Questions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "root, giamdoc")]
        public ActionResult DeleteConfirmed(int id)
        {
            Statuscheck();
            Question question = db.Question.Find(id);
            db.Question.Remove(question);
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
