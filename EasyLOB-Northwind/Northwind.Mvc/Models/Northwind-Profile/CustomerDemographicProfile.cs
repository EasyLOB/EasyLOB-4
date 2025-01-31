using EasyLOB;

namespace Northwind.Data
{
    public partial class CustomerDemographicViewModel
    {
        #region Methods

        public static void OnSetupProfile(IZProfile profile)
        {
            //profile.Collections["CustomerCustomerDemos"] = false;
        }

        #endregion Methods
    }
}
