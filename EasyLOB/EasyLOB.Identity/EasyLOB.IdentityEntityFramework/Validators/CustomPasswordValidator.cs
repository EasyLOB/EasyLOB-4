using Microsoft.AspNet.Identity;
using System.Threading.Tasks;

namespace EasyLOB.Identity
{
    public class CustomPasswordValidator : PasswordValidator
    {
        public override async Task<IdentityResult> ValidateAsync(string password)
        {
            IdentityResult result = await base.ValidateAsync(password);

            //if (password.Contains("12345"))
            //{
            //    var errors = result.Errors.ToList();
            //    errors.Add("Passwords cannot contain numeric sequences");
            //    result = new IdentityResult(errors);
            //}

            return result;
        }
    }
}