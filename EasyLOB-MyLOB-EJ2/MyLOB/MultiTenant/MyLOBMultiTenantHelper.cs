using EasyLOB;
using EasyLOB.Environment;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace MyLOB
{
    public static class MyLOBMultiTenantHelper
    {
        #region Properties

        private static string SessionName = "EasyLOB.MyLOBMultiTenant";

        public static MyLOBTenant Tenant
        {
            get { return GetTenant(MultiTenantHelper.Tenant.Name); }
        }

        public static List<MyLOBTenant> Tenants
        {
            get
            {
                IEnvironmentManager environmentManager = EasyLOBHelper.GetService<IEnvironmentManager>();

                List<MyLOBTenant> tenants = (List<MyLOBTenant>)environmentManager.SessionRead(SessionName);
                if (tenants == null || tenants.Count == 0)
                {
                    try
                    {
                        string filePath = Path.Combine(environmentManager.ApplicationPath(ConfigurationHelper.AppSettings<string>("EasyLOB.Directory.Configuration")),
                            "Tenant/MyLOBMultiTenant.json");
                        string json = File.ReadAllText(filePath);
                        tenants = JsonConvert.DeserializeObject<List<MyLOBTenant>>(json);
                    }
                    catch { }
                    tenants = tenants ?? new List<MyLOBTenant>();

                    environmentManager.SessionWrite(SessionName, tenants);
                }

                return tenants;
            }
        }

        private static IEnvironmentManager EnvironmentManager { get; set; }

        #endregion Properties

        #region Methods

        public static void Setup(IEnvironmentManager environmentManager)
        {
            EnvironmentManager = environmentManager;
        }

        public static MyLOBTenant GetTenant(string name)
        {
            MyLOBTenant MyLOBTenant = null;

            if (Tenants.Count > 0)
            {
                foreach (MyLOBTenant t in Tenants)
                {
                    if (t.Name.Equals(name, System.StringComparison.CurrentCultureIgnoreCase))
                    {
                        MyLOBTenant = t;
                        break;
                    }
                }
            }

            if (MyLOBTenant == null && Tenants.Count > 0)
            {
                MyLOBTenant = Tenants[0];
            }

            MyLOBTenant = MyLOBTenant ?? new MyLOBTenant();

            return MyLOBTenant;
        }

        #endregion
    }
}