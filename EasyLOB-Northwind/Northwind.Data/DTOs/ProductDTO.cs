using EasyLOB;
using EasyLOB.Data;
using EasyLOB.Library;
using System;
using System.Collections.Generic;

namespace Northwind.Data
{
    public partial class ProductDTO : ZDTOModel<ProductDTO, Product>
    {
        #region Properties
               
        public virtual int ProductId { get; set; }
               
        public virtual string ProductName { get; set; }
               
        public virtual int? SupplierId { get; set; }
               
        public virtual int? CategoryId { get; set; }
               
        public virtual string QuantityPerUnit { get; set; }
               
        public virtual decimal? UnitPrice { get; set; }
               
        public virtual short? UnitsInStock { get; set; }
               
        public virtual short? UnitsOnOrder { get; set; }
               
        public virtual short? ReorderLevel { get; set; }
               
        public virtual bool Discontinued { get; set; }

        #endregion Properties

        #region Associations (FK)

        public virtual string CategoryLookupText { get; set; } // CategoryId

        public virtual string SupplierLookupText { get; set; } // SupplierId

        #endregion Associations (FK)

        #region Methods

        public ProductDTO()
        {
            OnConstructor();
        }

        public ProductDTO(IZDataModel dataModel)
        {
            FromData(dataModel);
        }
        
        #endregion Methods
    }
}
