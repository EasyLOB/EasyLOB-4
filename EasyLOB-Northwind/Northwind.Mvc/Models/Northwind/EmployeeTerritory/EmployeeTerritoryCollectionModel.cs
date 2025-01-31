using EasyLOB;
using EasyLOB.Mvc;

namespace Northwind.Mvc
{
    public partial class EmployeeTerritoryCollectionModel : CollectionModel
    {
        #region Methods

        public EmployeeTerritoryCollectionModel()
            : base()
        {
            Entity = "EmployeeTerritory";

            OnConstructor();
        }

        public EmployeeTerritoryCollectionModel(ZActivityOperations activityOperations, string controllerAction, string masterControllerAction = null, string masterEntity = null, string masterKey = null, string operation = null)
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
