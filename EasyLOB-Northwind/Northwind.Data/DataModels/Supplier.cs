using EasyLOB.Data;
using EasyLOB.Library;
using System;
using System.Collections.Generic;

namespace Northwind.Data
{
    public partial class Supplier : ZDataModel
    {        
        #region Properties
        
        [ZKey(true)]
        public virtual int SupplierId { get; set; }
        
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
        
        public virtual string HomePage { get; set; }

        #endregion Properties

        #region Collections (PK)

        public virtual IList<Product> Products { get; }

        #endregion Collections (PK)

        #region Methods
        
        public Supplier()
        {
            Products = new List<Product>();
    
            OnConstructor();
        }

        public override object[] GetId()
        {
            return new object[] { SupplierId };
        }

        public override void SetId(object[] ids)
        {
            if (ids != null && ids[0] != null)
            {
                SupplierId = DataHelper.IdToInt32(ids[0]);
            }
        }

        #endregion Methods
    }
}
