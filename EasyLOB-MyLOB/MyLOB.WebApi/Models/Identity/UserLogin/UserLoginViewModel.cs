using EasyLOB.Identity.Data.Resources;
using EasyLOB.Data;
using EasyLOB.Library;
using EasyLOB.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EasyLOB.Identity.Data
{
    public partial class UserLoginViewModel : ZViewModel<UserLoginViewModel, UserLogin>
    {
        #region Properties
        
        [Display(Name = "PropertyLoginProvider", ResourceType = typeof(UserLoginResources))]
        //[Key]
        //[Column(Order=1)]
        [Required]
        [StringLength(128)]
        public virtual string LoginProvider { get; set; }
        
        [Display(Name = "PropertyProviderKey", ResourceType = typeof(UserLoginResources))]
        //[Key]
        //[Column(Order=2)]
        [Required]
        [StringLength(128)]
        public virtual string ProviderKey { get; set; }
        
        [Display(Name = "PropertyUserId", ResourceType = typeof(UserLoginResources))]
        //[Key]
        //[Column(Order=3)]
        [Required]
        [StringLength(128)]
        public virtual string UserId { get; set; }

        #endregion Properties

        #region Associations (FK)

        public virtual string UserLookupText { get; set; } // UserId
    
        #endregion Associations (FK)

        #region Methods
        
        public UserLoginViewModel()
        {
            OnConstructor();
        }

        public UserLoginViewModel(IZDataModel dataModel)
        {
            FromData(dataModel);
        }

        #endregion Methods
    }
}
