using EasyLOB.Identity.Data;

namespace EasyLOB.Identity.Persistence
{
    public class IdentityRoleRepository : IdentityGenericRepositoryNH<Role>
    {
        #region Methods

        public IdentityRoleRepository(IIdentityUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public override bool Create(ZOperationResult operationResult, Role entity)
        {
            return operationResult.Ok;
        }

        public override bool Delete(ZOperationResult operationResult, Role entity)
        {
            return operationResult.Ok;
        }

        public override bool Update(ZOperationResult operationResult, Role entity)
        {
            return operationResult.Ok;
        }

        #endregion Methods
    }
}