using EasyLOB.AuditTrail.Data.Resources;
using System.ComponentModel.DataAnnotations;

namespace EasyLOB.AuditTrail.Data
{
    public partial class AuditTrailConfigurationViewModel
    {
        #region Methods

        public override void OnConstructor()
        {
            LogMode = "N";
        }

        #endregion Methods
    }
}