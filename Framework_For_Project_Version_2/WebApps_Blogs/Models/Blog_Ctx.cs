using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApps_Blogs.Models;
using WebApps_Blogs.Models.Admin;
using WebApps_Blogs.Models.BlogModel;

namespace WebApps_Blogs.Models
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