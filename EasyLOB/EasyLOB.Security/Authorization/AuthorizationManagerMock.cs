namespace EasyLOB.Security
{
    public partial class AuthorizationManagerMock : IAuthorizationManager
    {
        #region Properties

        public IAuthenticationManager AuthenticationManager
        {
            get { return new AuthenticationManagerMock(); }
        }

        #endregion Properties

        #region Methods

        public virtual void Dispose()
        {
        }

        public ZActivityOperations GetOperations(string activityName)
        {
            ZActivityOperations activityOperations = new ZActivityOperations
            {
                IsIndex = true,
                IsSearch = true,
                IsCreate = true,
                IsRead = true,
                IsUpdate = true,
                IsDelete = true,
                IsExport = true,
                IsExecute = true
            };

            return activityOperations;
        }

        public bool IsAuthorized(string activityName, ZOperations operation)
        {
            return true;
        }

        public bool IsAuthorized(string activityName, ZOperations operation, ZOperationResult operationResult)
        {
            return true;
        }

        #endregion Methods

        #region Methods IsOperation

        public bool IsOperation(ZActivityOperations activityOperations, ZOperationResult operationResult)
        {
            return true;
        }

        public bool IsIndex(ZActivityOperations activityOperations, ZOperationResult operationResult)
        {
            return true;
        }

        public bool IsSearch(ZActivityOperations activityOperations, ZOperationResult operationResult)
        {
            return true;
        }

        public bool IsCreate(ZActivityOperations activityOperations, ZOperationResult operationResult)
        {
            return true;
        }

        public bool IsRead(ZActivityOperations activityOperations, ZOperationResult operationResult)
        {
            return true;
        }

        public bool IsUpdate(ZActivityOperations activityOperations, ZOperationResult operationResult)
        {
            return true;
        }

        public bool IsDelete(ZActivityOperations activityOperations, ZOperationResult operationResult)
        {
            return true;
        }

        public bool IsExport(ZActivityOperations activityOperations, ZOperationResult operationResult)
        {
            return true;
        }

        public bool IsExecute(ZActivityOperations activityOperations, ZOperationResult operationResult)
        {
            return true;
        }

        public bool IsDashboard(string domain, string dashboardDirectory, string dashboardName, ZOperationResult operationResult)
        {
            return true;
        }

        public bool IsReport(string domain, string reportDirectory, string reportName, ZOperationResult operationResult)
        {
            return true;
        }

        public bool IsTask(string domain, string task, ZOperationResult operationResult)
        {
            return true;
        }

        public bool IsSCRUD(ZActivityOperations activityOperations, ZOperationResult operationResult)
        {
            return true;
        }

        #endregion Methods IsOperation

        #region Methods Message

        public string MessageAuthorized(string activityName, ZOperations operation)
        {
            return "";
        }

        public string MessageNotAuthorized(string activityName, ZOperations operation)
        {
            return "";
        }

        #endregion Methods Message
    }
}