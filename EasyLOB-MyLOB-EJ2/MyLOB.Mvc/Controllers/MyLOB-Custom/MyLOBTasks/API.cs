using EasyLOB.Mvc;
using EasyLOB.Resources;
using System.Web.Mvc;

namespace MyLOB.Mvc
{
    public partial class MyLOBTasksController
    {
        #region Methods

        // GET: MyLOBTasks/API
        [HttpGet]
        public ActionResult API()
        {
            TaskViewModel viewModel = new TaskViewModel("MyLOBTasks", "MyLOBAPI", EasyLOBPresentationResources.TaskApplicationAPI);

            return ZView(viewModel);
        }

        #endregion Methods
    }
}