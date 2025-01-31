using MyLOB.Data;
using System.Data.Entity;

namespace MyLOB.Persistence
{
    public partial class MyLOBDbContext : DbContext
    {
        #region Properties

        #endregion Properties
        
        #region Methods
        
        static MyLOBDbContext()
        {
            /*
            // Refer to <configuration><entityframework><contexts> section in Web.config or App.config
            //Database.SetInitializer<MyLOBDbContext>(null);
            //Database.SetInitializer<MyLOBDbContext>(new CreateDatabaseIfNotExists<MyLOBDbContext>());
             */            
        }

        public MyLOBDbContext()
            : base("Name=MyLOB")
        {
            Setup();
        }

        //public MyLOBDbContext(string connectionString)
        //    : base(connectionString)
        //{
        //    Setup();
        //}

        //public MyLOBDbContext(ObjectContext objectContext, bool dbContextOwnsObjectContext)
        //    : base(objectContext, dbContextOwnsObjectContext)
        //{
        //    Setup();
        //}        

        //public MyLOBDbContext(DbConnection connection)
        //    : base(connection, false)
        //{
        //    Setup();
        //}

        private void Setup()
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;

            Database.Log = null;
            //Database.Log = Console.Write;
            //Database.Log = log => EntityFrameworkHelper.Log(log, ZLibrary.ZDatabaseLogger.File);
            //Database.Log = log => EntityFrameworkHelper.Log(log, ZLibrary.ZDatabaseLogger.NLog);
        }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<ModuleInfo>().Map(t =>
            //{
            //    t.ToTable("ModuleInfo");
            //});
        }
        
        #endregion Methods
    }
}
