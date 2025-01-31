using EasyLOB.Identity.Resources;
using EasyLOB.Security;
using System;
using System.Web.Mvc;

namespace EasyLOB.WebApi
{
    public class BaseApiController<TEntity> : BaseApi
        where TEntity : class, IZDataModel
    {
        #region Properties

        protected virtual string Entity
        {
            get { return ""; }
        }

        protected IAuthorizationManager AuthorizationManager { get; }

        private ZActivityOperations _activityOperations;

        protected virtual ZActivityOperations ActivityOperations
        {
            get
            {
                if (_activityOperations == null)
                {
                   _activityOperations = AuthorizationManager.GetOperations(SecurityHelper.EntityActivity("", Entity));
                }
                return _activityOperations;
            }
            set 
            {
                _activityOperations = value;
            }
        }

        #endregion Properties

        #region Methods

        public BaseApiController(IAuthorizationManager authorizationManager)
        {
            AuthorizationManager = authorizationManager;
        }

        #endregion Methods

        #region Methods Authentication

        protected virtual bool IsUserAdministrator()
        {
            return AuthorizationManager.AuthenticationManager.IsAdministrator;
        }

        protected virtual bool IsUserInRole(string role)
        {
            return AuthorizationManager.AuthenticationManager.Roles.Contains(role);
        }

        protected virtual bool IsUserInRole(ZOperationResult operationResult, string role)
        {
            bool result = AuthorizationManager.AuthenticationManager.Roles.Contains(role);
            operationResult.AddOperationWarning("",
                string.Format(SecurityIdentityResources.OperationAuthorizedRole, role));

            return result;
        }

        #endregion Methods Authentication

        #region Methods Authorization


        protected virtual bool IsOperation(ZOperationResult operationResult)
        {
            return AuthorizationManager.IsOperation(ActivityOperations, operationResult);
        }

        protected virtual bool IsIndex(string operation = null)
        {
            ZOperationResult operationResult = new ZOperationResult();

            return IsIndex(operationResult);
        }

        protected virtual bool IsIndex(ZOperationResult operationResult)
        {
            return AuthorizationManager.IsIndex(ActivityOperations, operationResult);
        }

        protected virtual bool IsSearch()
        {
            ZOperationResult operationResult = new ZOperationResult();

            return IsSearch(operationResult);
        }

        protected virtual bool IsSearch(ZOperationResult operationResult)
        {
            return AuthorizationManager.IsSearch(ActivityOperations, operationResult);
        }

        protected virtual bool IsCreate()
        {
            ZOperationResult operationResult = new ZOperationResult();

            return IsCreate(operationResult);
        }

        protected virtual bool IsCreate(ZOperationResult operationResult)
        {
            return AuthorizationManager.IsCreate(ActivityOperations, operationResult);
        }

        protected virtual bool IsRead()
        {
            ZOperationResult operationResult = new ZOperationResult();

            return IsRead(operationResult);
        }

        protected virtual bool IsRead(ZOperationResult operationResult)
        {
            return AuthorizationManager.IsRead(ActivityOperations, operationResult);
        }

        protected virtual bool IsUpdate()
        {
            ZOperationResult operationResult = new ZOperationResult();

            return IsUpdate(operationResult);
        }

        protected virtual bool IsUpdate(ZOperationResult operationResult)
        {
            return AuthorizationManager.IsUpdate(ActivityOperations, operationResult);
        }

        protected virtual bool IsDelete()
        {
            ZOperationResult operationResult = new ZOperationResult();

            return IsDelete(operationResult);
        }

        protected virtual bool IsDelete(ZOperationResult operationResult)
        {
            return AuthorizationManager.IsDelete(ActivityOperations, operationResult);
        }

        protected virtual bool IsExport()
        {
            ZOperationResult operationResult = new ZOperationResult();

            return IsExport(operationResult);
        }

        protected virtual bool IsExport(ZOperationResult operationResult)
        {
            return AuthorizationManager.IsExport(ActivityOperations, operationResult);
        }

        protected virtual bool IsExecute()
        {
            ZOperationResult operationResult = new ZOperationResult();

            return IsExecute(operationResult);
        }

        protected virtual bool IsExecute(ZOperationResult operationResult)
        {
            return AuthorizationManager.IsExecute(ActivityOperations, operationResult);
        }

        protected virtual bool IsTask(string task)
        {
            ZOperationResult operationResult = new ZOperationResult();

            return IsTask(operationResult, task);
        }

        protected virtual bool IsTask(ZOperationResult operationResult, string task)
        {
            return AuthorizationManager.IsTask("", task, operationResult);
        }

        #endregion Methods Authorization
    }
}