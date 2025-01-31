using EasyLOB.Resources;
using System.Web.Mvc;

namespace EasyLOB.Mvc
{
    public partial class TasksController
    {
        #region Methods

        // GET: Tasks/Help
        [HttpGet]
        public ActionResult Help()
        {
            TaskViewModel viewModel = new TaskViewModel("Tasks", "Help", EasyLOBPresentationResources.TaskHelp);

            return ZView(viewModel);
        }

        #endregion Methods
    }
}