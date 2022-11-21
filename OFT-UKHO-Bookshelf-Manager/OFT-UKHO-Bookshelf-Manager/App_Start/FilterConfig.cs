using System.Web;
using System.Web.Mvc;

namespace OFT_UKHO_Bookshelf_Manager
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
