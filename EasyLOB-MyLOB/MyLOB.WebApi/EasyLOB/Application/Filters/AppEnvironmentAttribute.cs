using System.Web.Mvc;

namespace EasyLOB
{
    public class AppEnvironmentAttribute : ActionFilterAttribute // !!!
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
        }
    }
}