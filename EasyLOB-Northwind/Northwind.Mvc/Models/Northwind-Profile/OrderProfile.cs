using EasyLOB;

namespace Northwind.Data
{
    public partial class OrderViewModel
    {
        #region Methods

        public static void OnSetupProfile(IZProfile profile)
        {
            //profile.Collections["OrderDetails"] = false;

            //profile.SetProfileProperty("CustomerLookupText", isGridVisible: true);
            //profile.SetProfileProperty("EmployeeLookupText", isGridVisible: true);
            //profile.SetProfileProperty("ShipperLookupText", isGridVisible: true);
        }

        #endregion Methods
    }
}
