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
    public class CartsController : Controller
    {
        private Model_Ctx db = new Model_Ctx();


        public ActionResult Add(int? id)
		{
            Cart cart = db.Carts.Find(id);
            if(cart.Product.ProductQuantity == 0)
			{
                TempData["outofstock"] = "Không có mặt hàng nào!";
                return RedirectToAction("Index");
            }
            String SqlCon = ConfigurationManager.ConnectionStrings["Db_Product"].ConnectionString;
            SqlConnection con = new SqlConnection(SqlCon);
            string sqlQuery = "Update Carts SET CartQuantity = CartQuantity + 1 where CartId = @CartId";
            string sqlQueryPriceCart = "Update Carts SET CartPrice = "+ cart.Product.ProductPrice + " * CartQuantity where ProductId = @ProductId";
            //string sqlQueryProduct = "Update Products SET ProductQuantity = ProductQuantity - 1 where ProductId = @ProductId";
            con.Open();

            SqlCommand cmd = new SqlCommand(sqlQuery, con);
           // SqlCommand cmdProduct = new SqlCommand(sqlQueryProduct, con);
            SqlCommand cmdPriceCart = new SqlCommand(sqlQueryPriceCart, con);

            cmd.Parameters.AddWithValue("@CartId", id);
           // cmdProduct.Parameters.AddWithValue("@ProductId", cart.ProductId);
            cmdPriceCart.Parameters.AddWithValue("@ProductId", cart.ProductId);

            cmd.ExecuteNonQuery();
            //cmdProduct.ExecuteNonQuery();
            cmdPriceCart.ExecuteNonQuery();

            con.Close();
            return RedirectToAction("Index");
        }

        String SqlCon = ConfigurationManager.ConnectionStrings["Db_Product"].ConnectionString;
        
        public ActionResult Minus(int? id)
        {
            SqlConnection con = new SqlConnection(SqlCon);
            Cart cart = db.Carts.Find(id);
            long num_ck = cart.CartQuantity;
            if(num_ck <= 1)
            {
                //string sqlQueryProduct = "Update Products SET ProductQuantity = ProductQuantity + 1 where ProductId = @ProductId";
                //con.Open();
                //SqlCommand cmdProduct = new SqlCommand(sqlQueryProduct, con);
                //cmdProduct.Parameters.AddWithValue("@ProductId", cart.ProductId);
                //cmdProduct.ExecuteNonQuery();
                //con.Close();

                db.Carts.Remove(cart);
                db.SaveChanges();
			}
			else
			{
                string sqlQuery = "Update Carts SET CartQuantity = CartQuantity - 1 where CartId = @CartId";
                string sqlQueryPriceCart = "Update Carts SET CartPrice = " + cart.Product.ProductPrice + " * CartQuantity where ProductId = @ProductId";
                //string sqlQueryProduct = "Update Products SET ProductQuantity = ProductQuantity + 1 where ProductId = @ProductId";
                con.Open();
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
               // SqlCommand cmdProduct = new SqlCommand(sqlQueryProduct, con);
                SqlCommand cmdPriceCart = new SqlCommand(sqlQueryPriceCart, con);

                cmd.Parameters.AddWithValue("@CartId", id);
                //cmdProduct.Parameters.AddWithValue("@ProductId", cart.ProductId);
                cmdPriceCart.Parameters.AddWithValue("@ProductId", cart.ProductId);

                cmd.ExecuteNonQuery();
                //cmdProduct.ExecuteNonQuery();
                cmdPriceCart.ExecuteNonQuery();
                con.Close();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            Cart cart = db.Carts.Find(id);
            //SqlConnection con = new SqlConnection(SqlCon);
            //string sqlQueryProduct = "Update Products SET ProductQuantity = ProductQuantity + "+cart.CartQuantity+" where ProductId = @ProductId";
            //con.Open();
            //SqlCommand cmdProduct = new SqlCommand(sqlQueryProduct, con);
            //cmdProduct.Parameters.AddWithValue("@ProductId", cart.ProductId);
            //cmdProduct.ExecuteNonQuery();
            //con.Close();
			db.Carts.Remove(cart);
			db.SaveChanges();
			return RedirectToAction("Index");
        }

        // GET: Carts
        public ActionResult Index()
        {
            var carts = db.Carts.Include(c => c.Product);
            if (TempData["outofstock"] != null)
            {

                ViewBag.outofstock = TempData["outofstock"];
                return View(carts.ToList());
            }
			return View(carts.ToList());
        }

        // GET: Carts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cart cart = db.Carts.Find(id);
            if (cart == null)
            {
                return HttpNotFound();
            }
            return View(cart);
        }

        //// GET: Carts/Create
        //public ActionResult Create()
        //{
        //    ViewBag.ProductId = new SelectList(db.Products, "ProductId", "ProductName");
        //    return View();
        //}

        //// POST: Carts/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "CartId,CartName,CartQuantity,CartPrice,CartCmt,ProductId")] Cart cart)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Carts.Add(cart);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.ProductId = new SelectList(db.Products, "ProductId", "ProductName", cart.ProductId);
        //    return View(cart);
        //}

        //// GET: Carts/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Cart cart = db.Carts.Find(id);
        //    if (cart == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.ProductId = new SelectList(db.Products, "ProductId", "ProductName", cart.ProductId);
        //    return View(cart);
        //}

        //// POST: Carts/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "CartId,CartName,CartQuantity,CartPrice,CartCmt,ProductId")] Cart cart)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(cart).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.ProductId = new SelectList(db.Products, "ProductId", "ProductName", cart.ProductId);
        //    return View(cart);
        //}

        //// GET: Carts/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Cart cart = db.Carts.Find(id);
        //    if (cart == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(cart);
        //}

        //// POST: Carts/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Cart cart = db.Carts.Find(id);
        //    db.Carts.Remove(cart);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
