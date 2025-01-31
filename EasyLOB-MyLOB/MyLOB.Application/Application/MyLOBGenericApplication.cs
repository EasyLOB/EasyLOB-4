using EasyLOB;
using EasyLOB.Application;

namespace MyLOB.Application
{
    public partial class MyLOBGenericApplication<TEntity>
        : GenericApplication<TEntity>, IMyLOBGenericApplication<TEntity>
        where TEntity : class, IZDataModel
    {
        #region Methods

        public MyLOBGenericApplication(IMyLOBUnitOfWork unitOfWork,
            IAuditTrailManager auditTrailManager,
            IAuthorizationManager authorizationManager)
            : base(unitOfWork, auditTrailManager, authorizationManager)
        {
        }

        #endregion Methods
    }
}