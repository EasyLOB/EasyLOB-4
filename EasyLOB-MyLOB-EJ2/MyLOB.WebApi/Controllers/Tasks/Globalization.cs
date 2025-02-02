using EasyLOB.Resources;
using System.Web.Mvc;

namespace EasyLOB.Mvc
{
    public partial class TasksController
    {
        #region Methods

        // GET: Tasks/Globalization
        [HttpGet]
        public ActionResult Globalization()
        {
            TaskViewModel viewModel = new TaskViewModel("Tasks", "Globalization", EasyLOBPresentationResources.TaskGlobalization);

            return ZView(viewModel);

        }

        #endregion Methods
    }
}
