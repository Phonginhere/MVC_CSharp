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
using WebApps_Blogs.Models;
using WebApps_Blogs.Models.BlogModel;

namespace WebApps_Blogs.Controllers.BlogController
{
    public class BlogsController : Controller
    {
        private Blog_Ctx db = new Blog_Ctx();

        public ActionResult BlogPublic_TagList(string check)
        {
            if (check == null)
            {
                return RedirectToAction("Error_Nothing", "Home");
            }
            var checking = from c in db.Blogs where c.BlogTag.Contains(check) select c;
            ViewBag.show = check;
            return View(checking);
        }

        public ActionResult BlogPublic_Index()
		{
            return View(db.Blogs.ToList());
        }

        public ActionResult BlogPublic_Details(int? id)
        {
            if (id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                return RedirectToAction("Error_Nothing", "Home");
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                //return HttpNotFound();
                return RedirectToAction("Error_Nothing", "Home");
            }
            return View(blog);
        }


        public ActionResult TagSearch(string check)
		{
            var checking = from c in db.Blogs where c.BlogTag.Contains(check) select c;

            return View(checking);
        }

        // GET: Blogs
        public ActionResult Index()
        {
            return View(db.Blogs.ToList());
        }

        // GET: Blogs/Details/5
        public ActionResult Details(int? id)
        {
            int i = 0;
            i++;
            if (id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                return RedirectToAction("Error_Nothing", "Home");
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                //return HttpNotFound();
                return RedirectToAction("Error_Nothing", "Home");
            }
            return View(blog);
        }

        // GET: Blogs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Blogs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //String SqlCon = ConfigurationManager.ConnectionStrings["Db_Product"].ConnectionString;
        String SqlCon = ConfigurationManager.ConnectionStrings["Db_Blog"].ConnectionString;
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BlogId,BlogName,BlogContent,BlogTag")] Blog blog)
        {
            if (ModelState.IsValid)
            {
                string[] tags = blog.BlogTag.Split(',');
                foreach(var tag in tags)
				{
                    int i = 0;
                    i++;
                    SqlConnection con = new SqlConnection(SqlCon);
                    String sqlCheckTag = "select * from Tags where TagName = @TagName";
                    con.Open();
                    SqlCommand cmd = new SqlCommand(sqlCheckTag, con);
                    cmd.Parameters.AddWithValue("@TagName", tag);
                    SqlDataReader read = cmd.ExecuteReader();
					while (!read.Read())
					{

                        Tag t = new Tag();
                        t.TagName = tag;
                       
                        db.Tags.Add(t);
                        break;
                    }
                    con.Close();
				}

                blog.BlogCreated = DateTime.Now;
                blog.BlogEdited = DateTime.Now;
                db.Blogs.Add(blog);
				db.SaveChanges();
				return RedirectToAction("Index");
            }

            return View(blog);
        }

        // GET: Blogs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                return RedirectToAction("Error_Nothing", "Home");
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                //return HttpNotFound();
                return RedirectToAction("Error_Nothing", "Home");
            }
            return View(blog);
        }

        // POST: Blogs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BlogId,BlogName,BlogContent,BlogTag")] Blog blog)
        {
            if (ModelState.IsValid)
            {
                String SqlCon = ConfigurationManager.ConnectionStrings["Db_Blog"].ConnectionString;
                SqlConnection con = new SqlConnection(SqlCon);
                string sqlQuery = "Update Blogs SET BlogName = @BlogName,BlogContent = @BlogContent,BlogTag = @BlogTag, BlogEdited = @BlogEdited where BlogId = @BlogId";
                con.Open();
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                cmd.Parameters.AddWithValue("@BlogName", blog.BlogName);
                cmd.Parameters.AddWithValue("@BlogContent", blog.BlogContent);
                cmd.Parameters.AddWithValue("@BlogTag", blog.BlogTag);
                cmd.Parameters.AddWithValue("@BlogEdited", DateTime.Now);
                cmd.Parameters.AddWithValue("@BlogId", blog.BlogId);
                int check = cmd.ExecuteNonQuery();
                con.Close();
                if (check == 1)
                {
                    TempData["Notify"] = "Insert Succesful";
                    return RedirectToAction("Index");
                }
                //blog.BlogEdited = DateTime.Now;
                //blog.BlogCreated = blog.BlogCreated;
                //int i = 0;
                //i++;
                //db.Entry(blog).State = EntityState.Modified;
                //db.SaveChanges();
                //return RedirectToAction("Index");
            }
            return View(blog);
        }

        // GET: Blogs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                return RedirectToAction("Error_Nothing", "Home");
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                //return HttpNotFound();
                return RedirectToAction("Error_Nothing", "Home");
            }
            return View(blog);
        }

        // POST: Blogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Blog blog = db.Blogs.Find(id);
            db.Blogs.Remove(blog);
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
