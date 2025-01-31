using EasyLOB;
using EasyLOB.Data;
using EasyLOB.Persistence;

namespace Northwind.Persistence
{
    public partial class NorthwindGenericRepositoryNH<TEntity> : GenericRepositoryNH<TEntity>, INorthwindGenericRepository<TEntity>
        where TEntity : class, IZDataModel
    {
        #region Methods

        public NorthwindGenericRepositoryNH(INorthwindUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            Session = (unitOfWork as NorthwindUnitOfWorkNH).Session;
        }

        #endregion Methods
    }
}

