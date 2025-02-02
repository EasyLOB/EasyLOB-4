using EasyLOB.Environment;
using System.Web.Mvc;

namespace EasyLOB
{
    public class EasyLOBMultiTenantAttribute : ActionFilterAttribute // !?! Multi-Tenant
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            AppTenant appTenant = MultiTenantHelper.Tenant; // !?! 100% sure Tenant is updated...
        }
    }
}