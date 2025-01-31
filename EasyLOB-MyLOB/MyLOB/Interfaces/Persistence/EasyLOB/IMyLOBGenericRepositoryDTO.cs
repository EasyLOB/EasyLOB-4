using EasyLOB;

namespace MyLOB
{
    public interface IMyLOBGenericRepositoryDTO<TEntityDTO, TEntity> : IGenericRepositoryDTO<TEntityDTO, TEntity>
        where TEntityDTO : class, IZDTOModel<TEntityDTO, TEntity>
        where TEntity : class, IZDataModel
    {
    }
}
