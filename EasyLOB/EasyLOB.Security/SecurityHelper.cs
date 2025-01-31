using System;

namespace EasyLOB.Security
{
    /// <summary>
    /// Security Helper.
    /// </summary>
    public static partial class SecurityHelper
    {
        #region Properties

        /// <summary>
        /// Operations acronyms.
        /// </summary>
        public static string[] OperationAcronyms
        {
            get
            {
                return new string[] {
                    "I", // Index
                    "S", // Search
                    "C", // Create
                    "R", // Read
                    "U", // Update
                    "D", // Delete
                    "E", // Export
                    "X"  // Execute
                };
            }
        }

        /// <summary>
        /// Operations names.
        /// </summary>
        public static string[] OperationNames
        {
            get
            {
                return new string[] {
                    "Index", // Index
                    "Search", // Search
                    "Create", // Create
                    "Read",   // Read
                    "Update", // Update
                    "Delete", // Delete
                    "Export", // Export
                    "Execute" // Execute
                };
            }
        }

        #endregion Properties

        #region Methods Activity

        /// <summary>
        /// Get dashboard activity name.
        /// </summary>
        /// <param name="domain">Domain</param>
        /// <param name="dashboardDirectory">Directory</param>
        /// <param name="dashboardName">Dashboard</param>
        /// <returns></returns>
        public static string DashboardActivity(string domain, string dashboardDirectory, string dashboardName)
        {
            // Domain-Dashboard-DashboardName
            // Domain-Dashboard-DashboardDirectory-DashboardName

            domain = ""; // !?!

            string activity = "";

            if (!string.IsNullOrEmpty(domain))
            {
                activity = domain;
            }

            activity = activity + (activity == "" ? "" : "-") + "Dashboard";

            if (!string.IsNullOrEmpty(dashboardDirectory))
            {
                activity = activity + (activity == "" ? "" : "-") + dashboardDirectory;
            }

            if (!string.IsNullOrEmpty(dashboardName))
            {
                activity = activity + (activity == "" ? "" : "-") + dashboardName;
            }

            return activity;
        }

        /// <summary>
        /// Get entity activity name.
        /// </summary>
        /// <param name="domain">Domain</param>
        /// <param name="entity">Entity</param>
        /// <returns></returns>
        public static string EntityActivity(string domain, string entity)
        {
            // Domain-Entity

            domain = ""; // !?!

            string activity = "";

            if (!string.IsNullOrEmpty(domain))
            {
                activity = domain;
            }

            if (!string.IsNullOrEmpty(entity))
            {
                activity = activity + (activity == "" ? "" : "-") + entity;
            }

            return activity;
        }

        /// <summary>
        /// Get report activity name.
        /// </summary>
        /// <param name="domain">Domain</param>
        /// <param name="reportDirectory">Directory</param>
        /// <param name="reportName">Report</param>
        /// <returns></returns>
        public static string ReportActivity(string domain, string reportDirectory, string reportName)
        {
            // Domain-Report-ReportName
            // Domain-Report-ReportDirectory-ReportName

            domain = ""; // !?!

            string activity = "";

            if (!string.IsNullOrEmpty(domain))
            {
                activity = domain;
            }

            activity = activity + (activity == "" ? "" : "-") + "Report";

            if (!string.IsNullOrEmpty(reportDirectory))
            {
                activity = activity + (activity == "" ? "" : "-") + reportDirectory;
            }

            if (!string.IsNullOrEmpty(reportName))
            {
                activity = activity + (activity == "" ? "" : "-") + reportName;
            }

            return activity;
        }

        /// <summary>
        /// Get task activity name.
        /// </summary>
        /// <param name="domain">Domain</param>
        /// <param name="taskName">Task</param>
        /// <returns></returns>
        public static string TaskActivity(string domain, string taskName)
        {
            // Domain-Task-TaskName

            domain = ""; // !?!

            string activity = "";

            if (!string.IsNullOrEmpty(domain))
            {
                activity = domain;
            }

            activity = activity + (activity == "" ? "" : "-") + "Task";

            if (!string.IsNullOrEmpty(taskName))
            {
                activity = activity + (activity == "" ? "" : "-") + taskName;
            }

            return activity;
        }

