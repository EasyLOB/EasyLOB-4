using EasyLOB.Identity.Data;

namespace EasyLOB.Identity.Persistence
{
    public class IdentityUserRoleRepository : IdentityGenericRepositoryEF<UserRole>
    {
        #region Methods

        public IdentityUserRoleRepository(IIdentityUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public override bool Create(ZOperationResult operationResult, UserRole entity)
        {
            return operationResult.Ok;
        }

        public override bool Delete(ZOperationResult operationResult, UserRole entity)
        {
            return operationResult.Ok;
        }

        public override bool Update(ZOperationResult operationResult, UserRole entity)
        {
            return operationResult.Ok;
        }

        #endregion Methods
    }
}