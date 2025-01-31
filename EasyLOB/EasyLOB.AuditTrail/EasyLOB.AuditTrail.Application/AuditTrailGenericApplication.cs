using EasyLOB.Application;

namespace EasyLOB.AuditTrail.Application
{
    public class AuditTrailGenericApplication<TEntity>
        : GenericApplication<TEntity>, IAuditTrailGenericApplication<TEntity>
        where TEntity : class, IZDataModel
    {
        #region Methods

        public AuditTrailGenericApplication(IAuditTrailUnitOfWork unitOfWork,
            IAuditTrailManager auditTrailManager,
            IAuthorizationManager authorizationManager)
            : base(unitOfWork, auditTrailManager, authorizationManager)
        {
        }

        #endregion Methods
    }
}
