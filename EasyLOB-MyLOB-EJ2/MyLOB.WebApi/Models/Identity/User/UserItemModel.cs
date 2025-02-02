using EasyLOB;
using EasyLOB.Mvc;
using EasyLOB.Identity.Data;

namespace EasyLOB.Identity.Mvc
{
    public partial class UserItemModel : ItemModel
    {
        #region Properties

        public UserViewModel User { get; set; }

        #endregion Properties
        
        #region Methods

        public UserItemModel()
            : base()
        {
            Entity = "User";
            User = new UserViewModel();

            OnConstructor();
        }

        public UserItemModel(ZActivityOperations activityOperations, string controllerAction, string masterEntity = null, string masterKey = null, UserViewModel user = null)
            : this()
        {
            ActivityOperations = activityOperations;
            ControllerAction = controllerAction;
            MasterEntity = masterEntity;
            MasterKey = masterKey;
            User = user ?? User;
        }
        
        #endregion Methods
    }
}
