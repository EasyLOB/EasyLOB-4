using EasyLOB.AuditTrail.Data;
using EasyLOB.Data;
using EasyLOB.Library;
using EasyLOB.Resources;
using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Resources;
using System.Threading;

namespace EasyLOB.Shell
{
    partial class Program
    {
        private static void DemoResources()
        {
            Console.WriteLine("\nResources Demo");

            try
            {
                Console.WriteLine();

                Type type = LibraryHelper.GetType("EasyLOB.AuditTrail.Data.Resources.AuditTrailLogResources");
                Console.WriteLine(LibraryHelper.GetStaticPropertyValue(type, "EntitySingular"));

                AuditTrailLog auditTrailLog = new AuditTrailLog();
                Console.WriteLine(auditTrailLog.GetResource("EntitySingular"));

                CultureInfo enUS = new CultureInfo("en-US");
                CultureInfo ptBR = new CultureInfo("pt-BR");

                // Resource Manager static Class

                Console.WriteLine("\nResource Manager static Class");
                Console.WriteLine(ErrorResources.EMailInvalidFrom);
                SetCulture("en-US");
                Console.WriteLine(ErrorResources.EMailInvalidFrom);
                SetCulture("pt-BR");
                Console.WriteLine(ErrorResources.EMailInvalidFrom);

                // ResourceManager

                ResourceManager rm;

                rm = new ResourceManager("EasyLOB.Resources.DataAnnotationResources", LibraryHelper.GetAssembly("EasyLOB"));

                Console.WriteLine("\nResource Manager");
                Console.WriteLine(rm.GetString("Range"));
                Console.WriteLine(rm.GetString("Range", enUS));
                Console.WriteLine(rm.GetString("Range", ptBR));

                // Data Annotations

                AuditTrailConfigurationViewModel viewModel = new AuditTrailConfigurationViewModel();
                DisplayAttribute attribute = viewModel.GetAttributeFrom<DisplayAttribute>("Entity");

                Console.WriteLine("\nData Annotations");
                Console.WriteLine(attribute.GetName());
                SetCulture("en-US");
                Console.WriteLine(attribute.GetName());
                SetCulture("pt-BR");
                Console.WriteLine(attribute.GetName());
            }
            catch (Exception exception)
            {
                WriteHelper.WriteException(exception);
            }
        }

        private static void SetCulture(string culture)
        {
            CultureInfo cultureInfo = new CultureInfo(culture);
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;
        }

        private static void SetCulture(CultureInfo cultureInfo)
        {
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;
        }
    }
}