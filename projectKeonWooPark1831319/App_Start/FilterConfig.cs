using System.Web;
using System.Web.Mvc;

namespace projectKeonWooPark1831319
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
