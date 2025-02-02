using EasyLOB.AuditTrail.Data.Resources;
using EasyLOB.Data;
using EasyLOB.Library;
using EasyLOB.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EasyLOB.AuditTrail.Data
{
    public partial class AuditTrailLogViewModel : ZViewModel<AuditTrailLogViewModel, AuditTrailLog>
    {
        #region Properties
        
        [Display(Name = "PropertyId", ResourceType = typeof(AuditTrailLogResources))]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        //[Key]
        [Required]
        public virtual int Id { get; set; }
        
        [Display(Name = "PropertyLogDate", ResourceType = typeof(AuditTrailLogResources))]
        //[DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:G}", ApplyFormatInEditMode = true)]
        public virtual DateTime? LogDate { get; set; }
        
        [Display(Name = "PropertyLogTime", ResourceType = typeof(AuditTrailLogResources))]
        //[DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:G}", ApplyFormatInEditMode = true)]
        public virtual DateTime? LogTime { get; set; }
        
        [Display(Name = "PropertyLogUserName", ResourceType = typeof(AuditTrailLogResources))]
        [StringLength(256)]
        public virtual string LogUserName { get; set; }

        [Display(Name = "PropertyLogDomain", ResourceType = typeof(AuditTrailLogResources))]
        [StringLength(256)]
        public virtual string LogDomain { get; set; }

        [Display(Name = "PropertyLogEntity", ResourceType = typeof(AuditTrailLogResources))]
        [StringLength(256)]
        public virtual string LogEntity { get; set; }
        
        [Display(Name = "PropertyLogOperation", ResourceType = typeof(AuditTrailLogResources))]
        [StringLength(1)]
        public virtual string LogOperation { get; set; }
        
        [Display(Name = "PropertyLogId", ResourceType = typeof(AuditTrailLogResources))]
        [StringLength(4096)]
        public virtual string LogId { get; set; }
        
        [Display(Name = "PropertyLogEntityBefore", ResourceType = typeof(AuditTrailLogResources))]
        [StringLength(4096)]
        public virtual string LogEntityBefore { get; set; }
        
        [Display(Name = "PropertyLogEntityAfter", ResourceType = typeof(AuditTrailLogResources))]
        [StringLength(4096)]
        public virtual string LogEntityAfter { get; set; }

        #endregion Properties

        #region Methods
        
        public AuditTrailLogViewModel()
        {
            OnConstructor();
        }

        public AuditTrailLogViewModel(IZDataModel dataModel)
        {
            FromData(dataModel);
        }

        #endregion Methods
    }
}
