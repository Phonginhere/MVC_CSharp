using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication_Product.Models
{
	public class Model_Ctx : DbContext
	{
		public Model_Ctx() : base ("name=Db_Product")
		{
			
		}
		public virtual DbSet<Product> Products { get; set; }
		public virtual DbSet<Item> Items { get; set; }
	}
}