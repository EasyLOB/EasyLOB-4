using Northwind.Data;
using EasyLOB;
using EasyLOB.Mvc;

namespace Northwind.Mvc
{
    public partial class OrderItemModel : ItemModel
    {
        #region Properties

        public OrderViewModel Order { get; set; }

        #endregion Properties
        
        #region Methods

        public OrderItemModel()
            : base()
        {
            Entity = "Order";
            Order = new OrderViewModel();

            OnConstructor();
        }

        public OrderItemModel(ZActivityOperations activityOperations, string controllerAction, string masterEntity = null, string masterKey = null, OrderViewModel order = null)
            : this()
        {
            ActivityOperations = activityOperations;
            ControllerAction = controllerAction;
            MasterEntity = masterEntity;
            MasterKey = masterKey;
            Order = order ?? Order;
        }
        
        #endregion Methods
    }
}
