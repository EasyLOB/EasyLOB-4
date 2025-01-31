using EasyLOB.Data;

namespace EasyLOB.Activity
{
    public interface IActivityGenericApplicationDTO<TEntityDTO, TEntity> : IGenericApplicationDTO<TEntityDTO, TEntity>
        where TEntityDTO : class, IZDTOModel<TEntityDTO, TEntity>
        where TEntity : class, IZDataModel
    {
    }
}