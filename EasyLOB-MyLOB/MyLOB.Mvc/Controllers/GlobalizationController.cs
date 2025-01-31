using System;
using System.Web;

namespace EasyLOB.Mvc
{
    public class GlobalizationController : BaseMvc
    {
        #region Methods

        public GlobalizationController(IAuthorizationManager authorizationManager)
            : base(authorizationManager.AuthenticationManager)
        {
        }

        public void Culture(string language, string locale)
        {
            // en-US
            // pt-BR
            string culture = string.Format("{0}-{1}", language, locale);

            HttpCookie cookie = Request.Cookies["ZCulture"];
            if (cookie != null)
            {
                cookie.Value = culture;
            }
            else
            {
                cookie = new HttpCookie("ZCulture");
                cookie.Value = culture;
                cookie.Expires = DateTime.Now.AddYears(1);
            }
            Response.Cookies.Add(cookie);

            //Response.Redirect(Url.Content("~/Home"));
            Response.Redirect(Url.Action("Logout", "Security"));
        }

        #endregion Methods
    }
}