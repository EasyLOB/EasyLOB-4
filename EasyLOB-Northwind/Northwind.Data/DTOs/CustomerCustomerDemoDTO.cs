using EasyLOB;
using EasyLOB.Data;
using EasyLOB.Library;
using System;
using System.Collections.Generic;

namespace Northwind.Data
{
    public partial class CustomerCustomerDemoDTO : ZDTOModel<CustomerCustomerDemoDTO, CustomerCustomerDemo>
    {
        #region Properties
               
        public virtual string CustomerId { get; set; }
               
        public virtual string CustomerTypeId { get; set; }

        #endregion Properties

        #region Associations (FK)

        public virtual string CustomerDemographicLookupText { get; set; } // CustomerTypeId

        public virtual string CustomerLookupText { get; set; } // CustomerId

        #endregion Associations (FK)

        #region Methods

        public CustomerCustomerDemoDTO()
        {
            OnConstructor();
        }

        public CustomerCustomerDemoDTO(IZDataModel dataModel)
        {
            FromData(dataModel);
        }
        
        #endregion Methods
    }
}
