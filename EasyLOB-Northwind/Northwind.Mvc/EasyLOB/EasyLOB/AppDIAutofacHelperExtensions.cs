using Autofac;
using EasyLOB.Extensions.Edm;
using EasyLOB.Extensions.Mail;

namespace EasyLOB
{
    public static partial class AppDIAutofacHelper
    {
        public static void SetupExtensions(ContainerBuilder containerBuilder)
        {
            //containerBuilder.RegisterType<EdmManagerMock>().As<IEdmManager>()
            //    .InstancePerLifetimeScope();
            containerBuilder.RegisterType<EdmManagerFileSystem>().As<IEdmManager>()
                .InstancePerDependency();
            //containerBuilder.RegisterType<EdmManagerFTP>().As<IEdmManager>()
            //    .InstancePerDependency();

            //containerBuilder.RegisterType<MailManagerMock>().As<IMailManager>()
            //    .InstancePerDependency();
            containerBuilder.RegisterType<MailManager>().As<IMailManager>()
                .InstancePerDependency();
        }
    }
}