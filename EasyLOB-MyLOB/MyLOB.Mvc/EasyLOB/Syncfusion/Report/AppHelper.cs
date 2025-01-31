//using EasyLOB.Data;
using EasyLOB.Environment;
using EasyLOB.Persistence;
using Syncfusion.EJ.ReportWriter;
using Syncfusion.Reports.EJ; // DataSourceCredentials
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace EasyLOB
{
    public static partial class AppHelper
    {
        #region Methods Reports

        public static global::Syncfusion.RDL.DOM.ReportDefinition DeSerializeReport(string reportPath)
        {
            global::Syncfusion.RDL.DOM.ReportDefinition reportDefinition = new global::Syncfusion.RDL.DOM.ReportDefinition();

            FileInfo info = new FileInfo(reportPath);
            FileStream stream = new FileStream(info.FullName, FileMode.Open, FileAccess.Read, FileShare.Read);
            XElement rdl = XElement.Load(XmlReader.Create(stream));
            string Namespace = (from attribute in rdl.Attributes() where attribute.Name.LocalName == "xmlns" select attribute.Value).FirstOrDefault();
            string Version = (Regex.IsMatch(Namespace, @"\d{4}") ? Regex.Match(Namespace, @"\d{4}").Value : string.Empty);
            XmlSerializer xs = new XmlSerializer(typeof(global::Syncfusion.RDL.DOM.ReportDefinition), Namespace);
            using (StringReader reader = new StringReader(rdl.ToString()))
            {
                reportDefinition = (global::Syncfusion.RDL.DOM.ReportDefinition)xs.Deserialize(reader);
            }
            stream.Close();

            return reportDefinition;
        }

        public static bool RDLExport(ZOperationResult operationResult, ref string exportPath, string exportFormat,
            string reportDirectory, string reportName, IDictionary<string, string> reportParameters)
        {
            try
            {
                ReportWriter reportWriter = new ReportWriter();
                reportWriter.ReportPath = "/" + MultiTenantHelper.Tenant.Name +
                    (string.IsNullOrEmpty(reportDirectory) ? "" : "/" + reportDirectory) +
                    "/" + reportName;
                reportWriter.ReportProcessingMode = ProcessingMode.Remote;

                // Report Credentials

                string user = ConfigurationHelper.AppSettings<string>("EasyLOB.Report.RDL.User");
                string password = ConfigurationHelper.AppSettings<string>("EasyLOB.Report.RDL.Password");
                reportWriter.ReportServerCredential = new System.Net.NetworkCredential(user, password);

                reportWriter.ReportServerUrl = ConfigurationHelper.AppSettings<string>("EasyLOB.Report.RDL.Url");

                // Data Source Credentials

                string connection = reportDirectory;
                string[] userPassword = AdoNetHelper.GetUserPassword(connection);
                DataSourceCredentials dataSourceCredentials = new DataSourceCredentials(connection, userPassword[0], userPassword[1]);
                reportWriter.SetDataSourceCredentials(new DataSourceCredentials[] { dataSourceCredentials });

                // Parameter(s)

                IList<ReportParameter> reportWriterParameters = new List<ReportParameter>(); // Syncfusion.Reports.EJ.ReportParameter
                foreach(KeyValuePair<string, string> keyValue in reportParameters)
                {
                    ReportParameter reportParameter = new ReportParameter();
                    reportParameter.Name = keyValue.Key;
                    reportParameter.Values.Add(keyValue.Value);
                    reportWriterParameters.Add(reportParameter);
                }
                reportWriter.SetParameters(reportWriterParameters);

                // Data Source(s) & DataSet(s)

                // Export

                string fileExtension = ".pdf";
                WriterFormat writerFormat = WriterFormat.PDF;
                switch (exportFormat.ToLower())
                {
                    case "doc":
                        fileExtension = ".doc";
                        writerFormat = WriterFormat.Word;
                        break;

                    case "xls":
                        fileExtension = ".xls";
                        writerFormat = WriterFormat.Excel;
                        break;
                }
                exportPath = exportPath.Trim() + fileExtension;
                FileStream fileStream = new FileStream(exportPath, FileMode.Create);
                reportWriter.Save(fileStream, writerFormat);
                fileStream.Close();

                operationResult.InformationMessage = exportPath;
            }
            catch (Exception exception)
            {
                operationResult.ParseException(exception);
            }

            return operationResult.Ok;
        }

        public static bool RDLCExport(ZOperationResult operationResult, ref string exportPath, string exportFormat,
            string rdlcDirectory, string reportDirectory, string reportName, IDictionary<string, string> reportParameters)
        {
            try
            {
                string reportPath = Path.Combine(rdlcDirectory,
                    MultiTenantHelper.Tenant.Name,
                    reportDirectory,
                    reportName + ".rdl");
                ReportWriter reportWriter = new ReportWriter(reportPath);
                reportWriter.ReportProcessingMode = ProcessingMode.Local;

                // Parameter(s)

                IList<ReportParameter> reportWriterParameters = new List<ReportParameter>(); // Syncfusion.Reports.EJ.ReportParameter
                foreach (KeyValuePair<string, string> keyValue in reportParameters)
                {
                    ReportParameter reportParameter = new ReportParameter();
                    reportParameter.Name = keyValue.Key;
                    reportParameter.Values.Add(keyValue.Value);
                    reportWriterParameters.Add(reportParameter);
                }
                //reportWriter.SetParameters(reportWriterParameters); // ???

                // Data Source(s) & Data Set(s)

                global::Syncfusion.RDL.DOM.ReportDefinition reportDefinition = DeSerializeReport(reportPath);
                IList<string> dataSetNames = reportWriter.GetDataSetNames();

                reportWriter.DataSources.Clear();
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
                        //foreach (var reportParameter in reportWriter.GetParameters()) // ???
                        foreach (var reportParameter in reportWriterParameters)
                        {
                            var defaultValue = reportParameter.Values.First() == null ? null : reportParameter.Values.First();

                            DbParameter parameter = command.CreateParameter();
                            //parameter.DbType = GetDbType(reportParameter.DataType); // ???
                            parameter.DbType = DbType.String;
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

                        reader = command.ExecuteReader(IsolationLevel.ReadUncommitted);

                        DataTable table = new DataTable();
                        table.Load(reader);

                        // System.Data.EnumerableRowCollection<System.Data.DataRow>
                        // https://msdn.microsoft.com/en-us/library/system.data.enumerablerowcollection%28v=vs.110%29.aspx
                        // System.Data.DataRow
                        // https://msdn.microsoft.com/en-us/library/system.data.datarow%28v=vs.110%29.aspx

                        reportWriter.DataSources.Add(new ReportDataSource { Name = dataSetName, Value = EasyLOB.Data.DataTableExtensions.AsEnumerable(table) });
                        //reportWriter.DataSources.Add(new ReportDataSource { Name = dataSetName, Value = table.AsEnumerable() });
                    }
                    catch (Exception exception)
                    {
                        operationResult.ParseException(exception);
                    }
                    finally
                    {
                        if (connection != null)
                        {
                            connection.Close();
                        }
                    }
                }

                if (operationResult.Ok)
                {

                    // Export

                    string fileExtension = ".pdf";
                    WriterFormat writerFormat = WriterFormat.PDF;
                    switch (exportFormat.ToLower())
                    {
                        case "doc":
                            fileExtension = ".doc";
                            writerFormat = WriterFormat.Word;
                            break;

                        case "xls":
                            fileExtension = ".xls";
                            writerFormat = WriterFormat.Excel;
                            break;
                    }

                    //PageSettings pageSettings = new PageSettings();
                    //pageSettings.LeftMargin = 0.39; // 10mm
                    //pageSettings.RightMargin = 0.39; // 10mm
                    //pageSettings.TopMargin = 0.39; // 10mm
                    //pageSettings.BottomMargin = 0.39; // 10mm
                    //pageSettings.PageWidth = 8.27; // 210mm
                    //pageSettings.PageHeight = 11.69; // 297mm
                    //reportWriter.PageSettings = pageSettings;

                    exportPath = exportPath.Trim() + fileExtension;
                    FileStream fileStream = new FileStream(exportPath, FileMode.Create);
                    reportWriter.Save(fileStream, writerFormat);
                    fileStream.Close();

                    operationResult.InformationMessage = exportPath;
                }
            }
            catch (Exception exception)
            {
                operationResult.ParseException(exception);
            }

            return operationResult.Ok;
        }

        #endregion Methods Reports
    }
}