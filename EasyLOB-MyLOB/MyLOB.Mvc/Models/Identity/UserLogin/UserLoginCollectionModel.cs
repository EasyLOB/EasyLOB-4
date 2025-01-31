using EasyLOB;
using EasyLOB.Mvc;

namespace EasyLOB.Identity.Mvc
{
    public partial class UserLoginCollectionModel : CollectionModel
    {
        #region Methods

        public UserLoginCollectionModel()
            : base()
        {
            Entity = "UserLogin";

            OnConstructor();
        }

        public UserLoginCollectionModel(ZActivityOperations activityOperations, string controllerAction, string masterControllerAction = null, string masterEntity = null, string masterKey = null, string operation = null)
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
