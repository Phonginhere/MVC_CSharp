﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebApplication_CodeFirst_Panel_2.Models;

namespace WebApplication_CodeFirst_Panel_2
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
