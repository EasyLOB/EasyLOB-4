using EasyLOB;

namespace Northwind.Data
{
    public partial class ProductViewModel
    {
        #region Methods

        public static void OnSetupProfile(IZProfile profile)
        {
            //profile.Collections["OrderDetails"] = false;

            //profile.SetProfileProperty("CategoryLookupText", isGridVisible: true);
            //profile.SetProfileProperty("SupplierLookupText", isGridVisible: true);
        }

        #endregion Methods
    }
}
