using EasyLOB;
using EasyLOB.Mvc;
using EasyLOB.Identity.Data;

namespace EasyLOB.Identity.Mvc
{
    public partial class RoleItemModel : ItemModel
    {
        #region Properties

        public RoleViewModel Role { get; set; }

        #endregion Properties
        
        #region Methods

        public RoleItemModel()
            : base()
        {
            Entity = "Role";
            Role = new RoleViewModel();

            OnConstructor();
        }

        public RoleItemModel(ZActivityOperations activityOperations, string controllerAction, string masterEntity = null, string masterKey = null, RoleViewModel role = null)
            : this()
        {
            ActivityOperations = activityOperations;
            ControllerAction = controllerAction;
            MasterEntity = masterEntity;
            MasterKey = masterKey;
            Role = role ?? Role;
        }
        
        #endregion Methods
    }
}
