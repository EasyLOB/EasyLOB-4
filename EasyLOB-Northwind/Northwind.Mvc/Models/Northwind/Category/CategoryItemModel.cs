using Northwind.Data;
using EasyLOB;
using EasyLOB.Mvc;

namespace Northwind.Mvc
{
    public partial class CategoryItemModel : ItemModel
    {
        #region Properties

        public CategoryViewModel Category { get; set; }

        #endregion Properties
        
        #region Methods

        public CategoryItemModel()
            : base()
        {
            Entity = "Category";
            Category = new CategoryViewModel();

            OnConstructor();
        }

        public CategoryItemModel(ZActivityOperations activityOperations, string controllerAction, string masterEntity = null, string masterKey = null, CategoryViewModel category = null)
            : this()
        {
            ActivityOperations = activityOperations;
            ControllerAction = controllerAction;
            MasterEntity = masterEntity;
            MasterKey = masterKey;
            Category = category ?? Category;
        }
        
        #endregion Methods
    }
}
