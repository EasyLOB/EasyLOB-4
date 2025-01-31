using EasyLOB;
using EasyLOB.Data;
using EasyLOB.Persistence;

namespace Northwind.Persistence
{
    public partial class NorthwindGenericRepositoryEF<TEntity> : GenericRepositoryEF<TEntity>, INorthwindGenericRepository<TEntity>
        where TEntity : class, IZDataModel
    {
        #region Methods

        public NorthwindGenericRepositoryEF(INorthwindUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            Context = (unitOfWork as NorthwindUnitOfWorkEF).Context;
        }

        #endregion Methods
    }
}

