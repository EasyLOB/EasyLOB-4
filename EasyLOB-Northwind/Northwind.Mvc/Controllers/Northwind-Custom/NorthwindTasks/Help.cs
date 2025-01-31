using EasyLOB.Mvc;
using EasyLOB.Resources;
using System.Web.Mvc;

namespace Northwind.Mvc
{
    public partial class NorthwindTasksController
    {
        #region Methods

        // GET: NorthwindTasks/Help
        [HttpGet]
        public ActionResult Help()
        {
            TaskViewModel viewModel = new TaskViewModel("NorthwindTasks", "Help", EasyLOBPresentationResources.TaskApplicationHelp);

            return ZView(viewModel);
        }

        #endregion Methods
    }
}