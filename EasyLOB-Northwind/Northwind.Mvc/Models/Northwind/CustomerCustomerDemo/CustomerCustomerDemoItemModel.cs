using Northwind.Data;
using EasyLOB;
using EasyLOB.Mvc;

namespace Northwind.Mvc
{
    public partial class CustomerCustomerDemoItemModel : ItemModel
    {
        #region Properties

        public CustomerCustomerDemoViewModel CustomerCustomerDemo { get; set; }

        #endregion Properties
        
        #region Methods

        public CustomerCustomerDemoItemModel()
            : base()
        {
            Entity = "CustomerCustomerDemo";
            CustomerCustomerDemo = new CustomerCustomerDemoViewModel();

            OnConstructor();
        }

        public CustomerCustomerDemoItemModel(ZActivityOperations activityOperations, string controllerAction, string masterEntity = null, string masterKey = null, CustomerCustomerDemoViewModel customerCustomerDemo = null)
            : this()
        {
            ActivityOperations = activityOperations;
            ControllerAction = controllerAction;
            MasterEntity = masterEntity;
            MasterKey = masterKey;
            CustomerCustomerDemo = customerCustomerDemo ?? CustomerCustomerDemo;
        }
        
        #endregion Methods
    }
}
