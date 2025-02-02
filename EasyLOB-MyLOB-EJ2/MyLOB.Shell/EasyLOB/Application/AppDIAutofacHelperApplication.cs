using Autofac;
using MyLOB;
using MyLOB.Application;
using MyLOB.Persistence;

namespace EasyLOB
{
    public static partial class AppDIAutofacHelper
    {
        public static void SetupApplication(ContainerBuilder containerBuilder) // !!!
        {
            /*
            containerBuilder.RegisterType<MyLOBApplication>().As<IMyLOBApplication>()
                .InstancePerLifetimeScope();

            containerBuilder.RegisterGeneric(typeof(MyLOBGenericApplication<>)).As(typeof(IMyLOBGenericApplication<>))
                .InstancePerLifetimeScope();
            containerBuilder.RegisterGeneric(typeof(MyLOBGenericApplicationDTO<,>)).As(typeof(IMyLOBGenericApplicationDTO<,>))
                .InstancePerLifetimeScope();

            // Entity Framework
            containerBuilder.RegisterType<MyLOBUnitOfWorkEF>().As<IMyLOBUnitOfWork>()
                .InstancePerLifetimeScope();
            containerBuilder.RegisterGeneric(typeof(MyLOBGenericRepositoryEF<>)).As(typeof(IMyLOBGenericRepository<>))
                .InstancePerLifetimeScope();

            // LINQ to DB
            //containerBuilder.RegisterType<MyLOBUnitOfWorkLINQ2DB>().As<IMyLOBUnitOfWork>()
            //    .InstancePerLifetimeScope();
            //containerBuilder.RegisterGeneric(typeof(MyLOBGenericRepositoryLINQ2DB<>)).As(typeof(IMyLOBGenericRepository<>))
            //    .InstancePerLifetimeScope();

            // NHibernate
            //containerBuilder.RegisterType<MyLOBUnitOfWorkEF>().As<IMyLOBUnitOfWork>()
            //    .InstancePerLifetimeScope();
            //containerBuilder.RegisterGeneric(typeof(MyLOBGenericRepositoryEF<>)).As(typeof(IMyLOBGenericRepository<>))
            //    .InstancePerLifetimeScope();
            */
        }
    }
}