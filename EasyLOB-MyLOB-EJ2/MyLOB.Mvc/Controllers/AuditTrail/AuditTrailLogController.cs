using EasyLOB.AuditTrail;
using EasyLOB.AuditTrail.Data;
using EasyLOB.AuditTrail.Data.Resources;
using EasyLOB;
using EasyLOB.Data;
using EasyLOB.Mvc;
using Newtonsoft.Json;
using Syncfusion.EJ2.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Mvc;

namespace EasyLOB.AuditTrail.Mvc
{
    public partial class AuditTrailLogController : BaseMvcControllerSCRUDApplication<AuditTrailLog>
    {
        #region Methods

        public AuditTrailLogController(IAuditTrailGenericApplication<AuditTrailLog> application)
            : base(application.AuthorizationManager)
        {
            Application = application;            
        }

        #endregion Methods

        #region Methods SCRUD

        // GET: AuditTrailLog
        // GET: AuditTrailLog/Index
        [HttpGet]
        public ActionResult Index(string operation = null)
        {
            AuditTrailLogCollectionModel auditTrailLogCollectionModel = new AuditTrailLogCollectionModel(ActivityOperations, "Index", null, null, null, operation);

            try
            {
                if (IsIndex(auditTrailLogCollectionModel.OperationResult))
                {
                    return ZView(auditTrailLogCollectionModel);
                }
            }
            catch (Exception exception)
            {
                auditTrailLogCollectionModel.OperationResult.ParseException(exception);
            }

            return ZViewOperationResult(auditTrailLogCollectionModel.OperationResult);
        }        

