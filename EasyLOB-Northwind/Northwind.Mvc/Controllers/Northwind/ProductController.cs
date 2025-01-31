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
    public partial class ProductController : BaseMvcControllerSCRUDApplication<Product>
    {
        #region Methods

        public ProductController(INorthwindGenericApplication<Product> application)
    : base(application.AuthorizationManager)
        {
            Application = application;            
        }

        #endregion Methods

        #region Methods SCRUD

        // GET: Product
        // GET: Product/Index
        [HttpGet]
        public ActionResult Index(string operation = null)
        {
            ProductCollectionModel productCollectionModel = new ProductCollectionModel(ActivityOperations, "Index", null, null, null, operation);

            try
            {
                if (IsIndex(productCollectionModel.OperationResult))
                {
                    return ZView(productCollectionModel);
                }
            }
            catch (Exception exception)
            {
                productCollectionModel.OperationResult.ParseException(exception);
            }

            return ZViewOperationResult(productCollectionModel.OperationResult);
        }        

        // GET & POST: Product/Search
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Search(string masterControllerAction = null, string masterEntity = null, string masterKey = null)
        {
            ProductCollectionModel productCollectionModel = new ProductCollectionModel(ActivityOperations, "Search", masterControllerAction, masterEntity, masterKey);

            try
            {
                if (IsOperation(productCollectionModel.OperationResult))
                {
                    return ZPartialView(productCollectionModel);
                }
            }
            catch (Exception exception)
            {
                productCollectionModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(productCollectionModel.OperationResult);
        }

        // GET & POST: Product/Lookup
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Lookup(string text, string valueId, bool? required = false, List<LookupModelElement> elements = null, string query = null)
        {
            LookupModel lookupModel = new LookupModel(ActivityOperations, text, valueId, required, elements, query);

            try
            {
                if (IsSearch(lookupModel.OperationResult))
                {
                    return ZPartialView("_ProductLookup", lookupModel);
                }
            }
            catch (Exception exception)
            {
                lookupModel.OperationResult.ParseException(exception);
            }

            return null;
        }

        // GET: Product/Create
        [HttpGet]
        public ActionResult Create(string masterEntity = null, string masterKey = null)
        {
            ProductItemModel productItemModel = new ProductItemModel(ActivityOperations, "Create", masterEntity, masterKey);

            try
            {
                if (IsCreate(productItemModel.OperationResult))
                {
                    return ZPartialView("CRUD", productItemModel);
                }            
            }
            catch (Exception exception)
            {
                productItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(productItemModel.OperationResult);
        }

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductItemModel productItemModel)
        {
            try
            {
                if (IsCreate(productItemModel.OperationResult))
                {
                    if (IsValid(productItemModel.OperationResult, productItemModel.Product))
                    {
                        Product product = (Product)productItemModel.Product.ToData();
                        if (Application.Create(productItemModel.OperationResult, product))
                        {
                            if (productItemModel.IsSave)
                            {
                                Create2Update(productItemModel.OperationResult);
                                return JsonResultSuccess(productItemModel.OperationResult,
                                    Url.Action("Update", "Product", new { ProductId = product.ProductId }, Request.Url.Scheme));
                            }
                            else
                            {
                                return JsonResultSuccess(productItemModel.OperationResult);
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                productItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(productItemModel.OperationResult);
        }

        // GET: Product/Read/1
        [HttpGet]
        public ActionResult Read(int productId, string masterEntity = null, string masterKey = null)
        {
            ProductItemModel productItemModel = new ProductItemModel(ActivityOperations, "Read", masterEntity, masterKey);
            
            try
            {
                if (IsRead(productItemModel.OperationResult))
                {
                    Product product = Application.GetById(productItemModel.OperationResult, new object[] { productId }, true);
                    if (product != null)
                    {
                        productItemModel.Product = new ProductViewModel(product);                    

                        return ZPartialView("CRUD", productItemModel);
                    }
                }
            }
            catch (Exception exception)
            {
                productItemModel.OperationResult.ParseException(exception);
            }            

            return JsonResultOperationResult(productItemModel.OperationResult);
        }

        // GET: Product/Update/1
        [HttpGet]
        public ActionResult Update(int productId, string masterEntity = null, string masterKey = null)
        {
            ProductItemModel productItemModel = new ProductItemModel(ActivityOperations, "Update", masterEntity, masterKey);
            
            try
            {
                if (IsUpdate(productItemModel.OperationResult))
                {            
                    Product product = Application.GetById(productItemModel.OperationResult, new object[] { productId }, true);
                    if (product != null)
                    {
                        productItemModel.Product = new ProductViewModel(product);

                        return ZPartialView("CRUD", productItemModel);
                    }
                }
            }
            catch (Exception exception)
            {
                productItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(productItemModel.OperationResult);
        }

        // POST: Product/Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(ProductItemModel productItemModel)
        {
            try
            {
                if (IsUpdate(productItemModel.OperationResult))
                {
                    if (IsValid(productItemModel.OperationResult, productItemModel.Product))
                    {
                        Product product = (Product)productItemModel.Product.ToData();
                        if (Application.Update(productItemModel.OperationResult, product))
                        {
                            if (productItemModel.IsSave)
                            {
                                return JsonResultSuccess(productItemModel.OperationResult,
                                    Url.Action("Update", "Product", new { ProductId = product.ProductId }, Request.Url.Scheme));
                            }
                            else
                            {
                                return JsonResultSuccess(productItemModel.OperationResult);
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                productItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(productItemModel.OperationResult);
        }

        // GET: Product/Delete/1
        [HttpGet]
        public ActionResult Delete(int productId, string masterEntity = null, string masterKey = null)
        {
            ProductItemModel productItemModel = new ProductItemModel(ActivityOperations, "Delete", masterEntity, masterKey);
            
            try
            {
                if (IsDelete(productItemModel.OperationResult))
                {            
                    Product product = Application.GetById(productItemModel.OperationResult, new object[] { productId }, true);
                    if (product != null)
                    {
                        productItemModel.Product = new ProductViewModel(product);

                        return ZPartialView("CRUD", productItemModel);
                    }
                }
            }
            catch (Exception exception)
            {
                productItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(productItemModel.OperationResult);
        }

        // POST: Product/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ProductItemModel productItemModel)
        {
            try
            {
                if (IsDelete(productItemModel.OperationResult))
                {
                    if (Application.Delete(productItemModel.OperationResult, (Product)productItemModel.Product.ToData()))
                    {
                        return JsonResultSuccess(productItemModel.OperationResult);
                    }
                }
            }
            catch (Exception exception)
            {
                productItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(productItemModel.OperationResult);
        }
        
        #endregion Methods SCRUD
        
        #region Methods Syncfusion

        // POST: Product/DataSource
        [HttpPost]
        public ActionResult DataSource(DataManager dataManager)
        {
            SyncfusionDataResult dataResult = new SyncfusionDataResult
            {
                result = new List<ProductViewModel>()
            };

            ZOperationResult operationResult = new ZOperationResult();

            if (IsSearch(operationResult))
            {
                try
                {
                    SyncfusionGrid syncfusionGrid = new SyncfusionGrid(typeof(Product), Application.UnitOfWork.DBMS);
                    ArrayList args = new ArrayList();
                    string where = syncfusionGrid.ToLinqWhere(dataManager.Search, dataManager.Where, args);
                    string orderBy = syncfusionGrid.ToLinqOrderBy(dataManager.Sorted);        
                    int take = (dataManager.Skip == 0 && dataManager.Take == 0) ? AppDefaults.SyncfusionRecordsBySearch : dataManager.Take; // Excel Filtering
                    dataResult.result = ZViewModelHelper<ProductViewModel, Product>.ToViewList(Application.Search(operationResult, where, args.ToArray(), orderBy, dataManager.Skip, take));
        
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

        // POST: Product/ExportToExcel
        [HttpPost]
        public void ExportToExcel(string gridModel)
        {
            if (IsExport())
            {
                ExportToExcel(gridModel, ProductResources.EntitySingular + ".xlsx");
            }
        }

        // POST: Product/ExportToPdf
        [HttpPost]
        public void ExportToPdf(string gridModel)
        {
            if (IsExport())
            {
                ExportToPdf(gridModel, ProductResources.EntitySingular + ".pdf");
            }
        }

        // POST: Product/ExportToWord
        [HttpPost]
        public void ExportToWord(string gridModel)
        {
            if (IsExport())
            {
                ExportToWord(gridModel, ProductResources.EntitySingular + ".docx");
            }
        }
        
        #endregion Methods Syncfusion
    }
}