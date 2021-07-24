using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication_PrepareTest.Models;

namespace WebApplication_PrepareTest.Controllers
{
    public class ExamsController : Controller
    {
        private Model_Context_School db = new Model_Context_School();

        // GET: Exams
        public ActionResult Index(string status,string name, string dropdownSub)
        {
            var list =  db.Subject.Select(e => e.SubjectName).Distinct();

            SelectList sl = new SelectList(list);

            ViewBag.subname = sl;

            db.Exam.ToList(); // phải có mấy cài này thì mới hiện lên được bảng :( 
            db.Subject.ToList();
            db.Student.ToList();

            //display table

            var exam = from m in db.Exam select m;

            //only radio button
            if (status == "Pass")
            {
                exam = from e in db.Exam where e.Mark >= 40 select e;
            }
            if (status == "Fail")
            {
                exam = from e in db.Exam where e.Mark < 40 select e;
            }

            //only text name

            if (!(String.IsNullOrEmpty(name)))
            {
                exam = from e in db.Exam where e.Student.StudentName.Contains(name) select e;
            }

            //only dropdown
            if (!(String.IsNullOrEmpty(dropdownSub)))
            {
                exam = from e in db.Exam where e.Subject.SubjectName.Equals(dropdownSub) select e;
            }

            //text name and dropdown

            if (!(String.IsNullOrEmpty(name)) && !(String.IsNullOrEmpty(dropdownSub)))
            {
                exam = from e in db.Exam where e.Student.StudentName.Contains(name) && e.Subject.SubjectName == dropdownSub select e;
            }

            //text name and filter

            if (status == "Pass" && !(String.IsNullOrEmpty(name)))
            {
                exam = from e in db.Exam where e.Mark >= 40 && e.Student.StudentName.Contains(name) select e;

            }
            if (status == "Fail" && !(String.IsNullOrEmpty(name)))
            {
                exam = from e in db.Exam where e.Mark < 40 && e.Student.StudentName.Contains(name) select e;

            }

            //filter and dropdown

            if (status == "Pass" && !(String.IsNullOrEmpty(dropdownSub)))
            {
                exam = from e in db.Exam where e.Mark >= 40 && e.Subject.SubjectName.Equals(dropdownSub) select e;

            }
            if (status == "Fail" && !(String.IsNullOrEmpty(dropdownSub)))
            {
                exam = from e in db.Exam where e.Mark < 40 && e.Subject.SubjectName.Equals(dropdownSub) select e;

            }

            //combine all

            if (status == "Pass" && !(String.IsNullOrEmpty(name)) && dropdownSub != "Select")
            {
                exam = from e in db.Exam where e.Mark >= 40 && e.Student.StudentName.Contains(name) && e.Subject.SubjectName.Equals(dropdownSub) select e;

            }
            if (status == "Fail" && !(String.IsNullOrEmpty(name)) && dropdownSub != "Select")
            {
                exam = from e in db.Exam where e.Mark < 40 && e.Student.StudentName.Contains(name) && e.Subject.SubjectName.Equals(dropdownSub) select e;

            }


            return View(exam);
        }

        // GET: Exams/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exam exam = db.Exam.Find(id);
            if (exam == null)
            {
                return HttpNotFound();
            }
            return View(exam);
        }

        // GET: Exams/Create
        public ActionResult Create()
        {
            ViewBag.StudentId = new SelectList(db.Student, "StudentId", "StudentName");
            ViewBag.SubjectId = new SelectList(db.Subject, "SubjectId", "SubjectName");
            return View();
        }

        // POST: Exams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ExamId,SubjectId,StudentId,Mark")] Exam exam)
        {
            if (ModelState.IsValid)
            {
                db.Exam.Add(exam);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StudentId = new SelectList(db.Student, "StudentId", "StudentName", exam.StudentId);
            ViewBag.SubjectId = new SelectList(db.Subject, "SubjectId", "SubjectName", exam.SubjectId);
            return View(exam);
        }

        // GET: Exams/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exam exam = db.Exam.Find(id);
            if (exam == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentId = new SelectList(db.Student, "StudentId", "StudentName", exam.StudentId);
            ViewBag.SubjectId = new SelectList(db.Subject, "SubjectId", "SubjectName", exam.SubjectId);
            return View(exam);
        }

        // POST: Exams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ExamId,SubjectId,StudentId,Mark")] Exam exam)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exam).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StudentId = new SelectList(db.Student, "StudentId", "StudentName", exam.StudentId);
            ViewBag.SubjectId = new SelectList(db.Subject, "SubjectId", "SubjectName", exam.SubjectId);
            return View(exam);
        }

        // GET: Exams/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exam exam = db.Exam.Find(id);
            if (exam == null)
            {
                return HttpNotFound();
            }
            return View(exam);
        }

        // POST: Exams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Exam exam = db.Exam.Find(id);
            db.Exam.Remove(exam);
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
