using EasyLOB.Security;
using System;

namespace EasyLOB.Mvc
{
    public class BaseMvcControllerSCRUD<TEntity> : BaseMvcController
        where TEntity : class, IZDataModel
    {
        #region Properties

        protected virtual string Entity
        {
            get { return ""; }
        }

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

        public BaseMvcControllerSCRUD(IAuthorizationManager authorizationManager)
            : base(authorizationManager)
        {
        }

        protected virtual void Create2Update(ZOperationResult operationResult)
        {
            //operationResult.InformationMessage = EasyLOB.Resources.PresentationResources.CreateToUpdate;
        }

        protected virtual bool IsValid(ZOperationResult operationResult, IZValidatableObject entity)
        {
            entity.Validate(operationResult);

            return base.IsValid(operationResult, typeof(TEntity).Name);
        }

        #endregion Methods

        #region Methods Authorization

        protected virtual bool IsOperation(ZOperationResult operationResult)
        {
            return AuthorizationManager.IsOperation(ActivityOperations, operationResult);
        }

        protected virtual bool IsIndex()
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

            return IsTask(task, operationResult);
        }

        protected virtual bool IsTask(string task, ZOperationResult operationResult)
        {
            return AuthorizationManager.IsTask("", task, operationResult);
        }

        #endregion Methods Authorization
    }
}