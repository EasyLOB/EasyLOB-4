using EasyLOB.Environment;
using Newtonsoft.Json;
using System.Globalization;

namespace EasyLOB
{
    public static partial class AppHelper
    {
        #region Properties

        // Culture = Language-Country ll-CC

        public static string Culture { get { return CultureInfo.CurrentCulture.Name ?? ""; } }

        public static string CultureLanguage { get { return Culture.Length >= 2 ? Culture.Substring(0, 2) : ""; } }

        public static string CultureCountry { get { return Culture.Length >= 4 ? Culture.Substring(3, 2) : ""; } }

        private static JsonSerializerSettings _jsonSettings;

        public static JsonSerializerSettings JsonSettings
        {
            get
            {
                if (_jsonSettings == null)
                {
                    _jsonSettings = new JsonSerializerSettings
                    {
                        Formatting = Formatting.None,
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    };
                }

                return _jsonSettings;
            }
        }

        #endregion Properties

        #region Methods

        public static void Log(ZOperationResult operationResult, string url, string header = null, string footer = null)
        {
            if (!operationResult.Ok)
            {
                if (string.IsNullOrEmpty(header))
                {
                    header =
                        url + System.Environment.NewLine
                        + MultiTenantHelper.Tenant.Name + System.Environment.NewLine
                        + EnvironmentHelper.Environment.UserName;
                }
                EasyLOBHelper.GetService<ILogManager>().OperationResult(operationResult, header, footer);
            }
        }

        #endregion Methods
    }
}