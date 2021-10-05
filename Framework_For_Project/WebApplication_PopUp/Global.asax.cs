using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Data.Entity;
using WebApplication_PopUp.Models;

namespace WebApplication_PopUp
{
	public class MvcApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);

			DropCreateDatabaseIfModelChanges<Model_Employee_Context> mec = new DropCreateDatabaseIfModelChanges<Model_Employee_Context>();
			Database.SetInitializer(mec);
		}
	}
}
