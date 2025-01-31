using EasyLOB.Application;

namespace EasyLOB.Activity.Application
{
    public class ActivityGenericApplication<TEntity> : GenericApplication<TEntity>, IActivityGenericApplication<TEntity>
        where TEntity : class, IZDataModel
    {
        #region Methods

        public ActivityGenericApplication(IActivityUnitOfWork unitOfWork,
            IAuditTrailManager auditTrailManager,
            IAuthorizationManager authorizationManager)
            : base(unitOfWork, auditTrailManager, authorizationManager)
        {
        }

        #endregion Methods
    }
}