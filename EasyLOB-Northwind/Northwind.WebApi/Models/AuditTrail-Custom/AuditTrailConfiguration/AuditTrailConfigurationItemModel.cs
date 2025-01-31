using EasyLOB.AuditTrail.Resources;
using System.Collections.Generic;
using System.Web.Mvc;

namespace EasyLOB.AuditTrail.Mvc
{
    public partial class AuditTrailConfigurationItemModel
    {
        #region Properties

        public virtual List<SelectListItem> LogModes { get; set; }

        #endregion Properties

        #region Methods

        public override void OnConstructor()
        {
            LogModes = new List<SelectListItem>();
            LogModes.Add(new SelectListItem { Text = AuditTrailResources.LogModeNone, Value = "N", Selected = true });
            LogModes.Add(new SelectListItem { Text = AuditTrailResources.LogModeKey, Value = "K" });
            LogModes.Add(new SelectListItem { Text = AuditTrailResources.LogModeEntity, Value = "E" });
        }
        
        #endregion Methods
    }
}
