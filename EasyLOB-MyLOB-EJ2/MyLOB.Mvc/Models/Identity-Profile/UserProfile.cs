namespace EasyLOB.Identity.Data
{
    public partial class UserViewModel
    {
        #region Methods

        public static void OnSetupProfile(IZProfile profile)
        {
            profile.Collections["UserClaims"] = false;
            profile.Collections["UserLogins"] = false;
            //profile.Collections["UserRoles"] = false;

            profile.SetProfileProperty("Id", isEditReadOnly: true);
            profile.SetProfileProperty("Email", isGridVisible: true);
            profile.SetProfileProperty("EmailConfirmed", isEditVisible: false);
            profile.SetProfileProperty("SecurityStamp", isEditVisible: false);
            profile.SetProfileProperty("PhoneNumber", isEditVisible: false);
            profile.SetProfileProperty("PhoneNumberConfirmed", isEditVisible: false);
            profile.SetProfileProperty("TwoFactorEnabled", isEditVisible: false);
            profile.SetProfileProperty("LockoutEndDateUtc", isGridVisible: true);
            profile.SetProfileProperty("LockoutEnabled", isGridVisible: true);
            profile.SetProfileProperty("AccessFailedCount", isEditVisible: false);
        }

        #endregion Methods
    }
}

