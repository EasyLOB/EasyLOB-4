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
    public partial class OrderController : BaseMvcControllerSCRUDApplication<Order>
    {
        #region Methods

        public OrderController(INorthwindGenericApplication<Order> application)
    : base(application.AuthorizationManager)
        {
            Application = application;            
        }

        #endregion Methods

        #region Methods SCRUD

        // GET: Order
        // GET: Order/Index
        [HttpGet]
        public ActionResult Index(string operation = null)
        {
            OrderCollectionModel orderCollectionModel = new OrderCollectionModel(ActivityOperations, "Index", null, null, null, operation);

            try
            {
                if (IsIndex(orderCollectionModel.OperationResult))
                {
                    return ZView(orderCollectionModel);
                }
            }
            catch (Exception exception)
            {
                orderCollectionModel.OperationResult.ParseException(exception);
            }

            return ZViewOperationResult(orderCollectionModel.OperationResult);
        }        

        // GET & POST: Order/Search
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Search(string masterControllerAction = null, string masterEntity = null, string masterKey = null)
        {
            OrderCollectionModel orderCollectionModel = new OrderCollectionModel(ActivityOperations, "Search", masterControllerAction, masterEntity, masterKey);

            try
            {
                if (IsOperation(orderCollectionModel.OperationResult))
                {
                    return ZPartialView(orderCollectionModel);
                }
            }
            catch (Exception exception)
            {
                orderCollectionModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(orderCollectionModel.OperationResult);
        }

        // GET & POST: Order/Lookup
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Lookup(string text, string valueId, bool? required = false, List<LookupModelElement> elements = null, string query = null)
        {
            LookupModel lookupModel = new LookupModel(ActivityOperations, text, valueId, required, elements, query);

            try
            {
                if (IsSearch(lookupModel.OperationResult))
                {
                    return ZPartialView("_OrderLookup", lookupModel);
                }
            }
            catch (Exception exception)
            {
                lookupModel.OperationResult.ParseException(exception);
            }

            return null;
        }

        // GET: Order/Create
        [HttpGet]
        public ActionResult Create(string masterEntity = null, string masterKey = null)
        {
            OrderItemModel orderItemModel = new OrderItemModel(ActivityOperations, "Create", masterEntity, masterKey);

            try
            {
                if (IsCreate(orderItemModel.OperationResult))
                {
                    return ZPartialView("CRUD", orderItemModel);
                }            
            }
            catch (Exception exception)
            {
                orderItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(orderItemModel.OperationResult);
        }

        // POST: Order/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrderItemModel orderItemModel)
        {
            try
            {
                if (IsCreate(orderItemModel.OperationResult))
                {
                    if (IsValid(orderItemModel.OperationResult, orderItemModel.Order))
                    {
                        Order order = (Order)orderItemModel.Order.ToData();
                        if (Application.Create(orderItemModel.OperationResult, order))
                        {
                            if (orderItemModel.IsSave)
                            {
                                Create2Update(orderItemModel.OperationResult);
                                return JsonResultSuccess(orderItemModel.OperationResult,
                                    Url.Action("Update", "Order", new { OrderId = order.OrderId }, Request.Url.Scheme));
                            }
                            else
                            {
                                return JsonResultSuccess(orderItemModel.OperationResult);
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                orderItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(orderItemModel.OperationResult);
        }

        // GET: Order/Read/1
        [HttpGet]
        public ActionResult Read(int orderId, string masterEntity = null, string masterKey = null)
        {
            OrderItemModel orderItemModel = new OrderItemModel(ActivityOperations, "Read", masterEntity, masterKey);
            
            try
            {
                if (IsRead(orderItemModel.OperationResult))
                {
                    Order order = Application.GetById(orderItemModel.OperationResult, new object[] { orderId }, true);

                    if (order != null)
                    {
                        orderItemModel.Order = new OrderViewModel(order);                    

                        return ZPartialView("CRUD", orderItemModel);
                    }
                }
            }
            catch (Exception exception)
            {
                orderItemModel.OperationResult.ParseException(exception);
            }            

            return JsonResultOperationResult(orderItemModel.OperationResult);
        }

        // GET: Order/Update/1
        [HttpGet]
        public ActionResult Update(int orderId, string masterEntity = null, string masterKey = null)
        {
            OrderItemModel orderItemModel = new OrderItemModel(ActivityOperations, "Update", masterEntity, masterKey);
            
            try
            {
                if (IsUpdate(orderItemModel.OperationResult))
                {            
                    Order order = Application.GetById(orderItemModel.OperationResult, new object[] { orderId }, true);
                    if (order != null)
                    {
                        orderItemModel.Order = new OrderViewModel(order);

                        return ZPartialView("CRUD", orderItemModel);
                    }
                }
            }
            catch (Exception exception)
            {
                orderItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(orderItemModel.OperationResult);
        }

        // POST: Order/Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(OrderItemModel orderItemModel)
        {
            try
            {
                if (IsUpdate(orderItemModel.OperationResult))
                {
                    if (IsValid(orderItemModel.OperationResult, orderItemModel.Order))
                    {
                        Order order = (Order)orderItemModel.Order.ToData();
                        if (Application.Update(orderItemModel.OperationResult, order))
                        {
                            if (orderItemModel.IsSave)
                            {
                                return JsonResultSuccess(orderItemModel.OperationResult,
                                    Url.Action("Update", "Order", new { OrderId = order.OrderId }, Request.Url.Scheme));
                            }
                            else
                            {
                                return JsonResultSuccess(orderItemModel.OperationResult);
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                orderItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(orderItemModel.OperationResult);
        }

        // GET: Order/Delete/1
        [HttpGet]
        public ActionResult Delete(int orderId, string masterEntity = null, string masterKey = null)
        {
            OrderItemModel orderItemModel = new OrderItemModel(ActivityOperations, "Delete", masterEntity, masterKey);
            
            try
            {
                if (IsDelete(orderItemModel.OperationResult))
                {            
                    Order order = Application.GetById(orderItemModel.OperationResult, new object[] { orderId }, true);
                    if (order != null)
                    {
                        orderItemModel.Order = new OrderViewModel(order);

                        return ZPartialView("CRUD", orderItemModel);
                    }
                }
            }
            catch (Exception exception)
            {
                orderItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(orderItemModel.OperationResult);
        }

        // POST: Order/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(OrderItemModel orderItemModel)
        {
            try
            {
                if (IsDelete(orderItemModel.OperationResult))
                {
                    if (Application.Delete(orderItemModel.OperationResult, (Order)orderItemModel.Order.ToData()))
                    {
                        return JsonResultSuccess(orderItemModel.OperationResult);
                    }
                }
            }
            catch (Exception exception)
            {
                orderItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(orderItemModel.OperationResult);
        }
        
        #endregion Methods SCRUD
        
        #region Methods Syncfusion

        // POST: Order/DataSource
        [HttpPost]
        public ActionResult DataSource(DataManager dataManager)
        {
            SyncfusionDataResult dataResult = new SyncfusionDataResult
            {
                result = new List<OrderViewModel>()
            };

            ZOperationResult operationResult = new ZOperationResult();

            if (IsSearch(operationResult))
            {
                try
                {
                    SyncfusionGrid syncfusionGrid = new SyncfusionGrid(typeof(Order), Application.UnitOfWork.DBMS);
                    ArrayList args = new ArrayList();
                    string where = syncfusionGrid.ToLinqWhere(dataManager.Search, dataManager.Where, args);
                    string orderBy = syncfusionGrid.ToLinqOrderBy(dataManager.Sorted);        
                    int take = (dataManager.Skip == 0 && dataManager.Take == 0) ? AppDefaults.SyncfusionRecordsBySearch : dataManager.Take; // Excel Filtering
                    dataResult.result = ZViewModelHelper<OrderViewModel, Order>.ToViewList(Application.Search(operationResult, where, args.ToArray(), orderBy, dataManager.Skip, take));
        
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

        // POST: Order/ExportToExcel
        [HttpPost]
        public void ExportToExcel(string gridModel)
        {
            if (IsExport())
            {
                ExportToExcel(gridModel, OrderResources.EntitySingular + ".xlsx");
            }
        }

        // POST: Order/ExportToPdf
        [HttpPost]
        public void ExportToPdf(string gridModel)
        {
            if (IsExport())
            {
                ExportToPdf(gridModel, OrderResources.EntitySingular + ".pdf");
            }
        }

        // POST: Order/ExportToWord
        [HttpPost]
        public void ExportToWord(string gridModel)
        {
            if (IsExport())
            {
                ExportToWord(gridModel, OrderResources.EntitySingular + ".docx");
            }
        }
        
        #endregion Methods Syncfusion
    }
}