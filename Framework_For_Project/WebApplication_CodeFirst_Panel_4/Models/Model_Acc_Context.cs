using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication_CodeFirst_Panel_4.Models
{
	public class Model_Acc_Context : DbContext
	{
		public Model_Acc_Context() : base("name=Db_Acc")
		{

		}
		public virtual DbSet<Employee> Employees { get; set; }
	}
}