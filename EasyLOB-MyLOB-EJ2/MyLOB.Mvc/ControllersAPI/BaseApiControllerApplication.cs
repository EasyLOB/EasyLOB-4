namespace EasyLOB.WebApi
{
    public class BaseApiControllerApplication<TEntity> : BaseApiController<TEntity>
        where TEntity : class, IZDataModel
    {
        #region Properties

        protected override string Entity
        {
            get { return Application.Repository.Entity; }
        }

        protected IGenericApplication<TEntity> Application { get; set; }

        #endregion Properties

        #region Methods

        public BaseApiControllerApplication(IAuthorizationManager authorizationManager)
            : base(authorizationManager)
        {
        }

        #endregion Methods
    }
}