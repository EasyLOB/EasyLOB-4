using EasyLOB.Activity.Data;
using System;

namespace EasyLOB.Shell
{
    partial class Program
    {
        private static void AutoMapperActivityDemo()
        {
            Console.WriteLine("\nApplication Activity DTO -> Data -> DTO\n");

            {
                Console.WriteLine("Activity");
                EasyLOB.Activity.Data.Activity data = new EasyLOB.Activity.Data.Activity();
                ActivityDTO dto = EasyLOBHelper.Mapper.Map<ActivityDTO>(data);
                data = EasyLOBHelper.Mapper.Map<EasyLOB.Activity.Data.Activity>(dto);
            }

            {
                Console.WriteLine("ActivityRole");
                ActivityRole data = new ActivityRole();
                ActivityRoleDTO dto = EasyLOBHelper.Mapper.Map<ActivityRoleDTO>(data);
                data = EasyLOBHelper.Mapper.Map<ActivityRole>(dto);
            }
        }
    }
}
