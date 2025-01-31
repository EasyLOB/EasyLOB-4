using EasyLOB.Identity.Data.Resources;
using EasyLOB.Data;
using EasyLOB.Library;
using EasyLOB.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EasyLOB.Identity.Data
{
    public partial class UserClaimViewModel : ZViewModel<UserClaimViewModel, UserClaim>
    {
        #region Properties
        
        [Display(Name = "PropertyId", ResourceType = typeof(UserClaimResources))]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        //[Key]
        [Required]
        public virtual int Id { get; set; }
        
        [Display(Name = "PropertyUserId", ResourceType = typeof(UserClaimResources))]
        [Required]
        [StringLength(128)]
        public virtual string UserId { get; set; }
        
        [Display(Name = "PropertyClaimType", ResourceType = typeof(UserClaimResources))]
        [StringLength(1024)]
        public virtual string ClaimType { get; set; }
        
        [Display(Name = "PropertyClaimValue", ResourceType = typeof(UserClaimResources))]
        [StringLength(1024)]
        public virtual string ClaimValue { get; set; }

        #endregion Properties

        #region Associations (FK)

        public virtual string UserLookupText { get; set; } // UserId
    
        #endregion Associations (FK)

        #region Methods
        
        public UserClaimViewModel()
        {
            OnConstructor();
        }

        public UserClaimViewModel(IZDataModel dataModel)
        {
            FromData(dataModel);
        }

        #endregion Methods
    }
}
