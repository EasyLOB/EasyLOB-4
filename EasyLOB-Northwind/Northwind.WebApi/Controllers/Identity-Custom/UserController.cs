using EasyLOB.Identity.Data;
using EasyLOB.Mvc;
using System;
using System.Web.Mvc;

namespace EasyLOB.Identity.Mvc
{
    public partial class UserController : BaseMvcControllerSCRUDApplication<User>
    {
        #region Properties

        protected IIdentityManager IdentityManager { get; }

        #endregion Properties

        #region Methods

        public UserController(IIdentityGenericApplication<User> application,
            IIdentityManager identityManager)
            : base(application.AuthorizationManager)
        {
            Application = application;
            IdentityManager = identityManager;
        }

        #endregion Methods

        #region Methods SCRUD

        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserItemModel userItemModel)
        {
            try
            {
                if (IsCreate(userItemModel.OperationResult))
                {
                    if (IsValid(userItemModel.OperationResult, userItemModel.User))
                    {
                        bool result = IdentityManager.CreateUser(userItemModel.OperationResult,
                            userItemModel.User.UserName,
                            userItemModel.User.Email,
                            userItemModel.User.PasswordHash,
                            new string[] { });
                        if (result)
                        {
                            if (userItemModel.IsSave)
                            {
                                Create2Update(userItemModel.OperationResult);
                                ApplicationUser user = IdentityManager.GetUserByName(userItemModel.User.UserName);
                                if (user != null)
                                {
                                    return JsonResultSuccess(userItemModel.OperationResult,
                                        Url.Action("Update", "User", new { Id = user.Id }, Request.Url.Scheme));
                                }
                            }
                            else
                            {
                                return JsonResultSuccess(userItemModel.OperationResult);
                            }
                        }
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
        [HttpGet]
        public ActionResult Update(string id, string masterEntity = null, string masterKey = null)
        {
            UserItemModel userItemModel = new UserItemModel(ActivityOperations, "Update", masterEntity, masterKey);

            try
            {
                if (IsUpdate(userItemModel.OperationResult))
                {
                    User user = Application.GetById(userItemModel.OperationResult, new object[] { id }, true);
                    if (user != null)
                    {
                        userItemModel.User = new UserViewModel(user);

                        //if (userItemModel.User.LockoutEndDateUtc != null)
                        //{
                        //    userItemModel.User.LockoutEndDateUtc =
                        //        (userItemModel.User.LockoutEndDateUtc ?? DateTime.Now.AddYears(1)).ToLocalTime();
                        //}

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

        // POST: User/Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(UserItemModel userItemModel)
        {
            try
            {
                if (IsUpdate(userItemModel.OperationResult))
                {
                    bool result = IdentityManager.UpdateUser(userItemModel.OperationResult,
                        userItemModel.User.Id, userItemModel.User.Email, userItemModel.User.LockoutEndDateUtc, userItemModel.User.LockoutEnabled);
                    if (result)
                    {
                        return JsonResultSuccess(userItemModel.OperationResult);
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(UserItemModel userItemModel)
        {
            try
            {
                if (IsDelete(userItemModel.OperationResult))
                {
                    bool result = IdentityManager.DeleteUser(userItemModel.OperationResult,
                        userItemModel.User.Id);
                    if (result)
                    {
                        return JsonResultSuccess(userItemModel.OperationResult);
                    }
                }
            }
            catch (Exception exception)
            {
                userItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(userItemModel.OperationResult);
        }
        
        #endregion Methods SCRUD
    }
}