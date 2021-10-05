using System.Web;
using System.Web.Mvc;

namespace WebApplication_Blog_Ver2
{
	public class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
		}
	}
}
