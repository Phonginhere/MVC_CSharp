using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using PagedList;
using WebApplication_EProject.Models;
using WebApplication_EProject.Models.Request;

namespace WebApplication_EProject.Controllers.RequestController
{
    [Authorize(Roles = "root, giamdoc, phong_vattu")]
    public class VanPhongPhamsController : Controller
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
        // GET: VanPhongPhams
        public ActionResult Index(string SearchString, int? Page_No)
        {
            Statuscheck();
            ViewBag.SortingByFullName = String.IsNullOrEmpty(SearchString) ? "FullName_Sort" : "";

            var item = from a in db.VanPhongPhams select a;
            if (!String.IsNullOrEmpty(SearchString))
            {
                item = item.Where(a => a.productName.Contains(SearchString));
            }

            item = item.OrderBy(a => a.producer);
            int Page_Size = 5;
            int No_Of_Page = (Page_No ?? 1);
            //var customers = db.Customers.Include(c => c.Class);
            return View(item.ToPagedList(No_Of_Page, Page_Size));
        }

        // GET: VanPhongPhams/Details/5
        public ActionResult Details(int? id)
        {
            Statuscheck();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VanPhongPham vanPhongPham = db.VanPhongPhams.Find(id);
            if (vanPhongPham == null)
            {
                return HttpNotFound();
            }
            return View(vanPhongPham);
        }

        // GET: VanPhongPhams/Create
        public ActionResult Create()
        {
            Statuscheck();
            return View();
        }

        // POST: VanPhongPhams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "productID,productName,producer")] VanPhongPham vanPhongPham, HttpPostedFileBase productImage)
        {
            Statuscheck();
            if (productImage != null)
            {

                var supportedTypes = new[] { "jpg", "jpeg", "png" };
                var fileExt = System.IO.Path.GetExtension(productImage.FileName).Substring(1);

                if (!supportedTypes.Contains(fileExt))
                {
                    ViewBag.ErrorMessage = "File Extension Is InValid - Only Upload jpg/jpeg/png File";
                    return View();
                }
                string FileName = System.IO.Path.GetFileName(productImage.FileName);
                string URLLink = Server.MapPath("~/Image/" + FileName);
                vanPhongPham.productImage = FileName;
                productImage.SaveAs(URLLink);
            }
            if (ModelState.IsValid)
            {
                db.VanPhongPhams.Add(vanPhongPham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vanPhongPham);
        }

        // GET: VanPhongPhams/Edit/5
        public ActionResult Edit(int? id)
        {
            Statuscheck();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VanPhongPham vanPhongPham = db.VanPhongPhams.Find(id);
            if (vanPhongPham == null)
            {
                return HttpNotFound();
            }
            return View(vanPhongPham);
        }

        // POST: VanPhongPhams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "productID,productName,producer")] VanPhongPham vanPhongPham, HttpPostedFileBase productImage)
        {
            Statuscheck();
            if (productImage != null)
            {

                var supportedTypes = new[] { "jpg", "jpeg", "png" };
                var fileExt = System.IO.Path.GetExtension(productImage.FileName).Substring(1);

                if (!supportedTypes.Contains(fileExt))
                {
                    ViewBag.ErrorMessage = "File Extension Is InValid - Only Upload jpg/jpeg/png File";
                    return View();
                }
                string FileName = System.IO.Path.GetFileName(productImage.FileName);
                string URLLink = Server.MapPath("~/Image/" + FileName);
                vanPhongPham.productImage = FileName;
                productImage.SaveAs(URLLink);
            }
            if (ModelState.IsValid)
            {

                db.Entry(vanPhongPham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vanPhongPham);
        }

        // GET: VanPhongPhams/Delete/5
        public ActionResult Delete(int? id)
        {
            Statuscheck();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VanPhongPham vanPhongPham = db.VanPhongPhams.Find(id);
            if (vanPhongPham == null)
            {
                return HttpNotFound();
            }
            return View(vanPhongPham);
        }

        // POST: VanPhongPhams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Statuscheck();
            VanPhongPham vanPhongPham = db.VanPhongPhams.Find(id);
            db.VanPhongPhams.Remove(vanPhongPham);
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
