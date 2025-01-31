using EasyLOB;

namespace Northwind.Data
{
    public partial class ShipperViewModel
    {
        #region Methods

        public static void OnSetupProfile(IZProfile profile)
        {
            //profile.Collections["Orders"] = false;
        }

        #endregion Methods
    }
}
