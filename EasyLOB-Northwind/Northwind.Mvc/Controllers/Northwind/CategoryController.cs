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
    public partial class CategoryController : BaseMvcControllerSCRUDApplication<Category>
    {
        #region Methods

        public CategoryController(INorthwindGenericApplication<Category> application)
    : base(application.AuthorizationManager)
        {
            Application = application;            
        }

        #endregion Methods

        #region Methods SCRUD

        // GET: Category
        // GET: Category/Index
        [HttpGet]
        public ActionResult Index(string operation = null)
        {
            CategoryCollectionModel categoryCollectionModel = new CategoryCollectionModel(ActivityOperations, "Index", null, null, null, operation);

            try
            {
                if (IsIndex(categoryCollectionModel.OperationResult))
                {
                    return ZView(categoryCollectionModel);
                }
            }
            catch (Exception exception)
            {
                categoryCollectionModel.OperationResult.ParseException(exception);
            }

            return ZViewOperationResult(categoryCollectionModel.OperationResult);
        }        

        // GET & POST: Category/Search
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Search(string masterControllerAction = null, string masterEntity = null, string masterKey = null)
        {
            CategoryCollectionModel categoryCollectionModel = new CategoryCollectionModel(ActivityOperations, "Search", masterControllerAction, masterEntity, masterKey);

            try
            {
                if (IsOperation(categoryCollectionModel.OperationResult))
                {
                    return ZPartialView(categoryCollectionModel);
                }
            }
            catch (Exception exception)
            {
                categoryCollectionModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(categoryCollectionModel.OperationResult);
        }

        // GET & POST: Category/Lookup
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Lookup(string text, string valueId, bool? required = false, List<LookupModelElement> elements = null, string query = null)
        {
            LookupModel lookupModel = new LookupModel(ActivityOperations, text, valueId, required, elements, query);

            try
            {
                if (IsSearch(lookupModel.OperationResult))
                {
                    return ZPartialView("_CategoryLookup", lookupModel);
                }
            }
            catch (Exception exception)
            {
                lookupModel.OperationResult.ParseException(exception);
            }

            return null;
        }

        // GET: Category/Create
        [HttpGet]
        public ActionResult Create(string masterEntity = null, string masterKey = null)
        {
            CategoryItemModel categoryItemModel = new CategoryItemModel(ActivityOperations, "Create", masterEntity, masterKey);

            try
            {
                if (IsCreate(categoryItemModel.OperationResult))
                {
                    return ZPartialView("CRUD", categoryItemModel);
                }            
            }
            catch (Exception exception)
            {
                categoryItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(categoryItemModel.OperationResult);
        }

        // POST: Category/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryItemModel categoryItemModel)
        {
            try
            {
                if (IsCreate(categoryItemModel.OperationResult))
                {
                    if (IsValid(categoryItemModel.OperationResult, categoryItemModel.Category))
                    {
                        Category category = (Category)categoryItemModel.Category.ToData();
                        if (Application.Create(categoryItemModel.OperationResult, category))
                        {
                            if (categoryItemModel.IsSave)
                            {
                                Create2Update(categoryItemModel.OperationResult);
                                return JsonResultSuccess(categoryItemModel.OperationResult,
                                    Url.Action("Update", "Category", new { CategoryId = category.CategoryId }, Request.Url.Scheme));
                            }
                            else
                            {
                                return JsonResultSuccess(categoryItemModel.OperationResult);
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                categoryItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(categoryItemModel.OperationResult);
        }

        // GET: Category/Read/1
        [HttpGet]
        public ActionResult Read(int categoryId, string masterEntity = null, string masterKey = null)
        {
            CategoryItemModel categoryItemModel = new CategoryItemModel(ActivityOperations, "Read", masterEntity, masterKey);
            
            try
            {
                if (IsRead(categoryItemModel.OperationResult))
                {
                    Category category = Application.GetById(categoryItemModel.OperationResult, new object[] { categoryId }, true);
                    if (category != null)
                    {
                        categoryItemModel.Category = new CategoryViewModel(category);                    

                        return ZPartialView("CRUD", categoryItemModel);
                    }
                }
            }
            catch (Exception exception)
            {
                categoryItemModel.OperationResult.ParseException(exception);
            }            

            return JsonResultOperationResult(categoryItemModel.OperationResult);
        }

        // GET: Category/Update/1
        [HttpGet]
        public ActionResult Update(int categoryId, string masterEntity = null, string masterKey = null)
        {
            CategoryItemModel categoryItemModel = new CategoryItemModel(ActivityOperations, "Update", masterEntity, masterKey);
            
            try
            {
                if (IsUpdate(categoryItemModel.OperationResult))
                {            
                    Category category = Application.GetById(categoryItemModel.OperationResult, new object[] { categoryId }, true);
                    if (category != null)
                    {
                        categoryItemModel.Category = new CategoryViewModel(category);

                        return ZPartialView("CRUD", categoryItemModel);
                    }
                }
            }
            catch (Exception exception)
            {
                categoryItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(categoryItemModel.OperationResult);
        }

        // POST: Category/Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(CategoryItemModel categoryItemModel)
        {
            try
            {
                if (IsUpdate(categoryItemModel.OperationResult))
                {
                    if (IsValid(categoryItemModel.OperationResult, categoryItemModel.Category))
                    {
                        Category category = (Category)categoryItemModel.Category.ToData();
                        if (Application.Update(categoryItemModel.OperationResult, category))
                        {
                            if (categoryItemModel.IsSave)
                            {
                                return JsonResultSuccess(categoryItemModel.OperationResult,
                                    Url.Action("Update", "Category", new { CategoryId = category.CategoryId }, Request.Url.Scheme));
                            }
                            else
                            {
                                return JsonResultSuccess(categoryItemModel.OperationResult);
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                categoryItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(categoryItemModel.OperationResult);
        }

        // GET: Category/Delete/1
        [HttpGet]
        public ActionResult Delete(int categoryId, string masterEntity = null, string masterKey = null)
        {
            CategoryItemModel categoryItemModel = new CategoryItemModel(ActivityOperations, "Delete", masterEntity, masterKey);
            
            try
            {
                if (IsDelete(categoryItemModel.OperationResult))
                {            
                    Category category = Application.GetById(categoryItemModel.OperationResult, new object[] { categoryId }, true);
                    if (category != null)
                    {
                        categoryItemModel.Category = new CategoryViewModel(category);

                        return ZPartialView("CRUD", categoryItemModel);
                    }
                }
            }
            catch (Exception exception)
            {
                categoryItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(categoryItemModel.OperationResult);
        }

        // POST: Category/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(CategoryItemModel categoryItemModel)
        {
            try
            {
                if (IsDelete(categoryItemModel.OperationResult))
                {
                    if (Application.Delete(categoryItemModel.OperationResult, (Category)categoryItemModel.Category.ToData()))
                    {
                        return JsonResultSuccess(categoryItemModel.OperationResult);
                    }
                }
            }
            catch (Exception exception)
            {
                categoryItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(categoryItemModel.OperationResult);
        }
        
        #endregion Methods SCRUD
        
        #region Methods Syncfusion

        // POST: Category/DataSource
        [HttpPost]
        public ActionResult DataSource(DataManager dataManager)
        {
            SyncfusionDataResult dataResult = new SyncfusionDataResult
            {
                result = new List<CategoryViewModel>()
            };

            ZOperationResult operationResult = new ZOperationResult();

            if (IsSearch(operationResult))
            {
                try
                {
                    SyncfusionGrid syncfusionGrid = new SyncfusionGrid(typeof(Category), Application.UnitOfWork.DBMS);
                    ArrayList args = new ArrayList();
                    string where = syncfusionGrid.ToLinqWhere(dataManager.Search, dataManager.Where, args);
                    string orderBy = syncfusionGrid.ToLinqOrderBy(dataManager.Sorted);        
                    int take = (dataManager.Skip == 0 && dataManager.Take == 0) ? AppDefaults.SyncfusionRecordsBySearch : dataManager.Take; // Excel Filtering
                    dataResult.result = ZViewModelHelper<CategoryViewModel, Category>.ToViewList(Application.Search(operationResult, where, args.ToArray(), orderBy, dataManager.Skip, take));
        
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

        // POST: Category/ExportToExcel
        [HttpPost]
        public void ExportToExcel(string gridModel)
        {
            if (IsExport())
            {
                ExportToExcel(gridModel, CategoryResources.EntitySingular + ".xlsx");
            }
        }

        // POST: Category/ExportToPdf
        [HttpPost]
        public void ExportToPdf(string gridModel)
        {
            if (IsExport())
            {
                ExportToPdf(gridModel, CategoryResources.EntitySingular + ".pdf");
            }
        }

        // POST: Category/ExportToWord
        [HttpPost]
        public void ExportToWord(string gridModel)
        {
            if (IsExport())
            {
                ExportToWord(gridModel, CategoryResources.EntitySingular + ".docx");
            }
        }
        
        #endregion Methods Syncfusion
    }
}