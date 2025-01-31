using EasyLOB;
using EasyLOB.Mvc;

namespace Northwind.Mvc
{
    public partial class SupplierCollectionModel : CollectionModel
    {
        #region Methods

        public SupplierCollectionModel()
            : base()
        {
            Entity = "Supplier";

            OnConstructor();
        }

        public SupplierCollectionModel(ZActivityOperations activityOperations, string controllerAction, string masterControllerAction = null, string masterEntity = null, string masterKey = null, string operation = null)
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
