using EasyLOB.Activity.Data.Resources;
using EasyLOB.Data;
using EasyLOB.Library;
using EasyLOB.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EasyLOB.Activity.Data
{
    public partial class ActivityViewModel : ZViewModel<ActivityViewModel, Activity>
    {
        #region Properties
        
        [Display(Name = "PropertyId", ResourceType = typeof(ActivityResources))]
        //[Key]
        [Required]
        [StringLength(128)]
        public virtual string Id { get; set; }
        
        [Display(Name = "PropertyName", ResourceType = typeof(ActivityResources))]
        [Required]
        [StringLength(256)]
        public virtual string Name { get; set; }

        #endregion Properties

        #region Methods
        
        public ActivityViewModel()
        {
            OnConstructor();
        }

        public ActivityViewModel(IZDataModel dataModel)
        {
            FromData(dataModel);
        }

        #endregion Methods
    }
}
