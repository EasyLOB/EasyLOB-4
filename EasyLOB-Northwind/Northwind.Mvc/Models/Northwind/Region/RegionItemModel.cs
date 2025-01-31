using Northwind.Data;
using EasyLOB;
using EasyLOB.Mvc;

namespace Northwind.Mvc
{
    public partial class RegionItemModel : ItemModel
    {
        #region Properties

        public RegionViewModel Region { get; set; }

        #endregion Properties
        
        #region Methods

        public RegionItemModel()
            : base()
        {
            Entity = "Region";
            Region = new RegionViewModel();

            OnConstructor();
        }

        public RegionItemModel(ZActivityOperations activityOperations, string controllerAction, string masterEntity = null, string masterKey = null, RegionViewModel region = null)
            : this()
        {
            ActivityOperations = activityOperations;
            ControllerAction = controllerAction;
            MasterEntity = masterEntity;
            MasterKey = masterKey;
            Region = region ?? Region;
        }
        
        #endregion Methods
    }
}
