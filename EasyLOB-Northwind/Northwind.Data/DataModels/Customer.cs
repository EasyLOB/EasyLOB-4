using EasyLOB.Data;
using EasyLOB.Library;
using System;
using System.Collections.Generic;

namespace Northwind.Data
{
    public partial class Customer : ZDataModel
    {        
        #region Properties
        
        [ZKey]
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

        #region Collections (PK)

        public virtual IList<CustomerCustomerDemo> CustomerCustomerDemos { get; }

        public virtual IList<Order> Orders { get; }

        #endregion Collections (PK)

        #region Methods
        
        public Customer()
        {
            CustomerCustomerDemos = new List<CustomerCustomerDemo>();
            Orders = new List<Order>();
    
            OnConstructor();
        }

        public override object[] GetId()
        {
            return new object[] { CustomerId };
        }

        public override void SetId(object[] ids)
        {
            if (ids != null && ids[0] != null)
            {
                CustomerId = DataHelper.IdToString(ids[0]);
            }
        }

        #endregion Methods
    }
}
