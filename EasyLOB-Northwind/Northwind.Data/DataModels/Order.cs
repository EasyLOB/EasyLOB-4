using EasyLOB.Data;
using EasyLOB.Library;
using System;
using System.Collections.Generic;

namespace Northwind.Data
{
    public partial class Order : ZDataModel
    {        
        #region Properties
        
        [ZKey(true)]
        public virtual int OrderId { get; set; }
        
        private string _customerId;
        
        public virtual string CustomerId
        {
            get { return this.Customer == null ? _customerId : this.Customer.CustomerId; }
            set
            {
                _customerId = value;
                Customer = null;
            }
        }
        
        private int? _employeeId;
        
        public virtual int? EmployeeId
        {
            get { return this.Employee == null ? _employeeId : this.Employee.EmployeeId; }
            set
            {
                _employeeId = value;
                Employee = null;
            }
        }
        
        public virtual DateTime? OrderDate { get; set; }
        
        public virtual DateTime? RequiredDate { get; set; }
        
        public virtual DateTime? ShippedDate { get; set; }
        
        private int? _shipVia;
        
        public virtual int? ShipVia
        {
            get { return this.Shipper == null ? _shipVia : this.Shipper.ShipperId; }
            set
            {
                _shipVia = value;
                Shipper = null;
            }
        }
        
        public virtual decimal? Freight { get; set; }
        
        public virtual string ShipName { get; set; }
        
        public virtual string ShipAddress { get; set; }
        
        public virtual string ShipCity { get; set; }
        
        public virtual string ShipRegion { get; set; }
        
        public virtual string ShipPostalCode { get; set; }
        
        public virtual string ShipCountry { get; set; }

        #endregion Properties

        #region Associations (FK)

        public virtual Customer Customer { get; set; } // CustomerId

        public virtual Employee Employee { get; set; } // EmployeeId

        public virtual Shipper Shipper { get; set; } // ShipVia

        #endregion Associations (FK)

        #region Collections (PK)

        public virtual IList<OrderDetail> OrderDetails { get; }

        #endregion Collections (PK)

        #region Methods
        
        public Order()
        {
            OrderDetails = new List<OrderDetail>();
    
            OnConstructor();
        }

        public override object[] GetId()
        {
            return new object[] { OrderId };
        }

        public override void SetId(object[] ids)
        {
            if (ids != null && ids[0] != null)
            {
                OrderId = DataHelper.IdToInt32(ids[0]);
            }
        }

        #endregion Methods
    }
}
