using System.Web;
using System.Web.Mvc;

namespace WebAppication_Blog_Only
{
	public class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
		}
	}
}
