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
    public partial class UserRoleController : BaseMvcControllerSCRUDApplication<UserRole>
    {
        #region Methods

        //public UserRoleController(IIdentityGenericApplication<UserRole> application)
        //    : base(application.AuthorizationManager)
        //{
        //    Application = application;            
        //}

        #endregion Methods

        #region Methods SCRUD

        // GET: UserRole
        // GET: UserRole/Index
        [HttpGet]
        public ActionResult Index(string operation = null)
        {
            UserRoleCollectionModel userRoleCollectionModel = new UserRoleCollectionModel(ActivityOperations, "Index", null, null, null, operation);

            try
            {
                if (IsIndex(userRoleCollectionModel.OperationResult))
                {
                    return ZView(userRoleCollectionModel);
                }
            }
            catch (Exception exception)
            {
                userRoleCollectionModel.OperationResult.ParseException(exception);
            }

            return ZViewOperationResult(userRoleCollectionModel.OperationResult);
        }        

        // GET & POST: UserRole/Search
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Search(string masterControllerAction = null, string masterEntity = null, string masterKey = null)
        {
            UserRoleCollectionModel userRoleCollectionModel = new UserRoleCollectionModel(ActivityOperations, "Search", masterControllerAction, masterEntity, masterKey);

            try
            {
                if (IsOperation(userRoleCollectionModel.OperationResult))
                {
                    return ZPartialView(userRoleCollectionModel);
                }
            }
            catch (Exception exception)
            {
                userRoleCollectionModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(userRoleCollectionModel.OperationResult);
        }

        // GET & POST: UserRole/Lookup
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Lookup(string text, string valueId, bool? required = false, List<LookupModelElement> elements = null, string query = null)
        {
            LookupModel lookupModel = new LookupModel(ActivityOperations, text, valueId, required, elements, query);

            try
            {
                if (IsSearch(lookupModel.OperationResult))
                {
                    return ZPartialView("_UserRoleLookup", lookupModel);
                }
            }
            catch (Exception exception)
            {
                lookupModel.OperationResult.ParseException(exception);
            }

            return null;
        }

        // GET: UserRole/Create
        [HttpGet]
        public ActionResult Create(string masterEntity = null, string masterKey = null)
        {
            UserRoleItemModel userRoleItemModel = new UserRoleItemModel(ActivityOperations, "Create", masterEntity, masterKey);

            try
            {
                if (IsCreate(userRoleItemModel.OperationResult))
                {
                    return ZPartialView("CRUD", userRoleItemModel);
                }            
            }
            catch (Exception exception)
            {
                userRoleItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(userRoleItemModel.OperationResult);
        }

        // POST: UserRole/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(UserRoleItemModel userRoleItemModel)
        //{
        //    try
        //    {
        //        if (IsCreate(userRoleItemModel.OperationResult))
        //        {
        //            if (IsValid(userRoleItemModel.OperationResult, userRoleItemModel.UserRole))
        //            {
        //                UserRole userRole = (UserRole)userRoleItemModel.UserRole.ToData();
        //                if (Application.Create(userRoleItemModel.OperationResult, userRole))
        //                {
        //                    if (userRoleItemModel.IsSave)
        //                    {
        //                        Create2Update(userRoleItemModel.OperationResult);
        //                        return JsonResultSuccess(userRoleItemModel.OperationResult,
        //                            Url.Action("Update", "UserRole", new { UserId = userRole.UserId, RoleId = userRole.RoleId }, Request.Url.Scheme));
        //                    }
        //                    else
        //                    {
        //                        return JsonResultSuccess(userRoleItemModel.OperationResult);
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception exception)
        //    {
        //        userRoleItemModel.OperationResult.ParseException(exception);
        //    }

        //    return JsonResultOperationResult(userRoleItemModel.OperationResult);
        //}

        // GET: UserRole/Read/1
        [HttpGet]
        public ActionResult Read(string userId, string roleId, string masterEntity = null, string masterKey = null)
        {
            UserRoleItemModel userRoleItemModel = new UserRoleItemModel(ActivityOperations, "Read", masterEntity, masterKey);
            
            try
            {
                if (IsRead(userRoleItemModel.OperationResult))
                {
                    UserRole userRole = Application.GetById(userRoleItemModel.OperationResult, new object[] { userId, roleId }, true);
                    if (userRole != null)
                    {
                        userRoleItemModel.UserRole = new UserRoleViewModel(userRole);                    

                        return ZPartialView("CRUD", userRoleItemModel);
                    }
                }
            }
            catch (Exception exception)
            {
                userRoleItemModel.OperationResult.ParseException(exception);
            }            

            return JsonResultOperationResult(userRoleItemModel.OperationResult);
        }

        // GET: UserRole/Update/1
        [HttpGet]
        public ActionResult Update(string userId, string roleId, string masterEntity = null, string masterKey = null)
        {
            UserRoleItemModel userRoleItemModel = new UserRoleItemModel(ActivityOperations, "Update", masterEntity, masterKey);
            
            try
            {
                if (IsUpdate(userRoleItemModel.OperationResult))
                {            
                    UserRole userRole = Application.GetById(userRoleItemModel.OperationResult, new object[] { userId, roleId }, true);
                    if (userRole != null)
                    {
                        userRoleItemModel.UserRole = new UserRoleViewModel(userRole);

                        return ZPartialView("CRUD", userRoleItemModel);
                    }
                }
            }
            catch (Exception exception)
            {
                userRoleItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(userRoleItemModel.OperationResult);
        }

        // POST: UserRole/Update
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Update(UserRoleItemModel userRoleItemModel)
        //{
        //    try
        //    {
        //        if (IsUpdate(userRoleItemModel.OperationResult))
        //        {
        //            if (IsValid(userRoleItemModel.OperationResult, userRoleItemModel.UserRole))
        //            {
        //                UserRole userRole = (UserRole)userRoleItemModel.UserRole.ToData();
        //                if (Application.Update(userRoleItemModel.OperationResult, userRole))
        //                {
        //                    if (userRoleItemModel.IsSave)
        //                    {
        //                        return JsonResultSuccess(userRoleItemModel.OperationResult,
        //                            Url.Action("Update", "UserRole", new { UserId = userRole.UserId, RoleId = userRole.RoleId }, Request.Url.Scheme));
        //                    }
        //                    else
        //                    {
        //                        return JsonResultSuccess(userRoleItemModel.OperationResult);
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception exception)
        //    {
        //        userRoleItemModel.OperationResult.ParseException(exception);
        //    }

        //    return JsonResultOperationResult(userRoleItemModel.OperationResult);
        //}

        // GET: UserRole/Delete/1
        [HttpGet]
        public ActionResult Delete(string userId, string roleId, string masterEntity = null, string masterKey = null)
        {
            UserRoleItemModel userRoleItemModel = new UserRoleItemModel(ActivityOperations, "Delete", masterEntity, masterKey);
            
            try
            {
                if (IsDelete(userRoleItemModel.OperationResult))
                {            
                    UserRole userRole = Application.GetById(userRoleItemModel.OperationResult, new object[] { userId, roleId }, true);
                    if (userRole != null)
                    {
                        userRoleItemModel.UserRole = new UserRoleViewModel(userRole);

                        return ZPartialView("CRUD", userRoleItemModel);
                    }
                }
            }
            catch (Exception exception)
            {
                userRoleItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(userRoleItemModel.OperationResult);
        }

        // POST: UserRole/Delete
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(UserRoleItemModel userRoleItemModel)
        //{
        //    try
        //    {
        //        if (IsDelete(userRoleItemModel.OperationResult))
        //        {
        //            if (Application.Delete(userRoleItemModel.OperationResult, (UserRole)userRoleItemModel.UserRole.ToData()))
        //            {
        //                return JsonResultSuccess(userRoleItemModel.OperationResult);
        //            }
        //        }
        //    }
        //    catch (Exception exception)
        //    {
        //        userRoleItemModel.OperationResult.ParseException(exception);
        //    }

        //    return JsonResultOperationResult(userRoleItemModel.OperationResult);
        //}
        
        #endregion Methods SCRUD
        
        #region Methods Syncfusion

        // POST: UserRole/DataSource
        [HttpPost]
        public ActionResult DataSource(DataManager dataManager)
        {
            SyncfusionDataResult dataResult = new SyncfusionDataResult
            {
                result = new List<UserRoleViewModel>()
            };

            ZOperationResult operationResult = new ZOperationResult();

            if (IsSearch(operationResult))
            {
                try
                {
                    SyncfusionGrid syncfusionGrid = new SyncfusionGrid(typeof(UserRole), Application.UnitOfWork.DBMS);
                    ArrayList args = new ArrayList();
                    string where = syncfusionGrid.ToLinqWhere(dataManager.Search, dataManager.Where, args);
                    string orderBy = syncfusionGrid.ToLinqOrderBy(dataManager.Sorted);        
                    int take = (dataManager.Skip == 0 && dataManager.Take == 0) ? AppDefaults.SyncfusionRecordsBySearch : dataManager.Take; // Excel Filtering
                    dataResult.result = ZViewModelHelper<UserRoleViewModel, UserRole>.ToViewList(Application.Search(operationResult, where, args.ToArray(), orderBy, dataManager.Skip, take));
        
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

        // POST: UserRole/ExportToExcel
        [HttpPost]
        public void ExportToExcel(string gridModel)
        {
            if (IsExport())
            {
                ExportToExcel(gridModel, UserRoleResources.EntitySingular + ".xlsx");
            }
        }

        // POST: UserRole/ExportToPdf
        [HttpPost]
        public void ExportToPdf(string gridModel)
        {
            if (IsExport())
            {
                ExportToPdf(gridModel, UserRoleResources.EntitySingular + ".pdf");
            }
        }

        // POST: UserRole/ExportToWord
        [HttpPost]
        public void ExportToWord(string gridModel)
        {
            if (IsExport())
            {
                ExportToWord(gridModel, UserRoleResources.EntitySingular + ".docx");
            }
        }
        
        #endregion Methods Syncfusion
    }
}