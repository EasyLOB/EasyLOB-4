using EasyLOB.Data;

namespace EasyLOB.AuditTrail
{
    public interface IAuditTrailGenericApplicationDTO<TEntityDTO, TEntity> : IGenericApplicationDTO<TEntityDTO, TEntity>
        where TEntityDTO : class, IZDTOModel<TEntityDTO, TEntity>
        where TEntity : class, IZDataModel
    {
    }
}