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
    public partial class RegionController : BaseMvcControllerSCRUDApplication<Region>
    {
        #region Methods

        public RegionController(INorthwindGenericApplication<Region> application)
    : base(application.AuthorizationManager)
        {
            Application = application;            
        }

        #endregion Methods

        #region Methods SCRUD

        // GET: Region
        // GET: Region/Index
        [HttpGet]
        public ActionResult Index(string operation = null)
        {
            RegionCollectionModel regionCollectionModel = new RegionCollectionModel(ActivityOperations, "Index", null, null, null, operation);

            try
            {
                if (IsIndex(regionCollectionModel.OperationResult))
                {
                    return ZView(regionCollectionModel);
                }
            }
            catch (Exception exception)
            {
                regionCollectionModel.OperationResult.ParseException(exception);
            }

            return ZViewOperationResult(regionCollectionModel.OperationResult);
        }        

        // GET & POST: Region/Search
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Search(string masterControllerAction = null, string masterEntity = null, string masterKey = null)
        {
            RegionCollectionModel regionCollectionModel = new RegionCollectionModel(ActivityOperations, "Search", masterControllerAction, masterEntity, masterKey);

            try
            {
                if (IsOperation(regionCollectionModel.OperationResult))
                {
                    return ZPartialView(regionCollectionModel);
                }
            }
            catch (Exception exception)
            {
                regionCollectionModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(regionCollectionModel.OperationResult);
        }

        // GET & POST: Region/Lookup
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Lookup(string text, string valueId, bool? required = false, List<LookupModelElement> elements = null, string query = null)
        {
            LookupModel lookupModel = new LookupModel(ActivityOperations, text, valueId, required, elements, query);

            try
            {
                if (IsSearch(lookupModel.OperationResult))
                {
                    return ZPartialView("_RegionLookup", lookupModel);
                }
            }
            catch (Exception exception)
            {
                lookupModel.OperationResult.ParseException(exception);
            }

            return null;
        }

        // GET: Region/Create
        [HttpGet]
        public ActionResult Create(string masterEntity = null, string masterKey = null)
        {
            RegionItemModel regionItemModel = new RegionItemModel(ActivityOperations, "Create", masterEntity, masterKey);

            try
            {
                if (IsCreate(regionItemModel.OperationResult))
                {
                    return ZPartialView("CRUD", regionItemModel);
                }            
            }
            catch (Exception exception)
            {
                regionItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(regionItemModel.OperationResult);
        }

        // POST: Region/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RegionItemModel regionItemModel)
        {
            try
            {
                if (IsCreate(regionItemModel.OperationResult))
                {
                    if (IsValid(regionItemModel.OperationResult, regionItemModel.Region))
                    {
                        Region region = (Region)regionItemModel.Region.ToData();
                        if (Application.Create(regionItemModel.OperationResult, region))
                        {
                            if (regionItemModel.IsSave)
                            {
                                Create2Update(regionItemModel.OperationResult);
                                return JsonResultSuccess(regionItemModel.OperationResult,
                                    Url.Action("Update", "Region", new { RegionId = region.RegionId }, Request.Url.Scheme));
                            }
                            else
                            {
                                return JsonResultSuccess(regionItemModel.OperationResult);
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                regionItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(regionItemModel.OperationResult);
        }

        // GET: Region/Read/1
        [HttpGet]
        public ActionResult Read(int regionId, string masterEntity = null, string masterKey = null)
        {
            RegionItemModel regionItemModel = new RegionItemModel(ActivityOperations, "Read", masterEntity, masterKey);
            
            try
            {
                if (IsRead(regionItemModel.OperationResult))
                {
                    Region region = Application.GetById(regionItemModel.OperationResult, new object[] { regionId }, true);
                    if (region != null)
                    {
                        regionItemModel.Region = new RegionViewModel(region);                    

                        return ZPartialView("CRUD", regionItemModel);
                    }
                }
            }
            catch (Exception exception)
            {
                regionItemModel.OperationResult.ParseException(exception);
            }            

            return JsonResultOperationResult(regionItemModel.OperationResult);
        }

        // GET: Region/Update/1
        [HttpGet]
        public ActionResult Update(int regionId, string masterEntity = null, string masterKey = null)
        {
            RegionItemModel regionItemModel = new RegionItemModel(ActivityOperations, "Update", masterEntity, masterKey);
            
            try
            {
                if (IsUpdate(regionItemModel.OperationResult))
                {            
                    Region region = Application.GetById(regionItemModel.OperationResult, new object[] { regionId }, true);
                    if (region != null)
                    {
                        regionItemModel.Region = new RegionViewModel(region);

                        return ZPartialView("CRUD", regionItemModel);
                    }
                }
            }
            catch (Exception exception)
            {
                regionItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(regionItemModel.OperationResult);
        }

        // POST: Region/Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(RegionItemModel regionItemModel)
        {
            try
            {
                if (IsUpdate(regionItemModel.OperationResult))
                {
                    if (IsValid(regionItemModel.OperationResult, regionItemModel.Region))
                    {
                        Region region = (Region)regionItemModel.Region.ToData();
                        if (Application.Update(regionItemModel.OperationResult, region))
                        {
                            if (regionItemModel.IsSave)
                            {
                                return JsonResultSuccess(regionItemModel.OperationResult,
                                    Url.Action("Update", "Region", new { RegionId = region.RegionId }, Request.Url.Scheme));
                            }
                            else
                            {
                                return JsonResultSuccess(regionItemModel.OperationResult);
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                regionItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(regionItemModel.OperationResult);
        }

        // GET: Region/Delete/1
        [HttpGet]
        public ActionResult Delete(int regionId, string masterEntity = null, string masterKey = null)
        {
            RegionItemModel regionItemModel = new RegionItemModel(ActivityOperations, "Delete", masterEntity, masterKey);
            
            try
            {
                if (IsDelete(regionItemModel.OperationResult))
                {            
                    Region region = Application.GetById(regionItemModel.OperationResult, new object[] { regionId }, true);
                    if (region != null)
                    {
                        regionItemModel.Region = new RegionViewModel(region);

                        return ZPartialView("CRUD", regionItemModel);
                    }
                }
            }
            catch (Exception exception)
            {
                regionItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(regionItemModel.OperationResult);
        }

        // POST: Region/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(RegionItemModel regionItemModel)
        {
            try
            {
                if (IsDelete(regionItemModel.OperationResult))
                {
                    if (Application.Delete(regionItemModel.OperationResult, (Region)regionItemModel.Region.ToData()))
                    {
                        return JsonResultSuccess(regionItemModel.OperationResult);
                    }
                }
            }
            catch (Exception exception)
            {
                regionItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(regionItemModel.OperationResult);
        }
        
        #endregion Methods SCRUD
        
        #region Methods Syncfusion

        // POST: Region/DataSource
        [HttpPost]
        public ActionResult DataSource(DataManager dataManager)
        {
            SyncfusionDataResult dataResult = new SyncfusionDataResult
            {
                result = new List<RegionViewModel>()
            };

            ZOperationResult operationResult = new ZOperationResult();

            if (IsSearch(operationResult))
            {
                try
                {
                    SyncfusionGrid syncfusionGrid = new SyncfusionGrid(typeof(Region), Application.UnitOfWork.DBMS);
                    ArrayList args = new ArrayList();
                    string where = syncfusionGrid.ToLinqWhere(dataManager.Search, dataManager.Where, args);
                    string orderBy = syncfusionGrid.ToLinqOrderBy(dataManager.Sorted);        
                    int take = (dataManager.Skip == 0 && dataManager.Take == 0) ? AppDefaults.SyncfusionRecordsBySearch : dataManager.Take; // Excel Filtering
                    dataResult.result = ZViewModelHelper<RegionViewModel, Region>.ToViewList(Application.Search(operationResult, where, args.ToArray(), orderBy, dataManager.Skip, take));
        
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

        // POST: Region/ExportToExcel
        [HttpPost]
        public void ExportToExcel(string gridModel)
        {
            if (IsExport())
            {
                ExportToExcel(gridModel, RegionResources.EntitySingular + ".xlsx");
            }
        }

        // POST: Region/ExportToPdf
        [HttpPost]
        public void ExportToPdf(string gridModel)
        {
            if (IsExport())
            {
                ExportToPdf(gridModel, RegionResources.EntitySingular + ".pdf");
            }
        }

        // POST: Region/ExportToWord
        [HttpPost]
        public void ExportToWord(string gridModel)
        {
            if (IsExport())
            {
                ExportToWord(gridModel, RegionResources.EntitySingular + ".docx");
            }
        }
        
        #endregion Methods Syncfusion
    }
}