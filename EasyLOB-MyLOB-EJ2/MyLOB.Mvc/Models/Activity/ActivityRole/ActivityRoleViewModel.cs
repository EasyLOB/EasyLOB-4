using EasyLOB.Activity.Data.Resources;
using EasyLOB.Data;
using EasyLOB.Library;
using EasyLOB.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EasyLOB.Activity.Data
{
    public partial class ActivityRoleViewModel : ZViewModel<ActivityRoleViewModel, ActivityRole>
    {
        #region Properties
        
        [Display(Name = "PropertyActivityId", ResourceType = typeof(ActivityRoleResources))]
        //[Key]
        //[Column(Order=1)]
        [Required]
        [StringLength(128)]
        public virtual string ActivityId { get; set; }
        
        [Display(Name = "PropertyRoleName", ResourceType = typeof(ActivityRoleResources))]
        //[Key]
        //[Column(Order=2)]
        [Required]
        [StringLength(256)]
        public virtual string RoleName { get; set; }
        
        [Display(Name = "PropertyOperations", ResourceType = typeof(ActivityRoleResources))]
        [StringLength(256)]
        public virtual string Operations { get; set; }

        #endregion Properties

        #region Associations (FK)

        public virtual string ActivityLookupText { get; set; } // ActivityId
    
        #endregion Associations (FK)

        #region Methods
        
        public ActivityRoleViewModel()
        {
            OnConstructor();
        }

        public ActivityRoleViewModel(IZDataModel dataModel)
        {
            FromData(dataModel);
        }

        #endregion Methods
    }
}
