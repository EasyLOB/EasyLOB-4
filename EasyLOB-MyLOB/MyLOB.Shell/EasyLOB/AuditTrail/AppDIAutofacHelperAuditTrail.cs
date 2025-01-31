using Autofac;
using EasyLOB.AuditTrail;
using EasyLOB.AuditTrail.Application;
using EasyLOB.AuditTrail.Persistence;

namespace EasyLOB
{
    public static partial class AppDIAutofacHelper
    {
        public static void SetupAuditTrail(ContainerBuilder containerBuilder)
        {
            //containerBuilder.RegisterType<AuditTrailManagerMock>().As<IAuditTrailManager>()
            //    .InstancePerLifetimeScope();
            containerBuilder.RegisterType<AuditTrailManager>().As<IAuditTrailManager>()
                .InstancePerLifetimeScope();

            containerBuilder.RegisterGeneric(typeof(AuditTrailGenericApplication<>)).As(typeof(IAuditTrailGenericApplication<>))
                .InstancePerLifetimeScope();
            containerBuilder.RegisterGeneric(typeof(AuditTrailGenericApplicationDTO<,>)).As(typeof(IAuditTrailGenericApplicationDTO<,>))
                .InstancePerLifetimeScope();

            // Entity Framework
            containerBuilder.RegisterType<AuditTrailUnitOfWorkEF>().As<IAuditTrailUnitOfWork>()
                .InstancePerLifetimeScope();
            containerBuilder.RegisterGeneric(typeof(AuditTrailGenericRepositoryEF<>)).As(typeof(IAuditTrailGenericRepository<>))
                .InstancePerLifetimeScope();

            // LINQ to DB
            //containerBuilder.RegisterType<AuditTrailUnitOfWorkLINQ2DB>().As<IAuditTrailUnitOfWork>()
            //    .InstancePerLifetimeScope();
            //containerBuilder.RegisterGeneric(typeof(AuditTrailGenericRepositoryLINQ2DB<>)).As(typeof(IAuditTrailGenericRepository<>))
            //    .InstancePerLifetimeScope();

            // NHibernate
            //containerBuilder.RegisterType<AuditTrailUnitOfWorkEF>().As<IAuditTrailUnitOfWork>()
            //    .InstancePerLifetimeScope();
            //containerBuilder.RegisterGeneric(typeof(AuditTrailGenericRepositoryEF<>)).As(typeof(IAuditTrailGenericRepository<>))
            //    .InstancePerLifetimeScope();
        }
    }
}