using System;

namespace EasyLOB.Shell
{
    partial class Program
    {
        private static void DemoConfiguration()
        {
            Console.WriteLine("\nConfiguration Demo");

            try
            {
                Console.WriteLine("\nConfiguration: {0}",
                    ConfigurationHelper.AppSettings<string>("EasyLOB.Directory.Configuration"));
                Console.WriteLine("Export: {0}",
                    ConfigurationHelper.AppSettings<string>("EasyLOB.Directory.Export"));
                Console.WriteLine("Import: {0}",
                    ConfigurationHelper.AppSettings<string>("EasyLOB.Directory.Import"));
                Console.WriteLine("Template: {0}",
                    ConfigurationHelper.AppSettings<string>("EasyLOB.Directory.Template"));
            }
            catch (Exception exception)
            {
                WriteHelper.WriteException(exception);
            }
        }
    }
}