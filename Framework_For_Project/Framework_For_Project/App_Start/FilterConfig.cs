﻿using System.Web;
using System.Web.Mvc;

namespace Framework_For_Project
{
	public class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
		}
	}
}
