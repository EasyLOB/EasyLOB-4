using System.Web.Mvc;

namespace EasyLOB.Mvc
{
    public class HomeController : BaseMvc
    {
        #region Methods

        public ActionResult Index(string operation = null)
        {
            return View();
        }

        #endregion
    }
}