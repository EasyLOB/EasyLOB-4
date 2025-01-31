using Northwind.Data.Resources;
using EasyLOB;
using EasyLOB.Data;
using EasyLOB.Library;
using EasyLOB.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Northwind.Data
{
    public partial class ProductViewModel : ZViewModel<ProductViewModel, Product>
    {
        #region Properties
        
        [Display(Name = "PropertyProductId", ResourceType = typeof(ProductResources))]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        //[Key]
        [Required]
        public virtual int ProductId { get; set; }
        
        [Display(Name = "PropertyProductName", ResourceType = typeof(ProductResources))]
        [Required]
        [StringLength(40)]
        public virtual string ProductName { get; set; }
        
        [Display(Name = "PropertySupplierId", ResourceType = typeof(ProductResources))]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public virtual int? SupplierId { get; set; }
        
        [Display(Name = "PropertyCategoryId", ResourceType = typeof(ProductResources))]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public virtual int? CategoryId { get; set; }
        
        [Display(Name = "PropertyQuantityPerUnit", ResourceType = typeof(ProductResources))]
        [StringLength(20)]
        public virtual string QuantityPerUnit { get; set; }
        
        [Display(Name = "PropertyUnitPrice", ResourceType = typeof(ProductResources))]
        [DisplayFormat(DataFormatString = "{0:f2}", ApplyFormatInEditMode = true)]
        public virtual decimal? UnitPrice { get; set; }
        
        [Display(Name = "PropertyUnitsInStock", ResourceType = typeof(ProductResources))]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public virtual short? UnitsInStock { get; set; }
        
        [Display(Name = "PropertyUnitsOnOrder", ResourceType = typeof(ProductResources))]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public virtual short? UnitsOnOrder { get; set; }
        
        [Display(Name = "PropertyReorderLevel", ResourceType = typeof(ProductResources))]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public virtual short? ReorderLevel { get; set; }
        
        [Display(Name = "PropertyDiscontinued", ResourceType = typeof(ProductResources))]
        [Required]
        public virtual bool Discontinued { get; set; }

        #endregion Properties

        #region Associations (FK)

        public virtual string CategoryLookupText { get; set; } // CategoryId

        public virtual string SupplierLookupText { get; set; } // SupplierId
    
        #endregion Associations (FK)

        #region Methods
        
        public ProductViewModel()
        {
            OnConstructor();
        }

        public ProductViewModel(IZDataModel dataModel)
        {
            FromData(dataModel);
        }

        #endregion Methods
    }
}
