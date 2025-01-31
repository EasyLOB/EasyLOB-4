using Microsoft.AspNet.Identity;
using System.Threading.Tasks;

namespace EasyLOB.Identity
{
    public class CustomUserValidator : UserValidator<ApplicationUser>
    {
        public CustomUserValidator(ApplicationUserManager manager)
            : base(manager)
        {
        }

        public override async Task<IdentityResult> ValidateAsync(ApplicationUser user)
        {
            IdentityResult result = await base.ValidateAsync(user);

            //if (!user.Email.ToLower().EndsWith("@example.com"))
            //{
            //    var errors = result.Errors.ToList();
            //    errors.Add("Only example.com email addresses are allowed");
            //    result = new IdentityResult(errors);
            //}

            return result;
        }
    }
}