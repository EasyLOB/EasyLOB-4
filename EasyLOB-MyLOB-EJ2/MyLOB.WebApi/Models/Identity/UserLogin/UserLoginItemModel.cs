using EasyLOB;
using EasyLOB.Mvc;
using EasyLOB.Identity.Data;

namespace EasyLOB.Identity.Mvc
{
    public partial class UserLoginItemModel : ItemModel
    {
        #region Properties

        public UserLoginViewModel UserLogin { get; set; }

        #endregion Properties
        
        #region Methods

        public UserLoginItemModel()
            : base()
        {
            Entity = "UserLogin";
            UserLogin = new UserLoginViewModel();

            OnConstructor();
        }

        public UserLoginItemModel(ZActivityOperations activityOperations, string controllerAction, string masterEntity = null, string masterKey = null, UserLoginViewModel userLogin = null)
            : this()
        {
            ActivityOperations = activityOperations;
            ControllerAction = controllerAction;
            MasterEntity = masterEntity;
            MasterKey = masterKey;
            UserLogin = userLogin ?? UserLogin;
        }
        
        #endregion Methods
    }
}
