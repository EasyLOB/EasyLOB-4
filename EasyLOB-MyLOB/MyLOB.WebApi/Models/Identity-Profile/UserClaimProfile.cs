namespace EasyLOB.Identity.Data
{
    public partial class UserClaimViewModel
    {
        #region Methods

        public static void OnSetupProfile(IZProfile profile)
        {
            profile.SetProfileProperty("ClaimType", isGridVisible: true);
            profile.SetProfileProperty("ClaimValue", isGridVisible: true);

            profile.SetProfileProperty("Id", isEditReadOnly: true);

            profile.SetProfileProperty("UserLookupText", isGridVisible: true);
        }

        #endregion Methods
    }
}

