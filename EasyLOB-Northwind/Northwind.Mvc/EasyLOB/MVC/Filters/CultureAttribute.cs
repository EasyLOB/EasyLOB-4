using System;
using System.Globalization;
using System.Threading;
using System.Web;
using System.Web.Mvc;

// How to Easily Manage Different Languages ​​on a Website: a Complete Tutorial With ASP.NET MVC
// http://www.spiria.com/en/blog/web-applications/how-easily-manage-different-languages-website-complete-tutorial-aspnet-mvc

namespace EasyLOB
{
    public class CultureAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpCookie cookie = filterContext.HttpContext.Request.Cookies["ZCulture"];
            if (cookie == null)
            {
                cookie = new HttpCookie("ZCulture");
                cookie.Value = "pt-BR"; // !!!
                cookie.Expires = DateTime.Now.AddYears(1);
                filterContext.HttpContext.Response.Cookies.Add(cookie);
            }

            CultureInfo ci = CultureInfo.CreateSpecificCulture(cookie.Value);

            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;

            CultureInfo.DefaultThreadCurrentCulture = ci;
            CultureInfo.DefaultThreadCurrentUICulture = ci;

            //CultureInfo ci = new CultureInfo(cookie.Value);
            //Thread.CurrentThread.CurrentCulture = ci;
            //Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(ci.Name);
        }
    }
}