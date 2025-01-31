using EasyLOB.Environment;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using NHibernate;
using NHibernate.AspNet.Identity;
using NHibernate.AspNet.Identity.Helpers;

namespace EasyLOB.Identity
{
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store)
            : base(store)
        {
        }

        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context) // ???
        {
            var entities = new[]
            {
                typeof(ApplicationUser)
            };
            var configuration = Fluently.Configure()
                .Database(MsSqlConfiguration
                    .MsSql2008
                    //.ConnectionString(x => x.FromConnectionStringWithKey("Identity"))
                    .ConnectionString(x => x.FromConnectionStringWithKey(MultiTenantHelper.GetConnectionName("Identity"))) // !?! Multi-Tenant
                    .Driver<SqlClientDriverEasyLOB>
                )
                .ExposeConfiguration(x =>
                {
                    x.AddDeserializedMapping(MappingHelper.GetIdentityMappings(entities), null);
                })
                ;
            ISessionFactory factory = configuration.BuildSessionFactory();
            ISession session = factory.OpenSession();

            ApplicationUserManager manager = new ApplicationUserManager(new UserStore<ApplicationUser>(session));

            manager.PasswordValidator = new CustomPasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = true,
                RequireUppercase = true
            };

            manager.UserValidator = new CustomUserValidator(manager)
            {
                AllowOnlyAlphanumericUserNames = true,
                RequireUniqueEmail = true
            };

            manager.EmailService = new EmailService();
            manager.SmsService = new SmsService();

            return manager;
        }
    }
}