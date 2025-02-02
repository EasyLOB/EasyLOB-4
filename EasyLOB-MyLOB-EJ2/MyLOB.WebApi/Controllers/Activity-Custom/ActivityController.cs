using EasyLOB.Activity;
using EasyLOB.Activity.Data;
using EasyLOB.Activity.Data.Resources;
using EasyLOB;
using EasyLOB.Data;
using EasyLOB.Mvc;
using Newtonsoft.Json;
using Syncfusion.EJ2.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Mvc;

namespace EasyLOB.Activity.Mvc
{
    public partial class ActivityController : BaseMvcControllerSCRUDApplication<EasyLOB.Activity.Data.Activity>
    {
        #region Methods

        public ActivityController(IActivityGenericApplication<EasyLOB.Activity.Data.Activity> application) // !?!
            : base(application.AuthorizationManager)
        {
            Application = application;            
        }

        #endregion Methods

        #region Methods SCRUD

        // GET: Activity
        // GET: Activity/Index
        [HttpGet]
        public ActionResult Index(string operation = null)
        {
            ActivityCollectionModel activityCollectionModel = new ActivityCollectionModel(ActivityOperations, "Index", null, null, null, operation);

            try
            {
                if (IsIndex(activityCollectionModel.OperationResult))
                {
                    return ZView(activityCollectionModel);
                }
            }
            catch (Exception exception)
            {
                activityCollectionModel.OperationResult.ParseException(exception);
            }

            return ZViewOperationResult(activityCollectionModel.OperationResult);
        }        

