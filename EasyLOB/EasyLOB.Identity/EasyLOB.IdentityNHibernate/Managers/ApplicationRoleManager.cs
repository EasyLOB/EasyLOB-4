using EasyLOB.Environment;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using NHibernate;
using NHibernate.AspNet.Identity;
using NHibernate.AspNet.Identity.Helpers;
using System;

namespace EasyLOB.Identity
{
    public class ApplicationRoleManager : RoleManager<ApplicationRole>, IDisposable
    {
        public ApplicationRoleManager(RoleStore<ApplicationRole> store)
            : base(store)
        {
        }

        public static ApplicationRoleManager Create(IdentityFactoryOptions<ApplicationRoleManager> options, IOwinContext context) // ???
        {
            var entities = new[]
            {
                typeof(ApplicationRole)
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

            return new ApplicationRoleManager(new RoleStore<ApplicationRole>(session));
        }
    }
}