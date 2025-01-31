﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace EasyLOB
{
    /// <summary>
    /// IUnitOfWorkDTO.
    /// </summary>
    public interface IUnitOfWorkDTO : IDisposable
    {
        #region Properties

        /// <summary>
        /// Authentication Manager.
        /// </summary>
        IAuthenticationManager AuthenticationManager { get; }

        /// <summary>
        /// Logger.
        /// </summary>
        ZDatabaseLogger DatabaseLogger { get; set; }

        /// <summary>
        /// DBMS.
        /// </summary>
        ZDBMS DBMS { get; }

        /// <summary>
        /// Domain.
        /// </summary>
        string Domain { get; }

        /// <summary>
        /// Repositories.
        /// </summary>
        IDictionary<Type, object> Repositories { get; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Begin Transaction.
        /// </summary>
        /// <param name="operationResult">Operation Result</param>
        /// <param name="isolationLevel">Isolation Level</param>
        /// <returns>Ok ?</returns>
        bool BeginTransaction(ZOperationResult operationResult, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);

        /// <summary>
        /// Commit Transaction.
        /// </summary>
        /// <param name="operationResult">Operation Result</param>
        /// <returns>Ok ?</returns>
        bool CommitTransaction(ZOperationResult operationResult);

        /// <summary>
        /// Get Profile.
        /// </summary>
        /// <typeparam name="TEntityDTO">DTO</typeparam>
        /// <typeparam name="TEntity">Entity</typeparam>
        /// <returns>Data Profile</returns>
        IZProfile GetProfile<TEntityDTO, TEntity>()
            where TEntityDTO : class, IZDTOModel<TEntityDTO, TEntity>
            where TEntity : class, IZDataModel;

        /// <summary>
        /// Get IQueryable.
        /// </summary>
        /// <typeparam name="TEntityDTO">DTO</typeparam>
        /// <typeparam name="TEntity">Entity</typeparam>
        /// <returns>Ok ?</returns>
        IQueryable<TEntityDTO> GetQuery<TEntityDTO, TEntity>()
            where TEntityDTO : class, IZDTOModel<TEntityDTO, TEntity>
            where TEntity : class, IZDataModel;

        /// <summary>
        /// Get Repository.
        /// </summary>
        /// <typeparam name="TEntityDTO">DTO</typeparam>
        /// <typeparam name="TEntity">Entity</typeparam>
        /// <returns>Ok ?</returns>
        IGenericRepositoryDTO<TEntityDTO, TEntity> GetRepository<TEntityDTO, TEntity>()
            where TEntityDTO : class, IZDTOModel<TEntityDTO, TEntity>
            where TEntity : class, IZDataModel;

        /// <summary>
        /// Rollback Transaction.
        /// </summary>
        /// <param name="operationResult">Operation Result</param>
        /// <returns>Ok ?</returns>
        bool RollbackTransaction(ZOperationResult operationResult);

        /// <summary>
        /// Save.
        /// </summary>
        /// <param name="operationResult">Operation Result</param>
        /// <returns>OK ?</returns>
        bool Save(ZOperationResult operationResult);

        /// <summary>
        /// Set Isolation Level.
        /// </summary>
        /// <param name="isolationLevel">Isolation Level</param>
        void SetIsolationLevel(IsolationLevel isolationLevel);

        #endregion Methods

        #region Methods SQL

        /// <summary>
        /// Execute SQL Command.
        /// </summary>
        /// <param name="sql">SQL</param>
        /// <returns>Scalar</returns>
        int SQLCommand(string sql);

        /// <summary>
        /// Execute SQL Query.
        /// </summary>
        /// <param name="sql">SQL</param>
        /// <returns>IEnumerable[TEntity]</returns>
        IEnumerable<TEntity> SQLQuery<TEntity>(string sql);
        /*
        /// <summary>
        /// Execute SQL Query.
        /// </summary>
        /// <param name="sql"></param>
        /// <returns>IEnumerable[dynamic]</returns>
        IEnumerable<dynamic> SqlQueryDynamic(string sql); // , params object[] parameters);
        // <param name="parameters">Parameters</param>
        */
        #endregion Methods SQL

        #region Triggers

        /// <summary>
        /// Before create Trigger.
        /// </summary>
        /// <param name="operationResult">Operation Result</param>
        /// <param name="entity">Entity</param>
        /// <returns>Ok ?</returns>
        bool BeforeCreate(ZOperationResult operationResult, object entity);

        /// <summary>
        /// After create Trigger.
        /// </summary>
        /// <param name="operationResult">Operation Result</param>
        /// <param name="entity">Entity</param>
        /// <returns>Ok ?</returns>
        bool AfterCreate(ZOperationResult operationResult, object entity);

        /// <summary>
        /// Before delete Trigger.
        /// </summary>
        /// <param name="operationResult">Operation Result</param>
        /// <param name="entity">Entity</param>
        /// <returns>Ok ?</returns>
        bool BeforeDelete(ZOperationResult operationResult, object entity);

        /// <summary>
        /// After delete Trigger.
        /// </summary>
        /// <param name="operationResult">Operation Result</param>
        /// <param name="entity">Entity</param>
        /// <returns>Ok ?</returns>
        bool AfterDelete(ZOperationResult operationResult, object entity);

        /// <summary>
        /// Before udpate Trigger.
        /// </summary>
        /// <param name="operationResult">Operation Result</param>
        /// <param name="entity">Entity</param>
        /// <returns>Ok ?</returns>
        bool BeforeUpdate(ZOperationResult operationResult, object entity);

        /// <summary>
        /// After update Trigger.
        /// </summary>
        /// <param name="operationResult">Operation Result</param>
        /// <param name="entity">Entity</param>
        /// <returns>Ok ?</returns>
        bool AfterUpdate(ZOperationResult operationResult, object entity);

        #endregion Triggers
    }
}
