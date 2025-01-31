using EasyLOB.Data;
using EasyLOB.Environment;
using EasyLOB.Persistence;
using Syncfusion.EJ.ReportViewer;
using Syncfusion.RDL.DOM;
using Syncfusion.Reports.EJ;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Http;
using System.Web.Script.Serialization;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

// RDL and Shared DataSources
// http://www.syncfusion.com/forums/119473/RDL-and-Shared-DataSources

// Report Viewer with RDLC error when using data from DataTable.AsEnumerable()
// https://www.syncfusion.com/support/directtrac/incidents/150777

namespace EasyLOB.Mvc
{
    public partial class RDLCApiController : ApiController, IReportController
    {
        Dictionary<string, object> JsonData = null;

        /// <summary>
        /// Action (HttpGet) method for getting resource for report.
        /// </summary>
        /// <param name="key">The unique key to get the required resource.</param>
        /// <param name="resourceType">The type of the requested resource.</param>
        /// <param name="isPrinting">If set to <see langword="true"/>, then the resource is generated for printing.</param>
        /// <returns>The object data.</returns>
        public object GetResource(string key, string resourceType, bool isPrinting)
        {
            return ReportHelper.GetResource(key, resourceType, isPrinting);
        }

        /// <summary>
        /// Report Initialization method that is triggered when report begin processed.
        /// </summary>
        /// <param name="reportOptions">The ReportViewer options.</param>
        public void OnInitReportOptions(ReportViewerOptions reportOptions)
        {
        }

        /// <summary>
        /// Report loaded method that is triggered when report and sub report begins to be loaded.
        /// </summary>
        /// <param name="reportOptions">The ReportViewer options.</param>
        public void OnReportLoaded(ReportViewerOptions reportOptions)
        {

            // User Parameters

            if (HttpContext.Current.Items.Contains("userParameters"))
            {
                reportOptions.ReportModel.Parameters =
                    new JavaScriptSerializer().Deserialize<List<global::Syncfusion.Reports.EJ.ReportParameter>>(HttpContext.Current.Items["userParameters"].ToString());
                HttpContext.Current.Items.Remove("userParameters");
            }

            // DataSet(s)

            reportOptions.ReportModel.DataSources.Clear();
            ReportDefinition reportDefinition = DeSerializeReport(reportOptions.ReportModel.ReportPath);
            ReportParameters reportParameters = reportDefinition.ReportParameters;
            IList<string> dataSetNames = ReportHelper.GetDataSetNames(JsonData, this);
            //IList<string> dataSetNames = ReportHelper.GetDataSetNames();
            foreach (var dataSetName in dataSetNames)
            {
                var dataSet = reportDefinition.DataSets.Where(x => x.Name == dataSetName);
                var connectionName = MultiTenantHelper.GetConnectionName(dataSet.First().Query.DataSourceName);
                var sql = dataSet.First().Query.CommandText;

                DbConnection connection = null;

                try
                {
                    DbProviderFactory provider;

                    provider = AdoNetHelper.GetProvider(connectionName);
                    connection = provider.CreateConnection();
                    connection.ConnectionString = AdoNetHelper.GetConnectionString(connectionName);
                    connection.Open();

                    DbCommand command;
                    DbDataReader reader;

                    command = provider.CreateCommand();
                    command.Connection = connection;
                    command.CommandTimeout = 600;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = sql;

                    command.Parameters.Clear();
                    if (reportOptions.ReportModel.Parameters != null && reportOptions.ReportModel.Parameters.Count() > 0)
                    {
                        int index = 0;
                        foreach (var userParameter in reportOptions.ReportModel.Parameters)
                        {
                            DbParameter parameter = command.CreateParameter();
                            parameter.DbType = GetDbType(reportParameters[index].DataType);
                            parameter.ParameterName = "@" + userParameter.Name;
                            parameter.Value = userParameter.Values.First();
                            command.Parameters.Add(parameter);

                            //command.AddParameterWithValue("@" + userParameter.Name, userParameter.Values.First());  // DbType.String

                            index++;
                        }
                    }
                    else
                    {
                        foreach (var reportParameter in reportParameters)
                        {
                            var defaultValue = reportParameter.DefaultValue == null ? null : reportParameter.DefaultValue.Values.First();

                            DbParameter parameter = command.CreateParameter();
                            parameter.DbType = GetDbType(reportParameter.DataType);
                            parameter.ParameterName = "@" + reportParameter.Name;
                            if (defaultValue == null)
                            {
                                parameter.Value = DBNull.Value;
                            }
                            else
                            {
                                parameter.Value = defaultValue;
                            }
                            command.Parameters.Add(parameter);

                            //command.AddParameterWithValue("@" + reportParameter.Name, defaultValue);
                        }
                    }

                    reader = command.ExecuteReader(IsolationLevel.ReadUncommitted);

                    DataTable table = new DataTable();
                    table.Load(reader);

                    // System.Data.EnumerableRowCollection<System.Data.DataRow>
                    // https://msdn.microsoft.com/en-us/library/system.data.enumerablerowcollection%28v=vs.110%29.aspx
                    // System.Data.DataRow
                    // https://msdn.microsoft.com/en-us/library/system.data.datarow%28v=vs.110%29.aspx

                    reportOptions.ReportModel.DataSources.Add(new ReportDataSource { Name = dataSetName, Value = table.AsEnumerable() });
                }
                catch // (Exception exception)
                {
                }
                finally
                {
                    if (connection != null)
                    {
                        connection.Close();
                    }
                }
            }
        }

