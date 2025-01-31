using Northwind.Data;
using EasyLOB;
using EasyLOB.Mvc;

namespace Northwind.Mvc
{
    public partial class EmployeeTerritoryItemModel : ItemModel
    {
        #region Properties

        public EmployeeTerritoryViewModel EmployeeTerritory { get; set; }

        #endregion Properties
        
        #region Methods

        public EmployeeTerritoryItemModel()
            : base()
        {
            Entity = "EmployeeTerritory";
            EmployeeTerritory = new EmployeeTerritoryViewModel();

            OnConstructor();
        }

        public EmployeeTerritoryItemModel(ZActivityOperations activityOperations, string controllerAction, string masterEntity = null, string masterKey = null, EmployeeTerritoryViewModel employeeTerritory = null)
            : this()
        {
            ActivityOperations = activityOperations;
            ControllerAction = controllerAction;
            MasterEntity = masterEntity;
            MasterKey = masterKey;
            EmployeeTerritory = employeeTerritory ?? EmployeeTerritory;
        }
        
        #endregion Methods
    }
}
