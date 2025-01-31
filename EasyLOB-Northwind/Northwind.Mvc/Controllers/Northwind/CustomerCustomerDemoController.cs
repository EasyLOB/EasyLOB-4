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
    public partial class CustomerCustomerDemoController : BaseMvcControllerSCRUDApplication<CustomerCustomerDemo>
    {
        #region Methods

        public CustomerCustomerDemoController(INorthwindGenericApplication<CustomerCustomerDemo> application)
    : base(application.AuthorizationManager)
        {
            Application = application;            
        }

        #endregion Methods

        #region Methods SCRUD

        // GET: CustomerCustomerDemo
        // GET: CustomerCustomerDemo/Index
        [HttpGet]
        public ActionResult Index(string operation = null)
        {
            CustomerCustomerDemoCollectionModel customerCustomerDemoCollectionModel = new CustomerCustomerDemoCollectionModel(ActivityOperations, "Index", null, null, null, operation);

            try
            {
                if (IsIndex(customerCustomerDemoCollectionModel.OperationResult))
                {
                    return ZView(customerCustomerDemoCollectionModel);
                }
            }
            catch (Exception exception)
            {
                customerCustomerDemoCollectionModel.OperationResult.ParseException(exception);
            }

            return ZViewOperationResult(customerCustomerDemoCollectionModel.OperationResult);
        }        

        // GET & POST: CustomerCustomerDemo/Search
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Search(string masterControllerAction = null, string masterEntity = null, string masterKey = null)
        {
            CustomerCustomerDemoCollectionModel customerCustomerDemoCollectionModel = new CustomerCustomerDemoCollectionModel(ActivityOperations, "Search", masterControllerAction, masterEntity, masterKey);

            try
            {
                if (IsOperation(customerCustomerDemoCollectionModel.OperationResult))
                {
                    return ZPartialView(customerCustomerDemoCollectionModel);
                }
            }
            catch (Exception exception)
            {
                customerCustomerDemoCollectionModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(customerCustomerDemoCollectionModel.OperationResult);
        }

        // GET & POST: CustomerCustomerDemo/Lookup
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Lookup(string text, string valueId, bool? required = false, List<LookupModelElement> elements = null, string query = null)
        {
            LookupModel lookupModel = new LookupModel(ActivityOperations, text, valueId, required, elements, query);

            try
            {
                if (IsSearch(lookupModel.OperationResult))
                {
                    return ZPartialView("_CustomerCustomerDemoLookup", lookupModel);
                }
            }
            catch (Exception exception)
            {
                lookupModel.OperationResult.ParseException(exception);
            }

            return null;
        }

        // GET: CustomerCustomerDemo/Create
        [HttpGet]
        public ActionResult Create(string masterEntity = null, string masterKey = null)
        {
            CustomerCustomerDemoItemModel customerCustomerDemoItemModel = new CustomerCustomerDemoItemModel(ActivityOperations, "Create", masterEntity, masterKey);

            try
            {
                if (IsCreate(customerCustomerDemoItemModel.OperationResult))
                {
                    return ZPartialView("CRUD", customerCustomerDemoItemModel);
                }            
            }
            catch (Exception exception)
            {
                customerCustomerDemoItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(customerCustomerDemoItemModel.OperationResult);
        }

        // POST: CustomerCustomerDemo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerCustomerDemoItemModel customerCustomerDemoItemModel)
        {
            try
            {
                if (IsCreate(customerCustomerDemoItemModel.OperationResult))
                {
                    if (IsValid(customerCustomerDemoItemModel.OperationResult, customerCustomerDemoItemModel.CustomerCustomerDemo))
                    {
                        CustomerCustomerDemo customerCustomerDemo = (CustomerCustomerDemo)customerCustomerDemoItemModel.CustomerCustomerDemo.ToData();
                        if (Application.Create(customerCustomerDemoItemModel.OperationResult, customerCustomerDemo))
                        {
                            if (customerCustomerDemoItemModel.IsSave)
                            {
                                Create2Update(customerCustomerDemoItemModel.OperationResult);
                                return JsonResultSuccess(customerCustomerDemoItemModel.OperationResult,
                                    Url.Action("Update", "CustomerCustomerDemo", new { CustomerId = customerCustomerDemo.CustomerId, CustomerTypeId = customerCustomerDemo.CustomerTypeId }, Request.Url.Scheme));
                            }
                            else
                            {
                                return JsonResultSuccess(customerCustomerDemoItemModel.OperationResult);
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                customerCustomerDemoItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(customerCustomerDemoItemModel.OperationResult);
        }

        // GET: CustomerCustomerDemo/Read/1
        [HttpGet]
        public ActionResult Read(string customerId, string customerTypeId, string masterEntity = null, string masterKey = null)
        {
            CustomerCustomerDemoItemModel customerCustomerDemoItemModel = new CustomerCustomerDemoItemModel(ActivityOperations, "Read", masterEntity, masterKey);
            
            try
            {
                if (IsRead(customerCustomerDemoItemModel.OperationResult))
                {
                    CustomerCustomerDemo customerCustomerDemo = Application.GetById(customerCustomerDemoItemModel.OperationResult, new object[] { customerId, customerTypeId }, true);
                    if (customerCustomerDemo != null)
                    {
                        customerCustomerDemoItemModel.CustomerCustomerDemo = new CustomerCustomerDemoViewModel(customerCustomerDemo);                    

                        return ZPartialView("CRUD", customerCustomerDemoItemModel);
                    }
                }
            }
            catch (Exception exception)
            {
                customerCustomerDemoItemModel.OperationResult.ParseException(exception);
            }            

            return JsonResultOperationResult(customerCustomerDemoItemModel.OperationResult);
        }

        // GET: CustomerCustomerDemo/Update/1
        [HttpGet]
        public ActionResult Update(string customerId, string customerTypeId, string masterEntity = null, string masterKey = null)
        {
            CustomerCustomerDemoItemModel customerCustomerDemoItemModel = new CustomerCustomerDemoItemModel(ActivityOperations, "Update", masterEntity, masterKey);
            
            try
            {
                if (IsUpdate(customerCustomerDemoItemModel.OperationResult))
                {            
                    CustomerCustomerDemo customerCustomerDemo = Application.GetById(customerCustomerDemoItemModel.OperationResult, new object[] { customerId, customerTypeId }, true);
                    if (customerCustomerDemo != null)
                    {
                        customerCustomerDemoItemModel.CustomerCustomerDemo = new CustomerCustomerDemoViewModel(customerCustomerDemo);

                        return ZPartialView("CRUD", customerCustomerDemoItemModel);
                    }
                }
            }
            catch (Exception exception)
            {
                customerCustomerDemoItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(customerCustomerDemoItemModel.OperationResult);
        }

        // POST: CustomerCustomerDemo/Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(CustomerCustomerDemoItemModel customerCustomerDemoItemModel)
        {
            try
            {
                if (IsUpdate(customerCustomerDemoItemModel.OperationResult))
                {
                    if (IsValid(customerCustomerDemoItemModel.OperationResult, customerCustomerDemoItemModel.CustomerCustomerDemo))
                    {
                        CustomerCustomerDemo customerCustomerDemo = (CustomerCustomerDemo)customerCustomerDemoItemModel.CustomerCustomerDemo.ToData();
                        if (Application.Update(customerCustomerDemoItemModel.OperationResult, customerCustomerDemo))
                        {
                            if (customerCustomerDemoItemModel.IsSave)
                            {
                                return JsonResultSuccess(customerCustomerDemoItemModel.OperationResult,
                                    Url.Action("Update", "CustomerCustomerDemo", new { CustomerId = customerCustomerDemo.CustomerId, CustomerTypeId = customerCustomerDemo.CustomerTypeId }, Request.Url.Scheme));
                            }
                            else
                            {
                                return JsonResultSuccess(customerCustomerDemoItemModel.OperationResult);
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                customerCustomerDemoItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(customerCustomerDemoItemModel.OperationResult);
        }

        // GET: CustomerCustomerDemo/Delete/1
        [HttpGet]
        public ActionResult Delete(string customerId, string customerTypeId, string masterEntity = null, string masterKey = null)
        {
            CustomerCustomerDemoItemModel customerCustomerDemoItemModel = new CustomerCustomerDemoItemModel(ActivityOperations, "Delete", masterEntity, masterKey);
            
            try
            {
                if (IsDelete(customerCustomerDemoItemModel.OperationResult))
                {            
                    CustomerCustomerDemo customerCustomerDemo = Application.GetById(customerCustomerDemoItemModel.OperationResult, new object[] { customerId, customerTypeId }, true);
                    if (customerCustomerDemo != null)
                    {
                        customerCustomerDemoItemModel.CustomerCustomerDemo = new CustomerCustomerDemoViewModel(customerCustomerDemo);

                        return ZPartialView("CRUD", customerCustomerDemoItemModel);
                    }
                }
            }
            catch (Exception exception)
            {
                customerCustomerDemoItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(customerCustomerDemoItemModel.OperationResult);
        }

        // POST: CustomerCustomerDemo/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(CustomerCustomerDemoItemModel customerCustomerDemoItemModel)
        {
            try
            {
                if (IsDelete(customerCustomerDemoItemModel.OperationResult))
                {
                    if (Application.Delete(customerCustomerDemoItemModel.OperationResult, (CustomerCustomerDemo)customerCustomerDemoItemModel.CustomerCustomerDemo.ToData()))
                    {
                        return JsonResultSuccess(customerCustomerDemoItemModel.OperationResult);
                    }
                }
            }
            catch (Exception exception)
            {
                customerCustomerDemoItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(customerCustomerDemoItemModel.OperationResult);
        }
        
        #endregion Methods SCRUD
        
        #region Methods Syncfusion

        // POST: CustomerCustomerDemo/DataSource
        [HttpPost]
        public ActionResult DataSource(DataManager dataManager)
        {
            SyncfusionDataResult dataResult = new SyncfusionDataResult
            {
                result = new List<CustomerCustomerDemoViewModel>()
            };

            ZOperationResult operationResult = new ZOperationResult();

            if (IsSearch(operationResult))
            {
                try
                {
                    SyncfusionGrid syncfusionGrid = new SyncfusionGrid(typeof(CustomerCustomerDemo), Application.UnitOfWork.DBMS);
                    ArrayList args = new ArrayList();
                    string where = syncfusionGrid.ToLinqWhere(dataManager.Search, dataManager.Where, args);
                    string orderBy = syncfusionGrid.ToLinqOrderBy(dataManager.Sorted);        
                    int take = (dataManager.Skip == 0 && dataManager.Take == 0) ? AppDefaults.SyncfusionRecordsBySearch : dataManager.Take; // Excel Filtering
                    dataResult.result = ZViewModelHelper<CustomerCustomerDemoViewModel, CustomerCustomerDemo>.ToViewList(Application.Search(operationResult, where, args.ToArray(), orderBy, dataManager.Skip, take));
        
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

        // POST: CustomerCustomerDemo/ExportToExcel
        [HttpPost]
        public void ExportToExcel(string gridModel)
        {
            if (IsExport())
            {
                ExportToExcel(gridModel, CustomerCustomerDemoResources.EntitySingular + ".xlsx");
            }
        }

        // POST: CustomerCustomerDemo/ExportToPdf
        [HttpPost]
        public void ExportToPdf(string gridModel)
        {
            if (IsExport())
            {
                ExportToPdf(gridModel, CustomerCustomerDemoResources.EntitySingular + ".pdf");
            }
        }

        // POST: CustomerCustomerDemo/ExportToWord
        [HttpPost]
        public void ExportToWord(string gridModel)
        {
            if (IsExport())
            {
                ExportToWord(gridModel, CustomerCustomerDemoResources.EntitySingular + ".docx");
            }
        }
        
        #endregion Methods Syncfusion
    }
}