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
    public partial class EmployeeTerritoryController : BaseMvcControllerSCRUDApplication<EmployeeTerritory>
    {
        #region Methods

        public EmployeeTerritoryController(INorthwindGenericApplication<EmployeeTerritory> application)
    : base(application.AuthorizationManager)
        {
            Application = application;            
        }

        #endregion Methods

        #region Methods SCRUD

        // GET: EmployeeTerritory
        // GET: EmployeeTerritory/Index
        [HttpGet]
        public ActionResult Index(string operation = null)
        {
            EmployeeTerritoryCollectionModel employeeTerritoryCollectionModel = new EmployeeTerritoryCollectionModel(ActivityOperations, "Index", null, null, null, operation);

            try
            {
                if (IsIndex(employeeTerritoryCollectionModel.OperationResult))
                {
                    return ZView(employeeTerritoryCollectionModel);
                }
            }
            catch (Exception exception)
            {
                employeeTerritoryCollectionModel.OperationResult.ParseException(exception);
            }

            return ZViewOperationResult(employeeTerritoryCollectionModel.OperationResult);
        }        

        // GET & POST: EmployeeTerritory/Search
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Search(string masterControllerAction = null, string masterEntity = null, string masterKey = null)
        {
            EmployeeTerritoryCollectionModel employeeTerritoryCollectionModel = new EmployeeTerritoryCollectionModel(ActivityOperations, "Search", masterControllerAction, masterEntity, masterKey);

            try
            {
                if (IsOperation(employeeTerritoryCollectionModel.OperationResult))
                {
                    return ZPartialView(employeeTerritoryCollectionModel);
                }
            }
            catch (Exception exception)
            {
                employeeTerritoryCollectionModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(employeeTerritoryCollectionModel.OperationResult);
        }

        // GET & POST: EmployeeTerritory/Lookup
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Lookup(string text, string valueId, bool? required = false, List<LookupModelElement> elements = null, string query = null)
        {
            LookupModel lookupModel = new LookupModel(ActivityOperations, text, valueId, required, elements, query);

            try
            {
                if (IsSearch(lookupModel.OperationResult))
                {
                    return ZPartialView("_EmployeeTerritoryLookup", lookupModel);
                }
            }
            catch (Exception exception)
            {
                lookupModel.OperationResult.ParseException(exception);
            }

            return null;
        }

        // GET: EmployeeTerritory/Create
        [HttpGet]
        public ActionResult Create(string masterEntity = null, string masterKey = null)
        {
            EmployeeTerritoryItemModel employeeTerritoryItemModel = new EmployeeTerritoryItemModel(ActivityOperations, "Create", masterEntity, masterKey);

            try
            {
                if (IsCreate(employeeTerritoryItemModel.OperationResult))
                {
                    return ZPartialView("CRUD", employeeTerritoryItemModel);
                }            
            }
            catch (Exception exception)
            {
                employeeTerritoryItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(employeeTerritoryItemModel.OperationResult);
        }

        // POST: EmployeeTerritory/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeTerritoryItemModel employeeTerritoryItemModel)
        {
            try
            {
                if (IsCreate(employeeTerritoryItemModel.OperationResult))
                {
                    if (IsValid(employeeTerritoryItemModel.OperationResult, employeeTerritoryItemModel.EmployeeTerritory))
                    {
                        EmployeeTerritory employeeTerritory = (EmployeeTerritory)employeeTerritoryItemModel.EmployeeTerritory.ToData();
                        if (Application.Create(employeeTerritoryItemModel.OperationResult, employeeTerritory))
                        {
                            if (employeeTerritoryItemModel.IsSave)
                            {
                                Create2Update(employeeTerritoryItemModel.OperationResult);
                                return JsonResultSuccess(employeeTerritoryItemModel.OperationResult,
                                    Url.Action("Update", "EmployeeTerritory", new { EmployeeId = employeeTerritory.EmployeeId, TerritoryId = employeeTerritory.TerritoryId }, Request.Url.Scheme));
                            }
                            else
                            {
                                return JsonResultSuccess(employeeTerritoryItemModel.OperationResult);
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                employeeTerritoryItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(employeeTerritoryItemModel.OperationResult);
        }

        // GET: EmployeeTerritory/Read/1
        [HttpGet]
        public ActionResult Read(int employeeId, string territoryId, string masterEntity = null, string masterKey = null)
        {
            EmployeeTerritoryItemModel employeeTerritoryItemModel = new EmployeeTerritoryItemModel(ActivityOperations, "Read", masterEntity, masterKey);
            
            try
            {
                if (IsRead(employeeTerritoryItemModel.OperationResult))
                {
                    EmployeeTerritory employeeTerritory = Application.GetById(employeeTerritoryItemModel.OperationResult, new object[] { employeeId, territoryId }, true);
                    if (employeeTerritory != null)
                    {
                        employeeTerritoryItemModel.EmployeeTerritory = new EmployeeTerritoryViewModel(employeeTerritory);                    

                        return ZPartialView("CRUD", employeeTerritoryItemModel);
                    }
                }
            }
            catch (Exception exception)
            {
                employeeTerritoryItemModel.OperationResult.ParseException(exception);
            }            

            return JsonResultOperationResult(employeeTerritoryItemModel.OperationResult);
        }

        // GET: EmployeeTerritory/Update/1
        [HttpGet]
        public ActionResult Update(int employeeId, string territoryId, string masterEntity = null, string masterKey = null)
        {
            EmployeeTerritoryItemModel employeeTerritoryItemModel = new EmployeeTerritoryItemModel(ActivityOperations, "Update", masterEntity, masterKey);
            
            try
            {
                if (IsUpdate(employeeTerritoryItemModel.OperationResult))
                {            
                    EmployeeTerritory employeeTerritory = Application.GetById(employeeTerritoryItemModel.OperationResult, new object[] { employeeId, territoryId }, true);
                    if (employeeTerritory != null)
                    {
                        employeeTerritoryItemModel.EmployeeTerritory = new EmployeeTerritoryViewModel(employeeTerritory);

                        return ZPartialView("CRUD", employeeTerritoryItemModel);
                    }
                }
            }
            catch (Exception exception)
            {
                employeeTerritoryItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(employeeTerritoryItemModel.OperationResult);
        }

        // POST: EmployeeTerritory/Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(EmployeeTerritoryItemModel employeeTerritoryItemModel)
        {
            try
            {
                if (IsUpdate(employeeTerritoryItemModel.OperationResult))
                {
                    if (IsValid(employeeTerritoryItemModel.OperationResult, employeeTerritoryItemModel.EmployeeTerritory))
                    {
                        EmployeeTerritory employeeTerritory = (EmployeeTerritory)employeeTerritoryItemModel.EmployeeTerritory.ToData();
                        if (Application.Update(employeeTerritoryItemModel.OperationResult, employeeTerritory))
                        {
                            if (employeeTerritoryItemModel.IsSave)
                            {
                                return JsonResultSuccess(employeeTerritoryItemModel.OperationResult,
                                    Url.Action("Update", "EmployeeTerritory", new { EmployeeId = employeeTerritory.EmployeeId, TerritoryId = employeeTerritory.TerritoryId }, Request.Url.Scheme));
                            }
                            else
                            {
                                return JsonResultSuccess(employeeTerritoryItemModel.OperationResult);
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                employeeTerritoryItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(employeeTerritoryItemModel.OperationResult);
        }

        // GET: EmployeeTerritory/Delete/1
        [HttpGet]
        public ActionResult Delete(int employeeId, string territoryId, string masterEntity = null, string masterKey = null)
        {
            EmployeeTerritoryItemModel employeeTerritoryItemModel = new EmployeeTerritoryItemModel(ActivityOperations, "Delete", masterEntity, masterKey);
            
            try
            {
                if (IsDelete(employeeTerritoryItemModel.OperationResult))
                {            
                    EmployeeTerritory employeeTerritory = Application.GetById(employeeTerritoryItemModel.OperationResult, new object[] { employeeId, territoryId }, true);
                    if (employeeTerritory != null)
                    {
                        employeeTerritoryItemModel.EmployeeTerritory = new EmployeeTerritoryViewModel(employeeTerritory);

                        return ZPartialView("CRUD", employeeTerritoryItemModel);
                    }
                }
            }
            catch (Exception exception)
            {
                employeeTerritoryItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(employeeTerritoryItemModel.OperationResult);
        }

        // POST: EmployeeTerritory/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(EmployeeTerritoryItemModel employeeTerritoryItemModel)
        {
            try
            {
                if (IsDelete(employeeTerritoryItemModel.OperationResult))
                {
                    if (Application.Delete(employeeTerritoryItemModel.OperationResult, (EmployeeTerritory)employeeTerritoryItemModel.EmployeeTerritory.ToData()))
                    {
                        return JsonResultSuccess(employeeTerritoryItemModel.OperationResult);
                    }
                }
            }
            catch (Exception exception)
            {
                employeeTerritoryItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(employeeTerritoryItemModel.OperationResult);
        }
        
        #endregion Methods SCRUD
        
        #region Methods Syncfusion

        // POST: EmployeeTerritory/DataSource
        [HttpPost]
        public ActionResult DataSource(DataManager dataManager)
        {
            SyncfusionDataResult dataResult = new SyncfusionDataResult
            {
                result = new List<EmployeeTerritoryViewModel>()
            };

            ZOperationResult operationResult = new ZOperationResult();

            if (IsSearch(operationResult))
            {
                try
                {
                    SyncfusionGrid syncfusionGrid = new SyncfusionGrid(typeof(EmployeeTerritory), Application.UnitOfWork.DBMS);
                    ArrayList args = new ArrayList();
                    string where = syncfusionGrid.ToLinqWhere(dataManager.Search, dataManager.Where, args);
                    string orderBy = syncfusionGrid.ToLinqOrderBy(dataManager.Sorted);        
                    int take = (dataManager.Skip == 0 && dataManager.Take == 0) ? AppDefaults.SyncfusionRecordsBySearch : dataManager.Take; // Excel Filtering
                    dataResult.result = ZViewModelHelper<EmployeeTerritoryViewModel, EmployeeTerritory>.ToViewList(Application.Search(operationResult, where, args.ToArray(), orderBy, dataManager.Skip, take));
        
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

        // POST: EmployeeTerritory/ExportToExcel
        [HttpPost]
        public void ExportToExcel(string gridModel)
        {
            if (IsExport())
            {
                ExportToExcel(gridModel, EmployeeTerritoryResources.EntitySingular + ".xlsx");
            }
        }

        // POST: EmployeeTerritory/ExportToPdf
        [HttpPost]
        public void ExportToPdf(string gridModel)
        {
            if (IsExport())
            {
                ExportToPdf(gridModel, EmployeeTerritoryResources.EntitySingular + ".pdf");
            }
        }

        // POST: EmployeeTerritory/ExportToWord
        [HttpPost]
        public void ExportToWord(string gridModel)
        {
            if (IsExport())
            {
                ExportToWord(gridModel, EmployeeTerritoryResources.EntitySingular + ".docx");
            }
        }
        
        #endregion Methods Syncfusion
    }
}