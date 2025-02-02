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
    public partial class UserLoginController : BaseMvcControllerSCRUDApplication<UserLogin>
    {
        #region Methods

        public UserLoginController(IIdentityGenericApplication<UserLogin> application)
            : base(application.AuthorizationManager)
        {
            Application = application;            
        }

        #endregion Methods

        #region Methods SCRUD

        // GET: UserLogin
        // GET: UserLogin/Index
        [HttpGet]
        public ActionResult Index(string operation = null)
        {
            UserLoginCollectionModel userLoginCollectionModel = new UserLoginCollectionModel(ActivityOperations, "Index", null, null, null, operation);

            try
            {
                if (IsIndex(userLoginCollectionModel.OperationResult))
                {
                    return ZView(userLoginCollectionModel);
                }
            }
            catch (Exception exception)
            {
                userLoginCollectionModel.OperationResult.ParseException(exception);
            }

            return ZViewOperationResult(userLoginCollectionModel.OperationResult);
        }        

        // GET & POST: UserLogin/Search
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Search(string masterControllerAction = null, string masterEntity = null, string masterKey = null)
        {
            UserLoginCollectionModel userLoginCollectionModel = new UserLoginCollectionModel(ActivityOperations, "Search", masterControllerAction, masterEntity, masterKey);

            try
            {
                if (IsOperation(userLoginCollectionModel.OperationResult))
                {
                    return ZPartialView(userLoginCollectionModel);
                }
            }
            catch (Exception exception)
            {
                userLoginCollectionModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(userLoginCollectionModel.OperationResult);
        }

        // GET & POST: UserLogin/Lookup
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Lookup(string text, string valueId, bool? required = false, List<LookupModelElement> elements = null, string query = null)
        {
            LookupModel lookupModel = new LookupModel(ActivityOperations, text, valueId, required, elements, query);

            try
            {
                if (IsSearch(lookupModel.OperationResult))
                {
                    return ZPartialView("_UserLoginLookup", lookupModel);
                }
            }
            catch (Exception exception)
            {
                lookupModel.OperationResult.ParseException(exception);
            }

            return null;
        }

        // GET: UserLogin/Create
        [HttpGet]
        public ActionResult Create(string masterEntity = null, string masterKey = null)
        {
            UserLoginItemModel userLoginItemModel = new UserLoginItemModel(ActivityOperations, "Create", masterEntity, masterKey);

            try
            {
                if (IsCreate(userLoginItemModel.OperationResult))
                {
                    return ZPartialView("CRUD", userLoginItemModel);
                }            
            }
            catch (Exception exception)
            {
                userLoginItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(userLoginItemModel.OperationResult);
        }

        // POST: UserLogin/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserLoginItemModel userLoginItemModel)
        {
            try
            {
                if (IsCreate(userLoginItemModel.OperationResult))
                {
                    if (IsValid(userLoginItemModel.OperationResult, userLoginItemModel.UserLogin))
                    {
                        UserLogin userLogin = (UserLogin)userLoginItemModel.UserLogin.ToData();
                        if (Application.Create(userLoginItemModel.OperationResult, userLogin))
                        {
                            if (userLoginItemModel.IsSave)
                            {
                                Create2Update(userLoginItemModel.OperationResult);
                                return JsonResultSuccess(userLoginItemModel.OperationResult,
                                    Url.Action("Update", "UserLogin", new { LoginProvider = userLogin.LoginProvider, ProviderKey = userLogin.ProviderKey, UserId = userLogin.UserId }, Request.Url.Scheme));
                            }
                            else
                            {
                                return JsonResultSuccess(userLoginItemModel.OperationResult);
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                userLoginItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(userLoginItemModel.OperationResult);
        }

        // GET: UserLogin/Read/1
        [HttpGet]
        public ActionResult Read(string loginProvider, string providerKey, string userId, string masterEntity = null, string masterKey = null)
        {
            UserLoginItemModel userLoginItemModel = new UserLoginItemModel(ActivityOperations, "Read", masterEntity, masterKey);
            
            try
            {
                if (IsRead(userLoginItemModel.OperationResult))
                {
                    UserLogin userLogin = Application.GetById(userLoginItemModel.OperationResult, new object[] { loginProvider, providerKey, userId }, true);
                    if (userLogin != null)
                    {
                        userLoginItemModel.UserLogin = new UserLoginViewModel(userLogin);                    

                        return ZPartialView("CRUD", userLoginItemModel);
                    }
                }
            }
            catch (Exception exception)
            {
                userLoginItemModel.OperationResult.ParseException(exception);
            }            

            return JsonResultOperationResult(userLoginItemModel.OperationResult);
        }

        // GET: UserLogin/Update/1
        [HttpGet]
        public ActionResult Update(string loginProvider, string providerKey, string userId, string masterEntity = null, string masterKey = null)
        {
            UserLoginItemModel userLoginItemModel = new UserLoginItemModel(ActivityOperations, "Update", masterEntity, masterKey);
            
            try
            {
                if (IsUpdate(userLoginItemModel.OperationResult))
                {            
                    UserLogin userLogin = Application.GetById(userLoginItemModel.OperationResult, new object[] { loginProvider, providerKey, userId }, true);
                    if (userLogin != null)
                    {
                        userLoginItemModel.UserLogin = new UserLoginViewModel(userLogin);

                        return ZPartialView("CRUD", userLoginItemModel);
                    }
                }
            }
            catch (Exception exception)
            {
                userLoginItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(userLoginItemModel.OperationResult);
        }

        // POST: UserLogin/Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(UserLoginItemModel userLoginItemModel)
        {
            try
            {
                if (IsUpdate(userLoginItemModel.OperationResult))
                {
                    if (IsValid(userLoginItemModel.OperationResult, userLoginItemModel.UserLogin))
                    {
                        UserLogin userLogin = (UserLogin)userLoginItemModel.UserLogin.ToData();
                        if (Application.Update(userLoginItemModel.OperationResult, userLogin))
                        {
                            if (userLoginItemModel.IsSave)
                            {
                                return JsonResultSuccess(userLoginItemModel.OperationResult,
                                    Url.Action("Update", "UserLogin", new { LoginProvider = userLogin.LoginProvider, ProviderKey = userLogin.ProviderKey, UserId = userLogin.UserId }, Request.Url.Scheme));
                            }
                            else
                            {
                                return JsonResultSuccess(userLoginItemModel.OperationResult);
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                userLoginItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(userLoginItemModel.OperationResult);
        }

        // GET: UserLogin/Delete/1
        [HttpGet]
        public ActionResult Delete(string loginProvider, string providerKey, string userId, string masterEntity = null, string masterKey = null)
        {
            UserLoginItemModel userLoginItemModel = new UserLoginItemModel(ActivityOperations, "Delete", masterEntity, masterKey);
            
            try
            {
                if (IsDelete(userLoginItemModel.OperationResult))
                {            
                    UserLogin userLogin = Application.GetById(userLoginItemModel.OperationResult, new object[] { loginProvider, providerKey, userId }, true);
                    if (userLogin != null)
                    {
                        userLoginItemModel.UserLogin = new UserLoginViewModel(userLogin);

                        return ZPartialView("CRUD", userLoginItemModel);
                    }
                }
            }
            catch (Exception exception)
            {
                userLoginItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(userLoginItemModel.OperationResult);
        }

        // POST: UserLogin/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(UserLoginItemModel userLoginItemModel)
        {
            try
            {
                if (IsDelete(userLoginItemModel.OperationResult))
                {
                    if (Application.Delete(userLoginItemModel.OperationResult, (UserLogin)userLoginItemModel.UserLogin.ToData()))
                    {
                        return JsonResultSuccess(userLoginItemModel.OperationResult);
                    }
                }
            }
            catch (Exception exception)
            {
                userLoginItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(userLoginItemModel.OperationResult);
        }
        
        #endregion Methods SCRUD
        
        #region Methods Syncfusion

        // POST: UserLogin/DataSource
        [HttpPost]
        public ActionResult DataSource(DataManagerRequest dataManager)
        {
            SyncfusionDataResult dataResult = new SyncfusionDataResult
            {
                result = new List<UserLoginViewModel>()
            };

            ZOperationResult operationResult = new ZOperationResult();

            if (IsSearch(operationResult))
            {
                try
                {
                    SyncfusionGrid syncfusionGrid = new SyncfusionGrid(typeof(UserLogin), Application.UnitOfWork.DBMS);
                    ArrayList args = new ArrayList();
                    string where = syncfusionGrid.ToLinqWhere(dataManager.Search, dataManager.Where, args);
                    string orderBy = syncfusionGrid.ToLinqOrderBy(dataManager.Sorted);        
                    int take = (dataManager.Skip == 0 && dataManager.Take == 0) ? AppDefaults.SyncfusionRecordsBySearch : dataManager.Take; // Excel Filtering
                    dataResult.result = ZViewModelHelper<UserLoginViewModel, UserLogin>.ToViewList(Application.Search(operationResult, where, args.ToArray(), orderBy, dataManager.Skip, take));
        
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