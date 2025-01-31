using EasyLOB.Data;
using EasyLOB.Library;
using System;
using System.Collections.Generic;

namespace Northwind.Data
{
    public partial class Region : ZDataModel
    {        
        #region Properties
        
        [ZKey]
        public virtual int RegionId { get; set; }
        
        public virtual string RegionDescription { get; set; }

        #endregion Properties

        #region Collections (PK)

        public virtual IList<Territory> Territories { get; }

        #endregion Collections (PK)

        #region Methods
        
        public Region()
        {
            Territories = new List<Territory>();
    
            OnConstructor();
        }

        public override object[] GetId()
        {
            return new object[] { RegionId };
        }

        public override void SetId(object[] ids)
        {
            if (ids != null && ids[0] != null)
            {
                RegionId = DataHelper.IdToInt32(ids[0]);
            }
        }

        #endregion Methods
    }
}
