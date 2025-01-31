using EasyLOB.Application;

namespace EasyLOB.Activity.Application
{
    public class ActivityGenericApplicationDTO<TEntityDTO, TEntity> : GenericApplicationDTO<TEntityDTO, TEntity>, IActivityGenericApplicationDTO<TEntityDTO, TEntity>
        where TEntityDTO : class, IZDTOModel<TEntityDTO, TEntity>
        where TEntity : class, IZDataModel
    {
        #region Methods

        public ActivityGenericApplicationDTO(IActivityUnitOfWork unitOfWork,
            IAuditTrailManager auditTrailManager,
            IAuthorizationManager authorizationManager)
            : base(unitOfWork, auditTrailManager, authorizationManager)
        {
        }

        #endregion Methods
    }
}