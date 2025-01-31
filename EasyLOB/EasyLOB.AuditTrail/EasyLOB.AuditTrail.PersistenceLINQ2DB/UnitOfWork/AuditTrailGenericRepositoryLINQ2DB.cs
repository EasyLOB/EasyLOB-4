using EasyLOB.Data;
using EasyLOB.Persistence;

namespace EasyLOB.AuditTrail.Persistence
{
    public class AuditTrailGenericRepositoryLINQ2DB<TEntity> : GenericRepositoryLINQ2DB<TEntity>, IAuditTrailGenericRepository<TEntity>
        where TEntity : class, IZDataModel
    {
        #region Methods

        public AuditTrailGenericRepositoryLINQ2DB(IAuditTrailUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            Connection = (unitOfWork as AuditTrailUnitOfWorkLINQ2DB).Connection;
        }

        #endregion Methods
    }
}

