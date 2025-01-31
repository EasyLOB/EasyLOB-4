using Autofac;
using EasyLOB.Environment;

namespace EasyLOB
{
    public static partial class AppDIAutofacHelper
    {
        #region Methods

        public static IContainer Setup(ContainerBuilder containerBuilder)
        {
            SetupActivity(containerBuilder);
            SetupAuditTrail(containerBuilder);
            SetupEasyLOB(containerBuilder);
            SetupExtensions(containerBuilder);
            SetupIdentity(containerBuilder);
            SetupLog(containerBuilder);

            SetupApplication(containerBuilder); // !!!

            containerBuilder.RegisterType<EnvironmentManagerDesktop>().As<IEnvironmentManager>()
                .SingleInstance();
            //containerBuilder.RegisterType<EnvironmentManagerWeb>().As<IEnvironmentManager>()
            //    .SingleInstance();

            return containerBuilder.Build();
        }

        #endregion Methods
    }
}