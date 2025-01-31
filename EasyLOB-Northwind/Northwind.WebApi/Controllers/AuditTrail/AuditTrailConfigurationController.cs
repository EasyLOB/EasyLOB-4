using EasyLOB.AuditTrail;
using EasyLOB.AuditTrail.Data;
using EasyLOB.AuditTrail.Data.Resources;
using EasyLOB;
using EasyLOB.Data;
using EasyLOB.Mvc;
using Newtonsoft.Json;
using Syncfusion.JavaScript;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Mvc;

namespace EasyLOB.AuditTrail.Mvc
{
    public partial class AuditTrailConfigurationController : BaseMvcControllerSCRUDApplication<AuditTrailConfiguration>
    {
        #region Methods

        public AuditTrailConfigurationController(IAuditTrailGenericApplication<AuditTrailConfiguration> application)
            : base(application.AuthorizationManager)
        {
            Application = application;            
        }

        #endregion Methods

        #region Methods SCRUD

        // GET: AuditTrailConfiguration
        // GET: AuditTrailConfiguration/Index
        [HttpGet]
        public ActionResult Index(string operation = null)
        {
            AuditTrailConfigurationCollectionModel auditTrailConfigurationCollectionModel = new AuditTrailConfigurationCollectionModel(ActivityOperations, "Index", null, null, null, operation);

            try
            {
                if (IsIndex(auditTrailConfigurationCollectionModel.OperationResult))
                {
                    return ZView(auditTrailConfigurationCollectionModel);
                }
            }
            catch (Exception exception)
            {
                auditTrailConfigurationCollectionModel.OperationResult.ParseException(exception);
            }

            return ZViewOperationResult(auditTrailConfigurationCollectionModel.OperationResult);
        }        

