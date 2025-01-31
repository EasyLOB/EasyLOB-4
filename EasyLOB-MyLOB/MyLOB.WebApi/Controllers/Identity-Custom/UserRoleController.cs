using EasyLOB.Identity.Data;
using EasyLOB.Mvc;
using System;
using System.Web.Mvc;

namespace EasyLOB.Identity.Mvc
{
    public partial class UserRoleController : BaseMvcControllerSCRUDApplication<UserRole>
    {
        #region Properties

        protected IIdentityManager IdentityManager { get; }

        #endregion Properties

        #region Methods

        public UserRoleController(IIdentityGenericApplication<UserRole> application,
            IIdentityManager identityManager)
            : base(application.AuthorizationManager)
        {
            Application = application;
            IdentityManager = identityManager;
        }

        #endregion Methods

        #region Methods SCRUD

        // POST: UserRole/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserRoleItemModel userRoleItemModel)
        {
            try
            {
                if (IsCreate(userRoleItemModel.OperationResult))
                {
                    if (IsValid(userRoleItemModel.OperationResult, userRoleItemModel.UserRole))
                    {
                        Role role = Application.UnitOfWork.GetRepository<Role>()
                            .GetById(userRoleItemModel.UserRole.RoleId);
                        if (role != null)
                        {
                            if (IdentityManager.AddUserToRole(userRoleItemModel.OperationResult,
                                userRoleItemModel.UserRole.UserId,
                                role.Name))
                            {
                                return JsonResultSuccess(userRoleItemModel.OperationResult);
                            }
                        }
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(UserRoleItemModel userRoleItemModel)
        {
            return JsonResultOperationResult(userRoleItemModel.OperationResult);
        }

        // POST: UserRole/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(UserRoleItemModel userRoleItemModel)
        {
            try
            {
                if (IsDelete(userRoleItemModel.OperationResult))
                {
                    Role role = Application.UnitOfWork.GetRepository<Role>()
                        .GetById(userRoleItemModel.UserRole.RoleId);
                    if (role != null)
                    {

                        if (IdentityManager.RemoveUserFromRole(userRoleItemModel.OperationResult,
                            userRoleItemModel.UserRole.UserId,
                            role.Name))
                        {
                            return JsonResultSuccess(userRoleItemModel.OperationResult);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                userRoleItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(userRoleItemModel.OperationResult);
        }
        
        #endregion Methods SCRUD
    }
}