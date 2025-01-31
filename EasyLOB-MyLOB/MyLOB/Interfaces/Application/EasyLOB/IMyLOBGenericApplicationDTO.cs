using EasyLOB;

namespace MyLOB
{
    public interface IMyLOBGenericApplicationDTO<TEntityDTO, TEntity>
        : IGenericApplicationDTO<TEntityDTO, TEntity>
        where TEntityDTO : class, IZDTOModel<TEntityDTO, TEntity>
        where TEntity : class, IZDataModel
    {
    }
}
