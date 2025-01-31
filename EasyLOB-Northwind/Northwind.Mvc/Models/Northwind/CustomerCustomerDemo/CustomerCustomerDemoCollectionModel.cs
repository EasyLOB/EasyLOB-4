using EasyLOB;
using EasyLOB.Mvc;

namespace Northwind.Mvc
{
    public partial class CustomerCustomerDemoCollectionModel : CollectionModel
    {
        #region Methods

        public CustomerCustomerDemoCollectionModel()
            : base()
        {
            Entity = "CustomerCustomerDemo";

            OnConstructor();
        }

        public CustomerCustomerDemoCollectionModel(ZActivityOperations activityOperations, string controllerAction, string masterControllerAction = null, string masterEntity = null, string masterKey = null, string operation = null)
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
