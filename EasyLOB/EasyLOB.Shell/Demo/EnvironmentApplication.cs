using System;

namespace EasyLOB.Shell
{
    partial class Program
    {
        private static void DemoEnvironmentApplication()
        {
            Console.WriteLine("\nAppDomain.CurrentDomain.BaseDirectory: {0}", AppDomain.CurrentDomain.BaseDirectory);

            string path = ConfigurationHelper.AppSettings<string>("EasyLOB.Directory.Configuration");

            IEnvironmentManager environmentManager = EasyLOBHelper.GetService<IEnvironmentManager>();

            Console.WriteLine("\nApplication Demo");
            Console.WriteLine("\nApplicationDirectory: {0}", environmentManager.ApplicationDirectory);
            Console.WriteLine("WebDirectory(path): {0}", environmentManager.ApplicationPath(path));
            Console.WriteLine("IsWeb: {0}", environmentManager.IsWeb.ToString());
            Console.WriteLine("WebUrl: {0}", environmentManager.WebUrl);
            Console.WriteLine("WebPath: {0}", environmentManager.WebPath);
            Console.WriteLine("WebDomain: {0}", environmentManager.WebDomain);
            Console.WriteLine("WebSubDomain: {0}", environmentManager.WebSubDomain);
        }
    }
}