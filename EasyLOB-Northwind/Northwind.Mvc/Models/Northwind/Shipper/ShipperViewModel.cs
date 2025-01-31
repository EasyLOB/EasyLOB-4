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
    public partial class ShipperViewModel : ZViewModel<ShipperViewModel, Shipper>
    {
        #region Properties
        
        [Display(Name = "PropertyShipperId", ResourceType = typeof(ShipperResources))]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        //[Key]
        [Required]
        public virtual int ShipperId { get; set; }
        
        [Display(Name = "PropertyCompanyName", ResourceType = typeof(ShipperResources))]
        [Required]
        [StringLength(40)]
        public virtual string CompanyName { get; set; }
        
        [Display(Name = "PropertyPhone", ResourceType = typeof(ShipperResources))]
        [StringLength(24)]
        public virtual string Phone { get; set; }

        #endregion Properties

        #region Methods
        
        public ShipperViewModel()
        {
            OnConstructor();
        }

        public ShipperViewModel(IZDataModel dataModel)
        {
            FromData(dataModel);
        }

        #endregion Methods
    }
}
