using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Data.Entity;
using WebApplication_CodeFirst_Panel_4.Models;

namespace WebApplication_CodeFirst_Panel_4
{
	public class MvcApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);

			DropCreateDatabaseIfModelChanges<Model_Acc_Context> mac = new DropCreateDatabaseIfModelChanges<Model_Acc_Context>();
			Database.SetInitializer(mac);
		}
	}
}
