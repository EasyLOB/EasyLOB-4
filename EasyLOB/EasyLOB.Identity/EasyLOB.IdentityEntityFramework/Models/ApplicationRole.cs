using Microsoft.AspNet.Identity.EntityFramework;

namespace EasyLOB.Identity
{
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole()
            : base()
        {
        }

        public ApplicationRole(string name)
            : base(name)
        {
        }
    }
}