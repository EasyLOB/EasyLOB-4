using EasyLOB;

namespace Northwind
{
    public interface INorthwindGenericRepositoryDTO<TEntityDTO, TEntity> : IGenericRepositoryDTO<TEntityDTO, TEntity>
        where TEntityDTO : class, IZDTOModel<TEntityDTO, TEntity>
        where TEntity : class, IZDataModel
    {
    }
}
