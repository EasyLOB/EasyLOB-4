using System;

namespace EasyLOB.Persistence
{
    /// <summary>
    /// IGenericRepository Extensions.
    /// </summary>
    public static class IGenericRepositoryDTOExtensions
    {
        /// <summary>
        /// Get repository type.
        /// </summary>
        /// <typeparam name="TEntityDTO">Entity</typeparam>
        /// <typeparam name="TEntity">Entity DTO</typeparam>
        /// <param name="_"></param>
        /// <returns>Type</returns>
        public static Type GetRepositoryType<TEntityDTO, TEntity>(this IGenericRepositoryDTO<TEntityDTO, TEntity> _)
            where TEntityDTO : class, IZDTOModel<TEntityDTO, TEntity>
            where TEntity : class, IZDataModel
        {
            return typeof(TEntityDTO);
        }
    }
}
