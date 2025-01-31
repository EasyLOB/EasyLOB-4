﻿using EasyLOB.Library;
using EasyLOB.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace EasyLOB.Application
{
    public abstract class GenericApplication<TEntity> : IGenericApplication<TEntity>
        where TEntity : class, IZDataModel
    {
        #region Properties

        public IUnitOfWork UnitOfWork { get; }

        public IGenericRepository<TEntity> Repository
        {
            get { return UnitOfWork.GetRepository<TEntity>(); }
        }

        public IAuditTrailManager AuditTrailManager { get; }

        public IAuthenticationManager AuthenticationManager
        {
            get { return AuthorizationManager.AuthenticationManager; }
        }

        public IAuthorizationManager AuthorizationManager { get; }

        public ZActivityOperations ActivityOperations
        {
            get
            {
                return AuthorizationManager.GetOperations(SecurityHelper.EntityActivity(UnitOfWork.Domain, Repository.Entity));
            }
        }

        #endregion Properties

        #region Methods

        public GenericApplication(IUnitOfWork unitOfWork,
            IAuditTrailManager auditTrailManager,
            IAuthorizationManager authorizationManager)
        {
            UnitOfWork = unitOfWork;

            AuditTrailManager = auditTrailManager;
            AuthorizationManager = authorizationManager;
        }

        public int Count(ZOperationResult operationResult, Expression<Func<TEntity, bool>> where)
        {
            int result = 0;

            try
            {
                if (IsSearch(operationResult))
                {
                    result = Repository.Count(where);
                }
            }
            catch (Exception exception)
            {
                operationResult.ParseException(exception);
            }

            return result;
        }

        public int Count(ZOperationResult operationResult, string where, object[] args = null)
        {
            int result = 0;

            try
            {
                if (IsSearch(operationResult))
                {
                    result = Repository.Count(where, args);
                }
            }
            catch (Exception exception)
            {
                operationResult.ParseException(exception);
            }

            return result;
        }

        public int CountAll(ZOperationResult operationResult)
        {
            int result = 0;

            try
            {
                if (IsSearch(operationResult))
                {
                    result = Repository.CountAll();
                }
            }
            catch (Exception exception)
            {
                operationResult.ParseException(exception);
            }

            return result;
        }

        public virtual bool Create(ZOperationResult operationResult, TEntity entity)
        {
            try
            {
                if (IsCreate(operationResult))
                {
                    if (Repository.Create(operationResult, entity))
                    {
                        if (UnitOfWork.Save(operationResult))
                        {
                            string logOperation = "C";
                            AuditTrailManager.AuditTrail(operationResult,
                                AuthenticationManager.UserName,
                                UnitOfWork.Domain,
                                Repository.Entity,
                                logOperation,
                                null,
                                entity);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                operationResult.ParseException(exception);
            }

            return operationResult.Ok;
        }

        public virtual bool Delete(ZOperationResult operationResult, TEntity entity)
        {
            try
            {
                if (IsDelete(operationResult))
                {
                    if (Repository.Delete(operationResult, entity))
                    {
                        if (UnitOfWork.Save(operationResult))
                        {
                            string logOperation = "D";
                            AuditTrailManager.AuditTrail(operationResult,
                                AuthenticationManager.UserName,
                                UnitOfWork.Domain,
                                Repository.Entity,
                                logOperation,
                                entity,
                                null);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                operationResult.ParseException(exception);
            }

            return operationResult.Ok;
        }

        public virtual TEntity Get(ZOperationResult operationResult, Expression<Func<TEntity, bool>> where, bool notFoundInformation = false)
        {
            TEntity result = null;

            try
            {
                if (IsSCRUD(operationResult))
                {
                    result = Repository.Get(where);
                    if (notFoundInformation && result == null)
                    {
                        operationResult.AddOperationInformation("", LibraryHelper.MessageNotFound(typeof(TEntity).Name, null));
                    }
                }
            }
            catch (Exception exception)
            {
                operationResult.ParseException(exception);
            }

            return result;
        }

        public virtual TEntity Get(ZOperationResult operationResult, string where, object[] args = null, bool notFoundInformation = false)
        {
            TEntity result = null;

            try
            {
                if (IsSCRUD(operationResult))
                {
                    result = Repository.Get(where, args);
                    if (notFoundInformation && result == null)
                    {
                        operationResult.AddOperationInformation("", LibraryHelper.MessageNotFound(typeof(TEntity).Name, null));
                    }
                }
            }
            catch (Exception exception)
            {
                operationResult.ParseException(exception);
            }

            return result;
        }

        public virtual TEntity GetById(ZOperationResult operationResult, object id, bool notFoundInformation = false)
        {
            return GetById(operationResult, new object[] { id }, notFoundInformation);
        }

        public virtual TEntity GetById(ZOperationResult operationResult, object[] ids, bool notFoundInformation = false)
        {
            TEntity result = null;

            try
            {
                if (IsSCRUD(operationResult))
                {
                    result = Repository.GetById(ids);
                    if (notFoundInformation && result == null)
                    {
                        operationResult.AddOperationInformation("", LibraryHelper.MessageNotFound(typeof(TEntity).Name, ids)); 
                    }
                }
            }
            catch (Exception exception)
            {
                operationResult.ParseException(exception);
            }

            return result;
        }

        public virtual object[] GetIds(TEntity entity)
        {
            return Repository.GetIds(entity);
        }

        public virtual List<TEntity> Search(ZOperationResult operationResult, Expression<Func<TEntity, bool>> where = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int? skip = null,
            int? take = null,
            List<Expression<Func<TEntity, object>>> associations = null)
        {
            List<TEntity> result = new List<TEntity>();

            try
            {
                if (IsSearch(operationResult))
                {
                    result = Repository.Search(where, orderBy, skip, take, associations);
                }
            }
            catch (Exception exception)
            {
                operationResult.ParseException(exception);
            }

            return result;
        }

        public virtual List<TEntity> Search(ZOperationResult operationResult, string where = null,
            object[] args = null,
            string orderBy = null,
            int? skip = null,
            int? take = null,
            List<string> associations = null)
        {
            List<TEntity> result = new List<TEntity>();

            try
            {
                if (IsSearch(operationResult))
                {
                    result = Repository.Search(where, args, orderBy, skip, take, associations);
                }
            }
            catch (Exception exception)
            {
                operationResult.ParseException(exception);
            }

            return result;
        }

        public List<TEntity> SearchAll(ZOperationResult operationResult)
        {
            List<TEntity> result = new List<TEntity>();

            try
            {
                if (IsSearch(operationResult))
                {
                    result = Repository.SearchAll();
                }
            }
            catch (Exception exception)
            {
                operationResult.ParseException(exception);
            }

            return result;
        }

        public bool Update(ZOperationResult operationResult, TEntity entity)
        {
            try
            {
                if (IsUpdate(operationResult))
                {
                    string logOperation = "U";
                    string logMode;
                    bool isAuditTrail = AuditTrailManager.IsAuditTrail(UnitOfWork.Domain, Repository.Entity, logOperation, out logMode);
                    TEntity entityBefore = null;
                    if (isAuditTrail)
                    {
                        entityBefore = Repository.GetById(entity.GetId());
                    }

                    if (Repository.Update(operationResult, entity))
                    {
                        if (UnitOfWork.Save(operationResult))
                        {
                            if (isAuditTrail)
                            {
                                AuditTrailManager.AuditTrail(operationResult,
                                    AuthenticationManager.UserName,
                                    UnitOfWork.Domain,
                                    Repository.Entity,
                                    logOperation,
                                    entityBefore,
                                    entity);
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                operationResult.ParseException(exception);
            }

            return operationResult.Ok;
        }

        #endregion Methods

        #region Methods IDispose

        private bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                }

                disposed = true;
            }
        }

        #endregion Methods IDispose

        #region Methods ActivityOperations

        protected bool IsIndex(ZOperationResult operationResult)
        {
            return AuthorizationManager.IsIndex(ActivityOperations, operationResult);
        }

        protected bool IsSearch(ZOperationResult operationResult)
        {
            return AuthorizationManager.IsSearch(ActivityOperations, operationResult);
        }

        protected bool IsCreate(ZOperationResult operationResult)
        {
            return AuthorizationManager.IsCreate(ActivityOperations, operationResult);
        }

        protected bool IsRead(ZOperationResult operationResult)
        {
            return AuthorizationManager.IsRead(ActivityOperations, operationResult);
        }

        protected bool IsUpdate(ZOperationResult operationResult)
        {
            return AuthorizationManager.IsUpdate(ActivityOperations, operationResult);
        }

        protected bool IsDelete(ZOperationResult operationResult)
        {
            return AuthorizationManager.IsDelete(ActivityOperations, operationResult);
        }

        protected bool IsExport(ZOperationResult operationResult)
        {
            return AuthorizationManager.IsExport(ActivityOperations, operationResult);
        }

        protected bool IsExecute(ZOperationResult operationResult)
        {
            return AuthorizationManager.IsExecute(ActivityOperations, operationResult);
        }

        protected bool IsSCRUD(ZOperationResult operationResult)
        {
            return AuthorizationManager.IsSCRUD(ActivityOperations, operationResult);
        }

        #endregion Methods ActivityOperations
    }
}