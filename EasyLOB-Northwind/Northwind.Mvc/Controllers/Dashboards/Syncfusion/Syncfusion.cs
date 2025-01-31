using EasyLOB.Library;
using System;
using System.IO;
using System.Web.Mvc;

namespace EasyLOB.Mvc
{
    public partial class DashboardsController : BaseMvcControllerDashboard
    {
        [HttpGet]
        public ActionResult Syncfusion(string dashboardDirectory, string dashboardName)
        {
            ZOperationResult operationResult = new ZOperationResult();

            try
            {
                if (string.IsNullOrEmpty(dashboardName))
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    if (!string.IsNullOrEmpty(dashboardDirectory))
                    {
                        ViewBag.ReportPath = Path.Combine(Server.MapPath(ConfigurationHelper.AppSettings<string>("EasyLOB.Dashboard.SyncfusionDirectory")), dashboardDirectory, dashboardName + ".sydx")
                            .Replace("\\", "\\\\");
                    }
                    else
                    {
                        ViewBag.ReportPath = Path.Combine(Server.MapPath(ConfigurationHelper.AppSettings<string>("EasyLOB.Dashboard.SyncfusionDirectory")), dashboardName + ".sydx")
                            .Replace("\\", "\\\\");
                    }

                    DashboardViewer dashboardViewer = new DashboardViewer();
                    ViewBag.Errormessage = dashboardViewer.Errormessage;
                    string url = ConfigurationHelper.AppSettings<string>("EasyLOB.Dashboard.SyncfusionUrl");
                    ViewBag.ServiceURL = string.IsNullOrEmpty(url) ? dashboardViewer.ServiceUrl : url;

                    return View("Syncfusion");
                }
            }
            catch (Exception exception)
            {
                operationResult.ParseException(exception);

                return ZViewOperationResult(operationResult);
            }
        }
    }
}