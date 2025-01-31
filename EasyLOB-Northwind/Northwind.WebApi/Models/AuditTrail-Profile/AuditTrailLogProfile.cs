namespace EasyLOB.AuditTrail.Data
{
    public partial class AuditTrailLogViewModel
    {
        #region Methods

        public static void OnSetupProfile(IZProfile profile)
        {
            profile.SetProfileProperty("LogDate", isGridVisible: true);
            profile.SetProfileProperty("LogTime", isGridVisible: true);
            profile.SetProfileProperty("LogUserName", isGridVisible: true);
            profile.SetProfileProperty("LogDomain", isGridVisible: false, isEditVisible: false);
            profile.SetProfileProperty("LogEntity", isGridVisible: true);
            profile.SetProfileProperty("LogOperation", isGridVisible: true);
            profile.SetProfileProperty("LogEntityBefore", editCSS: "col-md-5");
            profile.SetProfileProperty("LogEntityAfter", editCSS: "col-md-5");
        }

        #endregion Methods
    }
}

