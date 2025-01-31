using EasyLOB;
using EasyLOB.Data;
using EasyLOB.Library;
using System;
using System.Collections.Generic;

namespace Northwind.Data
{
    public partial class ShipperDTO : ZDTOModel<ShipperDTO, Shipper>
    {
        #region Properties
               
        public virtual int ShipperId { get; set; }
               
        public virtual string CompanyName { get; set; }
               
        public virtual string Phone { get; set; }

        #endregion Properties

        #region Methods

        public ShipperDTO()
        {
            OnConstructor();
        }

        public ShipperDTO(IZDataModel dataModel)
        {
            FromData(dataModel);
        }
        
        #endregion Methods
    }
}
