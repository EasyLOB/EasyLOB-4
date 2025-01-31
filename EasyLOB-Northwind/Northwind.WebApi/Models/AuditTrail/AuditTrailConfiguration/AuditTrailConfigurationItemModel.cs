using EasyLOB.AuditTrail.Data;
using EasyLOB;
using EasyLOB.Mvc;

namespace EasyLOB.AuditTrail.Mvc
{
    public partial class AuditTrailConfigurationItemModel : ItemModel
    {
        #region Properties

        public AuditTrailConfigurationViewModel AuditTrailConfiguration { get; set; }

        #endregion Properties
        
        #region Methods

        public AuditTrailConfigurationItemModel()
            : base()
        {
            Entity = "AuditTrailConfiguration";
            AuditTrailConfiguration = new AuditTrailConfigurationViewModel();

            OnConstructor();
        }

        public AuditTrailConfigurationItemModel(ZActivityOperations activityOperations, string controllerAction, string masterEntity = null, string masterKey = null, AuditTrailConfigurationViewModel auditTrailConfiguration = null)
            : this()
        {
            ActivityOperations = activityOperations;
            ControllerAction = controllerAction;
            MasterEntity = masterEntity;
            MasterKey = masterKey;
            AuditTrailConfiguration = auditTrailConfiguration ?? AuditTrailConfiguration;
        }
        
        #endregion Methods
    }
}
