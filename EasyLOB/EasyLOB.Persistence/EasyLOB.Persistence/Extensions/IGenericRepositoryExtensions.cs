using System;

namespace EasyLOB.Persistence
{
    /// <summary>
    /// IGenericRepository Extensions.
    /// </summary>
    public static class IGenericRepositoryExtensions
    {
        /// <summary>
        /// Get repository type.
        /// </summary>
        /// <typeparam name="TEntity">Entity</typeparam>
        /// <param name="_"></param>
        /// <returns>Type</returns>
        public static Type GetRepositoryType<TEntity>(this IGenericRepository<TEntity> _)
            where TEntity : class, IZDataModel
        {
            return typeof(TEntity);
        }
    }
}