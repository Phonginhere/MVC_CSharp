using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Data.Entity;
using WebApplication_Project_Version_2.Models;

namespace WebApplication_Project_Version_2
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            DropCreateDatabaseIfModelChanges<Model_Project_Context> mpc = new DropCreateDatabaseIfModelChanges<Model_Project_Context>();
            Database.SetInitializer(mpc);
        }
    }
}
