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
    public partial class OrderDetailController : BaseMvcControllerSCRUDApplication<OrderDetail>
    {
        #region Methods

        public OrderDetailController(INorthwindGenericApplication<OrderDetail> application)
    : base(application.AuthorizationManager)
        {
            Application = application;            
        }

        #endregion Methods

        #region Methods SCRUD

        // GET: OrderDetail
        // GET: OrderDetail/Index
        [HttpGet]
        public ActionResult Index(string operation = null)
        {
            OrderDetailCollectionModel orderDetailCollectionModel = new OrderDetailCollectionModel(ActivityOperations, "Index", null, null, null, operation);

            try
            {
                if (IsIndex(orderDetailCollectionModel.OperationResult))
                {
                    return ZView(orderDetailCollectionModel);
                }
            }
            catch (Exception exception)
            {
                orderDetailCollectionModel.OperationResult.ParseException(exception);
            }

            return ZViewOperationResult(orderDetailCollectionModel.OperationResult);
        }        

        // GET & POST: OrderDetail/Search
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Search(string masterControllerAction = null, string masterEntity = null, string masterKey = null)
        {
            OrderDetailCollectionModel orderDetailCollectionModel = new OrderDetailCollectionModel(ActivityOperations, "Search", masterControllerAction, masterEntity, masterKey);

            try
            {
                if (IsOperation(orderDetailCollectionModel.OperationResult))
                {
                    return ZPartialView(orderDetailCollectionModel);
                }
            }
            catch (Exception exception)
            {
                orderDetailCollectionModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(orderDetailCollectionModel.OperationResult);
        }

        // GET & POST: OrderDetail/Lookup
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Lookup(string text, string valueId, bool? required = false, List<LookupModelElement> elements = null, string query = null)
        {
            LookupModel lookupModel = new LookupModel(ActivityOperations, text, valueId, required, elements, query);

            try
            {
                if (IsSearch(lookupModel.OperationResult))
                {
                    return ZPartialView("_OrderDetailLookup", lookupModel);
                }
            }
            catch (Exception exception)
            {
                lookupModel.OperationResult.ParseException(exception);
            }

            return null;
        }

        // GET: OrderDetail/Create
        [HttpGet]
        public ActionResult Create(string masterEntity = null, string masterKey = null)
        {
            OrderDetailItemModel orderDetailItemModel = new OrderDetailItemModel(ActivityOperations, "Create", masterEntity, masterKey);

            try
            {
                if (IsCreate(orderDetailItemModel.OperationResult))
                {
                    return ZPartialView("CRUD", orderDetailItemModel);
                }            
            }
            catch (Exception exception)
            {
                orderDetailItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(orderDetailItemModel.OperationResult);
        }

        // POST: OrderDetail/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrderDetailItemModel orderDetailItemModel)
        {
            try
            {
                if (IsCreate(orderDetailItemModel.OperationResult))
                {
                    if (IsValid(orderDetailItemModel.OperationResult, orderDetailItemModel.OrderDetail))
                    {
                        OrderDetail orderDetail = (OrderDetail)orderDetailItemModel.OrderDetail.ToData();
                        if (Application.Create(orderDetailItemModel.OperationResult, orderDetail))
                        {
                            if (orderDetailItemModel.IsSave)
                            {
                                Create2Update(orderDetailItemModel.OperationResult);
                                return JsonResultSuccess(orderDetailItemModel.OperationResult,
                                    Url.Action("Update", "OrderDetail", new { OrderId = orderDetail.OrderId, ProductId = orderDetail.ProductId }, Request.Url.Scheme));
                            }
                            else
                            {
                                return JsonResultSuccess(orderDetailItemModel.OperationResult);
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                orderDetailItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(orderDetailItemModel.OperationResult);
        }

        // GET: OrderDetail/Read/1
        [HttpGet]
        public ActionResult Read(int orderId, int productId, string masterEntity = null, string masterKey = null)
        {
            OrderDetailItemModel orderDetailItemModel = new OrderDetailItemModel(ActivityOperations, "Read", masterEntity, masterKey);
            
            try
            {
                if (IsRead(orderDetailItemModel.OperationResult))
                {
                    OrderDetail orderDetail = Application.GetById(orderDetailItemModel.OperationResult, new object[] { orderId, productId }, true);
                    if (orderDetail != null)
                    {
                        orderDetailItemModel.OrderDetail = new OrderDetailViewModel(orderDetail);                    

                        return ZPartialView("CRUD", orderDetailItemModel);
                    }
                }
            }
            catch (Exception exception)
            {
                orderDetailItemModel.OperationResult.ParseException(exception);
            }            

            return JsonResultOperationResult(orderDetailItemModel.OperationResult);
        }

        // GET: OrderDetail/Update/1
        [HttpGet]
        public ActionResult Update(int orderId, int productId, string masterEntity = null, string masterKey = null)
        {
            OrderDetailItemModel orderDetailItemModel = new OrderDetailItemModel(ActivityOperations, "Update", masterEntity, masterKey);
            
            try
            {
                if (IsUpdate(orderDetailItemModel.OperationResult))
                {            
                    OrderDetail orderDetail = Application.GetById(orderDetailItemModel.OperationResult, new object[] { orderId, productId }, true);
                    if (orderDetail != null)
                    {
                        orderDetailItemModel.OrderDetail = new OrderDetailViewModel(orderDetail);

                        return ZPartialView("CRUD", orderDetailItemModel);
                    }
                }
            }
            catch (Exception exception)
            {
                orderDetailItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(orderDetailItemModel.OperationResult);
        }

        // POST: OrderDetail/Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(OrderDetailItemModel orderDetailItemModel)
        {
            try
            {
                if (IsUpdate(orderDetailItemModel.OperationResult))
                {
                    if (IsValid(orderDetailItemModel.OperationResult, orderDetailItemModel.OrderDetail))
                    {
                        OrderDetail orderDetail = (OrderDetail)orderDetailItemModel.OrderDetail.ToData();
                        if (Application.Update(orderDetailItemModel.OperationResult, orderDetail))
                        {
                            if (orderDetailItemModel.IsSave)
                            {
                                return JsonResultSuccess(orderDetailItemModel.OperationResult,
                                    Url.Action("Update", "OrderDetail", new { OrderId = orderDetail.OrderId, ProductId = orderDetail.ProductId }, Request.Url.Scheme));
                            }
                            else
                            {
                                return JsonResultSuccess(orderDetailItemModel.OperationResult);
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                orderDetailItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(orderDetailItemModel.OperationResult);
        }

        // GET: OrderDetail/Delete/1
        [HttpGet]
        public ActionResult Delete(int orderId, int productId, string masterEntity = null, string masterKey = null)
        {
            OrderDetailItemModel orderDetailItemModel = new OrderDetailItemModel(ActivityOperations, "Delete", masterEntity, masterKey);
            
            try
            {
                if (IsDelete(orderDetailItemModel.OperationResult))
                {            
                    OrderDetail orderDetail = Application.GetById(orderDetailItemModel.OperationResult, new object[] { orderId, productId }, true);
                    if (orderDetail != null)
                    {
                        orderDetailItemModel.OrderDetail = new OrderDetailViewModel(orderDetail);

                        return ZPartialView("CRUD", orderDetailItemModel);
                    }
                }
            }
            catch (Exception exception)
            {
                orderDetailItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(orderDetailItemModel.OperationResult);
        }

        // POST: OrderDetail/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(OrderDetailItemModel orderDetailItemModel)
        {
            try
            {
                if (IsDelete(orderDetailItemModel.OperationResult))
                {
                    if (Application.Delete(orderDetailItemModel.OperationResult, (OrderDetail)orderDetailItemModel.OrderDetail.ToData()))
                    {
                        return JsonResultSuccess(orderDetailItemModel.OperationResult);
                    }
                }
            }
            catch (Exception exception)
            {
                orderDetailItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(orderDetailItemModel.OperationResult);
        }
        
        #endregion Methods SCRUD
        
        #region Methods Syncfusion

        // POST: OrderDetail/DataSource
        [HttpPost]
        public ActionResult DataSource(DataManager dataManager)
        {
            SyncfusionDataResult dataResult = new SyncfusionDataResult
            {
                result = new List<OrderDetailViewModel>()
            };

            ZOperationResult operationResult = new ZOperationResult();

            if (IsSearch(operationResult))
            {
                try
                {
                    SyncfusionGrid syncfusionGrid = new SyncfusionGrid(typeof(OrderDetail), Application.UnitOfWork.DBMS);
                    ArrayList args = new ArrayList();
                    string where = syncfusionGrid.ToLinqWhere(dataManager.Search, dataManager.Where, args);
                    string orderBy = syncfusionGrid.ToLinqOrderBy(dataManager.Sorted);        
                    int take = (dataManager.Skip == 0 && dataManager.Take == 0) ? AppDefaults.SyncfusionRecordsBySearch : dataManager.Take; // Excel Filtering
                    dataResult.result = ZViewModelHelper<OrderDetailViewModel, OrderDetail>.ToViewList(Application.Search(operationResult, where, args.ToArray(), orderBy, dataManager.Skip, take));
        
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

        // POST: OrderDetail/ExportToExcel
        [HttpPost]
        public void ExportToExcel(string gridModel)
        {
            if (IsExport())
            {
                ExportToExcel(gridModel, OrderDetailResources.EntitySingular + ".xlsx");
            }
        }

        // POST: OrderDetail/ExportToPdf
        [HttpPost]
        public void ExportToPdf(string gridModel)
        {
            if (IsExport())
            {
                ExportToPdf(gridModel, OrderDetailResources.EntitySingular + ".pdf");
            }
        }

        // POST: OrderDetail/ExportToWord
        [HttpPost]
        public void ExportToWord(string gridModel)
        {
            if (IsExport())
            {
                ExportToWord(gridModel, OrderDetailResources.EntitySingular + ".docx");
            }
        }
        
        #endregion Methods Syncfusion
    }
}