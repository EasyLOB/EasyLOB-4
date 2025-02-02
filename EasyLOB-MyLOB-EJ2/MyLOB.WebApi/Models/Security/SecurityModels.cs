using EasyLOB.Resources;
using System.ComponentModel.DataAnnotations;

namespace EasyLOB.Security
{
    public class ChangePasswordViewModel
    {
        [DataType(DataType.Password)]
        //[Display(Name = "Current password")]
        [Display(Name = "OldPassword", ResourceType = typeof(EasyLOBSecurityResources))]
        [Required]
        public string OldPassword { get; set; }

        [DataType(DataType.Password)]
        //[Display(Name = "New password")]
        [Display(Name = "NewPassword", ResourceType = typeof(EasyLOBSecurityResources))]
        [Required]
        //[StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [StringLength(100, ErrorMessageResourceName = "NewPasswordError", ErrorMessageResourceType = typeof(EasyLOBSecurityResources), MinimumLength = 6)]
        public string NewPassword { get; set; }

        //[Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        [Compare("NewPassword", ErrorMessageResourceName = "ConfirmPasswordError", ErrorMessageResourceType = typeof(EasyLOBSecurityResources))]
        [DataType(DataType.Password)]
        //[Display(Name = "Confirm new password")]
        [Display(Name = "ConfirmPassword", ResourceType = typeof(EasyLOBSecurityResources))]
        public string ConfirmPassword { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        //[Display(Name = "EMail")]
        [Display(Name = "EMail", ResourceType = typeof(EasyLOBSecurityResources))]
        [EmailAddress]
        [Required]
        public string Email { get; set; }
    }

    public class LoginViewModel // !?!
    {
        //[Display(Name = "User Name")]
        [Display(Name = "UserName", ResourceType = typeof(EasyLOBSecurityResources))]
        [Required]
        public string UserName { get; set; }

        ////[Display(Name = "EMail")]
        //[Display(Name = "EMail", ResourceType = typeof(EasyLOBSecurityResources))]
        //[EmailAddress]
        //[Required]
        //public string Email { get; set; }

        [DataType(DataType.Password)]
        //[Display(Name = "Password")]
        [Display(Name = "Password", ResourceType = typeof(EasyLOBSecurityResources))]
        [Required]
        public string Password { get; set; }

        //[Display(Name = "Remember me?")]
        [Display(Name = "RememberMe", ResourceType = typeof(EasyLOBSecurityResources))]
        public bool RememberMe { get; set; }

        //[Display(Name = "TenantName", ResourceType = typeof(EasyLOBSecurityResources))]
        //public string TenantName { get; set; } // !?! Multi-Tenant
    }

    public class ResetPasswordViewModel
    {
        //[Display(Name = "EMail")]
        [Display(Name = "EMail", ResourceType = typeof(EasyLOBSecurityResources))]
        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        //[Display(Name = "Password")]
        [Display(Name = "Password", ResourceType = typeof(EasyLOBSecurityResources))]
        [Required]
        //[StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [StringLength(100, ErrorMessageResourceName = "NewPasswordError", ErrorMessageResourceType = typeof(EasyLOBSecurityResources), MinimumLength = 6)]
        public string Password { get; set; }

        //[Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        [Compare("Password", ErrorMessageResourceName = "ConfirmPasswordError", ErrorMessageResourceType = typeof(EasyLOBSecurityResources))]
        [DataType(DataType.Password)]
        //[Display(Name = "Confirm password")]
        [Display(Name = "ConfirmPassword", ResourceType = typeof(EasyLOBSecurityResources))]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }
}