        /// <summary>
        /// Action (HttpPost) method for posting the request for report process.
        /// </summary>
        /// <param name="jsonData">The JSON data posted for processing report.</param>
        /// <returns>The object data.</returns>
        public object PostReportAction(Dictionary<string, object> jsonData)
        {
            JsonData = jsonData;

            // Parameters
            if (jsonData.ContainsValue("GetDataSourceCredential") && jsonData.ContainsKey("params"))
            {
                HttpContext.Current.Items.Add("userParameters", jsonData["params"]);
            }

            return ReportHelper.ProcessReport(jsonData, this);
        }

        private ReportDefinition DeSerializeReport(string reportPath)
        {
            ReportDefinition reportDefinition = new ReportDefinition();

            FileInfo info = new FileInfo(reportPath);
            FileStream stream = new FileStream(info.FullName, FileMode.Open, FileAccess.Read, FileShare.Read);
            XElement rdl = XElement.Load(XmlReader.Create(stream));
            string Namespace = (from attribute in rdl.Attributes() where attribute.Name.LocalName == "xmlns" select attribute.Value).FirstOrDefault();
            string Version = (Regex.IsMatch(Namespace, @"\d{4}") ? Regex.Match(Namespace, @"\d{4}").Value : string.Empty);
            XmlSerializer xs = new XmlSerializer(typeof(ReportDefinition), Namespace);
            using (StringReader reader = new StringReader(rdl.ToString()))
            {
                reportDefinition = (ReportDefinition)xs.Deserialize(reader);
            }
            stream.Close();

            return reportDefinition;
        }

        private DbType GetDbType(DataTypes type)
        {
            switch (type)
            {
                case global::Syncfusion.RDL.DOM.DataTypes.Boolean:
                    return DbType.Boolean;

                case global::Syncfusion.RDL.DOM.DataTypes.DateTime:
                    return DbType.DateTime;

                case global::Syncfusion.RDL.DOM.DataTypes.Decimal:
                    return DbType.Decimal;

                case global::Syncfusion.RDL.DOM.DataTypes.Float:
                    return DbType.Double;

                case global::Syncfusion.RDL.DOM.DataTypes.Integer:
                    return DbType.Int32;

                case global::Syncfusion.RDL.DOM.DataTypes.String:
                    return DbType.String;

                default:
                    return DbType.String;
            }
        }
    }
}