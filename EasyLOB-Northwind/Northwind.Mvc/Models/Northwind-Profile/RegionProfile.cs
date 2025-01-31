using EasyLOB;

namespace Northwind.Data
{
    public partial class RegionViewModel
    {
        #region Methods

        public static void OnSetupProfile(IZProfile profile)
        {
            //profile.Collections["Territories"] = false;
        }

        #endregion Methods
    }
}
