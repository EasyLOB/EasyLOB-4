using Northwind.Data;
using EasyLOB;
using EasyLOB.Mvc;

namespace Northwind.Mvc
{
    public partial class TerritoryItemModel : ItemModel
    {
        #region Properties

        public TerritoryViewModel Territory { get; set; }

        #endregion Properties
        
        #region Methods

        public TerritoryItemModel()
            : base()
        {
            Entity = "Territory";
            Territory = new TerritoryViewModel();

            OnConstructor();
        }

        public TerritoryItemModel(ZActivityOperations activityOperations, string controllerAction, string masterEntity = null, string masterKey = null, TerritoryViewModel territory = null)
            : this()
        {
            ActivityOperations = activityOperations;
            ControllerAction = controllerAction;
            MasterEntity = masterEntity;
            MasterKey = masterKey;
            Territory = territory ?? Territory;
        }
        
        #endregion Methods
    }
}
