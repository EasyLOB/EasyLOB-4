using EasyLOB.Mvc;
using EasyLOB.Resources;
using System.Text;
using System.Web.Mvc;

namespace MyLOB.Mvc
{
    public partial class MyLOBTasksController
    {
        #region Methods

        // GET: MyLOBTasks/Status
        [HttpGet]
        public ActionResult Status()
        {
            StringBuilder result = new StringBuilder();

            MyLOBTenant MyLOBtenant = MyLOBMultiTenantHelper.Tenant;
            result.Append("<br /><b>Multi-Tenant MyLOB</b>");
            result.Append("<br />:: Name: " + MyLOBtenant.Name);

            ViewBag.Status = result.ToString();

            TaskViewModel viewModel = new TaskViewModel("MyLOBTasks", "MyLOBStatus", EasyLOBPresentationResources.TaskApplicationStatus);

            return ZView(viewModel);
        }

        #endregion Methods
    }
}