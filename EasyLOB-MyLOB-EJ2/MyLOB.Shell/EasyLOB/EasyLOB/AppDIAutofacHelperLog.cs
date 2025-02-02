using Autofac;
using EasyLOB.Log;

namespace EasyLOB
{
    public static partial class AppDIAutofacHelper
    {
        public static void SetupLog(ContainerBuilder containerBuilder)
        {
            //containerBuilder.RegisterType<LogManagerMock>().As<ILogManager>()
            //    .SingleInstance();
            containerBuilder.RegisterType<LogManagerNLog>().As<ILogManager>()
                .SingleInstance();
        }
    }
}