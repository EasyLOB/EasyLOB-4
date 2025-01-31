using Northwind.Data;
using EasyLOB;
using EasyLOB.Mvc;

namespace Northwind.Mvc
{
    public partial class SupplierItemModel : ItemModel
    {
        #region Properties

        public SupplierViewModel Supplier { get; set; }

        #endregion Properties
        
        #region Methods

        public SupplierItemModel()
            : base()
        {
            Entity = "Supplier";
            Supplier = new SupplierViewModel();

            OnConstructor();
        }

        public SupplierItemModel(ZActivityOperations activityOperations, string controllerAction, string masterEntity = null, string masterKey = null, SupplierViewModel supplier = null)
            : this()
        {
            ActivityOperations = activityOperations;
            ControllerAction = controllerAction;
            MasterEntity = masterEntity;
            MasterKey = masterKey;
            Supplier = supplier ?? Supplier;
        }
        
        #endregion Methods
    }
}
