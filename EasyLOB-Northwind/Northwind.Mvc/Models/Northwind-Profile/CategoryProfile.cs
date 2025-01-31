using EasyLOB;

namespace Northwind.Data
{
    public partial class CategoryViewModel
    {
        #region Methods

        public static void OnSetupProfile(IZProfile profile)
        {
            //profile.Collections["Products"] = false;

            // !!!
            profile.SetProfileProperty("Description", isEditRequired: true);
        }

        #endregion Methods
    }
}
