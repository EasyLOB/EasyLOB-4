using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace EasyLOB
{
    /// <summary>
    /// Generic Application for Data Models.
    /// </summary>
    /// <typeparam name="TEntity">Data type</typeparam>
    public interface IGenericApplication<TEntity> : IDisposable
        where TEntity : class, IZDataModel
    {
        #region Properties

        /// <summary>
        /// Unit of work.
        /// </summary>
        IUnitOfWork UnitOfWork { get; }

        /// <summary>
        /// Repository.
        /// </summary>
        IGenericRepository<TEntity> Repository { get; }

        /// <summary>
        /// Audit Trail manager.
        /// </summary>
        IAuditTrailManager AuditTrailManager { get; }

        /// <summary>
        /// Authentication manager.
        /// </summary>
        IAuthenticationManager AuthenticationManager { get; }

        /// <summary>
        /// Authorization manager.
        /// </summary>
        IAuthorizationManager AuthorizationManager { get; }

        /// <summary>
        /// Activity operations.
        /// </summary>
        ZActivityOperations ActivityOperations { get; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Count.
        /// </summary>
        /// <param name="operationResult">Operation result</param>
        /// <param name="where">Where LINQ</param>
        /// <returns></returns>
        int Count(ZOperationResult operationResult, Expression<Func<TEntity, bool>> where);

        /// <summary>
        /// Count.
        /// </summary>
        /// <param name="operationResult">Operation result</param>
        /// <param name="where">Where LINQ Dynamic</param>
        /// <param name="args">Args</param>
        /// <returns></returns>
        int Count(ZOperationResult operationResult, string where, object[] args = null);

        /// <summary>
        /// Count all.
        /// </summary>
        /// <param name="operationResult">Operation result</param>
        /// <returns></returns>
        int CountAll(ZOperationResult operationResult);

        /// <summary>
        /// Create.
        /// </summary>
        /// <param name="operationResult">Operation result</param>
        /// <param name="entity">Entity</param>
        /// <returns></returns>
        bool Create(ZOperationResult operationResult, TEntity entity);

        /// <summary>
        /// Delete.
        /// </summary>
        /// <param name="operationResult">Operation result</param>
        /// <param name="entity">Entity</param>
        /// <returns></returns>
        bool Delete(ZOperationResult operationResult, TEntity entity);

        /// <summary>
        /// Get.
        /// </summary>
        /// <param name="operationResult">Operation result</param>
        /// <param name="where">Where LINQ</param>
        /// <param name="notFoundInformation">NOT FOUND information ?</param>
        /// <returns></returns>
        TEntity Get(ZOperationResult operationResult, Expression<Func<TEntity, bool>> where, bool notFoundInformation = false);

        /// <summary>
        /// Get.
        /// </summary>
        /// <param name="operationResult">Operation result</param>
        /// <param name="where">Where LINQ Dynamic</param>
        /// <param name="args">Args</param>
        /// <param name="notFoundInformation">NOT FOUND information ?</param>
        /// <returns></returns>
        TEntity Get(ZOperationResult operationResult, string where, object[] args = null, bool notFoundInformation = false);

        /// <summary>
        /// Get by id.
        /// </summary>
        /// <param name="operationResult">Operation result</param>
        /// <param name="id">Id</param>
        /// <param name="notFoundInformation">NOT FOUND information ?</param>
        /// <returns></returns>
        TEntity GetById(ZOperationResult operationResult, object id, bool notFoundInformation = false);

        /// <summary>
        /// Get by id(s).
        /// </summary>
        /// <param name="operationResult">Operation result</param>
        /// <param name="ids">Id(s) array</param>
        /// <param name="notFoundInformation">NOT FOUND information ?</param>
        /// <returns></returns>
        TEntity GetById(ZOperationResult operationResult, object[] ids, bool notFoundInformation = false);

        /// <summary>
        /// Get id(s).
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        object[] GetIds(TEntity entity);

        /// <summary>
        /// Search.
        /// </summary>
        /// <param name="operationResult">Operation result</param>
        /// <param name="where">Where LINQ</param>
        /// <param name="orderBy">Order By LINQ</param>
        /// <param name="skip">Skip</param>
        /// <param name="take">Take</param>
        /// <param name="associations">Associations</param>
        /// <returns></returns>
        List<TEntity> Search(ZOperationResult operationResult,
            Expression<Func<TEntity, bool>> where = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int? skip = null,
            int? take = null,
            List<Expression<Func<TEntity, object>>> associations = null);

        /// <summary>
        /// Search
        /// </summary>
        /// <param name="operationResult">Operation result</param>
        /// <param name="where">Where LINQ Dynamic</param>
        /// <param name="args">Args</param>
        /// <param name="orderBy">Order By LINQ Dynamic</param>
        /// <param name="skip">Skip</param>
        /// <param name="take">Take</param>
        /// <param name="associations">Associations</param>
        /// <returns></returns>
        List<TEntity> Search(ZOperationResult operationResult,
            string where = null,
            object[] args = null,
            string orderBy = null,
            int? skip = null,
            int? take = null,
            List<string> associations = null);

        /// <summary>
        /// Searck all.
        /// </summary>
        /// <param name="operationResult">Operation result</param>
        /// <returns></returns>
        List<TEntity> SearchAll(ZOperationResult operationResult);

        /// <summary>
        /// Update.
        /// </summary>
        /// <param name="operationResult">Operation result</param>
        /// <param name="entity">Entity</param>
        /// <returns></returns>
        bool Update(ZOperationResult operationResult, TEntity entity);

        #endregion Methods
    }
}