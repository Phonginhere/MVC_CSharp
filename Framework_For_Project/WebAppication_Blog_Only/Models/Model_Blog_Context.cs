using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebAppication_Blog_Only.Models
{
	public class Model_Blog_Context : DbContext
	{
		public Model_Blog_Context() : base("name=Model_Blog")
		{

		}
		public virtual DbSet<Blog> Blogs { get; set; }
	}
}