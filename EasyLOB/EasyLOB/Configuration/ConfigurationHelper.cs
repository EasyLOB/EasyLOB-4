using System;
using System.ComponentModel;
using System.Configuration;

namespace EasyLOB
{
    /// <summary>
    /// Configuration Helper.
    /// </summary>
    public static partial class ConfigurationHelper
    {
        #region Methods

        /// <summary>
        /// Get AppSettings by setting name.
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="settingName">Setting name</param>
        /// <returns></returns>
        public static T AppSettings<T>(string settingName)
        {
            var appSetting = ConfigurationManager.AppSettings[settingName];
            var converter = TypeDescriptor.GetConverter(typeof(T));

            return (T)(converter.ConvertFromInvariantString(appSetting ?? ""));
        }

        /// <summary>
        /// Get ConnectionStrings by connection name.
        /// </summary>
        /// <param name="connectionName">Connection nanme</param>
        /// <returns></returns>
        public static string ConnectionStrings(string connectionName)
        {
            string connectionString = ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
            if (connectionString == null)
            {
                throw new Exception(string.Format("ConnectionStrings[\"{0}\"] = \"?\"", connectionString));
            }

            return connectionString;
        }

        #endregion Methods
    }
}