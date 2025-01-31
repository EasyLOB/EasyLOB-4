using EasyLOB.Library;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace EasyLOB.Environment
{
    public static partial class ResourcesHelper
    {
        #region Properties

        private static List<ResourcesJSON> DashboardResources { get; set; }

        private static List<ResourcesJSON> MenuResources { get; set; }

        private static List<ResourcesJSON> ReportResources { get; set; }

        private static List<string> Namespaces { get; set; }

        #endregion Properties

        #region Methods

        public static void Setup(IEnvironmentManager environmentManager)
        {
            Reload(environmentManager);

            Namespaces = new List<string>
            {
                "EasyLOB.Resources",
                "EasyLOB.Activity.Resources",
                "EasyLOB.Activity.Data.Resources",
                "EasyLOB.AuditTrail.Resources",
                "EasyLOB.AuditTrail.Data.Resources",
                "EasyLOB.Extensions.Edm.Resources",
                "EasyLOB.Identity.Resources",
                "EasyLOB.Identity.Data.Resources",
                "EasyLOB.Log.Resources",
                "EasyLOB.Security.Resources"
            };

            // "EasyLOB": {
            //   "AuditTrail": true,
            //   "Log": true,
            //   "MultiTenant": true,
            //   "Resources": [
            //     "MyLOB.Application.Resources",
            //     "MyLOB.Data.Resources",
            //     "MyLOB.Mvc.Resources"
            //   ],
            //   "Transaction": true
            // }

            //string[] resources = ConfigurationHelper.AppSettingsArray<string>("EasyLOB.Resources");
            //foreach (string r in resources.Reverse())
            //{
            //    Namespaces.Insert(0, r);
            //}
        }

        public static void Reload(IEnvironmentManager environmentManager)
        {
            string resourceFilePath;

            resourceFilePath = Path.Combine(environmentManager.ApplicationPath(ConfigurationHelper.AppSettings<string>("EasyLOB.Directory.Configuration")),
                "Resources/DashboardResources.json");
            DashboardResources = JsonConvert.DeserializeObject<List<ResourcesJSON>>(File.ReadAllText(resourceFilePath));

            resourceFilePath = Path.Combine(environmentManager.ApplicationPath(ConfigurationHelper.AppSettings<string>("EasyLOB.Directory.Configuration")),
                "Resources/MenuResources.json");
            MenuResources = JsonConvert.DeserializeObject<List<ResourcesJSON>>(File.ReadAllText(resourceFilePath));

            resourceFilePath = Path.Combine(environmentManager.ApplicationPath(ConfigurationHelper.AppSettings<string>("EasyLOB.Directory.Configuration")),
                "Resources/ReportResources.json");
            ReportResources = JsonConvert.DeserializeObject<List<ResourcesJSON>>(File.ReadAllText(resourceFilePath));
        }

        public static void AddResources(string resource)
        {
            if (!string.IsNullOrEmpty(resource))
            {
                Namespaces.Insert(0, resource);
            }
        }

        public static string GetResource(string resourceClass, string resourceKey)
        {
            string result = "";

            Type type;
            foreach (string n in Namespaces)
            {
                type = LibraryHelper.GetType(n + "." + resourceClass);
                if (type != null)
                {
                    try
                    {
                        result = (string)LibraryHelper.GetStaticPropertyValue(type, resourceKey);

                        break;
                    }
                    catch { }
                }
            }

            return result;
        }

        #endregion Methods

        #region Methods JSON

        public static string GetDashboardResource(string resourceKey)
        {
            return GetJSONResource(DashboardResources, resourceKey);
        }

        public static string GetMenuResource(string resourceKey)
        {
            return GetJSONResource(MenuResources, resourceKey);
        }

        public static string GetReportResource(string resourceKey)
        {
            return GetJSONResource(ReportResources, resourceKey);
        }

        private static ResourcesJSON GetJSONCulture(string culture, List<ResourcesJSON> resources)
        {
            ResourcesJSON result = null;

            foreach (ResourcesJSON resource in resources)
            {
                if (resource.Culture == culture)
                {
                    result = resource;
                    break;
                }
            }

            return result;
        }

        private static string GetJSONResource(List<ResourcesJSON> resources, string resourceKey)
        {
            string resourceValue = "? " + resourceKey.Trim() + " ?";

            ResourcesJSON resource = GetJSONCulture(CultureInfo.CurrentCulture.Name, resources);
            if (resource != null)
            {
                resourceKey = resourceKey.ToLower();
                foreach (KeyValuePair<string, string> entry in resource.Resources)
                {
                    if (entry.Key.ToLower() == resourceKey)
                    {
                        resourceValue = entry.Value?.Trim();
                        break;
                    }
                }
            }

            return resourceValue;
        }

        #endregion Methods JSON
    }
}