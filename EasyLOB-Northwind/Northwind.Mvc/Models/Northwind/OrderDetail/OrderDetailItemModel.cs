using Northwind.Data;
using EasyLOB;
using EasyLOB.Mvc;

namespace Northwind.Mvc
{
    public partial class OrderDetailItemModel : ItemModel
    {
        #region Properties

        public OrderDetailViewModel OrderDetail { get; set; }

        #endregion Properties
        
        #region Methods

        public OrderDetailItemModel()
            : base()
        {
            Entity = "OrderDetail";
            OrderDetail = new OrderDetailViewModel();

            OnConstructor();
        }

        public OrderDetailItemModel(ZActivityOperations activityOperations, string controllerAction, string masterEntity = null, string masterKey = null, OrderDetailViewModel orderDetail = null)
            : this()
        {
            ActivityOperations = activityOperations;
            ControllerAction = controllerAction;
            MasterEntity = masterEntity;
            MasterKey = masterKey;
            OrderDetail = orderDetail ?? OrderDetail;
        }
        
        #endregion Methods
    }
}
