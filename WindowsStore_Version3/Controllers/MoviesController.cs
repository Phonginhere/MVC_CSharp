using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WindowsStore_Version3.Models;
using PagedList;

namespace WindowsStore_Version3.Controllers
{
    public class MoviesController : Controller
    {
        private ExamEntities db = new ExamEntities();

        // GET: Movies
        public ActionResult Index(string Sorting_Order, string catename, string Search_Data, string Filter_Value, int? Page_No)
        {
            ViewBag.CurrentSortOrder = Sorting_Order;
            ViewBag.SortingName = String.IsNullOrEmpty(Sorting_Order) ? "Name_Description" : "";
            ViewBag.SortingDate = Sorting_Order == "Date_Enroll" ? "Date_Description" : "Date";

            //category name

            var namecategory = typeof(Movie).GetProperties().Select(n => n.Name);

            SelectList sl = new SelectList(namecategory);

            ViewBag.shownamecate = sl;

            //show table 

            var movies = from mve in db.Movies select mve;

            //search option 

            if (!(String.IsNullOrEmpty(Search_Data)))
            {
                if (catename == "Title")
                {
                    movies = from m in db.Movies where m.Title.Contains(Search_Data) select m;
                }
                else if (catename == "ReleaseDate")
                {
                    try
                    {
                        DateTime runtime = Convert.ToDateTime(Search_Data);
                        movies = from m in db.Movies where m.ReleaseDate == runtime select m;
                    }
                    catch (Exception e)
                    {
                        ViewBag.Error = "Lỗi cách nhập";
                    }

                }
                else if (catename == "RunningTime")
                {
                    try
                    {
                        int runtime = Convert.ToInt16(Search_Data);
                        movies = from m in db.Movies where m.RunningTime == runtime select m;
                    }
                    catch (Exception e)
                    {
                        ViewBag.Error = "Lỗi cách nhập";
                    }

                }
                else if (catename == "BoxOffice")
                {
                    try
                    {
                        //decimal boffice = System.Convert.ToDecimal(name);
                        var boffice = Decimal.Parse(Search_Data);
                        movies = from m in db.Movies where m.BoxOffice == boffice select m;
                    }
                    catch (Exception e)
                    {
                        ViewBag.Error = "Lỗi cách nhập";
                    }
                }
                else if (catename == "Genre")
                {
                    movies = from m in db.Movies where m.Genre.GenreName.Contains(Search_Data) select m;

                }
            }

            if (Search_Data != null)
            {
                Page_No = 1;
            }
            else
            {
                Search_Data = Filter_Value;
            }

            ViewBag.FilterValue = Search_Data;

            

            switch (Sorting_Order)
            {
                case "Name_Description":
                    movies = movies.OrderByDescending(mvc => mvc.Title);
                    break;
                case "Date_Enroll":
                    movies = movies.OrderBy(mvc => mvc.ReleaseDate);
                    break;
                case "Date_Description":
                    movies = movies.OrderByDescending(mvc => mvc.ReleaseDate);
                    break;
                default:
                    movies = movies.OrderBy(mvc => mvc.Title);
                    break;
            }
            int Size_Of_Page = 4;
            int No_Of_Page = (Page_No ?? 1);

            return View(movies.ToPagedList(No_Of_Page, Size_Of_Page));
        }

        // GET: Movies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // GET: Movies/Create
        public ActionResult Create()
        {
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "GenreName");
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MovieId,Title,ReleaseDate,RunningTime,GenreId,BoxOffice")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Movies.Add(movie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "GenreName", movie.GenreId);
            return View(movie);
        }

        // GET: Movies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "GenreName", movie.GenreId);
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MovieId,Title,ReleaseDate,RunningTime,GenreId,BoxOffice")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "GenreName", movie.GenreId);
            return View(movie);
        }

        // GET: Movies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
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
