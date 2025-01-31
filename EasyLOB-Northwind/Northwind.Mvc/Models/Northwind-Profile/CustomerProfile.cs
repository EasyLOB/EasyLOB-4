using EasyLOB;

namespace Northwind.Data
{
    public partial class CustomerViewModel
    {
        #region Methods

        public static void OnSetupProfile(IZProfile profile)
        {
            //profile.Collections["CustomerCustomerDemos"] = false;
            //profile.Collections["Orders"] = false;
        }

        #endregion Methods
    }
}
