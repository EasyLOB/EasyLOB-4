using EasyLOB.Identity.Data;

namespace EasyLOB.Identity.Persistence
{
    public class IdentityUserRepository : IdentityGenericRepositoryEF<User>
    {
        #region Methods

        public IdentityUserRepository(IIdentityUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public override bool Create(ZOperationResult operationResult, User entity)
        {
            return operationResult.Ok;
        }

        public override bool Delete(ZOperationResult operationResult, User entity)
        {
            return operationResult.Ok;
        }

        public override bool Update(ZOperationResult operationResult, User entity)
        {
            return operationResult.Ok;
        }

        #endregion Methods
    }
}