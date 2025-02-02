using EasyLOB;
using EasyLOB.Application;

namespace MyLOB.Application
{
    public partial class MyLOBGenericApplicationDTO<TEntityDTO, TEntity>
        : GenericApplicationDTO<TEntityDTO, TEntity>, IMyLOBGenericApplicationDTO<TEntityDTO, TEntity>
        where TEntityDTO : class, IZDTOModel<TEntityDTO, TEntity>
        where TEntity : class, IZDataModel
    {
        #region Methods

        public MyLOBGenericApplicationDTO(IMyLOBUnitOfWork unitOfWork,
            IAuditTrailManager auditTrailManager,
            IAuthorizationManager authorizationManager)
            : base(unitOfWork, auditTrailManager, authorizationManager)
        {
        }

        #endregion Methods
    }
}