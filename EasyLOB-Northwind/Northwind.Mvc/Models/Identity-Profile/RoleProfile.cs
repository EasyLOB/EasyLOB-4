namespace EasyLOB.Identity.Data
{
    public partial class RoleViewModel
    {
        #region Methods

        public static void OnSetupProfile(IZProfile profile)
        {
            //profile.Collections["UserRoles"] = false;

            profile.SetProfileProperty("Id", isEditReadOnly: true);
            profile.SetProfileProperty("Discriminator", isEditVisible: false);
        }

        #endregion Methods
    }
}

