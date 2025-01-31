using Northwind.Data;
using EasyLOB;
using EasyLOB.Mvc;

namespace Northwind.Mvc
{
    public partial class ProductItemModel : ItemModel
    {
        #region Properties

        public ProductViewModel Product { get; set; }

        #endregion Properties
        
        #region Methods

        public ProductItemModel()
            : base()
        {
            Entity = "Product";
            Product = new ProductViewModel();

            OnConstructor();
        }

        public ProductItemModel(ZActivityOperations activityOperations, string controllerAction, string masterEntity = null, string masterKey = null, ProductViewModel product = null)
            : this()
        {
            ActivityOperations = activityOperations;
            ControllerAction = controllerAction;
            MasterEntity = masterEntity;
            MasterKey = masterKey;
            Product = product ?? Product;
        }
        
        #endregion Methods
    }
}
