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
    public partial class ShipperController : BaseMvcControllerSCRUDApplication<Shipper>
    {
        #region Methods

        public ShipperController(INorthwindGenericApplication<Shipper> application)
    : base(application.AuthorizationManager)
        {
            Application = application;            
        }

        #endregion Methods

        #region Methods SCRUD

        // GET: Shipper
        // GET: Shipper/Index
        [HttpGet]
        public ActionResult Index(string operation = null)
        {
            ShipperCollectionModel shipperCollectionModel = new ShipperCollectionModel(ActivityOperations, "Index", null, null, null, operation);

            try
            {
                if (IsIndex(shipperCollectionModel.OperationResult))
                {
                    return ZView(shipperCollectionModel);
                }
            }
            catch (Exception exception)
            {
                shipperCollectionModel.OperationResult.ParseException(exception);
            }

            return ZViewOperationResult(shipperCollectionModel.OperationResult);
        }        

        // GET & POST: Shipper/Search
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Search(string masterControllerAction = null, string masterEntity = null, string masterKey = null)
        {
            ShipperCollectionModel shipperCollectionModel = new ShipperCollectionModel(ActivityOperations, "Search", masterControllerAction, masterEntity, masterKey);

            try
            {
                if (IsOperation(shipperCollectionModel.OperationResult))
                {
                    return ZPartialView(shipperCollectionModel);
                }
            }
            catch (Exception exception)
            {
                shipperCollectionModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(shipperCollectionModel.OperationResult);
        }

        // GET & POST: Shipper/Lookup
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Lookup(string text, string valueId, bool? required = false, List<LookupModelElement> elements = null, string query = null)
        {
            LookupModel lookupModel = new LookupModel(ActivityOperations, text, valueId, required, elements, query);

            try
            {
                if (IsSearch(lookupModel.OperationResult))
                {
                    return ZPartialView("_ShipperLookup", lookupModel);
                }
            }
            catch (Exception exception)
            {
                lookupModel.OperationResult.ParseException(exception);
            }

            return null;
        }

        // GET: Shipper/Create
        [HttpGet]
        public ActionResult Create(string masterEntity = null, string masterKey = null)
        {
            ShipperItemModel shipperItemModel = new ShipperItemModel(ActivityOperations, "Create", masterEntity, masterKey);

            try
            {
                if (IsCreate(shipperItemModel.OperationResult))
                {
                    return ZPartialView("CRUD", shipperItemModel);
                }            
            }
            catch (Exception exception)
            {
                shipperItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(shipperItemModel.OperationResult);
        }

        // POST: Shipper/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ShipperItemModel shipperItemModel)
        {
            try
            {
                if (IsCreate(shipperItemModel.OperationResult))
                {
                    if (IsValid(shipperItemModel.OperationResult, shipperItemModel.Shipper))
                    {
                        Shipper shipper = (Shipper)shipperItemModel.Shipper.ToData();
                        if (Application.Create(shipperItemModel.OperationResult, shipper))
                        {
                            if (shipperItemModel.IsSave)
                            {
                                Create2Update(shipperItemModel.OperationResult);
                                return JsonResultSuccess(shipperItemModel.OperationResult,
                                    Url.Action("Update", "Shipper", new { ShipperId = shipper.ShipperId }, Request.Url.Scheme));
                            }
                            else
                            {
                                return JsonResultSuccess(shipperItemModel.OperationResult);
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                shipperItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(shipperItemModel.OperationResult);
        }

        // GET: Shipper/Read/1
        [HttpGet]
        public ActionResult Read(int shipperId, string masterEntity = null, string masterKey = null)
        {
            ShipperItemModel shipperItemModel = new ShipperItemModel(ActivityOperations, "Read", masterEntity, masterKey);
            
            try
            {
                if (IsRead(shipperItemModel.OperationResult))
                {
                    Shipper shipper = Application.GetById(shipperItemModel.OperationResult, new object[] { shipperId }, true);
                    if (shipper != null)
                    {
                        shipperItemModel.Shipper = new ShipperViewModel(shipper);                    

                        return ZPartialView("CRUD", shipperItemModel);
                    }
                }
            }
            catch (Exception exception)
            {
                shipperItemModel.OperationResult.ParseException(exception);
            }            

            return JsonResultOperationResult(shipperItemModel.OperationResult);
        }

        // GET: Shipper/Update/1
        [HttpGet]
        public ActionResult Update(int shipperId, string masterEntity = null, string masterKey = null)
        {
            ShipperItemModel shipperItemModel = new ShipperItemModel(ActivityOperations, "Update", masterEntity, masterKey);
            
            try
            {
                if (IsUpdate(shipperItemModel.OperationResult))
                {            
                    Shipper shipper = Application.GetById(shipperItemModel.OperationResult, new object[] { shipperId }, true);
                    if (shipper != null)
                    {
                        shipperItemModel.Shipper = new ShipperViewModel(shipper);

                        return ZPartialView("CRUD", shipperItemModel);
                    }
                }
            }
            catch (Exception exception)
            {
                shipperItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(shipperItemModel.OperationResult);
        }

        // POST: Shipper/Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(ShipperItemModel shipperItemModel)
        {
            try
            {
                if (IsUpdate(shipperItemModel.OperationResult))
                {
                    if (IsValid(shipperItemModel.OperationResult, shipperItemModel.Shipper))
                    {
                        Shipper shipper = (Shipper)shipperItemModel.Shipper.ToData();
                        if (Application.Update(shipperItemModel.OperationResult, shipper))
                        {
                            if (shipperItemModel.IsSave)
                            {
                                return JsonResultSuccess(shipperItemModel.OperationResult,
                                    Url.Action("Update", "Shipper", new { ShipperId = shipper.ShipperId }, Request.Url.Scheme));
                            }
                            else
                            {
                                return JsonResultSuccess(shipperItemModel.OperationResult);
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                shipperItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(shipperItemModel.OperationResult);
        }

        // GET: Shipper/Delete/1
        [HttpGet]
        public ActionResult Delete(int shipperId, string masterEntity = null, string masterKey = null)
        {
            ShipperItemModel shipperItemModel = new ShipperItemModel(ActivityOperations, "Delete", masterEntity, masterKey);
            
            try
            {
                if (IsDelete(shipperItemModel.OperationResult))
                {            
                    Shipper shipper = Application.GetById(shipperItemModel.OperationResult, new object[] { shipperId }, true);
                    if (shipper != null)
                    {
                        shipperItemModel.Shipper = new ShipperViewModel(shipper);

                        return ZPartialView("CRUD", shipperItemModel);
                    }
                }
            }
            catch (Exception exception)
            {
                shipperItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(shipperItemModel.OperationResult);
        }

        // POST: Shipper/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ShipperItemModel shipperItemModel)
        {
            try
            {
                if (IsDelete(shipperItemModel.OperationResult))
                {
                    if (Application.Delete(shipperItemModel.OperationResult, (Shipper)shipperItemModel.Shipper.ToData()))
                    {
                        return JsonResultSuccess(shipperItemModel.OperationResult);
                    }
                }
            }
            catch (Exception exception)
            {
                shipperItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(shipperItemModel.OperationResult);
        }
        
        #endregion Methods SCRUD
        
        #region Methods Syncfusion

        // POST: Shipper/DataSource
        [HttpPost]
        public ActionResult DataSource(DataManager dataManager)
        {
            SyncfusionDataResult dataResult = new SyncfusionDataResult
            {
                result = new List<ShipperViewModel>()
            };

            ZOperationResult operationResult = new ZOperationResult();

            if (IsSearch(operationResult))
            {
                try
                {
                    SyncfusionGrid syncfusionGrid = new SyncfusionGrid(typeof(Shipper), Application.UnitOfWork.DBMS);
                    ArrayList args = new ArrayList();
                    string where = syncfusionGrid.ToLinqWhere(dataManager.Search, dataManager.Where, args);
                    string orderBy = syncfusionGrid.ToLinqOrderBy(dataManager.Sorted);        
                    int take = (dataManager.Skip == 0 && dataManager.Take == 0) ? AppDefaults.SyncfusionRecordsBySearch : dataManager.Take; // Excel Filtering
                    dataResult.result = ZViewModelHelper<ShipperViewModel, Shipper>.ToViewList(Application.Search(operationResult, where, args.ToArray(), orderBy, dataManager.Skip, take));
        
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

        // POST: Shipper/ExportToExcel
        [HttpPost]
        public void ExportToExcel(string gridModel)
        {
            if (IsExport())
            {
                ExportToExcel(gridModel, ShipperResources.EntitySingular + ".xlsx");
            }
        }

        // POST: Shipper/ExportToPdf
        [HttpPost]
        public void ExportToPdf(string gridModel)
        {
            if (IsExport())
            {
                ExportToPdf(gridModel, ShipperResources.EntitySingular + ".pdf");
            }
        }

        // POST: Shipper/ExportToWord
        [HttpPost]
        public void ExportToWord(string gridModel)
        {
            if (IsExport())
            {
                ExportToWord(gridModel, ShipperResources.EntitySingular + ".docx");
            }
        }
        
        #endregion Methods Syncfusion
    }
}