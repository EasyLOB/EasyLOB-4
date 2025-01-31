using EasyLOB.AuditTrail.Data;
using System;

namespace EasyLOB.Shell
{
    partial class Program
    {
        private static void AutoMapperAuditTrailDemo()
        {
            Console.WriteLine("\nApplication AuditTrail DTO -> Data -> DTO\n");

            {
                Console.WriteLine("AuditTrailConfiguration");
                AuditTrailConfiguration data = new AuditTrailConfiguration();
                AuditTrailConfigurationDTO dto = EasyLOBHelper.Mapper.Map<AuditTrailConfigurationDTO>(data);
                data = EasyLOBHelper.Mapper.Map<AuditTrailConfiguration>(dto);
            }

            {
                Console.WriteLine("AuditTrailLog");
                AuditTrailLog data = new AuditTrailLog();
                AuditTrailLogDTO dto = EasyLOBHelper.Mapper.Map<AuditTrailLogDTO>(data);
                data = EasyLOBHelper.Mapper.Map<AuditTrailLog>(dto);
            }
        }
    }
}
