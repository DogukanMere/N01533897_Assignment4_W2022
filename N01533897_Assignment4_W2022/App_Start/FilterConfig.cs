using System.Web;
using System.Web.Mvc;

namespace N01533897_Assignment4_W2022
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
