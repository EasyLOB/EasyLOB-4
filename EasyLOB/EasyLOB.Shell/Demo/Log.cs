using System;

namespace EasyLOB.Shell
{
    partial class Program
    {
        private static void DemoLog()
        {
            Console.WriteLine("\nLog Demo");
            try
            {
                ILogManager logManager = EasyLOBHelper.GetService<ILogManager>();

                logManager.Trace("Trace");
                logManager.Debug("Debug");
                logManager.Information("Information");
                logManager.Warning("Warning");
                logManager.Error("Error");
                logManager.Fatal("Fatal");

                logManager.Trace("Trace {0} {1} {2}", new object[] { "ABC", 1.23, DateTime.Now });
                logManager.Debug("Debug {0} {1} {2}", new object[] { "ABC", 1.23, DateTime.Now });
                logManager.Information("Information {0} {1} {2}", new object[] { "ABC", 1.23, DateTime.Now });
                logManager.Warning("Warning {0} {1} {2}", new object[] { "ABC", 1.23, DateTime.Now });
                logManager.Error("Error {0} {1} {2}", new object[] { "ABC", 1.23, DateTime.Now });
                logManager.Fatal("Fatal {0} {1} {2}", new object[] { "ABC", 1.23, DateTime.Now });

                try
                {
                    int x = Int32.Parse("ABC");
                    int y = x + 1;
                }
                catch (Exception exception)
                {
                    logManager.Exception(exception, "Exception {0} {1} {2}", new object[] { "ABC", 1.23, DateTime.Now });
                }

                {
                    int x = Int32.Parse("ABC");
                    int y = x + 1;
                }
            }
            catch (Exception exception)
            {
                ZOperationResult operationResult = new ZOperationResult();
                operationResult.ParseException(exception);
                AppHelper.Log(operationResult, "OperationResult", "Header", "Footer");
            }
        }
    }
}