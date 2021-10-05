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
using WebApplication_Product_Db.Models;
using WebApplication_Product_Db.Models.Product_Models;

namespace WebApplication_Product_Db.Controllers.Product_Controllers
{
    public class ProductsController : Controller
    {
        private Model_Ctx db = new Model_Ctx();

        String SqlCon = ConfigurationManager.ConnectionStrings["Db_Product"].ConnectionString;
        [ChildActionOnly]
        public ActionResult Count_Customer()
		{
            SqlConnection con = new SqlConnection(SqlCon);
            String sqlCount = "SELECT COUNT(CartId) FROM Carts";
            con.Open();
            SqlCommand cmd = new SqlCommand(sqlCount, con);
            Int32 count = (Int32)cmd.ExecuteScalar();
            con.Close(); //chua check cho nay dau
            ViewBag.haha = count;
            return PartialView();
        }

        public ActionResult View_Customer()
		{
            if(TempData["fail_order"] != null)
			{
                ViewBag.fail_order = TempData["fail_order"];
                return View(db.Products.ToList());
            }
            if(TempData["succeed_order"] != null)
			{
                ViewBag.succeed_order = TempData["succeed_order"];
                return View(db.Products.ToList());
            }
            if(TempData["outofstock"] != null)
			{
                ViewBag.outofstock = TempData["outofstock"];
                return View(db.Products.ToList());
            }
            return View(db.Products.ToList());
        }

        // GET: Products/Detail_Customer/5
        public ActionResult Detail_Customer(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        public ActionResult Buy(int id)
        {
			Cart c = new Cart();
            Product p = db.Products.Find(id);

            if(p.ProductQuantity == 0)
			{
                TempData["outofstock"] = "Không có mặt hàng nào!";
                return RedirectToAction("View_Customer");
            }
            String SqlCon = ConfigurationManager.ConnectionStrings["Db_Product"].ConnectionString;
			SqlConnection con = new SqlConnection(SqlCon);
			string sqlQuery = "Update Carts SET CartQuantity = CartQuantity + 1 where ProductId = @ProductId";
            string sqlQueryPriceCart = "Update Carts SET CartPrice = CartQuantity * "+p.ProductPrice+" where ProductId = @ProductId";
           // string sqlQueryProduct = "Update Products SET ProductQuantity = ProductQuantity - 1 where ProductId = @ProductId";
            con.Open();

			SqlCommand cmd = new SqlCommand(sqlQuery, con);
            //SqlCommand cmdProduct = new SqlCommand(sqlQueryProduct, con);
            SqlCommand cmdPriceCart = new SqlCommand(sqlQueryPriceCart, con);

            cmd.Parameters.AddWithValue("@ProductId", id);
            //cmdProduct.Parameters.AddWithValue("@ProductId", id);
            cmdPriceCart.Parameters.AddWithValue("@ProductId", id);

            int check = cmd.ExecuteNonQuery();
            //cmdProduct.ExecuteNonQuery();
            cmdPriceCart.ExecuteNonQuery();

            con.Close();
            if (check == 0)
			{
                c.CartName = p.ProductName;
                c.CartQuantity = 1;
                c.CartPrice = p.ProductPrice;
                c.CartCmt = p.ProductCmt;
                c.ProductId = p.ProductId;
                db.Carts.Add(c);
                db.SaveChanges();
            }

            return RedirectToAction("View_Customer");
        }

        // GET: Products
        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,ProductName,ProductPrice,ProductQuantity,ProductCmt")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,ProductName,ProductPrice,ProductQuantity,ProductCmt")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
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
