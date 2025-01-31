using Northwind.Data;
using EasyLOB;
using EasyLOB.Mvc;

namespace Northwind.Mvc
{
    public partial class CustomerDemographicItemModel : ItemModel
    {
        #region Properties

        public CustomerDemographicViewModel CustomerDemographic { get; set; }

        #endregion Properties
        
        #region Methods

        public CustomerDemographicItemModel()
            : base()
        {
            Entity = "CustomerDemographic";
            CustomerDemographic = new CustomerDemographicViewModel();

            OnConstructor();
        }

        public CustomerDemographicItemModel(ZActivityOperations activityOperations, string controllerAction, string masterEntity = null, string masterKey = null, CustomerDemographicViewModel customerDemographic = null)
            : this()
        {
            ActivityOperations = activityOperations;
            ControllerAction = controllerAction;
            MasterEntity = masterEntity;
            MasterKey = masterKey;
            CustomerDemographic = customerDemographic ?? CustomerDemographic;
        }
        
        #endregion Methods
    }
}
