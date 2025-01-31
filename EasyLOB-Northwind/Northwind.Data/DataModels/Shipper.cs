using EasyLOB.Data;
using EasyLOB.Library;
using System;
using System.Collections.Generic;

namespace Northwind.Data
{
    public partial class Shipper : ZDataModel
    {        
        #region Properties
        
        [ZKey(true)]
        public virtual int ShipperId { get; set; }
        
        public virtual string CompanyName { get; set; }
        
        public virtual string Phone { get; set; }

        #endregion Properties

        #region Collections (PK)

        public virtual IList<Order> Orders { get; }

        #endregion Collections (PK)

        #region Methods
        
        public Shipper()
        {
            Orders = new List<Order>();
    
            OnConstructor();
        }

        public override object[] GetId()
        {
            return new object[] { ShipperId };
        }

        public override void SetId(object[] ids)
        {
            if (ids != null && ids[0] != null)
            {
                ShipperId = DataHelper.IdToInt32(ids[0]);
            }
        }

        #endregion Methods
    }
}
