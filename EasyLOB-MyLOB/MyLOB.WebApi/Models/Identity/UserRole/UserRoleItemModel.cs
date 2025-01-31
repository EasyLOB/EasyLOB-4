using EasyLOB;
using EasyLOB.Mvc;
using EasyLOB.Identity.Data;

namespace EasyLOB.Identity.Mvc
{
    public partial class UserRoleItemModel : ItemModel
    {
        #region Properties

        public UserRoleViewModel UserRole { get; set; }

        #endregion Properties
        
        #region Methods

        public UserRoleItemModel()
            : base()
        {
            Entity = "UserRole";
            UserRole = new UserRoleViewModel();

            OnConstructor();
        }

        public UserRoleItemModel(ZActivityOperations activityOperations, string controllerAction, string masterEntity = null, string masterKey = null, UserRoleViewModel userRole = null)
            : this()
        {
            ActivityOperations = activityOperations;
            ControllerAction = controllerAction;
            MasterEntity = masterEntity;
            MasterKey = masterKey;
            UserRole = userRole ?? UserRole;
        }
        
        #endregion Methods
    }
}
