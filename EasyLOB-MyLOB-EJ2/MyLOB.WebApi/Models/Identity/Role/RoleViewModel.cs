using EasyLOB.Identity.Data.Resources;
using EasyLOB.Data;
using EasyLOB.Library;
using EasyLOB.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EasyLOB.Identity.Data
{
    public partial class RoleViewModel : ZViewModel<RoleViewModel, Role>
    {
        #region Properties
        
        //[Display(Name = "PropertyId", ResourceType = typeof(RoleResources))]
        ////[Key]
        //[Required]
        //[StringLength(128)]
        //public virtual string Id { get; set; }
        
        //[Display(Name = "PropertyName", ResourceType = typeof(RoleResources))]
        //[StringLength(256)]
        //public virtual string Name { get; set; }
        
        //[Display(Name = "PropertyDiscriminator", ResourceType = typeof(RoleResources))]
        //[Required]
        //[StringLength(128)]
        //public virtual string Discriminator { get; set; }

        #endregion Properties

        #region Methods
        
        public RoleViewModel()
        {
            OnConstructor();
        }

        public RoleViewModel(IZDataModel dataModel)
        {
            FromData(dataModel);
        }

        #endregion Methods
    }
}
