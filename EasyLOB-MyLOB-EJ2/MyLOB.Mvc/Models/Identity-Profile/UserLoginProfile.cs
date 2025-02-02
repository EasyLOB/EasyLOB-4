namespace EasyLOB.Identity.Data
{
    public partial class UserLoginViewModel
    {
        #region Methods

        public static void OnSetupProfile(IZProfile profile)
        {
            profile.SetProfileProperty("LoginProvider", isEditVisible: false);
            profile.SetProfileProperty("ProviderKey", isEditVisible: false);
            profile.SetProfileProperty("UserId", isGridVisible: true);

            profile.SetProfileProperty("UserLookupText", isGridVisible: true);
        }

        #endregion Methods
    }
}

