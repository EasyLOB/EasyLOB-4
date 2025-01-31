using Northwind.Data.Resources;
using EasyLOB;
using EasyLOB.Data;
using EasyLOB.Library;
using EasyLOB.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Northwind.Data
{
    public partial class RegionViewModel : ZViewModel<RegionViewModel, Region>
    {
        #region Properties
        
        [Display(Name = "PropertyRegionId", ResourceType = typeof(RegionResources))]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        //[Key]
        [Required]
        public virtual int RegionId { get; set; }
        
        [Display(Name = "PropertyRegionDescription", ResourceType = typeof(RegionResources))]
        [Required]
        [StringLength(50)]
        public virtual string RegionDescription { get; set; }

        #endregion Properties

        #region Methods
        
        public RegionViewModel()
        {
            OnConstructor();
        }

        public RegionViewModel(IZDataModel dataModel)
        {
            FromData(dataModel);
        }

        #endregion Methods
    }
}
