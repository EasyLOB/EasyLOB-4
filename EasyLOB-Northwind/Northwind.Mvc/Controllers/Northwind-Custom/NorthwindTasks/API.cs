using EasyLOB.Mvc;
using EasyLOB.Resources;
using System.Web.Mvc;

namespace Northwind.Mvc
{
    public partial class NorthwindTasksController
    {
        #region Methods

        // GET: NorthwindTasks/API
        [HttpGet]
        public ActionResult API()
        {
            TaskViewModel viewModel = new TaskViewModel("NorthwindTasks", "API", EasyLOBPresentationResources.TaskApplicationAPI);

            return ZView(viewModel);
        }

        #endregion Methods
    }
}