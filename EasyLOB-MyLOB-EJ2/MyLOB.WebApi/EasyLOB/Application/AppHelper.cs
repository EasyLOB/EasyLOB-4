using Autofac;
using AutoMapper;
using EasyLOB.Activity.Data;
using EasyLOB.AuditTrail.Data;
using EasyLOB.Data;
using EasyLOB.Environment;
using EasyLOB.Identity.Data;
using MyLOB;
using MyLOB.Data;
using System.Reflection;

namespace EasyLOB
{
    public static partial class AppHelper
    {
        #region Properties

        public static string AppName { get { return "MyLOB API"; } } // !!!

        public static string AppVersion { get { return "1.0"; } } // !!!

        public static string[] AppPath // !!!
        {
            get
            {
                return new string[] {
                    "MyLOB", // !!!
                    "MyLOB-Custom", // !!!
                    "Activity",
                    "Activity-Custom",
                    "AuditTrail",
                    "AuditTrail-Custom",
                    "Dashboards",
                    "Identity",
                    "Identity-Custom",
                    "Reports",
                    "Security",
                    "Tasks"
                };
            }
        }

        #endregion

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

            // MenuHelper
            MenuHelper.Setup(environmentManager);

            // MultiTenantHelper
            MultiTenantHelper.Setup(environmentManager);
            MyLOBMultiTenantHelper.Setup(environmentManager);

            // ResourcesHelper
            ResourcesHelper.Setup(environmentManager);
            ResourcesHelper.AddResources("MyLOB.Resources");
            ResourcesHelper.AddResources("MyLOB.Application.Resources");
            ResourcesHelper.AddResources("MyLOB.Data.Resources");

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

                // ZViewModel <-> ZDTOModel
                // Activity
                cfg.AddProfile<ActivityViewAutoMapper>();
                // Audit Trail
                cfg.AddProfile<AuditTrailViewAutoMapper>();
                // Identity
                cfg.AddProfile<IdentityViewAutoMapper>();
                // Application
                //cfg.AddProfile<MyLOBViewAutoMapper>(); // !!! Web API
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

            // ZViewModel
            string viewAssemblyName = Assembly.GetExecutingAssembly().GetName().Name;
            // Activity
            DataHelper.SetupViewProfiles("EasyLOB.Activity.Data", viewAssemblyName);
            // Audit Trail
            DataHelper.SetupViewProfiles("EasyLOB.AuditTrail.Data", viewAssemblyName);
            // Identity
            DataHelper.SetupViewProfiles("EasyLOB.Identity.Data", viewAssemblyName);
            // Application
            //DataHelper.SetupViewProfiles("MyLOB.Data", viewAssemblyName); // !!! Web API

            MyLOBDataHelper.SetupProfiles("MyLOB.Data"); // !!! 
        }

        #endregion Methods
    }
}