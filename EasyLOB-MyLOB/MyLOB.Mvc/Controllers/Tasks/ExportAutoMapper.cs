using AutoMapper;
using EasyLOB.Library;
using EasyLOB.Resources;
using System.Web.Mvc;
using System.IO;
using System;

namespace EasyLOB.Mvc
{
    public partial class TasksController
    {
        #region Methods

        // GET: Tasks/ExportAutoMapper
        [HttpGet]
        public ActionResult ExportAutoMapper()
        {
            ZOperationResult operationResult = new ZOperationResult();

            try
            {
                if (IsTask("ExportAutoMapper", operationResult))
                {
                    TaskViewModel viewModel = new TaskViewModel("Tasks", "ExportAutoMapper", EasyLOBPresentationResources.TaskExportAutoMapper);

                    return ZView("Task", viewModel);
                }
            }
            catch (Exception exception)
            {
                operationResult.ParseException(exception);
            }

            return ZViewOperationResult(operationResult);
        }

        // POST: Tasks/ExportAutoMapper
        [HttpPost]
        public ActionResult ExportAutoMapper(TaskViewModel viewModel)
        {
            viewModel.OperationResult.Clear();

            try
            {
                if (IsTask("ExportAutoMapper", viewModel.OperationResult))
                {
                    if (IsValid(viewModel.OperationResult, viewModel))
                    {
                        string fileDirectory = Server.MapPath(ConfigurationHelper.AppSettings<string>("EasyLOB.Directory.Export"));
                        string filePath;

                        if (ExportAutoMapper(viewModel.OperationResult, fileDirectory, out filePath))
                        {
                            byte[] file = System.IO.File.ReadAllBytes(filePath);

                            return File(file, EasyLOBHelper.GetContentType(ZFileTypes.ftXLSX), Path.GetFileName(filePath));
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                viewModel.OperationResult.ParseException(exception);
            }

            return ZView("Task", viewModel);
        }

        private bool ExportAutoMapper(ZOperationResult operationResult, string fileDirectory,
            out string filePath)
        {
            filePath = Path.Combine(fileDirectory, "AutoMapper.txt");

            try
            {
                using (StreamWriter stream = new StreamWriter(filePath))
                {
                    TypeMap[] typeMaps = EasyLOBHelper.Mapper.ConfigurationProvider.GetAllTypeMaps();
                    foreach (TypeMap typeMap in typeMaps)
                    {
                        stream.WriteLine("{0} -> {1}", typeMap.SourceType.ToString(), typeMap.DestinationType.ToString());
                    }
                }
            }
            catch (Exception exception)
            {
                operationResult.ParseException(exception);
            }

            return operationResult.Ok;
        }

        #endregion Methods
    }
}
