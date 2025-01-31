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
    public partial class CategoryViewModel : ZViewModel<CategoryViewModel, Category>
    {
        #region Properties
        
        [Display(Name = "PropertyCategoryId", ResourceType = typeof(CategoryResources))]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        //[Key]
        [Required]
        public virtual int CategoryId { get; set; }
        
        [Display(Name = "PropertyCategoryName", ResourceType = typeof(CategoryResources))]
        [Required]
        [StringLength(15)]
        public virtual string CategoryName { get; set; }
        
        [Display(Name = "PropertyDescription", ResourceType = typeof(CategoryResources))]
        [StringLength(1024)]
        public virtual string Description { get; set; }
        
        [Display(Name = "PropertyPicture", ResourceType = typeof(CategoryResources))]
        public virtual byte[] Picture { get; set; }

        #endregion Properties

        #region Methods
        
        public CategoryViewModel()
        {
            OnConstructor();
        }

        public CategoryViewModel(IZDataModel dataModel)
        {
            FromData(dataModel);
        }

        #endregion Methods
    }
}
