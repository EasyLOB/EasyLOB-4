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
    public partial class SupplierViewModel : ZViewModel<SupplierViewModel, Supplier>
    {
        #region Properties
        
        [Display(Name = "PropertySupplierId", ResourceType = typeof(SupplierResources))]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        //[Key]
        [Required]
        public virtual int SupplierId { get; set; }
        
        [Display(Name = "PropertyCompanyName", ResourceType = typeof(SupplierResources))]
        [Required]
        [StringLength(40)]
        public virtual string CompanyName { get; set; }
        
        [Display(Name = "PropertyContactName", ResourceType = typeof(SupplierResources))]
        [StringLength(30)]
        public virtual string ContactName { get; set; }
        
        [Display(Name = "PropertyContactTitle", ResourceType = typeof(SupplierResources))]
        [StringLength(30)]
        public virtual string ContactTitle { get; set; }
        
        [Display(Name = "PropertyAddress", ResourceType = typeof(SupplierResources))]
        [StringLength(60)]
        public virtual string Address { get; set; }
        
        [Display(Name = "PropertyCity", ResourceType = typeof(SupplierResources))]
        [StringLength(15)]
        public virtual string City { get; set; }
        
        [Display(Name = "PropertyRegion", ResourceType = typeof(SupplierResources))]
        [StringLength(15)]
        public virtual string Region { get; set; }
        
        [Display(Name = "PropertyPostalCode", ResourceType = typeof(SupplierResources))]
        [StringLength(10)]
        public virtual string PostalCode { get; set; }
        
        [Display(Name = "PropertyCountry", ResourceType = typeof(SupplierResources))]
        [StringLength(15)]
        public virtual string Country { get; set; }
        
        [Display(Name = "PropertyPhone", ResourceType = typeof(SupplierResources))]
        [StringLength(24)]
        public virtual string Phone { get; set; }
        
        [Display(Name = "PropertyFax", ResourceType = typeof(SupplierResources))]
        [StringLength(24)]
        public virtual string Fax { get; set; }
        
        [Display(Name = "PropertyHomePage", ResourceType = typeof(SupplierResources))]
        [StringLength(1024)]
        public virtual string HomePage { get; set; }

        #endregion Properties

        #region Methods
        
        public SupplierViewModel()
        {
            OnConstructor();
        }

        public SupplierViewModel(IZDataModel dataModel)
        {
            FromData(dataModel);
        }

        #endregion Methods
    }
}
