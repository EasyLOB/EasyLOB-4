using EasyLOB;
using EasyLOB.Mvc;

namespace Northwind.Mvc
{
    public partial class ShipperCollectionModel : CollectionModel
    {
        #region Methods

        public ShipperCollectionModel()
            : base()
        {
            Entity = "Shipper";

            OnConstructor();
        }

        public ShipperCollectionModel(ZActivityOperations activityOperations, string controllerAction, string masterControllerAction = null, string masterEntity = null, string masterKey = null, string operation = null)
            : this()
        {
            ActivityOperations = activityOperations;
            ControllerAction = controllerAction;
            MasterControllerAction = masterControllerAction;
            MasterEntity = masterEntity;
            MasterKey = masterKey;
            Operation = operation;
        }

        #endregion Methods
    }
}
