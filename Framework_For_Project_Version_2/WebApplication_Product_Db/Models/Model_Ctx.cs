using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication_Product_Db.Models.Product_Models;

namespace WebApplication_Product_Db.Models
{
	public class Model_Ctx : DbContext
	{
		public Model_Ctx() : base("name=Db_Product")
		{

		}
		public virtual DbSet<Product> Products { get; set; }
		public virtual DbSet<Cart> Carts { get; set; }

		public virtual DbSet<Order_Detail> Order_Details { get; set; }

		public virtual DbSet<Order> Orders { get; set; }
	}
}