        // GET & POST: AuditTrailConfiguration/Search
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Search(string masterControllerAction = null, string masterEntity = null, string masterKey = null)
        {
            AuditTrailConfigurationCollectionModel auditTrailConfigurationCollectionModel = new AuditTrailConfigurationCollectionModel(ActivityOperations, "Search", masterControllerAction, masterEntity, masterKey);

            try
            {
                if (IsOperation(auditTrailConfigurationCollectionModel.OperationResult))
                {
                    return ZPartialView(auditTrailConfigurationCollectionModel);
                }
            }
            catch (Exception exception)
            {
                auditTrailConfigurationCollectionModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(auditTrailConfigurationCollectionModel.OperationResult);
        }

        // GET & POST: AuditTrailConfiguration/Lookup
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Lookup(string text, string valueId, bool? required = false, List<LookupModelElement> elements = null, string query = null)
        {
            LookupModel lookupModel = new LookupModel(ActivityOperations, text, valueId, required, elements, query);

            try
            {
                if (IsSearch(lookupModel.OperationResult))
                {
                    return ZPartialView("_AuditTrailConfigurationLookup", lookupModel);
                }
            }
            catch (Exception exception)
            {
                lookupModel.OperationResult.ParseException(exception);
            }

            return null;
        }

        // GET: AuditTrailConfiguration/Create
        [HttpGet]
        public ActionResult Create(string masterEntity = null, string masterKey = null)
        {
            AuditTrailConfigurationItemModel auditTrailConfigurationItemModel = new AuditTrailConfigurationItemModel(ActivityOperations, "Create", masterEntity, masterKey);

            try
            {
                if (IsCreate(auditTrailConfigurationItemModel.OperationResult))
                {
                    return ZPartialView("CRUD", auditTrailConfigurationItemModel);
                }            
            }
            catch (Exception exception)
            {
                auditTrailConfigurationItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(auditTrailConfigurationItemModel.OperationResult);
        }

        // POST: AuditTrailConfiguration/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AuditTrailConfigurationItemModel auditTrailConfigurationItemModel)
        {
            try
            {
                if (IsCreate(auditTrailConfigurationItemModel.OperationResult))
                {
                    if (IsValid(auditTrailConfigurationItemModel.OperationResult, auditTrailConfigurationItemModel.AuditTrailConfiguration))
                    {
                        AuditTrailConfiguration auditTrailConfiguration = (AuditTrailConfiguration)auditTrailConfigurationItemModel.AuditTrailConfiguration.ToData();
                        if (Application.Create(auditTrailConfigurationItemModel.OperationResult, auditTrailConfiguration))
                        {
                            if (auditTrailConfigurationItemModel.IsSave)
                            {
                                Create2Update(auditTrailConfigurationItemModel.OperationResult);
                                return JsonResultSuccess(auditTrailConfigurationItemModel.OperationResult,
                                    Url.Action("Update", "AuditTrailConfiguration", new { Id = auditTrailConfiguration.Id }, Request.Url.Scheme));
                            }
                            else
                            {
                                return JsonResultSuccess(auditTrailConfigurationItemModel.OperationResult);
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                auditTrailConfigurationItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(auditTrailConfigurationItemModel.OperationResult);
        }

        // GET: AuditTrailConfiguration/Read/1
        [HttpGet]
        public ActionResult Read(int id)
        {
            AuditTrailConfigurationItemModel auditTrailConfigurationItemModel = new AuditTrailConfigurationItemModel(ActivityOperations, "Read");
            
            try
            {
                if (IsRead(auditTrailConfigurationItemModel.OperationResult))
                {
                    AuditTrailConfiguration auditTrailConfiguration = Application.GetById(auditTrailConfigurationItemModel.OperationResult, new object[] { id }, true);
                    if (auditTrailConfiguration != null)
                    {
                        auditTrailConfigurationItemModel.AuditTrailConfiguration = new AuditTrailConfigurationViewModel(auditTrailConfiguration);                    

                        return ZPartialView("CRUD", auditTrailConfigurationItemModel);
                    }
                }
            }
            catch (Exception exception)
            {
                auditTrailConfigurationItemModel.OperationResult.ParseException(exception);
            }            

            return JsonResultOperationResult(auditTrailConfigurationItemModel.OperationResult);
        }

        // GET: AuditTrailConfiguration/Update/1
        [HttpGet]
        public ActionResult Update(int id, string masterEntity = null, string masterKey = null)
        {
            AuditTrailConfigurationItemModel auditTrailConfigurationItemModel = new AuditTrailConfigurationItemModel(ActivityOperations, "Update", masterEntity, masterKey);
            
            try
            {
                if (IsUpdate(auditTrailConfigurationItemModel.OperationResult))
                {            
                    AuditTrailConfiguration auditTrailConfiguration = Application.GetById(auditTrailConfigurationItemModel.OperationResult, new object[] { id }, true);
                    if (auditTrailConfiguration != null)
                    {
                        auditTrailConfigurationItemModel.AuditTrailConfiguration = new AuditTrailConfigurationViewModel(auditTrailConfiguration);

                        return ZPartialView("CRUD", auditTrailConfigurationItemModel);
                    }
                }
            }
            catch (Exception exception)
            {
                auditTrailConfigurationItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(auditTrailConfigurationItemModel.OperationResult);
        }

        // POST: AuditTrailConfiguration/Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(AuditTrailConfigurationItemModel auditTrailConfigurationItemModel)
        {
            try
            {
                if (IsUpdate(auditTrailConfigurationItemModel.OperationResult))
                {
                    if (IsValid(auditTrailConfigurationItemModel.OperationResult, auditTrailConfigurationItemModel.AuditTrailConfiguration))
                    {
                        AuditTrailConfiguration auditTrailConfiguration = (AuditTrailConfiguration)auditTrailConfigurationItemModel.AuditTrailConfiguration.ToData();
                        if (Application.Update(auditTrailConfigurationItemModel.OperationResult, auditTrailConfiguration))
                        {
                            if (auditTrailConfigurationItemModel.IsSave)
                            {
                                return JsonResultSuccess(auditTrailConfigurationItemModel.OperationResult,
                                    Url.Action("Update", "AuditTrailConfiguration", new { Id = auditTrailConfiguration.Id }, Request.Url.Scheme));
                            }
                            else
                            {
                                return JsonResultSuccess(auditTrailConfigurationItemModel.OperationResult);
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                auditTrailConfigurationItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(auditTrailConfigurationItemModel.OperationResult);
        }

        // GET: AuditTrailConfiguration/Delete/1
        [HttpGet]
        public ActionResult Delete(int id, string masterEntity = null, string masterKey = null)
        {
            AuditTrailConfigurationItemModel auditTrailConfigurationItemModel = new AuditTrailConfigurationItemModel(ActivityOperations, "Delete", masterEntity, masterKey);
            
            try
            {
                if (IsDelete(auditTrailConfigurationItemModel.OperationResult))
                {            
                    AuditTrailConfiguration auditTrailConfiguration = Application.GetById(auditTrailConfigurationItemModel.OperationResult, new object[] { id }, true);
                    if (auditTrailConfiguration != null)
                    {
                        auditTrailConfigurationItemModel.AuditTrailConfiguration = new AuditTrailConfigurationViewModel(auditTrailConfiguration);

                        return ZPartialView("CRUD", auditTrailConfigurationItemModel);
                    }
                }
            }
            catch (Exception exception)
            {
                auditTrailConfigurationItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(auditTrailConfigurationItemModel.OperationResult);
        }

        // POST: AuditTrailConfiguration/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(AuditTrailConfigurationItemModel auditTrailConfigurationItemModel)
        {
            try
            {
                if (IsDelete(auditTrailConfigurationItemModel.OperationResult))
                {
                    if (Application.Delete(auditTrailConfigurationItemModel.OperationResult, (AuditTrailConfiguration)auditTrailConfigurationItemModel.AuditTrailConfiguration.ToData()))
                    {
                        return JsonResultSuccess(auditTrailConfigurationItemModel.OperationResult);
                    }
                }
            }
            catch (Exception exception)
            {
                auditTrailConfigurationItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(auditTrailConfigurationItemModel.OperationResult);
        }
        
        #endregion Methods SCRUD
        
        #region Methods Syncfusion

        // POST: AuditTrailConfiguration/DataSource
        [HttpPost]
        public ActionResult DataSource(DataManager dataManager)
        {
            SyncfusionDataResult dataResult = new SyncfusionDataResult
            {
                result = new List<AuditTrailConfigurationViewModel>()
            };

            ZOperationResult operationResult = new ZOperationResult();

            if (IsSearch(operationResult))
            {
                try
                {
                    SyncfusionGrid syncfusionGrid = new SyncfusionGrid(typeof(AuditTrailConfiguration), Application.UnitOfWork.DBMS);
                    ArrayList args = new ArrayList();
                    string where = syncfusionGrid.ToLinqWhere(dataManager.Search, dataManager.Where, args);
                    string orderBy = syncfusionGrid.ToLinqOrderBy(dataManager.Sorted);        
                    int take = (dataManager.Skip == 0 && dataManager.Take == 0) ? AppDefaults.SyncfusionRecordsBySearch : dataManager.Take; // Excel Filtering
                    dataResult.result = ZViewModelHelper<AuditTrailConfigurationViewModel, AuditTrailConfiguration>.ToViewList(Application.Search(operationResult, where, args.ToArray(), orderBy, dataManager.Skip, take));
        
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

        // POST: AuditTrailConfiguration/ExportToExcel
        [HttpPost]
        public void ExportToExcel(string gridModel)
        {
            if (IsExport())
            {
                ExportToExcel(gridModel, AuditTrailConfigurationResources.EntitySingular + ".xlsx");
            }
        }

        // POST: AuditTrailConfiguration/ExportToPdf
        [HttpPost]
        public void ExportToPdf(string gridModel)
        {
            if (IsExport())
            {
                ExportToPdf(gridModel, AuditTrailConfigurationResources.EntitySingular + ".pdf");
            }
        }

        // POST: AuditTrailConfiguration/ExportToWord
        [HttpPost]
        public void ExportToWord(string gridModel)
        {
            if (IsExport())
            {
                ExportToWord(gridModel, AuditTrailConfigurationResources.EntitySingular + ".docx");
            }
        }
        
        #endregion Methods Syncfusion
    }
}