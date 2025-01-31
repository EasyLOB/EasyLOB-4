using EasyLOB.Data;
using EasyLOB.Library;
using System;
using System.Collections.Generic;

namespace Northwind.Data
{
    public partial class CustomerDemographic : ZDataModel
    {        
        #region Properties
        
        [ZKey]
        public virtual string CustomerTypeId { get; set; }
        
        public virtual string CustomerDesc { get; set; }

        #endregion Properties

        #region Collections (PK)

        public virtual IList<CustomerCustomerDemo> CustomerCustomerDemos { get; }

        #endregion Collections (PK)

        #region Methods
        
        public CustomerDemographic()
        {
            CustomerCustomerDemos = new List<CustomerCustomerDemo>();
    
            OnConstructor();
        }

        public override object[] GetId()
        {
            return new object[] { CustomerTypeId };
        }

        public override void SetId(object[] ids)
        {
            if (ids != null && ids[0] != null)
            {
                CustomerTypeId = DataHelper.IdToString(ids[0]);
            }
        }

        #endregion Methods
    }
}
