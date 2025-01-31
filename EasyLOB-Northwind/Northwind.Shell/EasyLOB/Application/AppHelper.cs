using Autofac;
using AutoMapper;
using EasyLOB.Activity.Data;
using EasyLOB.AuditTrail.Data;
using EasyLOB.Data;
using EasyLOB.Environment;
using EasyLOB.Identity.Data;
using Northwind;
using Northwind.Data;

namespace EasyLOB
{
    public static partial class AppHelper
    {
        #region Methods

        public static void Setup(ContainerBuilder containerBuilder)
        {
            // Autofac
            IContainer container = AppDIAutofacHelper.Setup(containerBuilder);
            IDIManager diManager = new DIManagerAutofac(container);

            // AutoMapper
            IMapper mapper = SetupMappers();

            EasyLOBHelper.Setup(diManager, mapper);

            IEnvironmentManager environmentManager = EasyLOBHelper.GetService<IEnvironmentManager>();

            // EnvironmentHelper
            EnvironmentHelper.Setup(environmentManager);
            NorthwindEnvironmentHelper.Setup(environmentManager);

            // MultiTenantHelper
            MultiTenantHelper.Setup(environmentManager);
            NorthwindMultiTenantHelper.Setup(environmentManager);

            // Profiles
            SetupProfiles();
        }

        public static IMapper SetupMappers()
        {
            MapperConfiguration config = new MapperConfiguration(cfg => {
                // ZDataModel <-> ZDTOModel
                // Activity
                cfg.AddProfile<ActivityDataAutoMapper>();
                // Audit Trail
                cfg.AddProfile<AuditTrailDataAutoMapper>();
                // Identity
                cfg.AddProfile<IdentityDataAutoMapper>();
                // Application
                cfg.AddProfile<NorthwindDataAutoMapper>(); // !!!
            });

            config.CompileMappings();
            config.AssertConfigurationIsValid();

            return config.CreateMapper();
        }

        public static void SetupProfiles()
        {
            // ZDataModel
            // Activity
            DataHelper.SetupDataProfiles("EasyLOB.Activity.Data");
            // Audit Trail
            DataHelper.SetupDataProfiles("EasyLOB.AuditTrail.Data");
            // Identity
            DataHelper.SetupDataProfiles("EasyLOB.Identity.Data");
            // Application
            DataHelper.SetupDataProfiles("Northwind.Data"); // !!!
        }

        #endregion Methods
    }
}