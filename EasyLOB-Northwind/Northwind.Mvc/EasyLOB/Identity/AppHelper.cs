using EasyLOB.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security.DataProtection;
using System.Web;

namespace EasyLOB
{
    public static partial class AppHelper
    {
        #region Properties

        public static ApplicationUserManager UserManager
        {
            get
            {
                ApplicationUserManager userManager =
                    HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var provider =
                    new DpapiDataProtectionProvider("EasyLOB");
                userManager.UserTokenProvider =
                    new DataProtectorTokenProvider<EasyLOB.Identity.ApplicationUser, string>(provider.Create("UserToken")) as IUserTokenProvider<EasyLOB.Identity.ApplicationUser, string>;

                return userManager;
            }
        }

        #endregion Properties
    }
}