using EasyLOB.Resources;
using System.Web.Mvc;

namespace EasyLOB.Mvc
{
    public partial class TasksController
    {
        #region Methods

        // GET: Tasks/API
        [HttpGet]
        public ActionResult API()
        {
            TaskViewModel viewModel = new TaskViewModel("Tasks", "API", EasyLOBPresentationResources.TaskAPI);

            return ZView(viewModel);
        }

        #endregion Methods
    }
}