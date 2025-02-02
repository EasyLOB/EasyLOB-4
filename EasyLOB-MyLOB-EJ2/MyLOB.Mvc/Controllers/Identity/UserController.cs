using EasyLOB.Identity;
using EasyLOB.Identity.Data;
using EasyLOB.Identity.Data.Resources;
using EasyLOB;
using EasyLOB.Data;
using EasyLOB.Mvc;
using Newtonsoft.Json;
using Syncfusion.EJ2.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Mvc;

namespace EasyLOB.Identity.Mvc
{
    public partial class UserController : BaseMvcControllerSCRUDApplication<User>
    {
        #region Methods

        //public UserController(IIdentityGenericApplication<User> application)
        //    : base(application.AuthorizationManager)
        //{
        //    Application = application;            
        //}

        #endregion Methods

        #region Methods SCRUD

        // GET: User
        // GET: User/Index
        [HttpGet]
        public ActionResult Index(string operation = null)
        {
            UserCollectionModel userCollectionModel = new UserCollectionModel(ActivityOperations, "Index", null, null, null, operation);

            try
            {
                if (IsIndex(userCollectionModel.OperationResult))
                {
                    return ZView(userCollectionModel);
                }
            }
            catch (Exception exception)
            {
                userCollectionModel.OperationResult.ParseException(exception);
            }

            return ZViewOperationResult(userCollectionModel.OperationResult);
        }        

        // GET & POST: User/Search
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Search(string masterControllerAction = null, string masterEntity = null, string masterKey = null)
        {
            UserCollectionModel userCollectionModel = new UserCollectionModel(ActivityOperations, "Search", masterControllerAction, masterEntity, masterKey);

            try
            {
                if (IsOperation(userCollectionModel.OperationResult))
                {
                    return ZPartialView(userCollectionModel);
                }
            }
            catch (Exception exception)
            {
                userCollectionModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(userCollectionModel.OperationResult);
        }

        // GET & POST: User/Lookup
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Lookup(string text, string valueId, bool? required = false, List<LookupModelElement> elements = null, string query = null)
        {
            LookupModel lookupModel = new LookupModel(ActivityOperations, text, valueId, required, elements, query);

            try
            {
                if (IsSearch(lookupModel.OperationResult))
                {
                    return ZPartialView("_UserLookup", lookupModel);
                }
            }
            catch (Exception exception)
            {
                lookupModel.OperationResult.ParseException(exception);
            }

            return null;
        }

        // GET: User/Create
        [HttpGet]
        public ActionResult Create(string masterEntity = null, string masterKey = null)
        {
            UserItemModel userItemModel = new UserItemModel(ActivityOperations, "Create", masterEntity, masterKey);

            try
            {
                if (IsCreate(userItemModel.OperationResult))
                {
                    return ZPartialView("CRUD", userItemModel);
                }            
            }
            catch (Exception exception)
            {
                userItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(userItemModel.OperationResult);
        }

        // POST: User/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(UserItemModel userItemModel)
        //{
        //    try
        //    {
        //        if (IsCreate(userItemModel.OperationResult))
        //        {
        //            if (IsValid(userItemModel.OperationResult, userItemModel.User))
        //            {
        //                User user = (User)userItemModel.User.ToData();
        //                if (Application.Create(userItemModel.OperationResult, user))
        //                {
        //                    if (userItemModel.IsSave)
        //                    {
        //                        Create2Update(userItemModel.OperationResult);
        //                        return JsonResultSuccess(userItemModel.OperationResult,
        //                            Url.Action("Update", "User", new { Id = user.Id }, Request.Url.Scheme));
        //                    }
        //                    else
        //                    {
        //                        return JsonResultSuccess(userItemModel.OperationResult);
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception exception)
        //    {
        //        userItemModel.OperationResult.ParseException(exception);
        //    }

        //    return JsonResultOperationResult(userItemModel.OperationResult);
        //}

        // GET: User/Read/1
        [HttpGet]
        public ActionResult Read(string id)
        {
            UserItemModel userItemModel = new UserItemModel(ActivityOperations, "Read");
            
            try
            {
                if (IsRead(userItemModel.OperationResult))
                {
                    User user = Application.GetById(userItemModel.OperationResult, new object[] { id }, true);
                    if (user != null)
                    {
                        userItemModel.User = new UserViewModel(user);                    

                        return ZPartialView("CRUD", userItemModel);
                    }
                }
            }
            catch (Exception exception)
            {
                userItemModel.OperationResult.ParseException(exception);
            }            

            return JsonResultOperationResult(userItemModel.OperationResult);
        }

        // GET: User/Update/1
        //[HttpGet]
        //public ActionResult Update(string id, string masterEntity = null, string masterKey = null)
        //{
        //    UserItemModel userItemModel = new UserItemModel(ActivityOperations, "Update", masterEntity, masterKey);
            
        //    try
        //    {
        //        if (IsUpdate(userItemModel.OperationResult))
        //        {            
        //            User user = Application.GetById(userItemModel.OperationResult, new object[] { id }, true);
        //            if (user != null)
        //            {
        //                userItemModel.User = new UserViewModel(user);

        //                return ZPartialView("CRUD", userItemModel);
        //            }
        //        }
        //    }
        //    catch (Exception exception)
        //    {
        //        userItemModel.OperationResult.ParseException(exception);
        //    }

        //    return JsonResultOperationResult(userItemModel.OperationResult);
        //}

        // POST: User/Update
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Update(UserItemModel userItemModel)
        //{
        //    try
        //    {
        //        if (IsUpdate(userItemModel.OperationResult))
        //        {
        //            if (IsValid(userItemModel.OperationResult, userItemModel.User))
        //            {
        //                User user = (User)userItemModel.User.ToData();
        //                if (Application.Update(userItemModel.OperationResult, user))
        //                {
        //                    if (userItemModel.IsSave)
        //                    {
        //                        return JsonResultSuccess(userItemModel.OperationResult,
        //                            Url.Action("Update", "User", new { Id = user.Id }, Request.Url.Scheme));
        //                    }
        //                    else
        //                    {
        //                        return JsonResultSuccess(userItemModel.OperationResult);
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception exception)
        //    {
        //        userItemModel.OperationResult.ParseException(exception);
        //    }

