using Northwind.Data;
using EasyLOB;
using EasyLOB.Mvc;

namespace Northwind.Mvc
{
    public partial class ShipperItemModel : ItemModel
    {
        #region Properties

        public ShipperViewModel Shipper { get; set; }

        #endregion Properties
        
        #region Methods

        public ShipperItemModel()
            : base()
        {
            Entity = "Shipper";
            Shipper = new ShipperViewModel();

            OnConstructor();
        }

        public ShipperItemModel(ZActivityOperations activityOperations, string controllerAction, string masterEntity = null, string masterKey = null, ShipperViewModel shipper = null)
            : this()
        {
            ActivityOperations = activityOperations;
            ControllerAction = controllerAction;
            MasterEntity = masterEntity;
            MasterKey = masterKey;
            Shipper = shipper ?? Shipper;
        }
        
        #endregion Methods
    }
}
