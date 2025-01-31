using Autofac;
using EasyLOB.Activity;
using EasyLOB.Activity.Application;
using EasyLOB.Activity.Persistence;
using EasyLOB.Security;

namespace EasyLOB
{
    public static partial class AppDIAutofacHelper
    {
        public static void SetupActivity(ContainerBuilder containerBuilder)
        {
            //containerBuilder.RegisterType<AuthorizationManagerMock>().As<IAuthorizationManager>();
            //    .InstancePerLifetimeScope();
            containerBuilder.RegisterType<AuthorizationManager>().As<IAuthorizationManager>()
                .InstancePerLifetimeScope();

            containerBuilder.RegisterGeneric(typeof(ActivityGenericApplication<>)).As(typeof(IActivityGenericApplication<>))
                .InstancePerLifetimeScope();
            containerBuilder.RegisterGeneric(typeof(ActivityGenericApplicationDTO<,>)).As(typeof(IActivityGenericApplicationDTO<,>))
                .InstancePerLifetimeScope();

            // Entity Framework
            containerBuilder.RegisterType<ActivityUnitOfWorkEF>().As<IActivityUnitOfWork>()
                .InstancePerLifetimeScope();
            containerBuilder.RegisterGeneric(typeof(ActivityGenericRepositoryEF<>)).As(typeof(IActivityGenericRepository<>))
                .InstancePerLifetimeScope();

            // LINQ to DB
            //containerBuilder.RegisterType<ActivityUnitOfWorkLINQ2DB>().As<IActivityUnitOfWork>()
            //    .InstancePerLifetimeScope();
            //containerBuilder.RegisterGeneric(typeof(ActivityGenericRepositoryLINQ2DB<>)).As(typeof(IActivityGenericRepository<>))
            //    .InstancePerLifetimeScope();

            // NHibernate
            //containerBuilder.RegisterType<ActivityUnitOfWorkEF>().As<IActivityUnitOfWork>()
            //    .InstancePerLifetimeScope();
            //containerBuilder.RegisterGeneric(typeof(ActivityGenericRepositoryEF<>)).As(typeof(IActivityGenericRepository<>))
            //    .InstancePerLifetimeScope();
        }
    }
}