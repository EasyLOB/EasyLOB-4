using System;

namespace EasyLOB
{
    /// <summary>
    /// IAuthorizationManager.
    /// </summary>
    public interface IAuthorizationManager : IDisposable
    {
        #region Properties

        /// <summary>
        /// Authentication manager.
        /// </summary>
        IAuthenticationManager AuthenticationManager { get; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Get operations.
        /// </summary>
        /// <param name="activityName">Activity name</param>
        /// <returns></returns>
        ZActivityOperations GetOperations(string activityName);

        /// <summary>
        /// Is authorized ?
        /// </summary>
        /// <param name="activityName">Ativity name</param>
        /// <param name="operation">Operation</param>
        /// <returns></returns>
        bool IsAuthorized(string activityName, ZOperations operation);

        /// <summary>
        /// Is authorized ?
        /// </summary>
        /// <param name="activityName">Activity name</param>
        /// <param name="operation">Operation</param>
        /// <param name="operationResult">Operation result</param>
        /// <returns></returns>
        bool IsAuthorized(string activityName, ZOperations operation, ZOperationResult operationResult);

        #endregion Methods

        #region Methods IsOperation

        /// <summary>
        /// Is operation ?
        /// </summary>
        /// <param name="activityOperations">Activity operations</param>
        /// <param name="operationResult">Operation result</param>
        /// <returns></returns>
        bool IsOperation(ZActivityOperations activityOperations, ZOperationResult operationResult);

        /// <summary>
        /// Is index ?
        /// </summary>
        /// <param name="activityOperations">Activity operations</param>
        /// <param name="operationResult">Operation result</param>
        /// <returns></returns>
        bool IsIndex(ZActivityOperations activityOperations, ZOperationResult operationResult);

        /// <summary>
        /// Is search ?
        /// </summary>
        /// <param name="activityOperations">Activity operations</param>
        /// <param name="operationResult">Operation result</param>
        /// <returns></returns>
        bool IsSearch(ZActivityOperations activityOperations, ZOperationResult operationResult);

        /// <summary>
        /// Is create ?
        /// </summary>
        /// <param name="activityOperations">Activity operations</param>
        /// <param name="operationResult">Operation result</param>
        /// <returns></returns>
        bool IsCreate(ZActivityOperations activityOperations, ZOperationResult operationResult);

        /// <summary>
        /// Is read ?
        /// </summary>
        /// <param name="activityOperations">Activity operations</param>
        /// <param name="operationResult">Operation result</param>
        /// <returns></returns>
        bool IsRead(ZActivityOperations activityOperations, ZOperationResult operationResult);

        /// <summary>
        /// Is update ?
        /// </summary>
        /// <param name="activityOperations">Activity operations</param>
        /// <param name="operationResult">Operation result</param>
        /// <returns></returns>
        bool IsUpdate(ZActivityOperations activityOperations, ZOperationResult operationResult);

        /// <summary>
        /// Is delete ?
        /// </summary>
        /// <param name="activityOperations">Activity operations</param>
        /// <param name="operationResult">Operation result</param>
        /// <returns></returns>
        bool IsDelete(ZActivityOperations activityOperations, ZOperationResult operationResult);

        /// <summary>
        /// Is export ?
        /// </summary>
        /// <param name="activityOperations">Activity operations</param>
        /// <param name="operationResult">Operation result</param>
        /// <returns></returns>
        bool IsExport(ZActivityOperations activityOperations, ZOperationResult operationResult);

        /// <summary>
        /// Is execute ?
        /// </summary>
        /// <param name="activityOperations">Activity operations</param>
        /// <param name="operationResult">Operation result</param>
        /// <returns></returns>
        bool IsExecute(ZActivityOperations activityOperations, ZOperationResult operationResult);

        /// <summary>
        /// Is dashboard ?
        /// </summary>
        /// <param name="domain">Domain name</param>
        /// <param name="dashboardDirectory">Dashboard directory</param>
        /// <param name="dashboardName">Dashboard name</param>
        /// <param name="operationResult">Operation result</param>
        /// <returns></returns>
        bool IsDashboard(string domain, string dashboardDirectory, string dashboardName, ZOperationResult operationResult);

        /// <summary>
        /// Is report ?
        /// </summary>
        /// <param name="domain">Domain name</param>
        /// <param name="reportDirectory">Report directory</param>
        /// <param name="reportName">Report name</param>
        /// <param name="operationResult">Operation result</param>
        /// <returns></returns>
        bool IsReport(string domain, string reportDirectory, string reportName, ZOperationResult operationResult);

        /// <summary>
        /// Is task ?
        /// </summary>
        /// <param name="domain">Domain name</param>
        /// <param name="taskName">Task name</param>
        /// <param name="operationResult">Operation result</param>
        /// <returns></returns>
        bool IsTask(string domain, string taskName, ZOperationResult operationResult);

        /// <summary>
        /// Is search | create | read | update | delete ?
        /// </summary>
        /// <param name="activityOperations">Activity operations</param>
        /// <param name="operationResult">Operation result</param>
        /// <returns></returns>
        bool IsSCRUD(ZActivityOperations activityOperations, ZOperationResult operationResult);

        #endregion Methods IsOperation

        #region Methods Message

        /// <summary>
        /// Message authorized.
        /// </summary>
        /// <param name="activityName">Activity name</param>
        /// <param name="operation">Operation</param>
        /// <returns></returns>
        string MessageAuthorized(string activityName, ZOperations operation);

        /// <summary>
        /// Message NOT authorized.
        /// </summary>
        /// <param name="activityName">Activity name</param>
        /// <param name="operation">Operation</param>
        /// <returns></returns>
        string MessageNotAuthorized(string activityName, ZOperations operation);

        #endregion Methods Message
    }
}