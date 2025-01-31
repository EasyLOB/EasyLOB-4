using EasyLOB;
using EasyLOB.Mvc;

namespace Northwind.Mvc
{
    public partial class RegionCollectionModel : CollectionModel
    {
        #region Methods

        public RegionCollectionModel()
            : base()
        {
            Entity = "Region";

            OnConstructor();
        }

        public RegionCollectionModel(ZActivityOperations activityOperations, string controllerAction, string masterControllerAction = null, string masterEntity = null, string masterKey = null, string operation = null)
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