        // GET & POST: AuditTrailLog/Search
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Search(string masterControllerAction = null, string masterEntity = null, string masterKey = null)
        {
            AuditTrailLogCollectionModel auditTrailLogCollectionModel = new AuditTrailLogCollectionModel(ActivityOperations, "Search", masterControllerAction, masterEntity, masterKey);

            try
            {
                if (IsOperation(auditTrailLogCollectionModel.OperationResult))
                {
                    return ZPartialView(auditTrailLogCollectionModel);
                }
            }
            catch (Exception exception)
            {
                auditTrailLogCollectionModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(auditTrailLogCollectionModel.OperationResult);
        }

        // GET & POST: AuditTrailLog/Lookup
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Lookup(string text, string valueId, bool? required = false, List<LookupModelElement> elements = null, string query = null)
        {
            LookupModel lookupModel = new LookupModel(ActivityOperations, text, valueId, required, elements, query);

            try
            {
                if (IsSearch(lookupModel.OperationResult))
                {
                    return ZPartialView("_AuditTrailLogLookup", lookupModel);
                }
            }
            catch (Exception exception)
            {
                lookupModel.OperationResult.ParseException(exception);
            }

            return null;
        }

        // GET: AuditTrailLog/Create
        [HttpGet]
        public ActionResult Create(string masterEntity = null, string masterKey = null)
        {
            AuditTrailLogItemModel auditTrailLogItemModel = new AuditTrailLogItemModel(ActivityOperations, "Create", masterEntity, masterKey);

            try
            {
                if (IsCreate(auditTrailLogItemModel.OperationResult))
                {
                    return ZPartialView("CRUD", auditTrailLogItemModel);
                }            
            }
            catch (Exception exception)
            {
                auditTrailLogItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(auditTrailLogItemModel.OperationResult);
        }

        // POST: AuditTrailLog/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AuditTrailLogItemModel auditTrailLogItemModel)
        {
            try
            {
                if (IsCreate(auditTrailLogItemModel.OperationResult))
                {
                    if (IsValid(auditTrailLogItemModel.OperationResult, auditTrailLogItemModel.AuditTrailLog))
                    {
                        AuditTrailLog auditTrailLog = (AuditTrailLog)auditTrailLogItemModel.AuditTrailLog.ToData();
                        if (Application.Create(auditTrailLogItemModel.OperationResult, auditTrailLog))
                        {
                            if (auditTrailLogItemModel.IsSave)
                            {
                                Create2Update(auditTrailLogItemModel.OperationResult);
                                return JsonResultSuccess(auditTrailLogItemModel.OperationResult,
                                    Url.Action("Update", "AuditTrailLog", new { Id = auditTrailLog.Id }, Request.Url.Scheme));
                            }
                            else
                            {
                                return JsonResultSuccess(auditTrailLogItemModel.OperationResult);
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                auditTrailLogItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(auditTrailLogItemModel.OperationResult);
        }

        // GET: AuditTrailLog/Read/1
        [HttpGet]
        public ActionResult Read(int id)
        {
            AuditTrailLogItemModel auditTrailLogItemModel = new AuditTrailLogItemModel(ActivityOperations, "Read");
            
            try
            {
                if (IsRead(auditTrailLogItemModel.OperationResult))
                {
                    AuditTrailLog auditTrailLog = Application.GetById(auditTrailLogItemModel.OperationResult, new object[] { id }, true);
                    if (auditTrailLog != null)
                    {
                        auditTrailLogItemModel.AuditTrailLog = new AuditTrailLogViewModel(auditTrailLog);                    

                        return ZPartialView("CRUD", auditTrailLogItemModel);
                    }
                }
            }
            catch (Exception exception)
            {
                auditTrailLogItemModel.OperationResult.ParseException(exception);
            }            

            return JsonResultOperationResult(auditTrailLogItemModel.OperationResult);
        }

        // GET: AuditTrailLog/Update/1
        [HttpGet]
        public ActionResult Update(int id, string masterEntity = null, string masterKey = null)
        {
            AuditTrailLogItemModel auditTrailLogItemModel = new AuditTrailLogItemModel(ActivityOperations, "Update", masterEntity, masterKey);
            
            try
            {
                if (IsUpdate(auditTrailLogItemModel.OperationResult))
                {            
                    AuditTrailLog auditTrailLog = Application.GetById(auditTrailLogItemModel.OperationResult, new object[] { id }, true);
                    if (auditTrailLog != null)
                    {
                        auditTrailLogItemModel.AuditTrailLog = new AuditTrailLogViewModel(auditTrailLog);

                        return ZPartialView("CRUD", auditTrailLogItemModel);
                    }
                }
            }
            catch (Exception exception)
            {
                auditTrailLogItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(auditTrailLogItemModel.OperationResult);
        }

        // POST: AuditTrailLog/Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(AuditTrailLogItemModel auditTrailLogItemModel)
        {
            try
            {
                if (IsUpdate(auditTrailLogItemModel.OperationResult))
                {
                    if (IsValid(auditTrailLogItemModel.OperationResult, auditTrailLogItemModel.AuditTrailLog))
                    {
                        AuditTrailLog auditTrailLog = (AuditTrailLog)auditTrailLogItemModel.AuditTrailLog.ToData();
                        if (Application.Update(auditTrailLogItemModel.OperationResult, auditTrailLog))
                        {
                            if (auditTrailLogItemModel.IsSave)
                            {
                                return JsonResultSuccess(auditTrailLogItemModel.OperationResult,
                                    Url.Action("Update", "AuditTrailLog", new { Id = auditTrailLog.Id }, Request.Url.Scheme));
                            }
                            else
                            {
                                return JsonResultSuccess(auditTrailLogItemModel.OperationResult);
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                auditTrailLogItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(auditTrailLogItemModel.OperationResult);
        }

        // GET: AuditTrailLog/Delete/1
        [HttpGet]
        public ActionResult Delete(int id, string masterEntity = null, string masterKey = null)
        {
            AuditTrailLogItemModel auditTrailLogItemModel = new AuditTrailLogItemModel(ActivityOperations, "Delete", masterEntity, masterKey);
            
            try
            {
                if (IsDelete(auditTrailLogItemModel.OperationResult))
                {            
                    AuditTrailLog auditTrailLog = Application.GetById(auditTrailLogItemModel.OperationResult, new object[] { id }, true);
                    if (auditTrailLog != null)
                    {
                        auditTrailLogItemModel.AuditTrailLog = new AuditTrailLogViewModel(auditTrailLog);

                        return ZPartialView("CRUD", auditTrailLogItemModel);
                    }
                }
            }
            catch (Exception exception)
            {
                auditTrailLogItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(auditTrailLogItemModel.OperationResult);
        }

        // POST: AuditTrailLog/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(AuditTrailLogItemModel auditTrailLogItemModel)
        {
            try
            {
                if (IsDelete(auditTrailLogItemModel.OperationResult))
                {
                    if (Application.Delete(auditTrailLogItemModel.OperationResult, (AuditTrailLog)auditTrailLogItemModel.AuditTrailLog.ToData()))
                    {
                        return JsonResultSuccess(auditTrailLogItemModel.OperationResult);
                    }
                }
            }
            catch (Exception exception)
            {
                auditTrailLogItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(auditTrailLogItemModel.OperationResult);
        }
        
        #endregion Methods SCRUD
        
        #region Methods Syncfusion

        // POST: AuditTrailLog/DataSource
        [HttpPost]
        public ActionResult DataSource(DataManagerRequest dataManager)
        {
            SyncfusionDataResult dataResult = new SyncfusionDataResult
            {
                result = new List<AuditTrailLogViewModel>()
            };

            ZOperationResult operationResult = new ZOperationResult();

            if (IsSearch(operationResult))
            {
                try
                {
                    SyncfusionGrid syncfusionGrid = new SyncfusionGrid(typeof(AuditTrailLog), Application.UnitOfWork.DBMS);
                    ArrayList args = new ArrayList();
                    string where = syncfusionGrid.ToLinqWhere(dataManager.Search, dataManager.Where, args);
                    string orderBy = syncfusionGrid.ToLinqOrderBy(dataManager.Sorted);        
                    int take = (dataManager.Skip == 0 && dataManager.Take == 0) ? AppDefaults.SyncfusionRecordsBySearch : dataManager.Take; // Excel Filtering
                    dataResult.result = ZViewModelHelper<AuditTrailLogViewModel, AuditTrailLog>.ToViewList(Application.Search(operationResult, where, args.ToArray(), orderBy, dataManager.Skip, take));
        
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
        
        #endregion Methods Syncfusion
    }
}