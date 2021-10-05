using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebAppication_Blog_Only.Models;

namespace WebAppication_Blog_Only
{
	public class MvcApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);
			DropCreateDatabaseIfModelChanges<Model_Blog_Context> mbc = new DropCreateDatabaseIfModelChanges<Model_Blog_Context>();
			Database.SetInitializer(mbc);
		}
	}
}
