using EasyLOB.Activity.Data;
using EasyLOB;
using EasyLOB.Mvc;

namespace EasyLOB.Activity.Mvc
{
    public partial class ActivityRoleItemModel : ItemModel
    {
        #region Properties

        public ActivityRoleViewModel ActivityRole { get; set; }

        #endregion Properties

        #region Methods

        public ActivityRoleItemModel()
            : base()
        {
            Entity = "ActivityRole";
            ActivityRole = new ActivityRoleViewModel();

            OnConstructor();
        }

        public ActivityRoleItemModel(ZActivityOperations activityOperations, string controllerAction, string masterEntity = null, string masterKey = null, ActivityRoleViewModel activityRole = null)
            : this()
        {
            ActivityOperations = activityOperations;
            ControllerAction = controllerAction;
            MasterEntity = masterEntity;
            MasterKey = masterKey;
            ActivityRole = activityRole ?? ActivityRole;
        }

        #endregion Methods
    }
}