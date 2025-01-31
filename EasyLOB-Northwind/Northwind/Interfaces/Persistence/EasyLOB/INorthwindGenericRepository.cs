using EasyLOB;

namespace Northwind
{
    public interface INorthwindGenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : class, IZDataModel
    {
    }
}
