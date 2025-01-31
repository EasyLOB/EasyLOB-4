using EasyLOB;
using EasyLOB.Data;
using EasyLOB.Library;
using System;
using System.Collections.Generic;

namespace Northwind.Data
{
    public partial class OrderDTO : ZDTOModel<OrderDTO, Order>
    {
        #region Properties
               
        public virtual int OrderId { get; set; }
               
        public virtual string CustomerId { get; set; }
               
        public virtual int? EmployeeId { get; set; }
               
        public virtual DateTime? OrderDate { get; set; }
               
        public virtual DateTime? RequiredDate { get; set; }
               
        public virtual DateTime? ShippedDate { get; set; }
               
        public virtual int? ShipVia { get; set; }
               
        public virtual decimal? Freight { get; set; }
               
        public virtual string ShipName { get; set; }
               
        public virtual string ShipAddress { get; set; }
               
        public virtual string ShipCity { get; set; }
               
        public virtual string ShipRegion { get; set; }
               
        public virtual string ShipPostalCode { get; set; }
               
        public virtual string ShipCountry { get; set; }

        #endregion Properties

        #region Associations (FK)

        public virtual string CustomerLookupText { get; set; } // CustomerId

        public virtual string EmployeeLookupText { get; set; } // EmployeeId

        public virtual string ShipperLookupText { get; set; } // ShipVia

        #endregion Associations (FK)

        #region Methods

        public OrderDTO()
        {
            OnConstructor();
        }

        public OrderDTO(IZDataModel dataModel)
        {
            FromData(dataModel);
        }
        
        #endregion Methods
    }
}
