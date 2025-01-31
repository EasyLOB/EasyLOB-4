using EasyLOB;
using EasyLOB.Data;
using EasyLOB.Persistence;

namespace MyLOB.Persistence
{
    public partial class MyLOBGenericRepositoryEF<TEntity> : GenericRepositoryEF<TEntity>, IMyLOBGenericRepository<TEntity>
        where TEntity : class, IZDataModel
    {
        #region Methods

        public MyLOBGenericRepositoryEF(IMyLOBUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            Context = (unitOfWork as MyLOBUnitOfWorkEF).Context;
        }

        #endregion Methods
    }
}

