using EasyLOB.Data;
using EasyLOB.Identity.Data.Resources;
using System.ComponentModel.DataAnnotations;

namespace EasyLOB.Identity.Data
{
    public partial class RoleViewModel
    {
        #region Properties

        [Display(Name = "PropertyId", ResourceType = typeof(RoleResources))]
        //[Key]
        //[Required]
        [StringLength(128)]
        public virtual string Id { get; set; }

        [Display(Name = "PropertyName", ResourceType = typeof(RoleResources))]
        [Required]
        [StringLength(256)]
        public virtual string Name { get; set; }

        [Display(Name = "PropertyDiscriminator", ResourceType = typeof(RoleResources))]
        //[Required]
        [StringLength(128)]
        public virtual string Discriminator { get; set; }

        #endregion Properties
    }
}