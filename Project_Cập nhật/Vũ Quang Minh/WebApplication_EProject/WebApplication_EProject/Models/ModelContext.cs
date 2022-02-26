using System;
using System.Data.Entity;
using System.Linq;
using WebApplication_EProject.Models.NhanVienModel;
using WebApplication_EProject.Models.QvA;

namespace WebApplication_EProject.Models
{
    public class ModelContext : DbContext
    {
        public ModelContext() : base("name=ModelContext")       
        {
            
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Blog>()
        //        .Property(b => b.Url)
        //        .IsRequired();
        //}

        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        //public virtual DbSet<NhanVienRoleMapping> NhanVienRoleMappings { get; set; }
        public virtual DbSet<ResetPass> ResetPasses { get; set; }
        //public virtual DbSet<Answer> Answer { get; set; }
        public virtual DbSet<Question> Question { get; set; }

		public System.Data.Entity.DbSet<WebApplication_EProject.Models.QvA.Answer> Answers { get; set; }

		public System.Data.Entity.DbSet<WebApplication_EProject.Models.Request.VanPhongPham> VanPhongPhams { get; set; }

		public System.Data.Entity.DbSet<WebApplication_EProject.Models.Request.Request> Requests { get; set; }

		public System.Data.Entity.DbSet<WebApplication_EProject.Models.Request.Log> Logs { get; set; }
	}
}