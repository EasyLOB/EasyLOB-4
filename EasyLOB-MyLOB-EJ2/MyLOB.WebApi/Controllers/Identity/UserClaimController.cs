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
    public partial class UserClaimController : BaseMvcControllerSCRUDApplication<UserClaim>
    {
        #region Methods

        public UserClaimController(IIdentityGenericApplication<UserClaim> application)
            : base(application.AuthorizationManager)
        {
            Application = application;            
        }

        #endregion Methods

        #region Methods SCRUD

        // GET: UserClaim
        // GET: UserClaim/Index
        [HttpGet]
        public ActionResult Index(string operation = null)
        {
            UserClaimCollectionModel userClaimCollectionModel = new UserClaimCollectionModel(ActivityOperations, "Index", null, null, null, operation);

            try
            {
                if (IsIndex(userClaimCollectionModel.OperationResult))
                {
                    return ZView(userClaimCollectionModel);
                }
            }
            catch (Exception exception)
            {
                userClaimCollectionModel.OperationResult.ParseException(exception);
            }

            return ZViewOperationResult(userClaimCollectionModel.OperationResult);
        }        

        // GET & POST: UserClaim/Search
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Search(string masterControllerAction = null, string masterUserId = null)
        {
            UserClaimCollectionModel userClaimCollectionModel = new UserClaimCollectionModel(ActivityOperations, "Search", masterControllerAction, masterUserId);

            try
            {
                if (IsOperation(userClaimCollectionModel.OperationResult))
                {
                    return ZPartialView(userClaimCollectionModel);
                }
            }
            catch (Exception exception)
            {
                userClaimCollectionModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(userClaimCollectionModel.OperationResult);
        }

        // GET & POST: UserClaim/Lookup
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Lookup(string text, string valueId, bool? required = false, List<LookupModelElement> elements = null, string query = null)
        {
            LookupModel lookupModel = new LookupModel(ActivityOperations, text, valueId, required, elements, query);

            try
            {
                if (IsSearch(lookupModel.OperationResult))
                {
                    return ZPartialView("_UserClaimLookup", lookupModel);
                }
            }
            catch (Exception exception)
            {
                lookupModel.OperationResult.ParseException(exception);
            }

            return null;
        }

        // GET: UserClaim/Create
        [HttpGet]
        public ActionResult Create(string masterEntity = null, string masterKey = null)
        {
            UserClaimItemModel userClaimItemModel = new UserClaimItemModel(ActivityOperations, "Create", masterEntity, masterKey);

            try
            {
                if (IsCreate(userClaimItemModel.OperationResult))
                {
                    return ZPartialView("CRUD", userClaimItemModel);
                }            
            }
            catch (Exception exception)
            {
                userClaimItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(userClaimItemModel.OperationResult);
        }

        // POST: UserClaim/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserClaimItemModel userClaimItemModel)
        {
            try
            {
                if (IsCreate(userClaimItemModel.OperationResult))
                {
                    if (IsValid(userClaimItemModel.OperationResult, userClaimItemModel.UserClaim))
                    {
                        UserClaim userClaim = (UserClaim)userClaimItemModel.UserClaim.ToData();
                        if (Application.Create(userClaimItemModel.OperationResult, userClaim))
                        {
                            if (userClaimItemModel.IsSave)
                            {
                                Create2Update(userClaimItemModel.OperationResult);
                                return JsonResultSuccess(userClaimItemModel.OperationResult,
                                    Url.Action("Update", "UserClaim", new { Id = userClaim.Id }, Request.Url.Scheme));
                            }
                            else
                            {
                                return JsonResultSuccess(userClaimItemModel.OperationResult);
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                userClaimItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(userClaimItemModel.OperationResult);
        }

        // GET: UserClaim/Read/1
        [HttpGet]
        public ActionResult Read(int id, string masterEntity = null, string masterKey = null)
        {
            UserClaimItemModel userClaimItemModel = new UserClaimItemModel(ActivityOperations, "Read", masterEntity, masterKey);
            
            try
            {
                if (IsRead(userClaimItemModel.OperationResult))
                {
                    UserClaim userClaim = Application.GetById(userClaimItemModel.OperationResult, new object[] { id }, true);
                    if (userClaim != null)
                    {
                        userClaimItemModel.UserClaim = new UserClaimViewModel(userClaim);                    

                        return ZPartialView("CRUD", userClaimItemModel);
                    }
                }
            }
            catch (Exception exception)
            {
                userClaimItemModel.OperationResult.ParseException(exception);
            }            

            return JsonResultOperationResult(userClaimItemModel.OperationResult);
        }

        // GET: UserClaim/Update/1
        [HttpGet]
        public ActionResult Update(int id, string masterEntity = null, string masterKey = null)
        {
            UserClaimItemModel userClaimItemModel = new UserClaimItemModel(ActivityOperations, "Update", masterEntity, masterKey);
            
            try
            {
                if (IsUpdate(userClaimItemModel.OperationResult))
                {            
                    UserClaim userClaim = Application.GetById(userClaimItemModel.OperationResult, new object[] { id }, true);
                    if (userClaim != null)
                    {
                        userClaimItemModel.UserClaim = new UserClaimViewModel(userClaim);

                        return ZPartialView("CRUD", userClaimItemModel);
                    }
                }
            }
            catch (Exception exception)
            {
                userClaimItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(userClaimItemModel.OperationResult);
        }

        // POST: UserClaim/Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(UserClaimItemModel userClaimItemModel)
        {
            try
            {
                if (IsUpdate(userClaimItemModel.OperationResult))
                {
                    if (IsValid(userClaimItemModel.OperationResult, userClaimItemModel.UserClaim))
                    {
                        UserClaim userClaim = (UserClaim)userClaimItemModel.UserClaim.ToData();
                        if (Application.Update(userClaimItemModel.OperationResult, userClaim))
                        {
                            if (userClaimItemModel.IsSave)
                            {
                                return JsonResultSuccess(userClaimItemModel.OperationResult,
                                    Url.Action("Update", "UserClaim", new { Id = userClaim.Id }, Request.Url.Scheme));
                            }
                            else
                            {
                                return JsonResultSuccess(userClaimItemModel.OperationResult);
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                userClaimItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(userClaimItemModel.OperationResult);
        }

        // GET: UserClaim/Delete/1
        [HttpGet]
        public ActionResult Delete(int id, string masterEntity = null, string masterKey = null)
        {
            UserClaimItemModel userClaimItemModel = new UserClaimItemModel(ActivityOperations, "Delete", masterEntity, masterKey);
            
            try
            {
                if (IsDelete(userClaimItemModel.OperationResult))
                {            
                    UserClaim userClaim = Application.GetById(userClaimItemModel.OperationResult, new object[] { id }, true);
                    if (userClaim != null)
                    {
                        userClaimItemModel.UserClaim = new UserClaimViewModel(userClaim);

                        return ZPartialView("CRUD", userClaimItemModel);
                    }
                }
            }
            catch (Exception exception)
            {
                userClaimItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(userClaimItemModel.OperationResult);
        }

        // POST: UserClaim/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(UserClaimItemModel userClaimItemModel)
        {
            try
            {
                if (IsDelete(userClaimItemModel.OperationResult))
                {
                    if (Application.Delete(userClaimItemModel.OperationResult, (UserClaim)userClaimItemModel.UserClaim.ToData()))
                    {
                        return JsonResultSuccess(userClaimItemModel.OperationResult);
                    }
                }
            }
            catch (Exception exception)
            {
                userClaimItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(userClaimItemModel.OperationResult);
        }
        
        #endregion Methods SCRUD
        
        #region Methods Syncfusion

        // POST: UserClaim/DataSource
        [HttpPost]
        public ActionResult DataSource(DataManagerRequest dataManager)
        {
            SyncfusionDataResult dataResult = new SyncfusionDataResult
            {
                result = new List<UserClaimViewModel>()
            };

            ZOperationResult operationResult = new ZOperationResult();

            if (IsSearch(operationResult))
            {
                try
                {
                    SyncfusionGrid syncfusionGrid = new SyncfusionGrid(typeof(UserClaim), Application.UnitOfWork.DBMS);
                    ArrayList args = new ArrayList();
                    string where = syncfusionGrid.ToLinqWhere(dataManager.Search, dataManager.Where, args);
                    string orderBy = syncfusionGrid.ToLinqOrderBy(dataManager.Sorted);        
                    int take = (dataManager.Skip == 0 && dataManager.Take == 0) ? AppDefaults.SyncfusionRecordsBySearch : dataManager.Take; // Excel Filtering
                    dataResult.result = ZViewModelHelper<UserClaimViewModel, UserClaim>.ToViewList(Application.Search(operationResult, where, args.ToArray(), orderBy, dataManager.Skip, take));
        
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

        // POST: UserClaim/ExportToExcel
        [HttpPost]
        public void ExportToExcel(string gridModel)
        {
            if (IsExport())
            {
                ExportToExcel(gridModel, UserClaimResources.EntitySingular + ".xlsx");
            }
        }

        // POST: UserClaim/ExportToPdf
        [HttpPost]
        public void ExportToPdf(string gridModel)
        {
            if (IsExport())
            {
                ExportToPdf(gridModel, UserClaimResources.EntitySingular + ".pdf");
            }
        }

        // POST: UserClaim/ExportToWord
        [HttpPost]
        public void ExportToWord(string gridModel)
        {
            if (IsExport())
            {
                ExportToWord(gridModel, UserClaimResources.EntitySingular + ".docx");
            }
        }
        
        #endregion Methods Syncfusion
    }
}