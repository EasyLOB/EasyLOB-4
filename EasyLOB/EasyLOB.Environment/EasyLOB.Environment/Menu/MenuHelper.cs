﻿using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

// How to apply url, htmlAttribute, imageUrl, linkAttribute for Menu Items?
// https://www.syncfusion.com/kb/3008/how-to-apply-url-htmlattribute-imageurl-linkattribute-for-menu-items

namespace EasyLOB.Environment
{
    /// <summary>
    /// Menu Helper.
    /// </summary>
    public static partial class MenuHelper
    {
        #region Fields

        /// <summary>
        /// Session name.
        /// </summary>
        private static string _sessionName = "EasyLOB.Menu";

        #endregion Fields

        #region Properties

        private static IEnvironmentManager EnvironmentManager { get; set; }

        #endregion Properties

        #region Methods

        public static void Setup(IEnvironmentManager environmentManager)
        {
            EnvironmentManager = environmentManager;
        }

        /// <summary>
        /// Get menu.
        /// </summary>
        /// <param name="authenticationManager"></param>
        /// <returns></returns>
        public static List<AppMenu> Menu(IAuthenticationManager authenticationManager)
        {
            List<AppMenu> menu = (List<AppMenu>)EnvironmentManager.SessionRead(_sessionName);
            if (menu == null || menu.Count == 0)
            {
                menu = new List<AppMenu>();

                if (authenticationManager.IsAuthenticated)
                {
                    List<AppMenuJson> menuJson = new List<AppMenuJson>();
                    string tenantName = MultiTenantHelper.Tenant.Name;
                    // Menu.TenantName.json
                    string filePath = Path.Combine(EnvironmentManager.ApplicationPath(ConfigurationHelper.AppSettings<string>("EasyLOB.Directory.Configuration")),
                        "Menu/Menu" + "." + tenantName + ".json");
                    string json = File.ReadAllText(filePath);
                    menuJson = JsonConvert.DeserializeObject<List<AppMenuJson>>(json);

                    Parse(menu, menuJson, null,
                        authenticationManager.IsAdministrator, authenticationManager.Roles,
                        EnvironmentManager);

                    foreach (AppMenu appMenu in menu)
                    {
                        if (appMenu.Text.Contains("Resources."))
                        {
                            string[] words = appMenu.Text.Split('.');
                            if (words.Length == 2)
                            {
                                switch (words[0])
                                {
                                    case "DashboardResources":
                                        appMenu.Text = ResourcesHelper.GetDashboardResource(words[1]);
                                        break;

                                    case "MenuResources":
                                        appMenu.Text = ResourcesHelper.GetMenuResource(words[1]);
                                        break;

                                    case "ReportResources":
                                        appMenu.Text = ResourcesHelper.GetReportResource(words[1]);
                                        break;

                                    default:
                                        appMenu.Text = ResourcesHelper.GetResource(words[0], words[1]);
                                        break;
                                }
                            }
                        }
                    }
                }

                EnvironmentManager.SessionWrite(_sessionName, menu);
            }

            return menu;
        }

        /// <summary>
        /// Parse menu.
        /// </summary>
        /// <param name="menu"></param>
        /// <param name="menuJson"></param>
        /// <param name="parentId"></param>
        /// <param name="isAdministrator"></param>
        /// <param name="roles"></param>
        private static void Parse(List<AppMenu> menu, List<AppMenuJson> menuJson, int? parentId,
            bool isAdministrator, List<string> roles,
            IEnvironmentManager environmentManager)
        {
            if (menuJson != null)
            {
                int id = (parentId ?? 0) * 100;
                foreach (AppMenuJson appMenuJson in menuJson)
                {
                    bool authorized = true;

                    if (!isAdministrator && !string.IsNullOrEmpty(appMenuJson.Roles))
                    {
                        if (appMenuJson.Roles == "*")
                        {
                            authorized = true;
                        }
                        else
                        {
                            authorized = false;
                            string[] menuRoles = appMenuJson.Roles.Split(',');
                            foreach (string role in roles)
                            {
                                authorized = authorized || menuRoles.Contains(role);
                                if (authorized)
                                {
                                    break;
                                }
                            }
                        }
                    }

                    if (authorized)
                    {
                        id++;
                        string webPath = environmentManager.WebPath;
                        string url = appMenuJson.Url;
                        AppMenu appMenu = new AppMenu
                        {
                            Id = id,
                            Text = appMenuJson.Text,
                            ParentId = parentId == null ? null : parentId,
                            Url = appMenuJson.Url == null ? null :
                                (string.IsNullOrEmpty(url) ? "" : webPath + (url[0] == '/' ? "" : "/") + url)
                        };
                        menu.Add(appMenu);

                        Parse(menu, appMenuJson.SubMenus, id,
                            isAdministrator, roles,
                            environmentManager);
                    }
                }
            }
        }

        #endregion Methods
    }
}