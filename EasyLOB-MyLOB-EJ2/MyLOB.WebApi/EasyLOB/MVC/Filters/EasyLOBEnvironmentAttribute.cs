using EasyLOB.AuditTrail;
using EasyLOB.Environment;
using System;
using System.Web.Mvc;

namespace EasyLOB
{
    public class EasyLOBEnvironmentAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (string.IsNullOrEmpty(EnvironmentHelper.Environment.UserName))
            {
                EnvironmentHelper.Login(DependencyResolver.Current.GetService<IAuthenticationManager>(),
                    DependencyResolver.Current.GetService<IAuditTrailUnitOfWork>());
            }

            base.OnActionExecuting(filterContext);
        }
    }
}