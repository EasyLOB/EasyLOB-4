using EasyLOB;

namespace MyLOB
{
    public interface IMyLOBGenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : class, IZDataModel
    {
    }
}
