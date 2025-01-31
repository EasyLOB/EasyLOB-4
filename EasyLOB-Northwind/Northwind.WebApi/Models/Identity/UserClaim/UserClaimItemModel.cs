using EasyLOB;
using EasyLOB.Mvc;
using EasyLOB.Identity.Data;

namespace EasyLOB.Identity.Mvc
{
    public partial class UserClaimItemModel : ItemModel
    {
        #region Properties

        public UserClaimViewModel UserClaim { get; set; }

        #endregion Properties
        
        #region Methods

        public UserClaimItemModel()
            : base()
        {
            Entity = "UserClaim";
            UserClaim = new UserClaimViewModel();

            OnConstructor();
        }

        public UserClaimItemModel(ZActivityOperations activityOperations, string controllerAction, string masterEntity = null, string masterKey = null, UserClaimViewModel userClaim = null)
            : this()
        {
            ActivityOperations = activityOperations;
            ControllerAction = controllerAction;
            MasterEntity = masterEntity;
            MasterKey = masterKey;
            UserClaim = userClaim ?? UserClaim;
        }
        
        #endregion Methods
    }
}
