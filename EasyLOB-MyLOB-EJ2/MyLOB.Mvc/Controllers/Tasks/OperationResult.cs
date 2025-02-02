using System.Web.Mvc;

namespace EasyLOB.Mvc
{
    public partial class TasksController // ###
    {
        #region Methods

        // GET: Tasks/AjaxOperationResultFalse
        [HttpPost]
        public ActionResult AjaxOperationResultFalse()
        {
            ZOperationResult operationResult = new ZOperationResult();

            PresentationHelper.Error(operationResult);
            PresentationHelper.Exception(operationResult);
            PresentationHelper.Warning(operationResult);
            PresentationHelper.Data(operationResult);

            return JsonResultOperationResult(operationResult, "EasyLOB");
        }

        // GET: Tasks/AjaxOperationResultTrue
        [HttpPost]
        public ActionResult AjaxOperationResultTrue()
        {
            ZOperationResult operationResult = new ZOperationResult();

            PresentationHelper.Information(operationResult);
            PresentationHelper.Data(operationResult);

            return JsonResultOperationResult(operationResult, new { OperationResult = operationResult });
        }

        // GET: Tasks/OperationResultFalse
        [HttpGet]
        public ActionResult OperationResultFalse()
        {
            ZOperationResult operationResult = new ZOperationResult();

            PresentationHelper.Error(operationResult);
            PresentationHelper.Exception(operationResult);
            PresentationHelper.Warning(operationResult);
            PresentationHelper.Data(operationResult);

            OperationResultModel viewModel = new OperationResultModel(operationResult);

            return View("OperationResult", viewModel);
        }

        // GET: Tasks/OperationResultTrue
        [HttpGet]
        public ActionResult OperationResultTrue()
        {
            ZOperationResult operationResult = new ZOperationResult();

            PresentationHelper.Information(operationResult);
            PresentationHelper.Data(operationResult);

            OperationResultModel viewModel = new OperationResultModel(operationResult);

            return View("OperationResult", viewModel);
        }

        #endregion Methods
    }
}