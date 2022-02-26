using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Security.Authentication;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using WebApplication_EProject.Models;
using WebApplication_EProject.Models.NhanVienModel;

namespace WebApplication_EProject
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Database.SetInitializer<ModelContext>(new StudentDbInitializer());
        }

    }
    public class StudentDbInitializer : DropCreateDatabaseIfModelChanges<ModelContext>
    {
        protected override void Seed(ModelContext context)
        {
            //roles
            var roles = new List<Role>
        {
            new Role { Role_ID = 1, RoleName = "root" },
            new Role { Role_ID = 2, RoleName = "giamdoc" },
            new Role { Role_ID = 3, RoleName = "phong_nhansu" },
            new Role { Role_ID = 4, RoleName = "phong_ketoan" },
            new Role { Role_ID = 5, RoleName = "phong_vattu" },
            new Role { Role_ID = 6, RoleName = "truongphong_sanxuat" },
            new Role { Role_ID = 7, RoleName = "nhanvien_sanxuat" },
            new Role { Role_ID = 8, RoleName = "truongphong_nhansu_ketoan_vattu" }
        };

            //nhan vien
            var nhanviens = new List<NhanVien>
        {
            new NhanVien { Employee_ID = 1, Ten = "Hải Phong Trần", Email = "tranhaiphong2016fpt@gmail.com", SDT = "0312345678", NgayTao = DateTime.Now,
                NgaySua = DateTime.Now,  DOB = Convert.ToDateTime("2004-04-12 00:00:00.000"),
                MatKhau = BCrypt.Net.BCrypt.HashPassword("@Phongloveweb123"), Role_ID = 1, Status = 1}

        };

            //insert into db
            roles.ForEach(s => context.Roles.Add(s));
            nhanviens.ForEach(s => context.NhanViens.Add(s));
            context.SaveChanges();

        }
    }

}
