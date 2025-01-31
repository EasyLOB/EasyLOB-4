using EasyLOB;
using EasyLOB.Data;
using EasyLOB.Library;
using System;
using System.Collections.Generic;

namespace Northwind.Data
{
    public partial class CustomerDTO : ZDTOModel<CustomerDTO, Customer>
    {
        #region Properties
               
        public virtual string CustomerId { get; set; }
               
        public virtual string CompanyName { get; set; }
               
        public virtual string ContactName { get; set; }
               
        public virtual string ContactTitle { get; set; }
               
        public virtual string Address { get; set; }
               
        public virtual string City { get; set; }
               
        public virtual string Region { get; set; }
               
        public virtual string PostalCode { get; set; }
               
        public virtual string Country { get; set; }
               
        public virtual string Phone { get; set; }
               
        public virtual string Fax { get; set; }

        #endregion Properties

        #region Methods

        public CustomerDTO()
        {
            OnConstructor();
        }

        public CustomerDTO(IZDataModel dataModel)
        {
            FromData(dataModel);
        }
        
        #endregion Methods
    }
}
