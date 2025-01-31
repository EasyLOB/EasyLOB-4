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
    public partial class CustomerDemographicController : BaseMvcControllerSCRUDApplication<CustomerDemographic>
    {
        #region Methods

        public CustomerDemographicController(INorthwindGenericApplication<CustomerDemographic> application)
    : base(application.AuthorizationManager)
        {
            Application = application;            
        }

        #endregion Methods

        #region Methods SCRUD

        // GET: CustomerDemographic
        // GET: CustomerDemographic/Index
        [HttpGet]
        public ActionResult Index(string operation = null)
        {
            CustomerDemographicCollectionModel customerDemographicCollectionModel = new CustomerDemographicCollectionModel(ActivityOperations, "Index", null, null, null, operation);

            try
            {
                if (IsIndex(customerDemographicCollectionModel.OperationResult))
                {
                    return ZView(customerDemographicCollectionModel);
                }
            }
            catch (Exception exception)
            {
                customerDemographicCollectionModel.OperationResult.ParseException(exception);
            }

            return ZViewOperationResult(customerDemographicCollectionModel.OperationResult);
        }        

        // GET & POST: CustomerDemographic/Search
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Search(string masterControllerAction = null, string masterEntity = null, string masterKey = null)
        {
            CustomerDemographicCollectionModel customerDemographicCollectionModel = new CustomerDemographicCollectionModel(ActivityOperations, "Search", masterControllerAction, masterEntity, masterKey);

            try
            {
                if (IsOperation(customerDemographicCollectionModel.OperationResult))
                {
                    return ZPartialView(customerDemographicCollectionModel);
                }
            }
            catch (Exception exception)
            {
                customerDemographicCollectionModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(customerDemographicCollectionModel.OperationResult);
        }

        // GET & POST: CustomerDemographic/Lookup
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Lookup(string text, string valueId, bool? required = false, List<LookupModelElement> elements = null, string query = null)
        {
            LookupModel lookupModel = new LookupModel(ActivityOperations, text, valueId, required, elements, query);

            try
            {
                if (IsSearch(lookupModel.OperationResult))
                {
                    return ZPartialView("_CustomerDemographicLookup", lookupModel);
                }
            }
            catch (Exception exception)
            {
                lookupModel.OperationResult.ParseException(exception);
            }

            return null;
        }

        // GET: CustomerDemographic/Create
        [HttpGet]
        public ActionResult Create(string masterEntity = null, string masterKey = null)
        {
            CustomerDemographicItemModel customerDemographicItemModel = new CustomerDemographicItemModel(ActivityOperations, "Create", masterEntity, masterKey);

            try
            {
                if (IsCreate(customerDemographicItemModel.OperationResult))
                {
                    return ZPartialView("CRUD", customerDemographicItemModel);
                }            
            }
            catch (Exception exception)
            {
                customerDemographicItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(customerDemographicItemModel.OperationResult);
        }

        // POST: CustomerDemographic/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerDemographicItemModel customerDemographicItemModel)
        {
            try
            {
                if (IsCreate(customerDemographicItemModel.OperationResult))
                {
                    if (IsValid(customerDemographicItemModel.OperationResult, customerDemographicItemModel.CustomerDemographic))
                    {
                        CustomerDemographic customerDemographic = (CustomerDemographic)customerDemographicItemModel.CustomerDemographic.ToData();
                        if (Application.Create(customerDemographicItemModel.OperationResult, customerDemographic))
                        {
                            if (customerDemographicItemModel.IsSave)
                            {
                                Create2Update(customerDemographicItemModel.OperationResult);
                                return JsonResultSuccess(customerDemographicItemModel.OperationResult,
                                    Url.Action("Update", "CustomerDemographic", new { CustomerTypeId = customerDemographic.CustomerTypeId }, Request.Url.Scheme));
                            }
                            else
                            {
                                return JsonResultSuccess(customerDemographicItemModel.OperationResult);
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                customerDemographicItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(customerDemographicItemModel.OperationResult);
        }

        // GET: CustomerDemographic/Read/1
        [HttpGet]
        public ActionResult Read(string customerTypeId, string masterEntity = null, string masterKey = null)
        {
            CustomerDemographicItemModel customerDemographicItemModel = new CustomerDemographicItemModel(ActivityOperations, "Read", masterEntity, masterKey);
            
            try
            {
                if (IsRead(customerDemographicItemModel.OperationResult))
                {
                    CustomerDemographic customerDemographic = Application.GetById(customerDemographicItemModel.OperationResult, new object[] { customerTypeId }, true);
                    if (customerDemographic != null)
                    {
                        customerDemographicItemModel.CustomerDemographic = new CustomerDemographicViewModel(customerDemographic);                    

                        return ZPartialView("CRUD", customerDemographicItemModel);
                    }
                }
            }
            catch (Exception exception)
            {
                customerDemographicItemModel.OperationResult.ParseException(exception);
            }            

            return JsonResultOperationResult(customerDemographicItemModel.OperationResult);
        }

        // GET: CustomerDemographic/Update/1
        [HttpGet]
        public ActionResult Update(string customerTypeId, string masterEntity = null, string masterKey = null)
        {
            CustomerDemographicItemModel customerDemographicItemModel = new CustomerDemographicItemModel(ActivityOperations, "Update", masterEntity, masterKey);
            
            try
            {
                if (IsUpdate(customerDemographicItemModel.OperationResult))
                {            
                    CustomerDemographic customerDemographic = Application.GetById(customerDemographicItemModel.OperationResult, new object[] { customerTypeId }, true);
                    if (customerDemographic != null)
                    {
                        customerDemographicItemModel.CustomerDemographic = new CustomerDemographicViewModel(customerDemographic);

                        return ZPartialView("CRUD", customerDemographicItemModel);
                    }
                }
            }
            catch (Exception exception)
            {
                customerDemographicItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(customerDemographicItemModel.OperationResult);
        }

        // POST: CustomerDemographic/Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(CustomerDemographicItemModel customerDemographicItemModel)
        {
            try
            {
                if (IsUpdate(customerDemographicItemModel.OperationResult))
                {
                    if (IsValid(customerDemographicItemModel.OperationResult, customerDemographicItemModel.CustomerDemographic))
                    {
                        CustomerDemographic customerDemographic = (CustomerDemographic)customerDemographicItemModel.CustomerDemographic.ToData();
                        if (Application.Update(customerDemographicItemModel.OperationResult, customerDemographic))
                        {
                            if (customerDemographicItemModel.IsSave)
                            {
                                return JsonResultSuccess(customerDemographicItemModel.OperationResult,
                                    Url.Action("Update", "CustomerDemographic", new { CustomerTypeId = customerDemographic.CustomerTypeId }, Request.Url.Scheme));
                            }
                            else
                            {
                                return JsonResultSuccess(customerDemographicItemModel.OperationResult);
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                customerDemographicItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(customerDemographicItemModel.OperationResult);
        }

        // GET: CustomerDemographic/Delete/1
        [HttpGet]
        public ActionResult Delete(string customerTypeId, string masterEntity = null, string masterKey = null)
        {
            CustomerDemographicItemModel customerDemographicItemModel = new CustomerDemographicItemModel(ActivityOperations, "Delete", masterEntity, masterKey);
            
            try
            {
                if (IsDelete(customerDemographicItemModel.OperationResult))
                {            
                    CustomerDemographic customerDemographic = Application.GetById(customerDemographicItemModel.OperationResult, new object[] { customerTypeId }, true);
                    if (customerDemographic != null)
                    {
                        customerDemographicItemModel.CustomerDemographic = new CustomerDemographicViewModel(customerDemographic);

                        return ZPartialView("CRUD", customerDemographicItemModel);
                    }
                }
            }
            catch (Exception exception)
            {
                customerDemographicItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(customerDemographicItemModel.OperationResult);
        }

        // POST: CustomerDemographic/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(CustomerDemographicItemModel customerDemographicItemModel)
        {
            try
            {
                if (IsDelete(customerDemographicItemModel.OperationResult))
                {
                    if (Application.Delete(customerDemographicItemModel.OperationResult, (CustomerDemographic)customerDemographicItemModel.CustomerDemographic.ToData()))
                    {
                        return JsonResultSuccess(customerDemographicItemModel.OperationResult);
                    }
                }
            }
            catch (Exception exception)
            {
                customerDemographicItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(customerDemographicItemModel.OperationResult);
        }
        
        #endregion Methods SCRUD
        
        #region Methods Syncfusion

        // POST: CustomerDemographic/DataSource
        [HttpPost]
        public ActionResult DataSource(DataManager dataManager)
        {
            SyncfusionDataResult dataResult = new SyncfusionDataResult
            {
                result = new List<CustomerDemographicViewModel>()
            };

            ZOperationResult operationResult = new ZOperationResult();

            if (IsSearch(operationResult))
            {
                try
                {
                    SyncfusionGrid syncfusionGrid = new SyncfusionGrid(typeof(CustomerDemographic), Application.UnitOfWork.DBMS);
                    ArrayList args = new ArrayList();
                    string where = syncfusionGrid.ToLinqWhere(dataManager.Search, dataManager.Where, args);
                    string orderBy = syncfusionGrid.ToLinqOrderBy(dataManager.Sorted);        
                    int take = (dataManager.Skip == 0 && dataManager.Take == 0) ? AppDefaults.SyncfusionRecordsBySearch : dataManager.Take; // Excel Filtering
                    dataResult.result = ZViewModelHelper<CustomerDemographicViewModel, CustomerDemographic>.ToViewList(Application.Search(operationResult, where, args.ToArray(), orderBy, dataManager.Skip, take));
        
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

        // POST: CustomerDemographic/ExportToExcel
        [HttpPost]
        public void ExportToExcel(string gridModel)
        {
            if (IsExport())
            {
                ExportToExcel(gridModel, CustomerDemographicResources.EntitySingular + ".xlsx");
            }
        }

        // POST: CustomerDemographic/ExportToPdf
        [HttpPost]
        public void ExportToPdf(string gridModel)
        {
            if (IsExport())
            {
                ExportToPdf(gridModel, CustomerDemographicResources.EntitySingular + ".pdf");
            }
        }

        // POST: CustomerDemographic/ExportToWord
        [HttpPost]
        public void ExportToWord(string gridModel)
        {
            if (IsExport())
            {
                ExportToWord(gridModel, CustomerDemographicResources.EntitySingular + ".docx");
            }
        }
        
        #endregion Methods Syncfusion
    }
}