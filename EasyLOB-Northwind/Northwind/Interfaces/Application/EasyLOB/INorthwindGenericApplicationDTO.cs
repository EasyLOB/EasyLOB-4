using EasyLOB;

namespace Northwind
{
    public interface INorthwindGenericApplicationDTO<TEntityDTO, TEntity>
        : IGenericApplicationDTO<TEntityDTO, TEntity>
        where TEntityDTO : class, IZDTOModel<TEntityDTO, TEntity>
        where TEntity : class, IZDataModel
    {
    }
}
