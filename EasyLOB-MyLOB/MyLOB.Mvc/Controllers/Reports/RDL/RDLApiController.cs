using Syncfusion.EJ.ReportViewer;
using System.Collections.Generic;
using System.Web.Http;

namespace EasyLOB.Mvc
{
    public class RDLApiController : ApiController, IReportController
    {
        /// <summary>
        /// Action (HttpGet) method for getting resource for report.
        /// </summary>
        /// <param name="key">The unique key to get the required resource.</param>
        /// <param name="resourceType">The type of the requested resource.</param>
        /// <param name="isPrinting">If set to <see langword="true"/>, then the resource is generated for printing.</param>
        /// <returns>The object data.</returns>
        public object GetResource(string key, string resourceType, bool isPrinting)
        {
            // Returns the report resource for the requested key.
            return ReportHelper.GetResource(key, resourceType, isPrinting);
        }

        /// <summary>
        /// Report Initialization method that is triggered when report begin processed.
        /// </summary>
        /// <param name="reportOptions">The ReportViewer options.</param>
        public void OnInitReportOptions(ReportViewerOptions reportOptions)
        {
            //throw new NotImplementedException();

            // Add RDL Server and database credentials here

            // Report Server

            string user = ConfigurationHelper.AppSettings<string>("EasyLOB.Report.RDL.User");
            string password = ConfigurationHelper.AppSettings<string>("EasyLOB.Report.RDL.Password");
            reportOptions.ReportModel.ReportServerCredential = new System.Net.NetworkCredential(user, password);
            //string domain = ConfigurationHelper.AppSettings<string>("EasyLOB.Report.RDL.Domain");
            //reportOptions.ReportModel.ReportServerCredential = new System.Net.NetworkCredential(user, password, domain);

            // Report Path

            //reportOptions.ReportModel.ReportPath = ...

            // Data Source Credentials

            //string connection = MultiTenantHelper.Tenant.Connections[0].ConnectionName;
            //string[] userPassword = AdoNetHelper.GetUserPassword(connection);
            //DataSourceCredentials dataSourceCredentials = new DataSourceCredentials(connection, userPassword[0], userPassword[1]);
            //reportOptions.ReportModel.DataSourceCredentials.Add(dataSourceCredentials);
        }

        /// <summary>
        /// Report loaded method that is triggered when report and sub report begins to be loaded.
        /// </summary>
        /// <param name="reportOptions">The ReportViewer options.</param>
        public void OnReportLoaded(ReportViewerOptions reportOptions)
        {
            //throw new NotImplementedException();
        }

        /// <summary>
        /// Action (HttpPost) method for posting the request for report process.
        /// </summary>
        /// <param name="jsonData">The JSON data posted for processing report.</param>
        /// <returns>The object data.</returns>
        public object PostReportAction(Dictionary<string, object> jsonData)
        {
            // Processes the report request and returns the result.
            return ReportHelper.ProcessReport(jsonData, this);
        }
    }
}