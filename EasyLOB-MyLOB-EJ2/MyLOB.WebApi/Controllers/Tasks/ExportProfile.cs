using EasyLOB.Data;
using EasyLOB.Resources;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Web.Mvc;

namespace EasyLOB.Mvc
{
    public partial class TasksController
    {
        // GET: Tasks/ExportProfile
        [HttpGet]
        public ActionResult ExportProfile()
        {
            ZOperationResult operationResult = new ZOperationResult();

            try
            {
                if (IsTask("ExportProfile", operationResult))
                {
                    TaskViewModel viewModel = new TaskViewModel("Tasks", "ExportProfile", EasyLOBPresentationResources.TaskExportProfile);

                    return ZView("Task", viewModel);
                }
            }
            catch (Exception exception)
            {
                operationResult.ParseException(exception);
            }

            return ZViewOperationResult(operationResult);
        }

        // POST: Tasks/ExportProfile
        [HttpPost]
        public ActionResult ExportProfile(TaskViewModel viewModel)
        {
            viewModel.OperationResult.Clear();

            try
            {
                if (IsTask("ExportProfile", viewModel.OperationResult))
                {
                    if (IsValid(viewModel.OperationResult, viewModel))
                    {
                        string fileDirectory = Server.MapPath(ConfigurationHelper.AppSettings<string>("EasyLOB.Directory.Export"));

                        //string filePath;
                        //if (ExportProfile(viewModel.OperationResult, fileDirectory, out filePath))
                        //{
                        //    byte[] file = System.IO.File.ReadAllBytes(filePath);

                        //    return File(file, EasyLOBHelper.GetContentType(ZFileTypes.ftXLSX), Path.GetFileName(filePath));
                        //}

                        int files;
                        if (ExportProfiles(viewModel.OperationResult, fileDirectory, out files))
                        {
                            viewModel.OperationResult.AddOperationInformation("", files.ToString() + " Profile(s)");
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

        private bool ExportProfile(ZOperationResult operationResult, string fileDirectory,
            out string filePath)
        {
            filePath = Path.Combine(fileDirectory, "Profile.json");

            try
            {
                JsonSerializer serializer = new JsonSerializer
                {
                    DefaultValueHandling = DefaultValueHandling.Populate,
                    Formatting = Formatting.Indented,
                    NullValueHandling = NullValueHandling.Include
                };

                using (StreamWriter stream = new StreamWriter(filePath))
                using (JsonWriter writer = new JsonTextWriter(stream))
                {
                    serializer.Serialize(writer, DataHelper.Profiles);
                }
            }
            catch (Exception exception)
            {
                operationResult.ParseException(exception);
            }

            return operationResult.Ok;
        }

        private bool ExportProfiles(ZOperationResult operationResult, string fileDirectory,
            out int files)
        {
            files = 0;

            try
            {
                JsonSerializer serializer = new JsonSerializer
                {
                    DefaultValueHandling = DefaultValueHandling.Populate,
                    Formatting = Formatting.Indented,
                    NullValueHandling = NullValueHandling.Include
                };

                foreach (var profile in DataHelper.Profiles)
                {
                    // Dictionary<type, IZProfile>
                    // EasyLOB.Activity.Data.Activity, EasyLOB.Activity.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null

                    // FullName             EasyLOB.Activity.Data.Activity
                    // Name                 Activity
                    // Namespace            EasyLOB.Activity.Data

                    string filePath = Path.Combine(fileDirectory, profile.Key.FullName + ".json");

                    using (StreamWriter stream = new StreamWriter(filePath))
                    using (JsonWriter writer = new JsonTextWriter(stream))
                    {
                        serializer.Serialize(writer, profile);
                    }

                    files++;
                }

                files++;
            }
            catch (Exception exception)
            {
                operationResult.ParseException(exception);
            }

            return operationResult.Ok;
        }
    }
}