using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebApplication_CodeFirst_Panel.Models
{
	public class Model_Acc_Context : DbContext
	{
		public Model_Acc_Context() : base("name=Db_Acc")
		{

		}
		public virtual DbSet<Department> Departments { get; set; }
		public virtual DbSet<Employee>  Employees { get; set; }
		public virtual DbSet<EmployeeRoleMapping> EmployeeRoleMappings { get; set; }
		public virtual DbSet<Role> Roles { get; set; }
		public virtual DbSet<Contact> Contacts { get; set; }
	}
}