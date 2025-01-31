using EasyLOB.Identity.Data;
using EasyLOB.Mvc;
using System;
using System.Web.Mvc;

namespace EasyLOB.Identity.Mvc
{
    public partial class RoleController : BaseMvcControllerSCRUDApplication<Role>
    {
        #region Properties

        protected IIdentityManager IdentityManager { get; }

        #endregion Properties

        #region Methods

        public RoleController(IIdentityGenericApplication<Role> application,
            IIdentityManager identityManager)
            : base(application.AuthorizationManager)
        {
            Application = application;
            IdentityManager = identityManager;
        }

        #endregion Methods

        #region Methods SCRUD

        // POST: Role/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RoleItemModel roleItemModel)
        {
            try
            {
                if (IsCreate(roleItemModel.OperationResult))
                {
                    if (IsValid(roleItemModel.OperationResult, roleItemModel.Role))
                    {
                        bool result = IdentityManager.CreateRole(roleItemModel.OperationResult,
                            roleItemModel.Role.Name);
                        if (result)
                        {
                            if (roleItemModel.IsSave)
                            {
                                Create2Update(roleItemModel.OperationResult);
                                ApplicationRole role = IdentityManager.GetRoleByName(roleItemModel.Role.Name);
                                if (role != null)
                                {
                                    return JsonResultSuccess(roleItemModel.OperationResult,
                                        Url.Action("Update", "Role", new { Id = role.Id }, Request.Url.Scheme));
                                }
                            }
                            else
                            {
                                return JsonResultSuccess(roleItemModel.OperationResult);
                            }
                        }
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(RoleItemModel roleItemModel)
        {
            try
            {
                if (IsUpdate(roleItemModel.OperationResult))
                {
                    bool result = IdentityManager.UpdateRole(roleItemModel.OperationResult,
                        roleItemModel.Role.Id, roleItemModel.Role.Name);
                    if (result)
                    {
                        return JsonResultSuccess(roleItemModel.OperationResult);
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(RoleItemModel roleItemModel)
        {
            try
            {
                if (IsDelete(roleItemModel.OperationResult))
                {
                    bool result = IdentityManager.DeleteRole(roleItemModel.OperationResult,
                        roleItemModel.Role.Id);
                    if (result)
                    {
                        return JsonResultSuccess(roleItemModel.OperationResult);
                    }
                }
            }
            catch (Exception exception)
            {
                roleItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(roleItemModel.OperationResult);
        }
        
        #endregion Methods SCRUD
    }
}