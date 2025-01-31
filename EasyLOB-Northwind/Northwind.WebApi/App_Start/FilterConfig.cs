using System.Web.Mvc;

namespace EasyLOB
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());

            // Filters

            //filters.Add(new CultureAttribute()); // ???
            filters.Add(new ValidateModelStateAttribute());
        }
    }
}
