using EasyLOB.Log;
using System;
using System.Web.Mvc;

namespace EasyLOB.Mvc
{
    public partial class TasksController
    {
        // GET: Tasks/NLog
        [HttpGet]
        public ActionResult NLog()
        {
            ZOperationResult operationResult = new ZOperationResult();

            try
            {
                if (IsTask("NLog", operationResult))
                {
                    TaskViewModel viewModel = new TaskViewModel("Tasks", "NLog", "NLog");

                    return ZView("Task", viewModel);
                }
            }
            catch (Exception exception)
            {
                operationResult.ParseException(exception);
            }

            return ZViewOperationResult(operationResult);
        }

        // POST: Tasks/NLog
        [HttpPost]
        public ActionResult NLog(TaskViewModel viewModel)
        {
            viewModel.OperationResult.Clear();

            try
            {
                if (IsTask("NLog", viewModel.OperationResult))
                {
                    if (IsValid(viewModel.OperationResult, viewModel))
                    {
                        ILogManager logManager = EasyLOBHelper.GetService<ILogManager>();

                        logManager.Trace("Trace");
                        logManager.Debug("Debug");
                        logManager.Information("Information");
                        logManager.Warning("Warning");
                        logManager.Error("Error");
                        logManager.Fatal("Fatal");

                        logManager.Trace("Trace", new object[] { "ABC", 1.23, DateTime.Now });
                        logManager.Debug("Debug", new object[] { "ABC", 1.23, DateTime.Now });
                        logManager.Information("Information", new object[] { "ABC", 1.23, DateTime.Now });
                        logManager.Warning("Warning", new object[] { "ABC", 1.23, DateTime.Now });
                        logManager.Error("Error", new object[] { "ABC", 1.23, DateTime.Now });
                        logManager.Fatal("Fatal", new object[] { "ABC", 1.23, DateTime.Now });

                        logManager.Trace("{Parameter1} {Parameter2} {Parameter3}", "ABC", 1.23, DateTime.Now);

                        try
                        {
                            int x = Int32.Parse("ABC");
                            int y = x + 1;
                        }
                        catch (Exception exception)
                        {
                            logManager.Exception(exception, "ABC");
                        }

                        try
                        {
                            int x = Int32.Parse("ABC");
                            int y = x + 1;
                        }
                        catch (Exception exception)
                        {
                            ZOperationResult operationResult = new ZOperationResult();
                            operationResult.ParseException(exception);
                            AppHelper.Log(operationResult, Request.Url.OriginalString);
                        }

                        {
                            int x = Int32.Parse("ABC");
                            int y = x + 1;
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
    }
}