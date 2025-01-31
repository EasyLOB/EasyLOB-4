using Northwind.Application;
using Northwind.Data;
using Northwind.Data.Resources;
using EasyLOB;
using EasyLOB.Data;
using EasyLOB.Mvc;
using Newtonsoft.Json;
using Syncfusion.JavaScript;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Northwind.Mvc
{
    public partial class TerritoryController : BaseMvcControllerSCRUDApplication<Territory>
    {
        #region Methods

        public TerritoryController(INorthwindGenericApplication<Territory> application)
    : base(application.AuthorizationManager)
        {
            Application = application;            
        }

        #endregion Methods

        #region Methods SCRUD

        // GET: Territory
        // GET: Territory/Index
        [HttpGet]
        public ActionResult Index(string operation = null)
        {
            TerritoryCollectionModel territoryCollectionModel = new TerritoryCollectionModel(ActivityOperations, "Index", null, null, null, operation);

            try
            {
                if (IsIndex(territoryCollectionModel.OperationResult))
                {
                    return ZView(territoryCollectionModel);
                }
            }
            catch (Exception exception)
            {
                territoryCollectionModel.OperationResult.ParseException(exception);
            }

            return ZViewOperationResult(territoryCollectionModel.OperationResult);
        }        

        // GET & POST: Territory/Search
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Search(string masterControllerAction = null, string masterEntity = null, string masterKey = null)
        {
            TerritoryCollectionModel territoryCollectionModel = new TerritoryCollectionModel(ActivityOperations, "Search", masterControllerAction, masterEntity, masterKey);

            try
            {
                if (IsOperation(territoryCollectionModel.OperationResult))
                {
                    return ZPartialView(territoryCollectionModel);
                }
            }
            catch (Exception exception)
            {
                territoryCollectionModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(territoryCollectionModel.OperationResult);
        }

        // GET & POST: Territory/Lookup
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Lookup(string text, string valueId, bool? required = false, List<LookupModelElement> elements = null, string query = null)
        {
            LookupModel lookupModel = new LookupModel(ActivityOperations, text, valueId, required, elements, query);

            try
            {
                if (IsSearch(lookupModel.OperationResult))
                {
                    return ZPartialView("_TerritoryLookup", lookupModel);
                }
            }
            catch (Exception exception)
            {
                lookupModel.OperationResult.ParseException(exception);
            }

            return null;
        }

        // GET: Territory/Create
        [HttpGet]
        public ActionResult Create(string masterEntity = null, string masterKey = null)
        {
            TerritoryItemModel territoryItemModel = new TerritoryItemModel(ActivityOperations, "Create", masterEntity, masterKey);

            try
            {
                if (IsCreate(territoryItemModel.OperationResult))
                {
                    return ZPartialView("CRUD", territoryItemModel);
                }            
            }
            catch (Exception exception)
            {
                territoryItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(territoryItemModel.OperationResult);
        }

        // POST: Territory/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TerritoryItemModel territoryItemModel)
        {
            try
            {
                if (IsCreate(territoryItemModel.OperationResult))
                {
                    if (IsValid(territoryItemModel.OperationResult, territoryItemModel.Territory))
                    {
                        Territory territory = (Territory)territoryItemModel.Territory.ToData();
                        if (Application.Create(territoryItemModel.OperationResult, territory))
                        {
                            if (territoryItemModel.IsSave)
                            {
                                Create2Update(territoryItemModel.OperationResult);
                                return JsonResultSuccess(territoryItemModel.OperationResult,
                                    Url.Action("Update", "Territory", new { TerritoryId = territory.TerritoryId }, Request.Url.Scheme));
                            }
                            else
                            {
                                return JsonResultSuccess(territoryItemModel.OperationResult);
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                territoryItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(territoryItemModel.OperationResult);
        }

        // GET: Territory/Read/1
        [HttpGet]
        public ActionResult Read(string territoryId, string masterEntity = null, string masterKey = null)
        {
            TerritoryItemModel territoryItemModel = new TerritoryItemModel(ActivityOperations, "Read", masterEntity, masterKey);
            
            try
            {
                if (IsRead(territoryItemModel.OperationResult))
                {
                    Territory territory = Application.GetById(territoryItemModel.OperationResult, new object[] { territoryId }, true);
                    if (territory != null)
                    {
                        territoryItemModel.Territory = new TerritoryViewModel(territory);                    

                        return ZPartialView("CRUD", territoryItemModel);
                    }
                }
            }
            catch (Exception exception)
            {
                territoryItemModel.OperationResult.ParseException(exception);
            }            

            return JsonResultOperationResult(territoryItemModel.OperationResult);
        }

        // GET: Territory/Update/1
        [HttpGet]
        public ActionResult Update(string territoryId, string masterEntity = null, string masterKey = null)
        {
            TerritoryItemModel territoryItemModel = new TerritoryItemModel(ActivityOperations, "Update", masterEntity, masterKey);
            
            try
            {
                if (IsUpdate(territoryItemModel.OperationResult))
                {            
                    Territory territory = Application.GetById(territoryItemModel.OperationResult, new object[] { territoryId }, true);
                    if (territory != null)
                    {
                        territoryItemModel.Territory = new TerritoryViewModel(territory);

                        return ZPartialView("CRUD", territoryItemModel);
                    }
                }
            }
            catch (Exception exception)
            {
                territoryItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(territoryItemModel.OperationResult);
        }

        // POST: Territory/Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(TerritoryItemModel territoryItemModel)
        {
            try
            {
                if (IsUpdate(territoryItemModel.OperationResult))
                {
                    if (IsValid(territoryItemModel.OperationResult, territoryItemModel.Territory))
                    {
                        Territory territory = (Territory)territoryItemModel.Territory.ToData();
                        if (Application.Update(territoryItemModel.OperationResult, territory))
                        {
                            if (territoryItemModel.IsSave)
                            {
                                return JsonResultSuccess(territoryItemModel.OperationResult,
                                    Url.Action("Update", "Territory", new { TerritoryId = territory.TerritoryId }, Request.Url.Scheme));
                            }
                            else
                            {
                                return JsonResultSuccess(territoryItemModel.OperationResult);
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                territoryItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(territoryItemModel.OperationResult);
        }

        // GET: Territory/Delete/1
        [HttpGet]
        public ActionResult Delete(string territoryId, string masterEntity = null, string masterKey = null)
        {
            TerritoryItemModel territoryItemModel = new TerritoryItemModel(ActivityOperations, "Delete", masterEntity, masterKey);
            
            try
            {
                if (IsDelete(territoryItemModel.OperationResult))
                {            
                    Territory territory = Application.GetById(territoryItemModel.OperationResult, new object[] { territoryId }, true);
                    if (territory != null)
                    {
                        territoryItemModel.Territory = new TerritoryViewModel(territory);

                        return ZPartialView("CRUD", territoryItemModel);
                    }
                }
            }
            catch (Exception exception)
            {
                territoryItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(territoryItemModel.OperationResult);
        }

        // POST: Territory/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(TerritoryItemModel territoryItemModel)
        {
            try
            {
                if (IsDelete(territoryItemModel.OperationResult))
                {
                    if (Application.Delete(territoryItemModel.OperationResult, (Territory)territoryItemModel.Territory.ToData()))
                    {
                        return JsonResultSuccess(territoryItemModel.OperationResult);
                    }
                }
            }
            catch (Exception exception)
            {
                territoryItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(territoryItemModel.OperationResult);
        }
        
        #endregion Methods SCRUD
        
        #region Methods Syncfusion

        // POST: Territory/DataSource
        [HttpPost]
        public ActionResult DataSource(DataManager dataManager)
        {
            SyncfusionDataResult dataResult = new SyncfusionDataResult
            {
                result = new List<TerritoryViewModel>()
            };

            ZOperationResult operationResult = new ZOperationResult();

            if (IsSearch(operationResult))
            {
                try
                {
                    SyncfusionGrid syncfusionGrid = new SyncfusionGrid(typeof(Territory), Application.UnitOfWork.DBMS);
                    ArrayList args = new ArrayList();
                    string where = syncfusionGrid.ToLinqWhere(dataManager.Search, dataManager.Where, args);
                    string orderBy = syncfusionGrid.ToLinqOrderBy(dataManager.Sorted);        
                    int take = (dataManager.Skip == 0 && dataManager.Take == 0) ? AppDefaults.SyncfusionRecordsBySearch : dataManager.Take; // Excel Filtering
                    dataResult.result = ZViewModelHelper<TerritoryViewModel, Territory>.ToViewList(Application.Search(operationResult, where, args.ToArray(), orderBy, dataManager.Skip, take));
        
                    if (dataManager.RequiresCounts)
                    {
                        dataResult.count = Application.Count(operationResult, where, args.ToArray());
                    }
                }
                catch (Exception exception)
                {
                    operationResult.ParseException(exception);
                }
            }

            if (!operationResult.Ok)
            {
                operationResult.ThrowException();
            }

            return Json(JsonConvert.SerializeObject(dataResult), JsonRequestBehavior.AllowGet);
        } 

        // POST: Territory/ExportToExcel
        [HttpPost]
        public void ExportToExcel(string gridModel)
        {
            if (IsExport())
            {
                ExportToExcel(gridModel, TerritoryResources.EntitySingular + ".xlsx");
            }
        }

        // POST: Territory/ExportToPdf
        [HttpPost]
        public void ExportToPdf(string gridModel)
        {
            if (IsExport())
            {
                ExportToPdf(gridModel, TerritoryResources.EntitySingular + ".pdf");
            }
        }

        // POST: Territory/ExportToWord
        [HttpPost]
        public void ExportToWord(string gridModel)
        {
            if (IsExport())
            {
                ExportToWord(gridModel, TerritoryResources.EntitySingular + ".docx");
            }
        }
        
        #endregion Methods Syncfusion
    }
}