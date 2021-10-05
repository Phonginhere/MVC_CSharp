using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WebApplication_CLoud_Azure.Models
{
	public partial class Model_cloud : DbContext
	{
		public Model_cloud()
			: base("name=Model_cloud")
		{
		}

		public virtual DbSet<LinhsTestTable2> LinhsTestTable2 { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
		}
	}
}
