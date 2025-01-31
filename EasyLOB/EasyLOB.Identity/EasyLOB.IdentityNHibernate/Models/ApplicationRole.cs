using NHibernate.AspNet.Identity;

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