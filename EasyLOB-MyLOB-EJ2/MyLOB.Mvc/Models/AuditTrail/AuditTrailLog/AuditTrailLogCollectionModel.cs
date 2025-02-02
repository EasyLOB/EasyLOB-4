using EasyLOB;
using EasyLOB.Mvc;

namespace EasyLOB.AuditTrail.Mvc
{
    public partial class AuditTrailLogCollectionModel : CollectionModel
    {
        #region Methods

        public AuditTrailLogCollectionModel()
            : base()
        {
            Entity = "AuditTrailLog";

            OnConstructor();
        }

        public AuditTrailLogCollectionModel(ZActivityOperations activityOperations, string controllerAction, string masterControllerAction = null, string masterEntity = null, string masterKey = null, string operation = null)
            : this()
        {
            ActivityOperations = activityOperations;
            ControllerAction = controllerAction;
            MasterControllerAction = masterControllerAction;
            MasterEntity = masterEntity;
            MasterKey = masterKey;
            Operation = operation;
        }

        #endregion Methods
    }
}
