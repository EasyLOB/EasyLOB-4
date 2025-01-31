using EasyLOB.Data;
using EasyLOB.Library;
using System;
using System.Collections.Generic;

namespace Northwind.Data
{
    public partial class Employee : ZDataModel
    {        
        #region Properties
        
        [ZKey(true)]
        public virtual int EmployeeId { get; set; }
        
        public virtual string LastName { get; set; }
        
        public virtual string FirstName { get; set; }
        
        public virtual string Title { get; set; }
        
        public virtual string TitleOfCourtesy { get; set; }
        
        public virtual DateTime? BirthDate { get; set; }
        
        public virtual DateTime? HireDate { get; set; }
        
        public virtual string Address { get; set; }
        
        public virtual string City { get; set; }
        
        public virtual string Region { get; set; }
        
        public virtual string PostalCode { get; set; }
        
        public virtual string Country { get; set; }
        
        public virtual string HomePhone { get; set; }
        
        public virtual string Extension { get; set; }
        
        public virtual byte[] Photo { get; set; }
        
        public virtual string Notes { get; set; }
        
        private int? _reportsTo;
        
        public virtual int? ReportsTo
        {
            get { return this.EmployeeX == null ? _reportsTo : this.EmployeeX.EmployeeId; }
            set
            {
                _reportsTo = value;
                EmployeeX = null;
            }
        }
        
        public virtual string PhotoPath { get; set; }

        #endregion Properties

        #region Associations (FK)

        public virtual Employee EmployeeX { get; set; } // ReportsTo

        #endregion Associations (FK)

        #region Collections (PK)

        public virtual IList<Employee> Employees { get; }

        public virtual IList<EmployeeTerritory> EmployeeTerritories { get; }

        public virtual IList<Order> Orders { get; }

        #endregion Collections (PK)

        #region Methods
        
        public Employee()
        {
            Employees = new List<Employee>();
            EmployeeTerritories = new List<EmployeeTerritory>();
            Orders = new List<Order>();
    
            OnConstructor();
        }

        public override object[] GetId()
        {
            return new object[] { EmployeeId };
        }

        public override void SetId(object[] ids)
        {
            if (ids != null && ids[0] != null)
            {
                EmployeeId = DataHelper.IdToInt32(ids[0]);
            }
        }

        #endregion Methods
    }
}
