using Autofac;
using EasyLOB.Identity;
using EasyLOB.Identity.Application;
using EasyLOB.Identity.Persistence;
using EasyLOB.Security;

namespace EasyLOB
{
    public static partial class AppDIAutofacHelper
    {
        public static void SetupIdentity(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<AuthenticationManagerMock>().As<IAuthenticationManager>()
                .InstancePerLifetimeScope();
            //containerBuilder.RegisterType<AuthenticationManager>().As<IAuthenticationManager>()
            //    .InstancePerLifetimeScope();

            containerBuilder.RegisterGeneric(typeof(IdentityGenericApplication<>)).As(typeof(IIdentityGenericApplication<>))
                .InstancePerLifetimeScope();
            containerBuilder.RegisterGeneric(typeof(IdentityGenericApplicationDTO<,>)).As(typeof(IIdentityGenericApplicationDTO<,>))
                .InstancePerLifetimeScope();

            // Entity Framework
            containerBuilder.RegisterType<IdentityUnitOfWorkEF>().As<IIdentityUnitOfWork>()
                .InstancePerLifetimeScope();
            containerBuilder.RegisterGeneric(typeof(IdentityGenericRepositoryEF<>)).As(typeof(IIdentityGenericRepository<>))
                .InstancePerLifetimeScope();
            containerBuilder.RegisterType<IdentityManagerEF>().As<IIdentityManager>()
                .InstancePerLifetimeScope();

            // NHibernate
            //containerBuilder.RegisterType<IdentityUnitOfWorkEF>().As<IIdentityUnitOfWork>()
            //    .InstancePerLifetimeScope();
            //containerBuilder.RegisterGeneric(typeof(IdentityGenericRepositoryEF<>)).As(typeof(IIdentityGenericRepository<>))
            //    .InstancePerLifetimeScope();
            //containerBuilder.RegisterType<IdentityManagerNH>().As<IIdentityManager>()
            //    .InstancePerLifetimeScope();
        }
    }
}