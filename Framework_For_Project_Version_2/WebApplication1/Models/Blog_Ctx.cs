using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication_Blog_Ver2;
using WebApplication_Blog_Ver2.Admin;
using WebApplication_Blog_Ver2.BlogModel;

namespace WebApplication_Blog_Ver2.Models
{
	public class Blog_Ctx : DbContext
	{
		public Blog_Ctx() : base("name=Db_Blog")
		{

		}
		public virtual DbSet<Blog> Blogs { get; set; }
		public virtual DbSet<Tag> Tags { get; set; }
		public virtual DbSet<Account> Accounts { get; set; }
		public virtual DbSet<EmployeeRoleMapping> EmployeeRoleMappings { get; set; }
		public virtual DbSet<Role> Roles { get; set; }
	}
}