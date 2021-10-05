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
using WebApplication_CodeFirst_Panel_2.Models;

namespace WebApplication_CodeFirst_Panel_2.Controllers
{
    [Authorize(Roles = "Admin, Employee")]
    public class ContactsController : Controller
    {
        private Model_Acc_Context db = new Model_Acc_Context();

        // GET: Contacts
        public ActionResult Index()
        {
            return View(db.Contacts.ToList());
        }

        // GET: Contacts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // GET: Contacts/Create
        [AllowAnonymous]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contacts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Contact contact)
        {
            String SqlCon = ConfigurationManager.ConnectionStrings["DB_Acc"].ConnectionString;
            SqlConnection con = new SqlConnection(SqlCon);
            string sqlQuery = "insert into Contacts values(@Contact_Name, @Contact_Email, @Contact_Subject, @Contact_Body, @Contact_Check, @Contact_Date_Submit)";
            con.Open();
            SqlCommand cmd = new SqlCommand(sqlQuery, con);
            cmd.Parameters.AddWithValue("@Contact_Name", contact.Contact_Name);
            cmd.Parameters.AddWithValue("@Contact_Email", contact.Contact_Email);
            cmd.Parameters.AddWithValue("@Contact_Subject", contact.Contact_Subject);
            cmd.Parameters.AddWithValue("@Contact_Body", contact.Contact_Body);
            cmd.Parameters.AddWithValue("@Contact_Check", contact.Contact_Check);
            cmd.Parameters.AddWithValue("@Contact_Date_Submit", DateTime.Now);
            int check = cmd.ExecuteNonQuery();
            con.Close();
            if (check == 1)
            {
                TempData["Successful"] = "Insert Succesful";
                return RedirectToAction("Index", "Home", FormMethod.Get);
            }
            return View(contact);
        }

        // GET: Contacts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // POST: Contacts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Contact contact)
        {
            String SqlCon = ConfigurationManager.ConnectionStrings["DB_Acc"].ConnectionString;
            SqlConnection con = new SqlConnection(SqlCon);
            string sqlQuery = "Update Contacts set Contact_Check = @Contact_Check where Contact_Id = @Contact_Id";
            con.Open();
            SqlCommand cmd = new SqlCommand(sqlQuery, con);
            cmd.Parameters.AddWithValue("@Contact_Check", contact.Contact_Check);
            cmd.Parameters.AddWithValue("@Contact_Id", contact.Contact_Id);
            int check = cmd.ExecuteNonQuery();
            con.Close();
            if (check == 1)
            {
                TempData["Successful"] = "Insert Succesful";
                return RedirectToAction("Index");
            }

            return View(contact);
        }

        // GET: Contacts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // POST: Contacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contact contact = db.Contacts.Find(id);
            db.Contacts.Remove(contact);
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
