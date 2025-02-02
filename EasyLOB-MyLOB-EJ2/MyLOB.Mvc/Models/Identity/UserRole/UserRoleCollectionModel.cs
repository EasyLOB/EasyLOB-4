using EasyLOB;
using EasyLOB.Mvc;

namespace EasyLOB.Identity.Mvc
{
    public partial class UserRoleCollectionModel : CollectionModel
    {
        #region Methods

        public UserRoleCollectionModel()
            : base()
        {
            Entity = "UserRole";

            OnConstructor();
        }

        public UserRoleCollectionModel(ZActivityOperations activityOperations, string controllerAction, string masterControllerAction = null, string masterEntity = null, string masterKey = null, string operation = null)
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
