using EasyLOB;

namespace Northwind.Data
{
    public partial class OrderDetailViewModel
    {
        #region Methods

        public static void OnSetupProfile(IZProfile profile)
        {
            //profile.SetProfileProperty("OrderLookupText", isGridVisible: true);
            //profile.SetProfileProperty("ProductLookupText", isGridVisible: true);
        }

        #endregion Methods
    }
}
