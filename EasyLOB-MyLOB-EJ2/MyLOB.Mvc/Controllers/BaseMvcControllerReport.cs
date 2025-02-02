namespace EasyLOB.Mvc
{
    public class BaseMvcControllerReport : BaseMvcController
    {
        #region Methods

        public BaseMvcControllerReport(IAuthorizationManager authorizationManager)
            : base(authorizationManager)
        {
        }

        #endregion Methods

        #region Methods Authorization

        protected bool IsReport(string reportDirectory, string reportName)
        {
            ZOperationResult operationResult = new ZOperationResult();

            return IsReport(reportDirectory, reportName, operationResult);
        }

        protected bool IsReport(string reportDirectory, string reportName, ZOperationResult operationResult)
        {
            return AuthorizationManager.IsReport("", reportDirectory, reportName, operationResult);
        }

        #endregion Methods Authorization
    }
}