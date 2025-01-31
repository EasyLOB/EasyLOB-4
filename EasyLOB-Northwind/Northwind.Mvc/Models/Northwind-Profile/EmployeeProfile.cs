using EasyLOB;

namespace Northwind.Data
{
    public partial class EmployeeViewModel
    {
        #region Methods

        public static void OnSetupProfile(IZProfile profile)
        {
            //profile.Collections["Employees"] = false;
            //profile.Collections["EmployeeTerritories"] = false;
            //profile.Collections["Orders"] = false;

            //profile.SetProfileProperty("EmployeeXLookupText", isGridVisible: true);
        }

        #endregion Methods
    }
}
