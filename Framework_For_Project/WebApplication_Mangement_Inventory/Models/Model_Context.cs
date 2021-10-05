using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication_Mangement_Inventory.Models
{
	public class Model_Context : DbContext
	{
		public Model_Context() : base("name=DB_Acc")
		{

		}
		public virtual DbSet<Account> Account { get; set; }
	}
}