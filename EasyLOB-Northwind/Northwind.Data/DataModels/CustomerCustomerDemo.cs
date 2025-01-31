using EasyLOB.Data;
using EasyLOB.Library;
using System;
using System.Collections.Generic;

namespace Northwind.Data
{
    public partial class CustomerCustomerDemo : ZDataModel
    {        
        #region Properties
        
        private string _customerId;
        
        [ZKey]
        public virtual string CustomerId
        {
            get { return this.Customer == null ? _customerId : this.Customer.CustomerId; }
            set
            {
                _customerId = value;
                Customer = null;
            }
        }
        
        private string _customerTypeId;
        
        [ZKey]
        public virtual string CustomerTypeId
        {
            get { return this.CustomerDemographic == null ? _customerTypeId : this.CustomerDemographic.CustomerTypeId; }
            set
            {
                _customerTypeId = value;
                CustomerDemographic = null;
            }
        }

        #endregion Properties

        #region Associations (FK)

        public virtual CustomerDemographic CustomerDemographic { get; set; } // CustomerTypeId

        public virtual Customer Customer { get; set; } // CustomerId

        #endregion Associations (FK)

        #region Methods
        
        public CustomerCustomerDemo()
        {
            OnConstructor();
        }

        public override object[] GetId()
        {
            return new object[] { CustomerId, CustomerTypeId };
        }

        public override void SetId(object[] ids)
        {
            if (ids != null && ids[0] != null)
            {
                CustomerId = DataHelper.IdToString(ids[0]);
            }
            if (ids != null && ids[1] != null)
            {
                CustomerTypeId = DataHelper.IdToString(ids[1]);
            }
        }

        #endregion Methods

        #region Methods NHibernate

        public override bool Equals(Object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj is CustomerCustomerDemo)
            {
                var customerCustomerDemo = (CustomerCustomerDemo)obj;
                if (customerCustomerDemo == null)
                {
                    return false;
                }

                if (CustomerId == customerCustomerDemo.CustomerId && CustomerTypeId == customerCustomerDemo.CustomerTypeId)
                {
                    return true;
                }
            }

            return false;
        }

        public override int GetHashCode()
        {
            return (CustomerId.ToString() + "|" + CustomerTypeId.ToString()).GetHashCode();
        }

        #endregion Methods NHibernate
    }
}