        #endregion Methods Activity

        #region Methods GetSecurityOperations

        /// <summary>
        /// Get acronym from operation.
        /// </summary>
        /// <param name="operation">Operation</param>
        /// <returns></returns>
        public static string GetSecurityOperationAcronym(ZOperations operation)
        {
            string result = "";

            try
            {
                int index = (int)operation;
                result = OperationAcronyms[index];
            }
            catch
            {
            }

            return result;
        }

        /// <summary>
        /// Get operation from acronym.
        /// </summary>
        /// <param name="acronym">Acronym</param>
        /// <returns></returns>
        public static ZOperations GetSecurityOperationByAcronym(string acronym)
        {
            ZOperations result = ZOperations.None;

            try
            {
                int index = Array.IndexOf(OperationAcronyms, acronym);
                if (index > 0)
                {
                    result = (ZOperations)index;
                }
            }
            catch
            {
            }

            return result;
        }

        /// <summary>
        /// Get operation by name.
        /// </summary>
        /// <param name="operationName">Operation name</param>
        /// <returns></returns>
        public static ZOperations GetSecurityOperationByName(string operationName)
        {
            ZOperations result = ZOperations.None;

            try
            {
                int index = Array.IndexOf(OperationNames, operationName);
                if (index > 0)
                {
                    result = (ZOperations)index;
                }
            }
            catch
            {
            }

            return result;
        }

        /// <summary>
        /// Get name from operation.
        /// </summary>
        /// <param name="operation"></param>
        /// <returns></returns>
        public static string GetSecurityOperationName(ZOperations operation)
        {
            string result = "";

            try
            {
                int index = (int)operation;
                result = OperationNames[index];
            }
            catch
            {
            }

            return result;
        }

        #endregion Methods GetSecurityOperations

        #region Methods GetIsSecurityOperation

        /// <summary>
        /// Get "Is Operation" from activity operations.
        /// </summary>
        /// <param name="activityOperations">Activity operations</param>
        /// <param name="operation">Operation</param>
        /// <returns></returns>
        public static bool GetIsSecurityOperation(ZActivityOperations activityOperations, ZOperations operation)
        {
            bool result = false;

            switch (operation)
            {
                case ZOperations.Index:
                    result = activityOperations.IsIndex;
                    break;

                case ZOperations.Search:
                    result = activityOperations.IsSearch;
                    break;

                case ZOperations.Create:
                    result = activityOperations.IsCreate;
                    break;

                case ZOperations.Read:
                    result = activityOperations.IsRead;
                    break;

                case ZOperations.Update:
                    result = activityOperations.IsUpdate;
                    break;

                case ZOperations.Delete:
                    result = activityOperations.IsDelete;
                    break;

                case ZOperations.Export:
                    result = activityOperations.IsExport;
                    break;

                case ZOperations.Execute:
                    result = activityOperations.IsExecute;
                    break;
            }

            return result;
        }

        /// <summary>
        /// Get "Is Operation" from activity operations by acronym.
        /// </summary>
        /// <param name="activityOperations">Activity operations</param>
        /// <param name="acronym">Acronym</param>
        /// <returns></returns>
        public static bool GetIsSecurityOperationByAcronym(ZActivityOperations activityOperations, string acronym)
        {
            return GetIsSecurityOperation(activityOperations, SecurityHelper.GetSecurityOperationByAcronym(acronym));
        }

        /// <summary>
        /// Get "Is Operation" from activity operations by name.
        /// </summary>
        /// <param name="activityOperations">Activity operations</param>
        /// <param name="operationName">Operation name</param>
        /// <returns></returns>
        public static bool GetIsSecurityOperationByName(ZActivityOperations activityOperations, string operationName)
        {
            return GetIsSecurityOperation(activityOperations, SecurityHelper.GetSecurityOperationByName(operationName));
        }

        #endregion Methods GetIsSecurityOperation
    }
}