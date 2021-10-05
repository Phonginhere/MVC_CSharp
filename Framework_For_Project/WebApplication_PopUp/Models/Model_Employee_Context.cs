using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication_PopUp.Models
{
	public class Model_Employee_Context : DbContext
	{
		public Model_Employee_Context() : base("name=Db_Employee")
		{

		}
		public virtual DbSet<Employee> Employees { get; set; }
	}
}