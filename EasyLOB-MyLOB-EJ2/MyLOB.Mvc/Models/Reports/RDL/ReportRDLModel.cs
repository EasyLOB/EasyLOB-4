using System.Collections.Generic;

namespace EasyLOB.Mvc
{
    public class ReportRDLModel
    {
        public ZOperationResult OperationResult { get; set; }

        public string ReportDirectory { get; set; }

        public string ReportName { get; set; }

        public IDictionary<string, object> ReportParameters { get; set; }

        public ReportRDLModel()
        {
            OperationResult = new ZOperationResult();
            ReportParameters = new Dictionary<string, object>();
        }
    }
}