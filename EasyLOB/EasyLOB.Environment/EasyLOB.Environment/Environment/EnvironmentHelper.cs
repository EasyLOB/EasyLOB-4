using EasyLOB.AuditTrail;
using EasyLOB.AuditTrail.Data;
using System.Collections.Generic;
using System.Linq;

namespace EasyLOB.Environment
{
    /// <summary>
    /// Environment Helper.
    /// </summary>
    public static partial class EnvironmentHelper
    {
        #region Fields

        /// <summary>
        /// Session name.
        /// </summary>
        private static string _sessionName = "EasyLOB.Environment";

        #endregion Fields

        #region Properties

        /// <summary>
        /// Profile.
        /// </summary>
        public static AppEnvironment Environment
        {
            get
            {
                AppEnvironment environment = (AppEnvironment)EnvironmentManager.SessionRead(_sessionName);

                return environment ?? new AppEnvironment();
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
        /// Login.
        /// </summary>
        /// <param name="authenticationManager">Authentication manager</param>
        /// <param name="auditTrailunitOfWork">Authorization manager</param>
        public static void Login(IAuthenticationManager authenticationManager, IAuditTrailUnitOfWork auditTrailunitOfWork)
        {
            AppEnvironment profile = Environment;
            if (profile == null || string.IsNullOrEmpty(profile.UserName))
            {

                // User

                profile = new AppEnvironment(authenticationManager);

                // AuditTrail

                List<AuditTrailConfiguration> auditTrailConfigurations = auditTrailunitOfWork
                    .GetQuery<AuditTrailConfiguration>()
                    .OrderBy(x => x.Domain)
                    .ThenBy(x => x.Entity)
                    .ToList();
                foreach (AuditTrailConfiguration auditTrailConfiguration in auditTrailConfigurations)
                {
                    AppEnvironmentAuditTrail auditTrail = new AppEnvironmentAuditTrail();
                    auditTrail.Domain = auditTrailConfiguration.Domain;
                    auditTrail.Entity = auditTrailConfiguration.Entity;
                    auditTrail.LogMode = auditTrailConfiguration.LogMode;
                    auditTrail.LogOperations = auditTrailConfiguration.LogOperations;

                    profile.AuditTrail.Add(auditTrail);
                }

                EnvironmentManager.SessionWrite(_sessionName, profile);
            }
        }

        #endregion Methods
    }
}