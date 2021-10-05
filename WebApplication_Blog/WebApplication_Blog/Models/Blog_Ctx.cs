using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication_Blog.Models.Admin;
using WebApplication_Blog.Models.BlogModel;
using WebApplication_Blog.Models.Models.BlogModel;

namespace WebApplication_Blog.Models
{
	public class Blog_Ctx : DbContext
	{
		public Blog_Ctx() : base("name=Db_Blog")
		{

		}
		public virtual DbSet<Blog> Blogs { get; set; }
		public virtual DbSet<Tag> Tags { get; set; }
		public virtual DbSet<Account> Accounts { get; set; }
	}
}