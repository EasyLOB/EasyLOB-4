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
    public partial class EmployeeViewModel : ZViewModel<EmployeeViewModel, Employee>
    {
        #region Properties
        
        [Display(Name = "PropertyEmployeeId", ResourceType = typeof(EmployeeResources))]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        //[Key]
        [Required]
        public virtual int EmployeeId { get; set; }
        
        [Display(Name = "PropertyLastName", ResourceType = typeof(EmployeeResources))]
        [Required]
        [StringLength(20)]
        public virtual string LastName { get; set; }
        
        [Display(Name = "PropertyFirstName", ResourceType = typeof(EmployeeResources))]
        [Required]
        [StringLength(10)]
        public virtual string FirstName { get; set; }
        
        [Display(Name = "PropertyTitle", ResourceType = typeof(EmployeeResources))]
        [StringLength(30)]
        public virtual string Title { get; set; }
        
        [Display(Name = "PropertyTitleOfCourtesy", ResourceType = typeof(EmployeeResources))]
        [StringLength(25)]
        public virtual string TitleOfCourtesy { get; set; }
        
        [Display(Name = "PropertyBirthDate", ResourceType = typeof(EmployeeResources))]
        //[DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:G}", ApplyFormatInEditMode = true)]
        public virtual DateTime? BirthDate { get; set; }
        
        [Display(Name = "PropertyHireDate", ResourceType = typeof(EmployeeResources))]
        //[DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:G}", ApplyFormatInEditMode = true)]
        public virtual DateTime? HireDate { get; set; }
        
        [Display(Name = "PropertyAddress", ResourceType = typeof(EmployeeResources))]
        [StringLength(60)]
        public virtual string Address { get; set; }
        
        [Display(Name = "PropertyCity", ResourceType = typeof(EmployeeResources))]
        [StringLength(15)]
        public virtual string City { get; set; }
        
        [Display(Name = "PropertyRegion", ResourceType = typeof(EmployeeResources))]
        [StringLength(15)]
        public virtual string Region { get; set; }
        
        [Display(Name = "PropertyPostalCode", ResourceType = typeof(EmployeeResources))]
        [StringLength(10)]
        public virtual string PostalCode { get; set; }
        
        [Display(Name = "PropertyCountry", ResourceType = typeof(EmployeeResources))]
        [StringLength(15)]
        public virtual string Country { get; set; }
        
        [Display(Name = "PropertyHomePhone", ResourceType = typeof(EmployeeResources))]
        [StringLength(24)]
        public virtual string HomePhone { get; set; }
        
        [Display(Name = "PropertyExtension", ResourceType = typeof(EmployeeResources))]
        [StringLength(4)]
        public virtual string Extension { get; set; }
        
        [Display(Name = "PropertyPhoto", ResourceType = typeof(EmployeeResources))]
        public virtual byte[] Photo { get; set; }
        
        [Display(Name = "PropertyNotes", ResourceType = typeof(EmployeeResources))]
        [StringLength(1024)]
        public virtual string Notes { get; set; }
        
        [Display(Name = "PropertyReportsTo", ResourceType = typeof(EmployeeResources))]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public virtual int? ReportsTo { get; set; }
        
        [Display(Name = "PropertyPhotoPath", ResourceType = typeof(EmployeeResources))]
        [StringLength(255)]
        public virtual string PhotoPath { get; set; }

        #endregion Properties

        #region Associations (FK)

        public virtual string EmployeeXLookupText { get; set; } // ReportsTo
    
        #endregion Associations (FK)

        #region Methods
        
        public EmployeeViewModel()
        {
            OnConstructor();
        }

        public EmployeeViewModel(IZDataModel dataModel)
        {
            FromData(dataModel);
        }

        #endregion Methods
    }
}
