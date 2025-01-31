using EasyLOB.Data;
using EasyLOB.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace EasyLOB.Application
{
    public abstract class GenericApplicationDTO<TEntityDTO, TEntity> : GenericApplication<TEntity>, IGenericApplicationDTO<TEntityDTO, TEntity>
        where TEntityDTO : class, IZDTOModel<TEntityDTO, TEntity>
        where TEntity : class, IZDataModel
    {
        #region Methods

        public GenericApplicationDTO(IUnitOfWork unitOfWork,
            IAuditTrailManager auditTrailManager,
            IAuthorizationManager authorizationManager)
            : base(unitOfWork, auditTrailManager, authorizationManager)
        {
        }

        public virtual bool Create(ZOperationResult operationResult, TEntityDTO entityDTO)
        {
            try
            {
                if (IsCreate(operationResult))
                {
                    TEntity entity = (TEntity)entityDTO.ToData();

                    if (Repository.Create(operationResult, entity))
                    {
                        if (UnitOfWork.Save(operationResult))
                        {
                            entityDTO.FromData(entity);

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

        public virtual bool Delete(ZOperationResult operationResult, TEntityDTO entityDTO)
        {
            try
            {
                if (IsDelete(operationResult))
                {
                    TEntity entity = (TEntity)entityDTO.ToData();

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

        public new TEntityDTO Get(ZOperationResult operationResult, Expression<Func<TEntity, bool>> where, bool notFoundInformation = false)
        {
            TEntityDTO result = null;

            try
            {
                if (IsRead(operationResult) || IsUpdate(operationResult) || IsDelete(operationResult))
                {
                    TEntity entity = Repository.Get(where);
                    if (entity != null)
                    {
                        result = (TEntityDTO)Activator.CreateInstance(typeof(TEntityDTO), entity);
                    }
                    else if (notFoundInformation)
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

        public new TEntityDTO Get(ZOperationResult operationResult, string where, object[] args = null, bool notFoundInformation = false)
        {
            TEntityDTO result = null;

            try
            {
                if (IsRead(operationResult) || IsUpdate(operationResult) || IsDelete(operationResult))
                {
                    TEntity entity = Repository.Get(where, args);
                    if (entity != null)
                    {
                        result = (TEntityDTO)Activator.CreateInstance(typeof(TEntityDTO), entity);
                    }
                    else if (notFoundInformation)
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

        public new TEntityDTO GetById(ZOperationResult operationResult, object id, bool notFoundInformation = false)
        {
            return GetById(operationResult, new object[] { id }, notFoundInformation);
        }

        public new TEntityDTO GetById(ZOperationResult operationResult, object[] ids, bool notFoundInformation = false)
        {
            TEntityDTO result = null;

            try
            {
                if (IsRead(operationResult) || IsUpdate(operationResult) || IsDelete(operationResult))
                {
                    TEntity entity = Repository.GetById(ids);
                    if (entity != null)
                    {
                        result = (TEntityDTO)Activator.CreateInstance(typeof(TEntityDTO), entity);
                    }
                    else if (notFoundInformation)
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

        public virtual object[] GetIds(TEntityDTO entityDTO)
        {
            TEntity entity = (TEntity)entityDTO.ToData();

            return Repository.GetIds(entity);
        }

        public new List<TEntityDTO> Search(ZOperationResult operationResult,
            Expression<Func<TEntity, bool>> where = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int? skip = null,
            int? take = null,
            List<Expression<Func<TEntity, object>>> associations = null)
        {
            List<TEntityDTO> result = new List<TEntityDTO>();

            try
            {
                if (IsSearch(operationResult))
                {
                    return ZDTOModelHelper<TEntityDTO, TEntity>.ToDTOList(Repository.Search(where, orderBy, skip, take, associations));
                }
            }
            catch (Exception exception)
            {
                operationResult.ParseException(exception);
            }

            return result;
        }

        public new List<TEntityDTO> Search(ZOperationResult operationResult,
            string where = null,
            object[] args = null,
            string orderBy = null,
            int? skip = null,
            int? take = null,
            List<string> associations = null)
        {
            List<TEntityDTO> result = new List<TEntityDTO>();

            try
            {
                if (IsSearch(operationResult))
                {
                    return ZDTOModelHelper<TEntityDTO, TEntity>.ToDTOList(Repository.Search(where, args, orderBy, skip, take, associations));
                }
            }
            catch (Exception exception)
            {
                operationResult.ParseException(exception);
            }

            return result;
        }

        public new List<TEntityDTO> SearchAll(ZOperationResult operationResult)
        {
            List<TEntityDTO> result = new List<TEntityDTO>();

            try
            {
                if (IsSearch(operationResult))
                {
                    result = ZDTOModelHelper<TEntityDTO, TEntity>.ToDTOList(Repository.SearchAll());
                }
            }
            catch (Exception exception)
            {
                operationResult.ParseException(exception);
            }

            return result;
        }

        public virtual bool Update(ZOperationResult operationResult, TEntityDTO entityDTO)
        {
            try
            {
                if (IsUpdate(operationResult))
                {
                    TEntity entity = (TEntity)entityDTO.ToData();

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
                            entityDTO.FromData(entity);

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
    }
}