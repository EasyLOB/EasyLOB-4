namespace EasyLOB.Identity
{
    public interface IIdentityGenericApplicationDTO<TEntityDTO, TEntity> : IGenericApplicationDTO<TEntityDTO, TEntity>
        where TEntityDTO : class, IZDTOModel<TEntityDTO, TEntity>
        where TEntity : class, IZDataModel
    {
    }
}