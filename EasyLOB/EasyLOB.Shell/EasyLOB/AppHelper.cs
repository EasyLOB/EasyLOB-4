﻿using EasyLOB.Environment;
using Newtonsoft.Json;

namespace EasyLOB
{
    public static partial class AppHelper
    {
        #region Properties

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