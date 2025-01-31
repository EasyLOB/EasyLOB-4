using EasyLOB.Library;
using EasyLOB.Resources;
using System;
using System.Web.Mvc;

namespace EasyLOB.Mvc
{
    public partial class TasksController
    {
        // GET: Tasks/CleanExportImport
        [HttpGet]
        public ActionResult CleanExportImport()
        {
            //if (IsTask("CleanExportImport", OperationResult))
            //{
                TaskViewModel viewModel = new TaskViewModel("Tasks", "CleanExportImport", EasyLOBPresentationResources.TaskCleanExportImport);

                return ZView("TaskAjax", viewModel);
            //}

            //return ZViewOperationResult(OperationResult);
        }

        // POST: Tasks/CleanExportImport
        [HttpPost]
        public ActionResult CleanExportImport(TaskViewModel viewModel)
        {
            viewModel.OperationResult.Clear();

            try
            {
                //if (IsTask("CleanExportImport", viewModel.OperationResult))
                //{
                //    if (ValidateModelState())
                //    {
                        // Z-Export

                        if (viewModel.OperationResult.Ok)
                        {
                            LibraryHelper.CleanDirectory(viewModel.OperationResult, Server.MapPath(ConfigurationHelper.AppSettings<string>("EasyLOB.Directory.Export")));
                        }

                        // Z-Import

                        if (viewModel.OperationResult.Ok)
                        {
                            LibraryHelper.CleanDirectory(viewModel.OperationResult, Server.MapPath(ConfigurationHelper.AppSettings<string>("EasyLOB.Directory.Import")));
                        }

                        viewModel.OperationResult.InformationMessage = string.Format(ErrorResources.Successful, EasyLOBPresentationResources.TaskCleanExportImport);
                //    }
                //}
            }
            catch (Exception exception)
            {
                viewModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(viewModel.OperationResult);
        }
    }
}