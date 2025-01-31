using EasyLOB;

namespace MyLOB
{
    public interface IMyLOBGenericApplication<TEntity>
        : IGenericApplication<TEntity>
        where TEntity : class, IZDataModel
    {
    }
}
