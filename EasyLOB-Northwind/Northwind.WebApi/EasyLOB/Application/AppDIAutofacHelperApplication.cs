using Autofac;
using Northwind;
using Northwind.Application;
using Northwind.Persistence;

namespace EasyLOB
{
    public static partial class AppDIAutofacHelper
    {
        public static void SetupApplication(ContainerBuilder containerBuilder) // !!!
        {
            /*
            containerBuilder.RegisterType<NorthwindApplication>().As<INorthwindApplication>()
                .InstancePerLifetimeScope();

            containerBuilder.RegisterGeneric(typeof(NorthwindGenericApplication<>)).As(typeof(INorthwindGenericApplication<>))
                .InstancePerLifetimeScope();
            containerBuilder.RegisterGeneric(typeof(NorthwindGenericApplicationDTO<,>)).As(typeof(INorthwindGenericApplicationDTO<,>))
                .InstancePerLifetimeScope();

            // Entity Framework
            containerBuilder.RegisterType<NorthwindUnitOfWorkEF>().As<INorthwindUnitOfWork>()
                .InstancePerLifetimeScope();
            containerBuilder.RegisterGeneric(typeof(NorthwindGenericRepositoryEF<>)).As(typeof(INorthwindGenericRepository<>))
                .InstancePerLifetimeScope();

            // LINQ to DB
            //containerBuilder.RegisterType<NorthwindUnitOfWorkLINQ2DB>().As<INorthwindUnitOfWork>()
            //    .InstancePerLifetimeScope();
            //containerBuilder.RegisterGeneric(typeof(NorthwindGenericRepositoryLINQ2DB<>)).As(typeof(INorthwindGenericRepository<>))
            //    .InstancePerLifetimeScope();

            // NHibernate
            //containerBuilder.RegisterType<NorthwindUnitOfWorkEF>().As<INorthwindUnitOfWork>()
            //    .InstancePerLifetimeScope();
            //containerBuilder.RegisterGeneric(typeof(NorthwindGenericRepositoryEF<>)).As(typeof(INorthwindGenericRepository<>))
            //    .InstancePerLifetimeScope();
            */
        }
    }
}