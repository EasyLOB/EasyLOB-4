using EasyLOB.AuditTrail.Data;
using EasyLOB;
using EasyLOB.Mvc;

namespace EasyLOB.AuditTrail.Mvc
{
    public partial class AuditTrailLogItemModel : ItemModel
    {
        #region Properties

        public AuditTrailLogViewModel AuditTrailLog { get; set; }

        #endregion Properties
        
        #region Methods

        public AuditTrailLogItemModel()
            : base()
        {
            Entity = "AuditTrailLog";
            AuditTrailLog = new AuditTrailLogViewModel();

            OnConstructor();
        }

        public AuditTrailLogItemModel(ZActivityOperations activityOperations, string controllerAction, string masterEntity = null, string masterKey = null, AuditTrailLogViewModel auditTrailLog = null)
            : this()
        {
            ActivityOperations = activityOperations;
            ControllerAction = controllerAction;
            MasterEntity = masterEntity;
            MasterKey = masterKey;
            AuditTrailLog = auditTrailLog ?? AuditTrailLog;
        }
        
        #endregion Methods
    }
}
