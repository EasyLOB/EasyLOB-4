using EasyLOB.Identity.Data.Resources;
using EasyLOB.Data;
using EasyLOB.Library;
using EasyLOB.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EasyLOB.Identity.Data
{
    public partial class UserViewModel : ZViewModel<UserViewModel, User>
    {
        #region Properties

        //[Display(Name = "PropertyId", ResourceType = typeof(UserResources))]
        ////[Key]
        //[Required]
        //[StringLength(128)]
        //public virtual string Id { get; set; }

        //[Display(Name = "PropertyEmail", ResourceType = typeof(UserResources))]
        //[StringLength(256)]
        //public virtual string Email { get; set; }

        //[Display(Name = "PropertyEmailConfirmed", ResourceType = typeof(UserResources))]
        //[Required]
        //public virtual bool EmailConfirmed { get; set; }

        [Display(Name = "PropertyPasswordHash", ResourceType = typeof(UserResources))]
        [StringLength(1024)]
        public virtual string PasswordHash { get; set; }

        [Display(Name = "PropertySecurityStamp", ResourceType = typeof(UserResources))]
        [StringLength(1024)]
        public virtual string SecurityStamp { get; set; }
        
        [Display(Name = "PropertyPhoneNumber", ResourceType = typeof(UserResources))]
        [StringLength(1024)]
        public virtual string PhoneNumber { get; set; }
        
        //[Display(Name = "PropertyPhoneNumberConfirmed", ResourceType = typeof(UserResources))]
        //[Required]
        //public virtual bool PhoneNumberConfirmed { get; set; }
        
        //[Display(Name = "PropertyTwoFactorEnabled", ResourceType = typeof(UserResources))]
        //[Required]
        //public virtual bool TwoFactorEnabled { get; set; }
        
        [Display(Name = "PropertyLockoutEndDateUtc", ResourceType = typeof(UserResources))]
        //[DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:G}", ApplyFormatInEditMode = true)]
        public virtual DateTime? LockoutEndDateUtc { get; set; }
        
        //[Display(Name = "PropertyLockoutEnabled", ResourceType = typeof(UserResources))]
        //[Required]
        //public virtual bool LockoutEnabled { get; set; }
        
        //[Display(Name = "PropertyAccessFailedCount", ResourceType = typeof(UserResources))]
        //[DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        //[Required]
        //public virtual int AccessFailedCount { get; set; }
        
        //[Display(Name = "PropertyUserName", ResourceType = typeof(UserResources))]
        //[Required]
        //[StringLength(256)]
        //public virtual string UserName { get; set; }

        #endregion Properties

        #region Methods
        
        public UserViewModel()
        {
            OnConstructor();
        }

        public UserViewModel(IZDataModel dataModel)
        {
            FromData(dataModel);
        }

        #endregion Methods
    }
}
