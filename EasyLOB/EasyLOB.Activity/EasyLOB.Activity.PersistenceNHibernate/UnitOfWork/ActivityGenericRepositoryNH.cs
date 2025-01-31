using EasyLOB.Data;
using EasyLOB.Persistence;

namespace EasyLOB.Activity.Persistence
{
    public class ActivityGenericRepositoryNH<TEntity> : GenericRepositoryNH<TEntity>, IActivityGenericRepository<TEntity>
        where TEntity : class, IZDataModel
    {
        #region Methods

        public ActivityGenericRepositoryNH(IActivityUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            Session = (unitOfWork as ActivityUnitOfWorkNH).Session;
        }

        #endregion Methods
    }
}