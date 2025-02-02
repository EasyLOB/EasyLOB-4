namespace EasyLOB.Mvc
{
    public partial class DashboardsController : BaseMvcControllerDashboard
    {
        #region Methods

        public DashboardsController(IAuthorizationManager authorizationManager)
            : base(authorizationManager)
        {
        }

        #endregion Methods
    }
}