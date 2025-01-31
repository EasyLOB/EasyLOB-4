﻿using System.Collections.Generic;

namespace EasyLOB.Environment
{
    public class AppEnvironment
    {
        #region Properties User

        public bool IsAdministrator { get; }

        public bool IsAuthenticated { get; }

        public List<string> Roles { get; }

        public string UserName { get; }

        #endregion Properties User

        #region Properties Audit Trail

        public List<AppEnvironmentAuditTrail> AuditTrail { get; }

        #endregion Properties Audit Trail

        #region Methods

        public AppEnvironment()
        {
            IsAdministrator = false;
            IsAuthenticated = false;
            Roles = new List<string>();
            UserName = "";

            AuditTrail = new List<AppEnvironmentAuditTrail>();
        }

        public AppEnvironment(IAuthenticationManager authenticationManager)
        {
            IsAdministrator = authenticationManager.IsAdministrator;
            IsAuthenticated = authenticationManager.IsAuthenticated;
            Roles = authenticationManager.Roles;
            UserName = authenticationManager.UserName;

            AuditTrail = new List<AppEnvironmentAuditTrail>();
        }

        #endregion Methods
    }

    public class AppEnvironmentAuditTrail
    {
        #region Properties

        public string Domain { get; set; }

        public string Entity { get; set; }

        public string LogMode { get; set; }

        public string LogOperations { get; set; }

        #endregion Properties
    }
}