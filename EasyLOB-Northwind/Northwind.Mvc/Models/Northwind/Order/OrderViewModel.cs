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
    public partial class OrderViewModel : ZViewModel<OrderViewModel, Order>
    {
        #region Properties
        
        [Display(Name = "PropertyOrderId", ResourceType = typeof(OrderResources))]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        //[Key]
        [Required]
        public virtual int OrderId { get; set; }
        
        [Display(Name = "PropertyCustomerId", ResourceType = typeof(OrderResources))]
        [StringLength(5)]
        public virtual string CustomerId { get; set; }
        
        [Display(Name = "PropertyEmployeeId", ResourceType = typeof(OrderResources))]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public virtual int? EmployeeId { get; set; }
        
        [Display(Name = "PropertyOrderDate", ResourceType = typeof(OrderResources))]
        //[DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:G}", ApplyFormatInEditMode = true)]
        public virtual DateTime? OrderDate { get; set; }
        
        [Display(Name = "PropertyRequiredDate", ResourceType = typeof(OrderResources))]
        //[DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:G}", ApplyFormatInEditMode = true)]
        public virtual DateTime? RequiredDate { get; set; }
        
        [Display(Name = "PropertyShippedDate", ResourceType = typeof(OrderResources))]
        //[DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:G}", ApplyFormatInEditMode = true)]
        public virtual DateTime? ShippedDate { get; set; }
        
        [Display(Name = "PropertyShipVia", ResourceType = typeof(OrderResources))]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public virtual int? ShipVia { get; set; }
        
        [Display(Name = "PropertyFreight", ResourceType = typeof(OrderResources))]
        [DisplayFormat(DataFormatString = "{0:f2}", ApplyFormatInEditMode = true)]
        public virtual decimal? Freight { get; set; }
        
        [Display(Name = "PropertyShipName", ResourceType = typeof(OrderResources))]
        [StringLength(40)]
        public virtual string ShipName { get; set; }
        
        [Display(Name = "PropertyShipAddress", ResourceType = typeof(OrderResources))]
        [StringLength(60)]
        public virtual string ShipAddress { get; set; }
        
        [Display(Name = "PropertyShipCity", ResourceType = typeof(OrderResources))]
        [StringLength(15)]
        public virtual string ShipCity { get; set; }
        
        [Display(Name = "PropertyShipRegion", ResourceType = typeof(OrderResources))]
        [StringLength(15)]
        public virtual string ShipRegion { get; set; }
        
        [Display(Name = "PropertyShipPostalCode", ResourceType = typeof(OrderResources))]
        [StringLength(10)]
        public virtual string ShipPostalCode { get; set; }
        
        [Display(Name = "PropertyShipCountry", ResourceType = typeof(OrderResources))]
        [StringLength(15)]
        public virtual string ShipCountry { get; set; }

        #endregion Properties

        #region Associations (FK)

        public virtual string CustomerLookupText { get; set; } // CustomerId

        public virtual string EmployeeLookupText { get; set; } // EmployeeId

        public virtual string ShipperLookupText { get; set; } // ShipVia
    
        #endregion Associations (FK)

        #region Methods
        
        public OrderViewModel()
        {
            OnConstructor();
        }

        public OrderViewModel(IZDataModel dataModel)
        {
            FromData(dataModel);
        }

        #endregion Methods
    }
}
