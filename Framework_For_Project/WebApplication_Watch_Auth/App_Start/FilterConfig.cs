﻿using System.Web;
using System.Web.Mvc;

namespace WebApplication_Watch_Auth
{
	public class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
		}
	}
}
