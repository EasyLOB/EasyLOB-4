using EasyLOB.Data;
using EasyLOB.Library;
using EasyLOB.Resources;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Web.Mvc;

namespace EasyLOB.Mvc
{
    public partial class TasksController
    {
        // GET: Tasks/ProfileViewer
        [HttpGet]
        public ActionResult ProfileViewer()
        {
            ZOperationResult operationResult = new ZOperationResult();

            try
            {
                if (IsTask("ProfileViewer", operationResult))
                {
                    ProfileViewerViewModel viewModel = new ProfileViewerViewModel("Tasks", "ProfileViewer", EasyLOBPresentationResources.TaskProfileViewer);

                    Dictionary<string, string> entities = new Dictionary<string, string>();
                    Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
                    //Array.Sort(assemblies);
                    foreach (Assembly assembly in assemblies)
                    {
                        Type[] types = assembly.GetTypes();
                        //Array.Sort(types);
                        foreach (Type type in types)
                        {
                            if (type.IsSubclassOf(typeof(ZDataModel))
                                && !type.IsAbstract
                                && !type.FullName.StartsWith("System.Data.Entity.DynamicProxies"))
                            {
                                entities.Add(type.FullName, type.FullName);
                            }
                        }
                    }

                    // C# Sort Dictionary: Keys and Values
                    // https://www.dotnetperls.com/sort-dictionary
                    viewModel.Entities.Add("...", "...");
                    foreach (KeyValuePair<string, string> kv in entities.OrderBy(x => x.Value))
                    {
                        viewModel.Entities.Add(kv.Key, kv.Value);
                    }

                    return ZView(viewModel);
                }
            }
            catch (Exception exception)
            {
                operationResult.ParseException(exception);
            }

            return ZViewOperationResult(operationResult);
        }

        // POST: Tasks/ProfileViewer
        [HttpPost]
        public ActionResult ProfileViewer(ProfileViewerViewModel viewModel)
        {
            viewModel.OperationResult.Clear();

            try
            {
                if (IsTask("ProfileViewer", viewModel.OperationResult))
                {
                    if (IsValid(viewModel.OperationResult, viewModel))
                    {
                    }
                }
            }
            catch (Exception exception)
            {
                viewModel.OperationResult.ParseException(exception);
            }

            return ZView(viewModel);
        }

        [HttpPost]
        public ActionResult AjaxProfile(string entity) // Task<JsonResult>
        {
            ZOperationResult operationResult = new ZOperationResult();
            IZProfile profile = null;

            Type type = LibraryHelper.GetType(entity);
            if (type != null)
            {
                profile = DataHelper.GetProfile(type);
            }

            return JsonResultOperationResult(operationResult, profile);
        }
    }
}