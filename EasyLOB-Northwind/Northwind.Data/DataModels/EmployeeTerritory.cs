using EasyLOB.Data;
using EasyLOB.Library;
using System;
using System.Collections.Generic;

namespace Northwind.Data
{
    public partial class EmployeeTerritory : ZDataModel
    {        
        #region Properties
        
        private int _employeeId;
        
        [ZKey]
        public virtual int EmployeeId
        {
            get { return this.Employee == null ? _employeeId : this.Employee.EmployeeId; }
            set
            {
                _employeeId = value;
                Employee = null;
            }
        }
        
        private string _territoryId;
        
        [ZKey]
        public virtual string TerritoryId
        {
            get { return this.Territory == null ? _territoryId : this.Territory.TerritoryId; }
            set
            {
                _territoryId = value;
                Territory = null;
            }
        }

        #endregion Properties

        #region Associations (FK)

        public virtual Employee Employee { get; set; } // EmployeeId

        public virtual Territory Territory { get; set; } // TerritoryId

        #endregion Associations (FK)

        #region Methods
        
        public EmployeeTerritory()
        {
            OnConstructor();
        }

        public override object[] GetId()
        {
            return new object[] { EmployeeId, TerritoryId };
        }

        public override void SetId(object[] ids)
        {
            if (ids != null && ids[0] != null)
            {
                EmployeeId = DataHelper.IdToInt32(ids[0]);
            }
            if (ids != null && ids[1] != null)
            {
                TerritoryId = DataHelper.IdToString(ids[1]);
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

            if (obj is EmployeeTerritory)
            {
                var employeeTerritory = (EmployeeTerritory)obj;
                if (employeeTerritory == null)
                {
                    return false;
                }

                if (EmployeeId == employeeTerritory.EmployeeId && TerritoryId == employeeTerritory.TerritoryId)
                {
                    return true;
                }
            }

            return false;
        }

        public override int GetHashCode()
        {
            return (EmployeeId.ToString() + "|" + TerritoryId.ToString()).GetHashCode();
        }

        #endregion Methods NHibernate
    }
}
