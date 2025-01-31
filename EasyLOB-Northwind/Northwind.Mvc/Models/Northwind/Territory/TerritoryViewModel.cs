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
    public partial class TerritoryViewModel : ZViewModel<TerritoryViewModel, Territory>
    {
        #region Properties
        
        [Display(Name = "PropertyTerritoryId", ResourceType = typeof(TerritoryResources))]
        //[Key]
        [Required]
        [StringLength(20)]
        public virtual string TerritoryId { get; set; }
        
        [Display(Name = "PropertyTerritoryDescription", ResourceType = typeof(TerritoryResources))]
        [Required]
        [StringLength(50)]
        public virtual string TerritoryDescription { get; set; }
        
        [Display(Name = "PropertyRegionId", ResourceType = typeof(TerritoryResources))]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        [Range(1, System.Int32.MaxValue, ErrorMessageResourceName = "Range", ErrorMessageResourceType = typeof(DataAnnotationResources))]
        [Required]
        public virtual int RegionId { get; set; }

        #endregion Properties

        #region Associations (FK)

        public virtual string RegionLookupText { get; set; } // RegionId
    
        #endregion Associations (FK)

        #region Methods
        
        public TerritoryViewModel()
        {
            OnConstructor();
        }

        public TerritoryViewModel(IZDataModel dataModel)
        {
            FromData(dataModel);
        }

        #endregion Methods
    }
}
