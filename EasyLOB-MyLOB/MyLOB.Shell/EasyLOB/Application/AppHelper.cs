using Autofac;
using AutoMapper;
using EasyLOB.Activity.Data;
using EasyLOB.AuditTrail.Data;
using EasyLOB.Data;
using EasyLOB.Environment;
using EasyLOB.Identity.Data;
using MyLOB;
using MyLOB.Data;

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
            MyLOBEnvironmentHelper.Setup(environmentManager);

            // MultiTenantHelper
            MultiTenantHelper.Setup(environmentManager);
            MyLOBMultiTenantHelper.Setup(environmentManager);

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
                cfg.AddProfile<MyLOBDataAutoMapper>(); // !!!
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
            DataHelper.SetupDataProfiles("MyLOB.Data"); // !!!
        }

        #endregion Methods
    }
}