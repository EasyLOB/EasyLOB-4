namespace EasyLOB.WebApi
{
    public class BaseApiControllerPersistence<TEntity> : BaseApiController<TEntity>
        where TEntity : class, IZDataModel
    {
        #region Properties

        protected override string Entity
        {
            get { return Repository.Entity; }
        }

        protected IUnitOfWork UnitOfWork { get; set; }

        protected IGenericRepository<TEntity> Repository { get { return UnitOfWork.GetRepository<TEntity>(); } }

        #endregion Properties

        #region Methods

        public BaseApiControllerPersistence(IAuthorizationManager authorizationManager)
            : base(authorizationManager)
        {
        }

        #endregion Methods
    }
}