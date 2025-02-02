using EasyLOB.AuditTrail.Data.Resources;
using EasyLOB.Data;
using EasyLOB.Library;
using EasyLOB.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EasyLOB.AuditTrail.Data
{
    public partial class AuditTrailConfigurationViewModel : ZViewModel<AuditTrailConfigurationViewModel, AuditTrailConfiguration>
    {
        #region Properties
        
        [Display(Name = "PropertyId", ResourceType = typeof(AuditTrailConfigurationResources))]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        //[Key]
        [Required]
        public virtual int Id { get; set; }

        [Display(Name = "PropertyDomain", ResourceType = typeof(AuditTrailConfigurationResources))]
        [Required]
        [StringLength(256)]
        public virtual string Domain { get; set; }

        [Display(Name = "PropertyEntity", ResourceType = typeof(AuditTrailConfigurationResources))]
        [Required]
        [StringLength(256)]
        public virtual string Entity { get; set; }
        
        [Display(Name = "PropertyLogMode", ResourceType = typeof(AuditTrailConfigurationResources))]
        [Required]
        [StringLength(1)]
        public virtual string LogMode { get; set; }
        
        [Display(Name = "PropertyLogOperations", ResourceType = typeof(AuditTrailConfigurationResources))]
        [StringLength(256)]
        public virtual string LogOperations { get; set; }

        #endregion Properties

        #region Methods
        
        public AuditTrailConfigurationViewModel()
        {
            OnConstructor();
        }

        public AuditTrailConfigurationViewModel(IZDataModel dataModel)
        {
            FromData(dataModel);
        }

        #endregion Methods
    }
}
