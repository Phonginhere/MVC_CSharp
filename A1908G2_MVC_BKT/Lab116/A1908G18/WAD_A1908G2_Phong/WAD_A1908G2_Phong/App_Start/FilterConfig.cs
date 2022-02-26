using System.Web;
using System.Web.Mvc;

namespace WAD_A1908G2_Phong
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
