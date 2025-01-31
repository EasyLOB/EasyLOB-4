namespace EasyLOB.Activity.Data
{
    public partial class ActivityViewModel
    {
        #region Methods

        public static void OnSetupProfile(IZProfile profile)
        {
            //profile.Collections["ActivityRoles"] = false;

            profile.SetProfileProperty("Id", isEditReadOnly: true);
        }

        #endregion Methods
    }
}
