using EasyLOB;
using EasyLOB.Data;
using EasyLOB.Persistence;

namespace Northwind.Persistence
{
    public partial class NorthwindGenericRepositoryLINQ2DB<TEntity> : GenericRepositoryLINQ2DB<TEntity>, INorthwindGenericRepository<TEntity>
        where TEntity : class, IZDataModel
    {
        #region Methods

        public NorthwindGenericRepositoryLINQ2DB(INorthwindUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            Connection = (unitOfWork as NorthwindUnitOfWorkLINQ2DB).Connection;
        }

        #endregion Methods
    }
}

