using System.Web.Mvc;

namespace EasyLOB.Mvc
{
    public partial class DashboardsController : BaseMvcControllerDashboard
    {
        [HttpGet]
        public ActionResult PowerBI(string dashboardId)
        {
            ViewBag.Url = "https://app.powerbi.com/view?r=" + dashboardId;
            return View("PowerBI");
        }
    }
}
