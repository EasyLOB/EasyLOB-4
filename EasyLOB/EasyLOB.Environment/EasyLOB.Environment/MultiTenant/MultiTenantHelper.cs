using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace EasyLOB.Environment
{
    /// <summary>
    /// Multitenant Helper.
    /// </summary>
    public static partial class MultiTenantHelper
    {
        #region Fields

        /// <summary>
        /// Session name.
        /// </summary>
        private static string _sessionName = "EasyLOB.MultiTenant";

        #endregion Fields

        #region Properties

        /// <summary>
        /// Has tenants ?
        /// </summary>
        public static bool HasTenants
        {
            get { return IsMultiTenant && Tenants != null ? true : false; }
        }

        /// <summary>
        /// Is multitenant automatic ?
        /// </summary>
        public static bool IsAuto { get; set; } = true;

        /// <summary>
        /// Is multitenant ?
        /// </summary>
        public static bool IsMultiTenant
        {
            get { return ConfigurationHelper.AppSettings<bool>("EasyLOB.MultiTenant"); }
        }

        /// <summary>
        /// Tenant.
        /// </summary>
        public static AppTenant Tenant
        {
            get { return GetTenant(TenantName); }
        }

        private static string _tenantName = "";

        /// <summary>
        /// Tenant name.
        /// </summary>
        public static string TenantName
        {
            get
            {
                // IsAuto
                // Desktop false
                // Web     true  DEFAULT
                if (IsAuto)
                {
                    string tenantName = EnvironmentManager.WebSubDomain;
                    // EnvironmentManagerDesktop.WebSubDomain = ""
                    if (!string.IsNullOrEmpty(tenantName))
                    {
                        _tenantName = tenantName ?? "";
                    }
                }

                return _tenantName ?? "";
            }
            set
            {
                _tenantName = value ?? "";
            }
        }

        /// <summary>
        /// Tenants.
        /// </summary>
        public static List<AppTenant> Tenants
        {
            get
            {
                List<AppTenant> tenants = (List<AppTenant>)EnvironmentManager.SessionRead(_sessionName);
                if (tenants == null || tenants.Count == 0)
                {
                    /*
                    try
                    {
                        string filePath = Path.Combine(EnvironmentManager.ApplicationPath(ConfigurationHelper.AppSettings<string>("EasyLOB.Directory.Configuration")),
                            "Tenant/MultiTenant.json");
                        string json = File.ReadAllText(filePath);
                        tenants = JsonConvert.DeserializeObject<List<AppTenant>>(json);
                    }
                    catch { }
                    tenants = tenants ?? new List<AppTenant>();
                    */
                    tenants = Load();

                    EnvironmentManager.SessionWrite(_sessionName, tenants);
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

        /// <summary>
        /// Get connection name.
        /// </summary>
        /// <param name="defaultConnectionName">Default connection name</param>
        /// <returns></returns>
        public static string GetConnectionName(string defaultConnectionName)
        {
            string result = defaultConnectionName;

            if (Tenant != null)
            {
                foreach (AppTenantConnection appTenantConnection in Tenant.Connections)
                {
                    if (appTenantConnection.Name == defaultConnectionName)
                    {
                        result = appTenantConnection.ConnectionName;
                        break;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Get connection string.
        /// </summary>
        /// <param name="defaultConnectionName">Default connection string</param>
        /// <returns></returns>
        public static string GetConnectionString(string defaultConnectionName)
        {
            return ConfigurationHelper.ConnectionStrings(GetConnectionName(defaultConnectionName));
        }

        /// <summary>
        /// Get tenant by name.
        /// </summary>
        /// <param name="name">Tenant name</param>
        /// <returns></returns>
        public static AppTenant GetTenant(string name)
        {
            AppTenant appTenant = null;

            if (IsMultiTenant)
            {
                if (Tenants.Count > 0)
                {
                    name = name.ToLower();
                    foreach (AppTenant t in Tenants)
                    {
                        if (name.StartsWith(t.Name.ToLower()))
                        //if (t.Name.Equals(name, System.StringComparison.CurrentCultureIgnoreCase))
                        {
                            appTenant = t;
                            break;
                        }
                    }
                }
            }

            if (appTenant == null && Tenants.Count > 0)
            {
                appTenant = Tenants[0];
            }

            appTenant = appTenant ?? new AppTenant();

            return appTenant;
        }

        /// <summary>
        /// Load JSON.
        /// </summary>
        /// <returns></returns>
        private static List<AppTenant> Load()
        {
            List<AppTenant> tenants = null;

            try
            {
                string filePath = Path.Combine(EnvironmentManager.ApplicationPath(ConfigurationHelper.AppSettings<string>("EasyLOB.Directory.Configuration")),
                    "Tenant/MultiTenant.json");
                string json = File.ReadAllText(filePath);
                tenants = JsonConvert.DeserializeObject<List<AppTenant>>(json);
            }
            catch { }

            tenants = tenants ?? new List<AppTenant>();

            return tenants;
        }

        /// <summary>
        /// Reload JSON.
        /// </summary>
        public static void Reload()
        {
            List<AppTenant> tenantsJSON = Load();
            if (tenantsJSON.Count > 0)
            {
                foreach (AppTenant tenantJSON in tenantsJSON)
                {
                    bool add = true;

                    for (int index = 0; index < Tenants.Count; index++)
                    {
                        if (Tenants[index].Name.Equals(tenantJSON.Name, System.StringComparison.CurrentCultureIgnoreCase))
                        {
                            Tenants[index] = tenantJSON;
                            add = false;
                        }
                    }

                    if (add)
                    {
                        Tenants.Add(tenantJSON);
                    }
                }

                EnvironmentManager.SessionWrite(_sessionName, Tenants);
            }
        }

        /// <summary>
        /// Save JSON.
        /// </summary>
        public static void Save()
        {
            try
            {
                string filePath = Path.Combine(EnvironmentManager.ApplicationPath(ConfigurationHelper.AppSettings<string>("EasyLOB.Directory.Configuration")),
                    "Tenant/MultiTenant.json");
                string json = JsonConvert.SerializeObject(MultiTenantHelper.Tenants, Formatting.Indented);
                File.WriteAllText(filePath, json);
            }
            catch { }
        }

        #endregion Methods
    }
}