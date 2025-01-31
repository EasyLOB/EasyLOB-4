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
    public partial class EmployeeTerritoryViewModel : ZViewModel<EmployeeTerritoryViewModel, EmployeeTerritory>
    {
        #region Properties
        
        [Display(Name = "PropertyEmployeeId", ResourceType = typeof(EmployeeTerritoryResources))]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        //[Key]
        //[Column(Order=1)]
        [Range(1, System.Int32.MaxValue, ErrorMessageResourceName = "Range", ErrorMessageResourceType = typeof(DataAnnotationResources))]
        [Required]
        public virtual int EmployeeId { get; set; }
        
        [Display(Name = "PropertyTerritoryId", ResourceType = typeof(EmployeeTerritoryResources))]
        //[Key]
        //[Column(Order=2)]
        [Required]
        [StringLength(20)]
        public virtual string TerritoryId { get; set; }

        #endregion Properties

        #region Associations (FK)

        public virtual string EmployeeLookupText { get; set; } // EmployeeId

        public virtual string TerritoryLookupText { get; set; } // TerritoryId
    
        #endregion Associations (FK)

        #region Methods
        
        public EmployeeTerritoryViewModel()
        {
            OnConstructor();
        }

        public EmployeeTerritoryViewModel(IZDataModel dataModel)
        {
            FromData(dataModel);
        }

        #endregion Methods
    }
}
