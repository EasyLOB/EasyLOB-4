using EasyLOB.Data;
using EasyLOB.Persistence;

namespace EasyLOB.AuditTrail.Persistence
{
    public class AuditTrailGenericRepositoryNH<TEntity> : GenericRepositoryNH<TEntity>, IAuditTrailGenericRepository<TEntity>
        where TEntity : class, IZDataModel
    {
        #region Methods

        public AuditTrailGenericRepositoryNH(IAuditTrailUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            Session = (unitOfWork as AuditTrailUnitOfWorkNH).Session;
        }

        #endregion Methods
    }
}

