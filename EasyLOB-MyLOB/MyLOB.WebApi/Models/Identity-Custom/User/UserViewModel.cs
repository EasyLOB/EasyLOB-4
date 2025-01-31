using EasyLOB.Data;
using EasyLOB.Identity.Data.Resources;
using System.ComponentModel.DataAnnotations;

namespace EasyLOB.Identity.Data
{
    public partial class UserViewModel
    {
        #region Properties

        [Display(Name = "PropertyId", ResourceType = typeof(UserResources))]
        //[Key]
        //[Required]
        [StringLength(128)]
        public virtual string Id { get; set; }

        [Display(Name = "PropertyEmail", ResourceType = typeof(UserResources))]
        [Required]
        [StringLength(256)]
        public virtual string Email { get; set; }

        [Display(Name = "PropertyEmailConfirmed", ResourceType = typeof(UserResources))]
        //[Required]
        public virtual bool EmailConfirmed { get; set; }

        [Display(Name = "PropertyPhoneNumberConfirmed", ResourceType = typeof(UserResources))]
        //[Required]
        public virtual bool PhoneNumberConfirmed { get; set; }

        [Display(Name = "PropertyTwoFactorEnabled", ResourceType = typeof(UserResources))]
        //[Required]
        public virtual bool TwoFactorEnabled { get; set; }

        [Display(Name = "PropertyLockoutEnabled", ResourceType = typeof(UserResources))]
        //[Required]
        public virtual bool LockoutEnabled { get; set; }

        [Display(Name = "PropertyAccessFailedCount", ResourceType = typeof(UserResources))]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        //[Required]
        public virtual int AccessFailedCount { get; set; }

        [Display(Name = "PropertyUserName", ResourceType = typeof(UserResources))]
        //[Required]
        [StringLength(256)]
        public virtual string UserName { get; set; }

        #endregion Properties
    }
}