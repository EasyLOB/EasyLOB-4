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
    public partial class CustomerController : BaseMvcControllerSCRUDApplication<Customer>
    {
        #region Methods

        public CustomerController(INorthwindGenericApplication<Customer> application)
    : base(application.AuthorizationManager)
        {
            Application = application;            
        }

        #endregion Methods

        #region Methods SCRUD

        // GET: Customer
        // GET: Customer/Index
        [HttpGet]
        public ActionResult Index(string operation = null)
        {
            CustomerCollectionModel customerCollectionModel = new CustomerCollectionModel(ActivityOperations, "Index", null, null, null, operation);

            try
            {
                if (IsIndex(customerCollectionModel.OperationResult))
                {
                    return ZView(customerCollectionModel);
                }
            }
            catch (Exception exception)
            {
                customerCollectionModel.OperationResult.ParseException(exception);
            }

            return ZViewOperationResult(customerCollectionModel.OperationResult);
        }        

        // GET & POST: Customer/Search
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Search(string masterControllerAction = null, string masterEntity = null, string masterKey = null)
        {
            CustomerCollectionModel customerCollectionModel = new CustomerCollectionModel(ActivityOperations, "Search", masterControllerAction, masterEntity, masterKey);

            try
            {
                if (IsOperation(customerCollectionModel.OperationResult))
                {
                    return ZPartialView(customerCollectionModel);
                }
            }
            catch (Exception exception)
            {
                customerCollectionModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(customerCollectionModel.OperationResult);
        }

        // GET & POST: Customer/Lookup
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Lookup(string text, string valueId, bool? required = false, List<LookupModelElement> elements = null, string query = null)
        {
            LookupModel lookupModel = new LookupModel(ActivityOperations, text, valueId, required, elements, query);

            try
            {
                if (IsSearch(lookupModel.OperationResult))
                {
                    return ZPartialView("_CustomerLookup", lookupModel);
                }
            }
            catch (Exception exception)
            {
                lookupModel.OperationResult.ParseException(exception);
            }

            return null;
        }

        // GET: Customer/Create
        [HttpGet]
        public ActionResult Create(string masterEntity = null, string masterKey = null)
        {
            CustomerItemModel customerItemModel = new CustomerItemModel(ActivityOperations, "Create", masterEntity, masterKey);

            try
            {
                if (IsCreate(customerItemModel.OperationResult))
                {
                    return ZPartialView("CRUD", customerItemModel);
                }            
            }
            catch (Exception exception)
            {
                customerItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(customerItemModel.OperationResult);
        }

        // POST: Customer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerItemModel customerItemModel)
        {
            try
            {
                if (IsCreate(customerItemModel.OperationResult))
                {
                    if (IsValid(customerItemModel.OperationResult, customerItemModel.Customer))
                    {
                        Customer customer = (Customer)customerItemModel.Customer.ToData();
                        if (Application.Create(customerItemModel.OperationResult, customer))
                        {
                            if (customerItemModel.IsSave)
                            {
                                Create2Update(customerItemModel.OperationResult);
                                return JsonResultSuccess(customerItemModel.OperationResult,
                                    Url.Action("Update", "Customer", new { CustomerId = customer.CustomerId }, Request.Url.Scheme));
                            }
                            else
                            {
                                return JsonResultSuccess(customerItemModel.OperationResult);
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                customerItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(customerItemModel.OperationResult);
        }

        // GET: Customer/Read/1
        [HttpGet]
        public ActionResult Read(string customerId, string masterEntity = null, string masterKey = null)
        {
            CustomerItemModel customerItemModel = new CustomerItemModel(ActivityOperations, "Read", masterEntity, masterKey);
            
            try
            {
                if (IsRead(customerItemModel.OperationResult))
                {
                    Customer customer = Application.GetById(customerItemModel.OperationResult, new object[] { customerId }, true);
                    if (customer != null)
                    {
                        customerItemModel.Customer = new CustomerViewModel(customer);                    

                        return ZPartialView("CRUD", customerItemModel);
                    }
                }
            }
            catch (Exception exception)
            {
                customerItemModel.OperationResult.ParseException(exception);
            }            

            return JsonResultOperationResult(customerItemModel.OperationResult);
        }

        // GET: Customer/Update/1
        [HttpGet]
        public ActionResult Update(string customerId, string masterEntity = null, string masterKey = null)
        {
            CustomerItemModel customerItemModel = new CustomerItemModel(ActivityOperations, "Update", masterEntity, masterKey);
            
            try
            {
                if (IsUpdate(customerItemModel.OperationResult))
                {            
                    Customer customer = Application.GetById(customerItemModel.OperationResult, new object[] { customerId }, true);
                    if (customer != null)
                    {
                        customerItemModel.Customer = new CustomerViewModel(customer);

                        return ZPartialView("CRUD", customerItemModel);
                    }
                }
            }
            catch (Exception exception)
            {
                customerItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(customerItemModel.OperationResult);
        }

        // POST: Customer/Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(CustomerItemModel customerItemModel)
        {
            try
            {
                if (IsUpdate(customerItemModel.OperationResult))
                {
                    if (IsValid(customerItemModel.OperationResult, customerItemModel.Customer))
                    {
                        Customer customer = (Customer)customerItemModel.Customer.ToData();
                        if (Application.Update(customerItemModel.OperationResult, customer))
                        {
                            if (customerItemModel.IsSave)
                            {
                                return JsonResultSuccess(customerItemModel.OperationResult,
                                    Url.Action("Update", "Customer", new { CustomerId = customer.CustomerId }, Request.Url.Scheme));
                            }
                            else
                            {
                                return JsonResultSuccess(customerItemModel.OperationResult);
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                customerItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(customerItemModel.OperationResult);
        }

        // GET: Customer/Delete/1
        [HttpGet]
        public ActionResult Delete(string customerId, string masterEntity = null, string masterKey = null)
        {
            CustomerItemModel customerItemModel = new CustomerItemModel(ActivityOperations, "Delete", masterEntity, masterKey);
            
            try
            {
                if (IsDelete(customerItemModel.OperationResult))
                {            
                    Customer customer = Application.GetById(customerItemModel.OperationResult, new object[] { customerId }, true);
                    if (customer != null)
                    {
                        customerItemModel.Customer = new CustomerViewModel(customer);

                        return ZPartialView("CRUD", customerItemModel);
                    }
                }
            }
            catch (Exception exception)
            {
                customerItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(customerItemModel.OperationResult);
        }

        // POST: Customer/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(CustomerItemModel customerItemModel)
        {
            try
            {
                if (IsDelete(customerItemModel.OperationResult))
                {
                    if (Application.Delete(customerItemModel.OperationResult, (Customer)customerItemModel.Customer.ToData()))
                    {
                        return JsonResultSuccess(customerItemModel.OperationResult);
                    }
                }
            }
            catch (Exception exception)
            {
                customerItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(customerItemModel.OperationResult);
        }
        
        #endregion Methods SCRUD
        
        #region Methods Syncfusion

        // POST: Customer/DataSource
        [HttpPost]
        public ActionResult DataSource(DataManager dataManager)
        {
            SyncfusionDataResult dataResult = new SyncfusionDataResult
            {
                result = new List<CustomerViewModel>()
            };

            ZOperationResult operationResult = new ZOperationResult();

            if (IsSearch(operationResult))
            {
                try
                {
                    SyncfusionGrid syncfusionGrid = new SyncfusionGrid(typeof(Customer), Application.UnitOfWork.DBMS);
                    ArrayList args = new ArrayList();
                    string where = syncfusionGrid.ToLinqWhere(dataManager.Search, dataManager.Where, args);
                    string orderBy = syncfusionGrid.ToLinqOrderBy(dataManager.Sorted);        
                    int take = (dataManager.Skip == 0 && dataManager.Take == 0) ? AppDefaults.SyncfusionRecordsBySearch : dataManager.Take; // Excel Filtering
                    dataResult.result = ZViewModelHelper<CustomerViewModel, Customer>.ToViewList(Application.Search(operationResult, where, args.ToArray(), orderBy, dataManager.Skip, take));
        
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

        // POST: Customer/ExportToExcel
        [HttpPost]
        public void ExportToExcel(string gridModel)
        {
            if (IsExport())
            {
                ExportToExcel(gridModel, CustomerResources.EntitySingular + ".xlsx");
            }
        }

        // POST: Customer/ExportToPdf
        [HttpPost]
        public void ExportToPdf(string gridModel)
        {
            if (IsExport())
            {
                ExportToPdf(gridModel, CustomerResources.EntitySingular + ".pdf");
            }
        }

        // POST: Customer/ExportToWord
        [HttpPost]
        public void ExportToWord(string gridModel)
        {
            if (IsExport())
            {
                ExportToWord(gridModel, CustomerResources.EntitySingular + ".docx");
            }
        }
        
        #endregion Methods Syncfusion
    }
}