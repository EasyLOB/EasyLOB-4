using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace EasyLOB
{
    /// <summary>
    /// Generic Application for DTO Models.
    /// </summary>
    /// <typeparam name="TEntityDTO">DTO type</typeparam>
    /// <typeparam name="TEntity">Data type</typeparam>
    public interface IGenericApplicationDTO<TEntityDTO, TEntity> : IGenericApplication<TEntity>
        where TEntityDTO : class, IZDTOModel<TEntityDTO, TEntity>
        where TEntity : class, IZDataModel
    {
        #region Methods

        /// <summary>
        /// Create.
        /// </summary>
        /// <param name="operationResult">Operation result</param>
        /// <param name="entityDTO">Entity DTO</param>
        /// <returns></returns>
        bool Create(ZOperationResult operationResult, TEntityDTO entityDTO);

        /// <summary>
        /// Delete.
        /// </summary>
        /// <param name="operationResult">Operation result</param>
        /// <param name="entityDTO">Entity DTO</param>
        /// <returns></returns>
        bool Delete(ZOperationResult operationResult, TEntityDTO entityDTO);

        /// <summary>
        /// Get.
        /// </summary>
        /// <param name="operationResult">Operation result</param>
        /// <param name="where">Where LINQ</param>
        /// <param name="notFoundInformation">NOT FOUND information ?</param>
        /// <returns></returns>
        new TEntityDTO Get(ZOperationResult operationResult, Expression<Func<TEntity, bool>> where, bool notFoundInformation = false);

        /// <summary>
        /// Get.
        /// </summary>
        /// <param name="operationResult">Operation result</param>
        /// <param name="where">Where LINQ Dynamic</param>
        /// <param name="args">Args</param>
        /// <param name="notFoundInformation">NOT FOUND information ?</param>
        /// <returns></returns>
        new TEntityDTO Get(ZOperationResult operationResult, string where, object[] args = null, bool notFoundInformation = false);

        /// <summary>
        /// Get by id.
        /// </summary>
        /// <param name="operationResult">Operation result</param>
        /// <param name="id">Id</param>
        /// <param name="notFoundInformation">NOT FOUND information ?</param>
        /// <returns></returns>
        new TEntityDTO GetById(ZOperationResult operationResult, object id, bool notFoundInformation = false);

        /// <summary>
        /// Get by id(s).
        /// </summary>
        /// <param name="operationResult">Operation result</param>
        /// <param name="ids">Id(s) array</param>
        /// <param name="notFoundInformation">NOT FOUND information ?</param>
        /// <returns></returns>
        new TEntityDTO GetById(ZOperationResult operationResult, object[] ids, bool notFoundInformation = false);

        /// <summary>
        /// Get id(s).
        /// </summary>
        /// <param name="entityDTO">Entity DTO</param>
        /// <returns></returns>
        object[] GetIds(TEntityDTO entityDTO);

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
        new List<TEntityDTO> Search(ZOperationResult operationResult,
            Expression<Func<TEntity, bool>> where = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int? skip = null,
            int? take = null,
            List<Expression<Func<TEntity, object>>> associations = null);

        /// <summary>
        /// Search.
        /// </summary>
        /// <param name="operationResult">Operation result</param>
        /// <param name="where">Where LINQ Dynamic.</param>
        /// <param name="args">Args</param>
        /// <param name="orderBy">Order By LINQ Dynamic</param>
        /// <param name="skip">Skip</param>
        /// <param name="take">Take</param>
        /// <param name="associations">Associations</param>
        /// <returns></returns>
        new List<TEntityDTO> Search(ZOperationResult operationResult,
            string where = null,
            object[] args = null,
            string orderBy = null,
            int? skip = null,
            int? take = null,
            List<string> associations = null);

        /// <summary>
        /// Search all.
        /// </summary>
        /// <param name="operationResult">Operation result</param>
        /// <returns></returns>
        new List<TEntityDTO> SearchAll(ZOperationResult operationResult);

        /// <summary>
        /// Update.
        /// </summary>
        /// <param name="operationResult">Operation result</param>
        /// <param name="entityDTO">Entity DTO</param>
        /// <returns></returns>
        bool Update(ZOperationResult operationResult, TEntityDTO entityDTO);

        #endregion Methods
    }
}