using EasyLOB;

namespace Northwind
{
    public interface INorthwindGenericApplication<TEntity>
        : IGenericApplication<TEntity>
        where TEntity : class, IZDataModel
    {
    }
}