        //    return JsonResultOperationResult(userItemModel.OperationResult);
        //}

        // GET: User/Delete/1
        [HttpGet]
        public ActionResult Delete(string id, string masterEntity = null, string masterKey = null)
        {
            UserItemModel userItemModel = new UserItemModel(ActivityOperations, "Delete", masterEntity, masterKey);
            
            try
            {
                if (IsDelete(userItemModel.OperationResult))
                {            
                    User user = Application.GetById(userItemModel.OperationResult, new object[] { id }, true);
                    if (user != null)
                    {
                        userItemModel.User = new UserViewModel(user);

                        return ZPartialView("CRUD", userItemModel);
                    }
                }
            }
            catch (Exception exception)
            {
                userItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(userItemModel.OperationResult);
        }

        // POST: User/Delete
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(UserItemModel userItemModel)
        //{
        //    try
        //    {
        //        if (IsDelete(userItemModel.OperationResult))
        //        {
        //            if (Application.Delete(userItemModel.OperationResult, (User)userItemModel.User.ToData()))
        //            {
        //                return JsonResultSuccess(userItemModel.OperationResult);
        //            }
        //        }
        //    }
        //    catch (Exception exception)
        //    {
        //        userItemModel.OperationResult.ParseException(exception);
        //    }

        //    return JsonResultOperationResult(userItemModel.OperationResult);
        //}
        
        #endregion Methods SCRUD
        
        #region Methods Syncfusion

        // POST: User/DataSource
        [HttpPost]
        public ActionResult DataSource(DataManagerRequest dataManager)
        {
            SyncfusionDataResult dataResult = new SyncfusionDataResult
            {
                result = new List<UserViewModel>()
            };

            ZOperationResult operationResult = new ZOperationResult();

            if (IsSearch(operationResult))
            {
                try
                {
                    SyncfusionGrid syncfusionGrid = new SyncfusionGrid(typeof(User), Application.UnitOfWork.DBMS);
                    ArrayList args = new ArrayList();
                    string where = syncfusionGrid.ToLinqWhere(dataManager.Search, dataManager.Where, args);
                    string orderBy = syncfusionGrid.ToLinqOrderBy(dataManager.Sorted);        
                    int take = (dataManager.Skip == 0 && dataManager.Take == 0) ? AppDefaults.SyncfusionRecordsBySearch : dataManager.Take; // Excel Filtering
                    dataResult.result = ZViewModelHelper<UserViewModel, User>.ToViewList(Application.Search(operationResult, where, args.ToArray(), orderBy, dataManager.Skip, take));
        
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
        
        #endregion Methods Syncfusion
    }
}