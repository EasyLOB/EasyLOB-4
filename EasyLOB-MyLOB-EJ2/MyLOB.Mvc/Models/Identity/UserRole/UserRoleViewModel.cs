using EasyLOB.Identity.Data.Resources;
using EasyLOB.Data;
using EasyLOB.Library;
using EasyLOB.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EasyLOB.Identity.Data
{
    public partial class UserRoleViewModel : ZViewModel<UserRoleViewModel, UserRole>
    {
        #region Properties
        
        [Display(Name = "PropertyUserId", ResourceType = typeof(UserRoleResources))]
        //[Key]
        //[Column(Order=1)]
        [Required]
        [StringLength(128)]
        public virtual string UserId { get; set; }
        
        [Display(Name = "PropertyRoleId", ResourceType = typeof(UserRoleResources))]
        //[Key]
        //[Column(Order=2)]
        [Required]
        [StringLength(128)]
        public virtual string RoleId { get; set; }

        #endregion Properties

        #region Associations (FK)

        public virtual string RoleLookupText { get; set; } // RoleId

        public virtual string UserLookupText { get; set; } // UserId
    
        #endregion Associations (FK)

        #region Methods
        
        public UserRoleViewModel()
        {
            OnConstructor();
        }

        public UserRoleViewModel(IZDataModel dataModel)
        {
            FromData(dataModel);
        }

        #endregion Methods
    }
}
