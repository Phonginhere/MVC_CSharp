using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication_Product_Db.Models;
using WebApplication_Product_Db.Models.Product_Models;

namespace WebApplication_Product_Db.Controllers.Product_Controllers
{
    public class OrdersController : Controller
    {
        private Model_Ctx db = new Model_Ctx();

        List<Cart> listp = null;
        public List<Cart> findAll()
        {
            listp = new List<Cart>();
            var cart = from c in db.Carts select c;
            foreach (var item in cart)
            {
                Cart c = new Cart();
                c.CartId = item.CartId;
                c.CartName = item.CartName;
                c.CartQuantity = item.CartQuantity;
                c.CartPrice = item.CartPrice;
                c.CartCmt = item.CartCmt;
                listp.Add(c);
            }
            return this.listp;
        }

        // GET: Orders
        public ActionResult Index()
        {
            var orders = db.Orders.Include(o => o.Order_Detail);
            return View(orders.ToList());
        }

        // GET: Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            var cartlist_all = from cl in db.Carts select cl;

            if (cartlist_all.Count() == 0)
            {
                TempData["fail_order"] = "Đặt Hàng Thất Bại";
                return RedirectToAction("View_Customer", "Products");
            }

            ViewBag.carts = findAll();
            ViewBag.Order_DetailId = new SelectList(db.Order_Details, "Order_DetailId", "Order_DetailName");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderId,Order_CustomerName,Order_CustomerPhoneNum,Order_CustomerAddress,Order_Time,Order_DetailId")] Order order)
        {
            if (ModelState.IsValid)
            {
                var cartlist_all = from cl in db.Carts select cl;

                if(cartlist_all.Count() == 0)
				{
                    TempData["fail_order"] = "Đặt Hàng Thất Bại";
                    return RedirectToAction("View_Customer", "Products");
                }

                foreach (var item in cartlist_all)
                {
                    Order_Detail od = new Order_Detail();
                    od.Order_DetailId = item.CartId;
                    od.Order_DetailName = item.CartName;
                    od.Order_DetailQuantity = item.CartQuantity;
                    od.Order_DetailPrice = item.CartPrice;
                    db.Order_Details.Add(od);

                    Order order1 = new Order();
                    order1.Order_DetailId = order.OrderId;
                    order1.Order_CustomerName = order.Order_CustomerName;
                    order1.Order_CustomerAddress = order.Order_CustomerAddress;
                    order1.Order_CustomerPhoneNum = order.Order_CustomerPhoneNum;
                    order1.Order_Time = DateTime.Now;
                    order1.Order_DetailId = item.CartId;
                    db.Orders.Add(order1);
                }

                db.Carts.RemoveRange(db.Carts.ToList());
                db.SaveChanges();

                TempData["succeed_order"] = "Đặt Hàng Thành Công";
                return RedirectToAction("View_Customer", "Products");
            }

            ViewBag.Order_DetailId = new SelectList(db.Order_Details, "Order_DetailId", "Order_DetailName", order.Order_DetailId);
            return View(order);
        }

        // GET: Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.Order_DetailId = new SelectList(db.Order_Details, "Order_DetailId", "Order_DetailName", order.Order_DetailId);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderId,Order_CustomerName,Order_CustomerPhoneNum,Order_CustomerAddress,Order_Time,Order_DetailId")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Order_DetailId = new SelectList(db.Order_Details, "Order_DetailId", "Order_DetailName", order.Order_DetailId);
            return View(order);
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
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
