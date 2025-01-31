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
    public partial class CustomerViewModel : ZViewModel<CustomerViewModel, Customer>
    {
        #region Properties
        
        [Display(Name = "PropertyCustomerId", ResourceType = typeof(CustomerResources))]
        //[Key]
        [Required]
        [StringLength(5)]
        public virtual string CustomerId { get; set; }
        
        [Display(Name = "PropertyCompanyName", ResourceType = typeof(CustomerResources))]
        [Required]
        [StringLength(40)]
        public virtual string CompanyName { get; set; }
        
        [Display(Name = "PropertyContactName", ResourceType = typeof(CustomerResources))]
        [StringLength(30)]
        public virtual string ContactName { get; set; }
        
        [Display(Name = "PropertyContactTitle", ResourceType = typeof(CustomerResources))]
        [StringLength(30)]
        public virtual string ContactTitle { get; set; }
        
        [Display(Name = "PropertyAddress", ResourceType = typeof(CustomerResources))]
        [StringLength(60)]
        public virtual string Address { get; set; }
        
        [Display(Name = "PropertyCity", ResourceType = typeof(CustomerResources))]
        [StringLength(15)]
        public virtual string City { get; set; }
        
        [Display(Name = "PropertyRegion", ResourceType = typeof(CustomerResources))]
        [StringLength(15)]
        public virtual string Region { get; set; }
        
        [Display(Name = "PropertyPostalCode", ResourceType = typeof(CustomerResources))]
        [StringLength(10)]
        public virtual string PostalCode { get; set; }
        
        [Display(Name = "PropertyCountry", ResourceType = typeof(CustomerResources))]
        [StringLength(15)]
        public virtual string Country { get; set; }
        
        [Display(Name = "PropertyPhone", ResourceType = typeof(CustomerResources))]
        [StringLength(24)]
        public virtual string Phone { get; set; }
        
        [Display(Name = "PropertyFax", ResourceType = typeof(CustomerResources))]
        [StringLength(24)]
        public virtual string Fax { get; set; }

        #endregion Properties

        #region Methods
        
        public CustomerViewModel()
        {
            OnConstructor();
        }

        public CustomerViewModel(IZDataModel dataModel)
        {
            FromData(dataModel);
        }

        #endregion Methods
    }
}
