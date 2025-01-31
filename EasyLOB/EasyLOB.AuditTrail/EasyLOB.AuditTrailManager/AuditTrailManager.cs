using EasyLOB.AuditTrail.Data;
using EasyLOB.Data;
using EasyLOB.Environment;
using EasyLOB.Persistence;
using Newtonsoft.Json;
using System;

namespace EasyLOB.AuditTrail
{
    public partial class AuditTrailManager : IAuditTrailManager
    {
        #region Properties

        public IAuditTrailUnitOfWork UnitOfWork { get; }

        #endregion Properties

        #region Methods

        public AuditTrailManager(IAuditTrailUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public virtual void Dispose()
        {
        }

        public bool AuditTrail(ZOperationResult operationResult, string logUserName, string logDomain, string logEntity, string logOperation, IZDataModel entityBefore, IZDataModel entityAfter)
        {
            string logMode;

            if (IsAuditTrail(logDomain, logEntity, logOperation, out logMode))
            {
                // (N) None
                // (K) Entity Key
                // (E) Full Entity
                if (!(string.IsNullOrEmpty(logMode) || logMode == "N"))
                {
                    JsonSerializerSettings jsonSettings = new JsonSerializerSettings
                    {
                        //Formatting = Formatting.Indented
                        Formatting = Formatting.None,
                        MaxDepth = 1
                    };

                    object[] ids;
                    IZProfile profile;
                    if (entityAfter != null)
                    {
                        ids = entityAfter.GetId();
                        profile = DataHelper.GetProfile(entityAfter.GetType());
                    }
                    else // entityBefore != null
                    {
                        ids = entityBefore.GetId();
                        profile = DataHelper.GetProfile(entityBefore.GetType());
                    }

                    // 1|2
                    string logId = "";
                    int idIndex = 0;
                    foreach (string idProperty in profile.Keys)
                    {
                        logId += (string.IsNullOrEmpty(logId) ? "" : "|") + JsonConvert.SerializeObject(ids[idIndex++], jsonSettings);
                    }

                    // {"Id1":1,"Id2":2}
                    //string logId = "";
                    //int idIndex = 0;
                    //foreach (string idProperty in profile.Keys)
                    //{
                    //    logId += (string.IsNullOrEmpty(logId) ? "" : ",") + "\"" + idProperty + "\":" + JsonConvert.SerializeObject(ids[idIndex++], settings);
                    //}
                    //logId = "{" + logId + "}";

                    AuditTrailLog auditTrailLog = new AuditTrailLog();
                    auditTrailLog.LogDate = DateTime.Today;
                    auditTrailLog.LogTime = DateTime.Now;
                    auditTrailLog.LogUserName = logUserName;
                    auditTrailLog.LogDomain = logDomain;
                    auditTrailLog.LogEntity = logEntity;
                    auditTrailLog.LogOperation = logOperation;
                    // K
                    auditTrailLog.LogId = logId;
                    // E
                    if (logMode == "E")
                    {
                        auditTrailLog.LogEntityBefore = entityBefore == null ? "" : JsonConvert.SerializeObject(entityBefore, jsonSettings);
                        auditTrailLog.LogEntityAfter = entityAfter == null ? "" : JsonConvert.SerializeObject(entityAfter, jsonSettings);
                    }

                    IGenericRepository<AuditTrailLog> repository = UnitOfWork.GetRepository<AuditTrailLog>();
                    if (repository.Create(operationResult, auditTrailLog))
                    {
                        UnitOfWork.Save(operationResult);
                    }
                }
            }

            return operationResult.Ok;
        }

        public bool IsAuditTrail(string logDomain, string logEntity, string logOperation, out string logMode)
        {
            bool result = false;
            logMode = "N";

            if (AuditTrailHelper.IsAuditTrail)
            {
                logDomain = logDomain.ToLower();
                logEntity = logEntity.ToLower();
                foreach (AppEnvironmentAuditTrail auditTrail in EnvironmentHelper.Environment.AuditTrail)
                {
                    if (auditTrail.Domain.ToLower() == logDomain && auditTrail.Entity.ToLower() == logEntity)
                    {
                        if (auditTrail.LogOperations.Contains(logOperation))
                        {
                            result = true;
                            logMode = auditTrail.LogMode;
                        }

                        break;
                    }
                }

                //AuditTrailConfiguration auditTrailConfiguration = UnitOfWork
                //    .GetRepository<AuditTrailConfiguration>()
                //    .Get(x => x.Domain.ToLower() == logDomain && x.Entity.ToLower() == logEntity && x.LogOperations.Contains(logOperation));
                //if (auditTrailConfiguration != null)
                //{
                //    result = true;
                //    logMode = auditTrailConfiguration.LogMode;
                //}
            }

            return result;
        }

        #endregion Methods
    }
}