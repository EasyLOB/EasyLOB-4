using Northwind.Data;
using EasyLOB;
using EasyLOB.Mvc;

namespace Northwind.Mvc
{
    public partial class EmployeeItemModel : ItemModel
    {
        #region Properties

        public EmployeeViewModel Employee { get; set; }

        #endregion Properties
        
        #region Methods

        public EmployeeItemModel()
            : base()
        {
            Entity = "Employee";
            Employee = new EmployeeViewModel();

            OnConstructor();
        }

        public EmployeeItemModel(ZActivityOperations activityOperations, string controllerAction, string masterEntity = null, string masterKey = null, EmployeeViewModel employee = null)
            : this()
        {
            ActivityOperations = activityOperations;
            ControllerAction = controllerAction;
            MasterEntity = masterEntity;
            MasterKey = masterKey;
            Employee = employee ?? Employee;
        }
        
        #endregion Methods
    }
}
