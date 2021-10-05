using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApps_Blogs
{
	public class RouteConfig
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
				name: "Default",
				url: "{controller}/{action}/{id}",
				defaults: new { controller = "Blogs", action = "BlogPublic_Index", id = UrlParameter.Optional }
			);

			//routes.MapRoute(
			//name: "CatchAll",
			//url: "{*any}",
			//defaults: new { controller = "Blogs", action = "BlogPublic_Index", id = UrlParameter.Optional }
			//);
		}
	}
}