        // GET & POST: Activity/Search
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Search(string masterControllerAction = null, string masterEntity = null, string masterKey = null)
        {
            ActivityCollectionModel activityCollectionModel = new ActivityCollectionModel(ActivityOperations, "Search", masterControllerAction, masterEntity, masterKey);

            try
            {
                if (IsOperation(activityCollectionModel.OperationResult))
                {
                    return ZPartialView(activityCollectionModel);
                }
            }
            catch (Exception exception)
            {
                activityCollectionModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(activityCollectionModel.OperationResult);
        }

        // GET & POST: Activity/Lookup
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Lookup(string text, string valueId, bool? required = false, List<LookupModelElement> elements = null, string query = null)
        {
            LookupModel lookupModel = new LookupModel(ActivityOperations, text, valueId, required, elements, query);

            try
            {
                if (IsSearch(lookupModel.OperationResult))
                {
                    return ZPartialView("_ActivityLookup", lookupModel);
                }
            }
            catch (Exception exception)
            {
                lookupModel.OperationResult.ParseException(exception);
            }

            return null;
        }

        // GET: Activity/Create
        [HttpGet]
        public ActionResult Create(string masterEntity = null, string masterKey = null)
        {
            ActivityItemModel activityItemModel = new ActivityItemModel(ActivityOperations, "Create", masterEntity, masterKey);

            try
            {
                if (IsCreate(activityItemModel.OperationResult))
                {
                    return ZPartialView("CRUD", activityItemModel);
                }            
            }
            catch (Exception exception)
            {
                activityItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(activityItemModel.OperationResult);
        }

        // POST: Activity/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ActivityItemModel activityItemModel)
        {
            try
            {
                if (IsCreate(activityItemModel.OperationResult))
                {
                    if (IsValid(activityItemModel.OperationResult, activityItemModel.Activity))
                    {
                        EasyLOB.Activity.Data.Activity activity = (EasyLOB.Activity.Data.Activity)activityItemModel.Activity.ToData(); // !?!
                        if (Application.Create(activityItemModel.OperationResult, activity))
                        {
                            if (activityItemModel.IsSave)
                            {
                                Create2Update(activityItemModel.OperationResult);
                                return JsonResultSuccess(activityItemModel.OperationResult,
                                    Url.Action("Update", "Activity", new { Id = activity.Id }, Request.Url.Scheme));
                            }
                            else
                            {
                                return JsonResultSuccess(activityItemModel.OperationResult);
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                activityItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(activityItemModel.OperationResult);
        }

        // GET: Activity/Read/1
        [HttpGet]
        public ActionResult Read(string id)
        {
            ActivityItemModel activityItemModel = new ActivityItemModel(ActivityOperations, "Read");
            
            try
            {
                if (IsRead(activityItemModel.OperationResult))
                {
                    EasyLOB.Activity.Data.Activity activity = Application.GetById(activityItemModel.OperationResult, new object[] { id }, true); // !?!
                    if (activity != null)
                    {
                        activityItemModel.Activity = new ActivityViewModel(activity);                    

                        return ZPartialView("CRUD", activityItemModel);
                    }
                }
            }
            catch (Exception exception)
            {
                activityItemModel.OperationResult.ParseException(exception);
            }            

            return JsonResultOperationResult(activityItemModel.OperationResult);
        }

        // GET: Activity/Update/1
        [HttpGet]
        public ActionResult Update(string id, string masterEntity = null, string masterKey = null)
        {
            ActivityItemModel activityItemModel = new ActivityItemModel(ActivityOperations, "Update", masterEntity, masterKey);
            
            try
            {
                if (IsUpdate(activityItemModel.OperationResult))
                {
                    EasyLOB.Activity.Data.Activity activity = Application.GetById(activityItemModel.OperationResult, new object[] { id }, true); // !?!
                    if (activity != null)
                    {
                        activityItemModel.Activity = new ActivityViewModel(activity);

                        return ZPartialView("CRUD", activityItemModel);
                    }
                }
            }
            catch (Exception exception)
            {
                activityItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(activityItemModel.OperationResult);
        }

        // POST: Activity/Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(ActivityItemModel activityItemModel)
        {
            try
            {
                if (IsUpdate(activityItemModel.OperationResult))
                {
                    if (IsValid(activityItemModel.OperationResult, activityItemModel.Activity))
                    {
                        EasyLOB.Activity.Data.Activity activity = (EasyLOB.Activity.Data.Activity)activityItemModel.Activity.ToData(); // !?!
                        if (Application.Update(activityItemModel.OperationResult, activity))
                        {
                            if (activityItemModel.IsSave)
                            {
                                return JsonResultSuccess(activityItemModel.OperationResult,
                                    Url.Action("Update", "Activity", new { Id = activity.Id }, Request.Url.Scheme));
                            }
                            else
                            {
                                return JsonResultSuccess(activityItemModel.OperationResult);
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                activityItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(activityItemModel.OperationResult);
        }

        // GET: Activity/Delete/1
        [HttpGet]
        public ActionResult Delete(string id, string masterEntity = null, string masterKey = null)
        {
            ActivityItemModel activityItemModel = new ActivityItemModel(ActivityOperations, "Delete", masterEntity, masterKey);
            
            try
            {
                if (IsDelete(activityItemModel.OperationResult))
                {
                    EasyLOB.Activity.Data.Activity activity = Application.GetById(activityItemModel.OperationResult, new object[] { id }, true); // !?!
                    if (activity != null)
                    {
                        activityItemModel.Activity = new ActivityViewModel(activity);

                        return ZPartialView("CRUD", activityItemModel);
                    }
                }
            }
            catch (Exception exception)
            {
                activityItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(activityItemModel.OperationResult);
        }

        // POST: Activity/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ActivityItemModel activityItemModel)
        {
            try
            {
                if (IsDelete(activityItemModel.OperationResult))
                {
                    if (Application.Delete(activityItemModel.OperationResult, (EasyLOB.Activity.Data.Activity)activityItemModel.Activity.ToData())) // !?!
                    {
                        return JsonResultSuccess(activityItemModel.OperationResult);
                    }
                }
            }
            catch (Exception exception)
            {
                activityItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(activityItemModel.OperationResult);
        }

        #endregion Methods SCRUD

        #region Methods Syncfusion

        // POST: Activity/DataSource
        [HttpPost]
        public ActionResult DataSource(DataManagerRequest dataManager)
        {
            SyncfusionDataResult dataResult = new SyncfusionDataResult
            {
                result = new List<EasyLOB.Activity.Data.ActivityViewModel>()
            };

            ZOperationResult operationResult = new ZOperationResult();

            if (IsSearch(operationResult))
            {
                try
                {
                    SyncfusionGrid syncfusionGrid = new SyncfusionGrid(typeof(EasyLOB.Activity.Data.Activity), Application.UnitOfWork.DBMS);
                    ArrayList args = new ArrayList();
                    string where = syncfusionGrid.ToLinqWhere(dataManager.Search, dataManager.Where, args);
                    string orderBy = syncfusionGrid.ToLinqOrderBy(dataManager.Sorted);
                    int take = (dataManager.Skip == 0 && dataManager.Take == 0) ? AppDefaults.SyncfusionRecordsBySearch : dataManager.Take; // Excel Filtering
                    dataResult.result = ZViewModelHelper<EasyLOB.Activity.Data.ActivityViewModel, EasyLOB.Activity.Data.Activity>.ToViewList(Application.Search(operationResult, where, args.ToArray(), orderBy, dataManager.Skip, take));

                    if (dataManager.RequiresCounts)
                    {
                        dataResult.count = Application.Count(operationResult, where, args.ToArray());
                    }
                }
                catch (Exception exception)
                {
                    operationResult.ParseException(exception);
                }

                if (!operationResult.Ok)
                {
                    operationResult.ThrowException();
                }
            }

            return Json(JsonConvert.SerializeObject(dataResult), JsonRequestBehavior.AllowGet);
        }

        // POST: Activity/ExportToExcel
        [HttpPost]
        public void ExportToExcel(string gridModel)
        {
            if (IsExport())
            {
                ExportToExcel(gridModel, ActivityResources.EntitySingular + ".xlsx");
            }
        }

        // POST: Activity/ExportToPdf
        [HttpPost]
        public void ExportToPdf(string gridModel)
        {
            if (IsExport())
            {
                ExportToPdf(gridModel, ActivityResources.EntitySingular + ".pdf");
            }
        }

        // POST: Activity/ExportToWord
        [HttpPost]
        public void ExportToWord(string gridModel)
        {
            if (IsExport())
            {
                ExportToWord(gridModel, ActivityResources.EntitySingular + ".docx");
            }
        }
        
        #endregion Methods Syncfusion
    }
}