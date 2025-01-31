using EasyLOB.Security;
using EasyLOB.Resources;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Diagnostics.Contracts;
using System.Xml.XPath;

namespace EasyLOB.Activity.Data
{
    public partial class ActivityRoleViewModel
    {
        #region Properties

        [Display(Name = "IsIndex", ResourceType = typeof(EasyLOBSecurityResources))]
        [Required]
        public virtual bool IsIndex { get; set; }

        [Display(Name = "IsSearch", ResourceType = typeof(EasyLOBSecurityResources))]
        [Required]
        public virtual bool IsSearch { get; set; }

        [Display(Name = "IsCreate", ResourceType = typeof(EasyLOBSecurityResources))]
        [Required]
        public virtual bool IsCreate { get; set; }

        [Display(Name = "IsRead", ResourceType = typeof(EasyLOBSecurityResources))]
        [Required]
        public virtual bool IsRead { get; set; }

        [Display(Name = "IsUpdate", ResourceType = typeof(EasyLOBSecurityResources))]
        [Required]
        public virtual bool IsUpdate { get; set; }

        [Display(Name = "IsDelete", ResourceType = typeof(EasyLOBSecurityResources))]
        [Required]
        public virtual bool IsDelete { get; set; }

        [Display(Name = "IsExecute", ResourceType = typeof(EasyLOBSecurityResources))]
        [Required]
        public virtual bool IsExecute { get; set; }

        #endregion Properties

        #region Methods

        public override void OnConstructor()
        {
            IsIndex = false;
            IsSearch = false;
            IsCreate = false;
            IsRead = false;
            IsUpdate = false;
            IsDelete = false;
            IsExecute = false;
        }

        public void Operations2Is()
        {
            string operations = (Operations ?? "").ToUpper();

            IsIndex = operations.Contains(SecurityHelper.GetSecurityOperationAcronym(ZOperations.Index));
            IsSearch = operations.Contains(SecurityHelper.GetSecurityOperationAcronym(ZOperations.Search));
            IsCreate = operations.Contains(SecurityHelper.GetSecurityOperationAcronym(ZOperations.Create));
            IsRead = operations.Contains(SecurityHelper.GetSecurityOperationAcronym(ZOperations.Read));
            IsUpdate = operations.Contains(SecurityHelper.GetSecurityOperationAcronym(ZOperations.Update));
            IsDelete = operations.Contains(SecurityHelper.GetSecurityOperationAcronym(ZOperations.Delete));
            IsExecute = operations.Contains(SecurityHelper.GetSecurityOperationAcronym(ZOperations.Execute));
        }

        public void Is2Operations()
        {
            Operations = "";

            Operations += IsIndex ? SecurityHelper.GetSecurityOperationAcronym(ZOperations.Index) : "";
            Operations += IsSearch ? SecurityHelper.GetSecurityOperationAcronym(ZOperations.Search) : "";
            Operations += IsCreate ? SecurityHelper.GetSecurityOperationAcronym(ZOperations.Create) : "";
            Operations += IsRead ? SecurityHelper.GetSecurityOperationAcronym(ZOperations.Read) : "";
            Operations += IsUpdate ? SecurityHelper.GetSecurityOperationAcronym(ZOperations.Update) : "";
            Operations += IsDelete ? SecurityHelper.GetSecurityOperationAcronym(ZOperations.Delete) : "";
            Operations += IsExecute ? SecurityHelper.GetSecurityOperationAcronym(ZOperations.Execute) : "";
        }

        #endregion Methods
    }
}
