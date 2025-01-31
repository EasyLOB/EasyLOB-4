using EasyLOB.Data;
using EasyLOB.Library;
using System;
using System.Collections.Generic;

namespace Northwind.Data
{
    public partial class Territory : ZDataModel
    {        
        #region Properties
        
        [ZKey]
        public virtual string TerritoryId { get; set; }
        
        public virtual string TerritoryDescription { get; set; }
        
        private int _regionId;
        
        public virtual int RegionId
        {
            get { return this.Region == null ? _regionId : this.Region.RegionId; }
            set
            {
                _regionId = value;
                Region = null;
            }
        }

        #endregion Properties

        #region Associations (FK)

        public virtual Region Region { get; set; } // RegionId

        #endregion Associations (FK)

        #region Collections (PK)

        public virtual IList<EmployeeTerritory> EmployeeTerritories { get; }

        #endregion Collections (PK)

        #region Methods
        
        public Territory()
        {
            EmployeeTerritories = new List<EmployeeTerritory>();
    
            OnConstructor();
        }

        public override object[] GetId()
        {
            return new object[] { TerritoryId };
        }

        public override void SetId(object[] ids)
        {
            if (ids != null && ids[0] != null)
            {
                TerritoryId = DataHelper.IdToString(ids[0]);
            }
        }

        #endregion Methods
    }
}
