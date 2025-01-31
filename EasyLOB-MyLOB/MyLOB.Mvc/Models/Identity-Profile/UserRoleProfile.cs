namespace EasyLOB.Identity.Data
{
    public partial class UserRoleViewModel
    {
        #region Methods

        public static void OnSetupProfile(IZProfile profile)
        {
            profile.SetProfileProperty("RoleLookupText", isGridVisible: true);
            profile.SetProfileProperty("UserLookupText", isGridVisible: true);
        }

        #endregion Methods
    }
}

