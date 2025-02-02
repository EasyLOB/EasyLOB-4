namespace EasyLOB.Mvc
{
    public class BaseMvcControllerDashboard : BaseMvcController
    {
        #region Methods

        public BaseMvcControllerDashboard(IAuthorizationManager authorizationManager)
            : base(authorizationManager)
        {
        }

        #endregion Methods

        #region Methods Authorization

        protected bool IsDashboard(string dashboardDirectory, string dashboardName)
        {
            ZOperationResult operationResult = new ZOperationResult();

            return IsDashboard(dashboardDirectory, dashboardName, operationResult);
        }

        protected bool IsDashboard(string dashboardDirectory, string dashboardName, ZOperationResult operationResult)
        {
            return AuthorizationManager.IsDashboard("", dashboardDirectory, dashboardName, operationResult);
        }

        #endregion Methods Authorization
    }
}