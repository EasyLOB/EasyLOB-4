using EasyLOB;
using EasyLOB.Data;
using EasyLOB.Library;
using System;
using System.Collections.Generic;

namespace Northwind.Data
{
    public partial class OrderDetailDTO : ZDTOModel<OrderDetailDTO, OrderDetail>
    {
        #region Properties
               
        public virtual int OrderId { get; set; }
               
        public virtual int ProductId { get; set; }
               
        public virtual decimal UnitPrice { get; set; }
               
        public virtual short Quantity { get; set; }
               
        public virtual float Discount { get; set; }

        #endregion Properties

        #region Associations (FK)

        public virtual string OrderLookupText { get; set; } // OrderId

        public virtual string ProductLookupText { get; set; } // ProductId

        #endregion Associations (FK)

        #region Methods

        public OrderDetailDTO()
        {
            OnConstructor();
        }

        public OrderDetailDTO(IZDataModel dataModel)
        {
            FromData(dataModel);
        }
        
        #endregion Methods
    }
}
