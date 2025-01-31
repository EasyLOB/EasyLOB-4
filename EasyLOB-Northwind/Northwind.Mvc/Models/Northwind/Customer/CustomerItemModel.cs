using Northwind.Data;
using EasyLOB;
using EasyLOB.Mvc;

namespace Northwind.Mvc
{
    public partial class CustomerItemModel : ItemModel
    {
        #region Properties

        public CustomerViewModel Customer { get; set; }

        #endregion Properties
        
        #region Methods

        public CustomerItemModel()
            : base()
        {
            Entity = "Customer";
            Customer = new CustomerViewModel();

            OnConstructor();
        }

        public CustomerItemModel(ZActivityOperations activityOperations, string controllerAction, string masterEntity = null, string masterKey = null, CustomerViewModel customer = null)
            : this()
        {
            ActivityOperations = activityOperations;
            ControllerAction = controllerAction;
            MasterEntity = masterEntity;
            MasterKey = masterKey;
            Customer = customer ?? Customer;
        }
        
        #endregion Methods
    }
}
