using EasyLOB.Data;
using EasyLOB.Library;
using System;
using System.Collections.Generic;

namespace Northwind.Data
{
    public partial class Category : ZDataModel
    {        
        #region Properties
        
        [ZKey(true)]
        public virtual int CategoryId { get; set; }
        
        public virtual string CategoryName { get; set; }
        
        public virtual string Description { get; set; }
        
        public virtual byte[] Picture { get; set; }

        #endregion Properties

        #region Collections (PK)

        public virtual IList<Product> Products { get; }

        #endregion Collections (PK)

        #region Methods
        
        public Category()
        {
            Products = new List<Product>();
    
            OnConstructor();
        }

        public override object[] GetId()
        {
            return new object[] { CategoryId };
        }

        public override void SetId(object[] ids)
        {
            if (ids != null && ids[0] != null)
            {
                CategoryId = DataHelper.IdToInt32(ids[0]);
            }
        }

        #endregion Methods
    }
}
