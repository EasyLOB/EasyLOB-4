using EasyLOB.Library;
using Syncfusion.RDL.DOM;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace EasyLOB.Mvc
{
    public partial class ReportsController
    {
        public ActionResult RDLCExport(string exportFormat, string reportDirectory, string reportName)
        {
            OperationResultModel viewModel = new OperationResultModel();

            try
            {
                string exportPath = Path.Combine(Server.MapPath(ConfigurationHelper.AppSettings<string>("EasyLOB.Directory.Export")),
                    reportName + string.Format(".{0:yyyyMMdd.HHmmss.fff}", DateTime.Now));

                string rdlcDirectory = Server.MapPath(ConfigurationHelper.AppSettings<string>("EasyLOB.Report.RDLC.Directory"));

                IDictionary<string, string> reportParameters = new Dictionary<string, string>();
                if (System.Web.HttpContext.Current.Request.QueryString.Count > 3)
                {
                    for (int q = 3; q < System.Web.HttpContext.Current.Request.QueryString.Count; q++)
                    {
                        reportParameters.Add(System.Web.HttpContext.Current.Request.QueryString.AllKeys[q],
                            System.Web.HttpContext.Current.Request.QueryString[q]);
                    }
                }

                if (AppHelper.RDLCExport(viewModel.OperationResult, ref exportPath, exportFormat,
                    rdlcDirectory, reportDirectory, reportName, reportParameters))
                {
                    byte[] file = System.IO.File.ReadAllBytes(exportPath);
                    return File(file,
                        EasyLOBHelper.GetContentType(EasyLOBHelper.GetFileType(Path.GetExtension(exportPath))),
                        Path.GetFileName(exportPath));
                }
            }
            catch (Exception exception)
            {
                viewModel.OperationResult.ParseException(exception);
            }

            return ZViewOperationResult(viewModel.OperationResult);
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
    }
}