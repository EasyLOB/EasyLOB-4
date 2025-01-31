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
    public partial class CustomerDemographicViewModel : ZViewModel<CustomerDemographicViewModel, CustomerDemographic>
    {
        #region Properties
        
        [Display(Name = "PropertyCustomerTypeId", ResourceType = typeof(CustomerDemographicResources))]
        //[Key]
        [Required]
        [StringLength(10)]
        public virtual string CustomerTypeId { get; set; }
        
        [Display(Name = "PropertyCustomerDesc", ResourceType = typeof(CustomerDemographicResources))]
        [StringLength(1024)]
        public virtual string CustomerDesc { get; set; }

        #endregion Properties

        #region Methods
        
        public CustomerDemographicViewModel()
        {
            OnConstructor();
        }

        public CustomerDemographicViewModel(IZDataModel dataModel)
        {
            FromData(dataModel);
        }

        #endregion Methods
    }
}
