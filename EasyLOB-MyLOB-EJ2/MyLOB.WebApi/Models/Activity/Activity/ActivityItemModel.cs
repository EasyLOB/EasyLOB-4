using EasyLOB.Activity.Data;
using EasyLOB;
using EasyLOB.Mvc;

namespace EasyLOB.Activity.Mvc
{
    public partial class ActivityItemModel : ItemModel
    {
        #region Properties

        public ActivityViewModel Activity { get; set; }

        #endregion Properties
        
        #region Methods

        public ActivityItemModel()
            : base()
        {
            Entity = "Activity";
            Activity = new ActivityViewModel();

            OnConstructor();
        }

        public ActivityItemModel(ZActivityOperations activityOperations, string controllerAction, string masterEntity = null, string masterKey = null, ActivityViewModel activity = null)
            : this()
        {
            ActivityOperations = activityOperations;
            ControllerAction = controllerAction;
            MasterEntity = masterEntity;
            MasterKey = masterKey;
            Activity = activity ?? Activity;
        }
        
        #endregion Methods
    }
}
