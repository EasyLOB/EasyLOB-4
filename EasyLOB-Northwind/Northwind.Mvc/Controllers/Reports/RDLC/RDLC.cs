using EasyLOB.Environment;
using EasyLOB.Resources;
using Syncfusion.JavaScript.Models.ReportViewer;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

// Syncfusion Report Viewer
// http://help.syncfusion.com/aspnetmvc/reportviewer/getting-started
// http://help.syncfusion.com/aspnetmvc/reportviewer/report-controller

namespace EasyLOB.Mvc
{
    public partial class ReportsController
    {
        [HttpGet]
        public ActionResult RDLC(string reportDirectory, string reportName)
        {
            ZOperationResult operationResult = new ZOperationResult();

            try
            {
                if (string.IsNullOrEmpty(reportName))
                {
                    operationResult.ErrorMessage = ErrorResources.RDL_Parameters;

                    return ZViewOperationResult(operationResult);
                }
                else
                {
                    if (!IsReport(reportDirectory, reportName, operationResult))
                    {
                        return ZViewOperationResult(operationResult);
                    }
                    else
                    {
                        ReportRDLCModel reportModel = new ReportRDLCModel();

                        reportModel.ReportDirectory = MultiTenantHelper.Tenant.Name +
                            (string.IsNullOrEmpty(reportDirectory) ? "" : "/" + reportDirectory);
                        reportModel.ReportName = reportName;

                        if (System.Web.HttpContext.Current.Request.QueryString.Count > 2)
                        {
                            for (int q = 2; q < System.Web.HttpContext.Current.Request.QueryString.Count; q++)
                            {
                                ReportParameter reportParameter = new ReportParameter
                                {
                                    Name = System.Web.HttpContext.Current.Request.QueryString.AllKeys[q],
                                    Labels = new List<string>() { "" },
                                    Prompt = "",
                                    Values = new List<string>() { System.Web.HttpContext.Current.Request.QueryString[q] },
                                    Nullable = true
                                };
                                reportModel.ReportParameters.Add(reportParameter);
                            }
                        }

                        return ZView("RDLC", reportModel);
                    }
                }
            }
            catch (Exception exception)
            {
                operationResult.ParseException(exception);
            }

            return ZViewOperationResult(operationResult);
        }
    }
}