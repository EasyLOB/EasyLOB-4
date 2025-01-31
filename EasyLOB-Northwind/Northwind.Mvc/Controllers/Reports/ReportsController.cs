namespace EasyLOB.Mvc
{
    public partial class ReportsController : BaseMvcControllerReport
    {
        #region Methods

        public ReportsController(IAuthorizationManager authorizationManager)
            : base(authorizationManager)
        {
        }

        #endregion Methods
    }
}