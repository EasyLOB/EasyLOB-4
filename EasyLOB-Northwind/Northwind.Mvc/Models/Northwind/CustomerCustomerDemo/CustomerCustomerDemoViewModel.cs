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
    public partial class CustomerCustomerDemoViewModel : ZViewModel<CustomerCustomerDemoViewModel, CustomerCustomerDemo>
    {
        #region Properties
        
        [Display(Name = "PropertyCustomerId", ResourceType = typeof(CustomerCustomerDemoResources))]
        //[Key]
        //[Column(Order=1)]
        [Required]
        [StringLength(5)]
        public virtual string CustomerId { get; set; }
        
        [Display(Name = "PropertyCustomerTypeId", ResourceType = typeof(CustomerCustomerDemoResources))]
        //[Key]
        //[Column(Order=2)]
        [Required]
        [StringLength(10)]
        public virtual string CustomerTypeId { get; set; }

        #endregion Properties

        #region Associations (FK)

        public virtual string CustomerDemographicLookupText { get; set; } // CustomerTypeId

        public virtual string CustomerLookupText { get; set; } // CustomerId
    
        #endregion Associations (FK)

        #region Methods
        
        public CustomerCustomerDemoViewModel()
        {
            OnConstructor();
        }

        public CustomerCustomerDemoViewModel(IZDataModel dataModel)
        {
            FromData(dataModel);
        }

        #endregion Methods
    }
}
