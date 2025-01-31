using EasyLOB.Identity;
using EasyLOB.Identity.Data;
using EasyLOB.Identity.Data.Resources;
using EasyLOB;
using EasyLOB.Data;
using EasyLOB.Mvc;
using Newtonsoft.Json;
using Syncfusion.JavaScript;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Mvc;

namespace EasyLOB.Identity.Mvc
{
    public partial class RoleController : BaseMvcControllerSCRUDApplication<Role>
    {
        #region Methods

        //public RoleController(IIdentityGenericApplication<Role> application)
        //    : base(application.AuthorizationManager)
        //{
        //    Application = application;            
        //}

        #endregion Methods

        #region Methods SCRUD

        // GET: Role
        // GET: Role/Index
        [HttpGet]
        public ActionResult Index(string operation = null)
        {
            RoleCollectionModel roleCollectionModel = new RoleCollectionModel(ActivityOperations, "Index", null, null, null, operation);

            try
            {
                if (IsIndex(roleCollectionModel.OperationResult))
                {
                    return ZView(roleCollectionModel);
                }
            }
            catch (Exception exception)
            {
                roleCollectionModel.OperationResult.ParseException(exception);
            }

            return ZViewOperationResult(roleCollectionModel.OperationResult);
        }        

        // GET & POST: Role/Search
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Search(string masterControllerAction = null, string masterEntity = null, string masterKey = null)
        {
            RoleCollectionModel roleCollectionModel = new RoleCollectionModel(ActivityOperations, "Search", masterControllerAction, masterEntity, masterKey);

            try
            {
                if (IsOperation(roleCollectionModel.OperationResult))
                {
                    return ZPartialView(roleCollectionModel);
                }
            }
            catch (Exception exception)
            {
                roleCollectionModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(roleCollectionModel.OperationResult);
        }

        // GET & POST: Role/Lookup
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Lookup(string text, string valueId, bool? required = false, List<LookupModelElement> elements = null, string query = null)
        {
            LookupModel lookupModel = new LookupModel(ActivityOperations, text, valueId, required, elements, query);

            try
            {
                if (IsSearch(lookupModel.OperationResult))
                {
                    return ZPartialView("_RoleLookup", lookupModel);
                }
            }
            catch (Exception exception)
            {
                lookupModel.OperationResult.ParseException(exception);
            }

            return null;
        }

        // GET: Role/Create
        [HttpGet]
        public ActionResult Create(string masterEntity = null, string masterKey = null)
        {
            RoleItemModel roleItemModel = new RoleItemModel(ActivityOperations, "Create", masterEntity, masterKey);

            try
            {
                if (IsCreate(roleItemModel.OperationResult))
                {
                    return ZPartialView("CRUD", roleItemModel);
                }            
            }
            catch (Exception exception)
            {
                roleItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(roleItemModel.OperationResult);
        }

        // POST: Role/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(RoleItemModel roleItemModel)
        //{
        //    try
        //    {
        //        if (IsCreate(roleItemModel.OperationResult))
        //        {
        //            if (IsValid(roleItemModel.OperationResult, roleItemModel.Role))
        //            {
        //                Role role = (Role)roleItemModel.Role.ToData();
        //                if (Application.Create(roleItemModel.OperationResult, role))
        //                {
        //                    if (roleItemModel.IsSave)
        //                    {
        //                        Create2Update(roleItemModel.OperationResult);
        //                        return JsonResultSuccess(roleItemModel.OperationResult,
        //                            Url.Action("Update", "Role", new { Id = role.Id }, Request.Url.Scheme));
        //                    }
        //                    else
        //                    {
        //                        return JsonResultSuccess(roleItemModel.OperationResult);
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception exception)
        //    {
        //        roleItemModel.OperationResult.ParseException(exception);
        //    }

        //    return JsonResultOperationResult(roleItemModel.OperationResult);
        //}

        // GET: Role/Read/1
        [HttpGet]
        public ActionResult Read(string id)
        {
            RoleItemModel roleItemModel = new RoleItemModel(ActivityOperations, "Read");
            
            try
            {
                if (IsRead(roleItemModel.OperationResult))
                {
                    Role role = Application.GetById(roleItemModel.OperationResult, new object[] { id }, true);
                    if (role != null)
                    {
                        roleItemModel.Role = new RoleViewModel(role);                    

                        return ZPartialView("CRUD", roleItemModel);
                    }
                }
            }
            catch (Exception exception)
            {
                roleItemModel.OperationResult.ParseException(exception);
            }            

            return JsonResultOperationResult(roleItemModel.OperationResult);
        }

        // GET: Role/Update/1
        [HttpGet]
        public ActionResult Update(string id, string masterEntity = null, string masterKey = null)
        {
            RoleItemModel roleItemModel = new RoleItemModel(ActivityOperations, "Update", masterEntity, masterKey);
            
            try
            {
                if (IsUpdate(roleItemModel.OperationResult))
                {            
                    Role role = Application.GetById(roleItemModel.OperationResult, new object[] { id }, true);
                    if (role != null)
                    {
                        roleItemModel.Role = new RoleViewModel(role);

                        return ZPartialView("CRUD", roleItemModel);
                    }
                }
            }
            catch (Exception exception)
            {
                roleItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(roleItemModel.OperationResult);
        }

        // POST: Role/Update
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Update(RoleItemModel roleItemModel)
        //{
        //    try
        //    {
        //        if (IsUpdate(roleItemModel.OperationResult))
        //        {
        //            if (IsValid(roleItemModel.OperationResult, roleItemModel.Role))
        //            {
        //                Role role = (Role)roleItemModel.Role.ToData();
        //                if (Application.Update(roleItemModel.OperationResult, role))
        //                {
        //                    if (roleItemModel.IsSave)
        //                    {
        //                        return JsonResultSuccess(roleItemModel.OperationResult,
        //                            Url.Action("Update", "Role", new { Id = role.Id }, Request.Url.Scheme));
        //                    }
        //                    else
        //                    {
        //                        return JsonResultSuccess(roleItemModel.OperationResult);
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception exception)
        //    {
        //        roleItemModel.OperationResult.ParseException(exception);
        //    }

        //    return JsonResultOperationResult(roleItemModel.OperationResult);
        //}

        // GET: Role/Delete/1
        [HttpGet]
        public ActionResult Delete(string id, string masterEntity = null, string masterKey = null)
        {
            RoleItemModel roleItemModel = new RoleItemModel(ActivityOperations, "Delete", masterEntity, masterKey);
            
            try
            {
                if (IsDelete(roleItemModel.OperationResult))
                {            
                    Role role = Application.GetById(roleItemModel.OperationResult, new object[] { id }, true);
                    if (role != null)
                    {
                        roleItemModel.Role = new RoleViewModel(role);

                        return ZPartialView("CRUD", roleItemModel);
                    }
                }
            }
            catch (Exception exception)
            {
                roleItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(roleItemModel.OperationResult);
        }

        // POST: Role/Delete
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(RoleItemModel roleItemModel)
        //{
        //    try
        //    {
        //        if (IsDelete(roleItemModel.OperationResult))
        //        {
        //            if (Application.Delete(roleItemModel.OperationResult, (Role)roleItemModel.Role.ToData()))
        //            {
        //                return JsonResultSuccess(roleItemModel.OperationResult);
        //            }
        //        }
        //    }
        //    catch (Exception exception)
        //    {
        //        roleItemModel.OperationResult.ParseException(exception);
        //    }

        //    return JsonResultOperationResult(roleItemModel.OperationResult);
        //}
        
        #endregion Methods SCRUD
        
        #region Methods Syncfusion

        // POST: Role/DataSource
        [HttpPost]
        public ActionResult DataSource(DataManager dataManager)
        {
            SyncfusionDataResult dataResult = new SyncfusionDataResult
            {
                result = new List<RoleViewModel>()
            };

            ZOperationResult operationResult = new ZOperationResult();

            if (IsSearch(operationResult))
            {
                try
                {
                    SyncfusionGrid syncfusionGrid = new SyncfusionGrid(typeof(Role), Application.UnitOfWork.DBMS);
                    ArrayList args = new ArrayList();
                    string where = syncfusionGrid.ToLinqWhere(dataManager.Search, dataManager.Where, args);
                    string orderBy = syncfusionGrid.ToLinqOrderBy(dataManager.Sorted);        
                    int take = (dataManager.Skip == 0 && dataManager.Take == 0) ? AppDefaults.SyncfusionRecordsBySearch : dataManager.Take; // Excel Filtering
                    dataResult.result = ZViewModelHelper<RoleViewModel, Role>.ToViewList(Application.Search(operationResult, where, args.ToArray(), orderBy, dataManager.Skip, take));
        
                    if (dataManager.RequiresCounts)
                    {
                        dataResult.count = Application.Count(operationResult, where, args.ToArray());
                    }
                }
                catch (Exception exception)
                {
                    operationResult.ParseException(exception);
                }

                if (!operationResult.Ok)
                {
                    operationResult.ThrowException();
                }
            }

            return Json(JsonConvert.SerializeObject(dataResult), JsonRequestBehavior.AllowGet);
        } 

        // POST: Role/ExportToExcel
        [HttpPost]
        public void ExportToExcel(string gridModel)
        {
            if (IsExport())
            {
                ExportToExcel(gridModel, RoleResources.EntitySingular + ".xlsx");
            }
        }

        // POST: Role/ExportToPdf
        [HttpPost]
        public void ExportToPdf(string gridModel)
        {
            if (IsExport())
            {
                ExportToPdf(gridModel, RoleResources.EntitySingular + ".pdf");
            }
        }

        // POST: Role/ExportToWord
        [HttpPost]
        public void ExportToWord(string gridModel)
        {
            if (IsExport())
            {
                ExportToWord(gridModel, RoleResources.EntitySingular + ".docx");
            }
        }
        
        #endregion Methods Syncfusion
    }
}