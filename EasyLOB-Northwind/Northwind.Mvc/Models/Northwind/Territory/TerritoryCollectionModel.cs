using EasyLOB;
using EasyLOB.Mvc;

namespace Northwind.Mvc
{
    public partial class TerritoryCollectionModel : CollectionModel
    {
        #region Methods

        public TerritoryCollectionModel()
            : base()
        {
            Entity = "Territory";

            OnConstructor();
        }

        public TerritoryCollectionModel(ZActivityOperations activityOperations, string controllerAction, string masterControllerAction = null, string masterEntity = null, string masterKey = null, string operation = null)
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
