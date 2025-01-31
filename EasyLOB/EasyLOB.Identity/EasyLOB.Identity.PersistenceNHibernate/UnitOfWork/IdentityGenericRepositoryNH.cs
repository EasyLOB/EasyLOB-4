using EasyLOB.Data;
using EasyLOB.Persistence;

namespace EasyLOB.Identity.Persistence
{
    public class IdentityGenericRepositoryNH<TEntity> : GenericRepositoryNH<TEntity>, IIdentityGenericRepository<TEntity>
        where TEntity : class, IZDataModel
    {
        #region Methods

        public IdentityGenericRepositoryNH(IIdentityUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            Session = (unitOfWork as IdentityUnitOfWorkNH).Session;
        }

        #endregion Methods
    }
}