using System.Collections.Generic;

namespace EasyLOB.Mvc
{
    public class ReportRDLCModel
    {
        public ZOperationResult OperationResult { get; set; }

        public string ReportDirectory { get; set; }

        public string ReportName { get; set; }

        public IDictionary<string, object> ReportParameters { get; set; }

        public ReportRDLCModel()
        {
            OperationResult = new ZOperationResult();
            ReportParameters = new Dictionary<string, object>();
        }
    }
}