using EasyLOB.Mvc;
using EasyLOB.Resources;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Northwind.Mvc
{
    public partial class NorthwindTasksController
    {
        #region Methods

        // GET: NorthwindTasks/Status
        [HttpGet]
        public ActionResult Status()
        {
            StringBuilder result = new StringBuilder();

            NorthwindTenant tenant = NorthwindMultiTenantHelper.Tenant;
            result.Append("<br /><b>Multi-Tenant Northwind</b>");
            result.Append("<br />:: URL: " + tenant.Name);

            ViewBag.Status = result.ToString();

            TaskViewModel taskViewModel = new TaskViewModel("NorthwindTasks", "Status", EasyLOBPresentationResources.TaskApplicationStatus);

            return ZView(taskViewModel);
        }

        #endregion Methods
    }
}