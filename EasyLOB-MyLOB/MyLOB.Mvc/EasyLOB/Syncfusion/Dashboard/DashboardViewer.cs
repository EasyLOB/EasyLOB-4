using Microsoft.Win32;
using System;
using System.IO;
using System.Net;

namespace EasyLOB
{
    public class DashboardViewer
    {
        private readonly string _environmentFolder = AppDomain.CurrentDomain.BaseDirectory;
        private string Version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        public string ServiceUrl;
        public string Errormessage;

        public DashboardViewer()
        {
            #region Pick Windows Dashboard Service Url

            ServiceUrl = GetWindowsServiceUrl();

            #endregion Pick Windows Dashboard Service Url

            #region Pick IIS Express Dashboard Service Url if Windows Dashboard Service is not running

            if (ValidateDashboardService(ServiceUrl))
            {
                DashboardServiceSerialization serializer = new DashboardServiceSerialization();
                DashboardServicePreviewSettings settings = new DashboardServicePreviewSettings();
                string dashboardServiceSettingPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData) + @"\Syncfusion\Dashboard Platform SDK\" + Version + @"\DashboardServiceSetting.xml";
                if (File.Exists(dashboardServiceSettingPath))
                {
                    settings = serializer.Deserialize(dashboardServiceSettingPath);
                    if (!ValidateDashboardService(settings.ServiceURL))
                        ServiceUrl = settings.ServiceURL;
                    else
                    {
                        ServiceUrl = string.Empty;
                        Errormessage = "Dashboard Service is not running. Please start the DashboardServiceInstaller.exe file to start the service.";
                    }
                }
                else
                {
                    Errormessage = "Dashboard Service is not running. Please start the DashboardServiceInstaller.exe file to start the service.";
                    ServiceUrl = string.Empty;
                }
            }

            #endregion Pick IIS Express Dashboard Service Url if Windows Dashboard Service is not running
        }

        /// <summary>
        /// Validate whether Dashboard Service is running in the Url
        /// </summary>
        /// <param name="dashboardServiceUrl">Dashboard Service Url</param>
        /// <returns>returns whether valid dashboard service</returns>
        private static bool ValidateDashboardService(string dashboardServiceUrl)
        {
            bool errorOccured = false;
            try
            {
                if (string.IsNullOrWhiteSpace(dashboardServiceUrl))
                {
                    return true;
                }
                if (!dashboardServiceUrl.Contains("http://") && !dashboardServiceUrl.Contains("https://"))
                    dashboardServiceUrl = "http://" + dashboardServiceUrl + @"/IsServiceExists";
                else
                    dashboardServiceUrl = dashboardServiceUrl + @"/IsServiceExists";
                WebRequest request = WebRequest.Create(new Uri(dashboardServiceUrl, UriKind.Absolute));
                request.Method = "GET";
                using (WebResponse response = request.GetResponse())
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        string text = reader.ReadToEnd();
                        if (!text.Contains(System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes("DashboardServiceExists"))))
                        {
                            errorOccured = true;
                        }
                    }
                }
                dashboardServiceUrl = dashboardServiceUrl.Replace(@"/IsServiceExists", "");
            }
            catch // (Exception e)
            {
                dashboardServiceUrl = dashboardServiceUrl.Replace(@"/IsServiceExists", "");
                errorOccured = true;
            }
            return errorOccured;
        }

        /// <summary>
        /// Used to pick the Windows Dashboard Service URL
        /// </summary>
        /// <returns>ServiceURL of Windows Dashboard Service</returns>
        private string GetWindowsServiceUrl()
        {
            string url = string.Empty;
            try
            {
                RegistryKey key = Registry.LocalMachine.OpenSubKey(@"Software\SyncfusionDashboard\Syncfusion Dashboard Service");
                if (key != null)
                {
                    url = (string)key.GetValue("ServiceURL");
                    key.Close();
                }
            }
            catch (Exception)
            {
            }
            return url;
        }
    }
}