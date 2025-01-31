using EasyLOB.Mvc;
using EasyLOB.Resources;
using System.Web.Mvc;

namespace MyLOB.Mvc
{
    public partial class MyLOBTasksController
    {
        #region Methods

        // GET: MyLOBTasks/Help
        [HttpGet]
        public ActionResult Help()
        {
            TaskViewModel viewModel = new TaskViewModel("MyLOBTasks", "Help", EasyLOBPresentationResources.TaskApplicationHelp);

            return ZView(viewModel);
        }

        #endregion Methods
    }
}