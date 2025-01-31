using Northwind.Data;
using System.Data.Entity;

namespace Northwind.Persistence
{
    public partial class NorthwindDbContext : DbContext
    {
        #region Properties

        //public DbSet<ModuleInfo> ModulesInfo { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<CustomerCustomerDemo> CustomerCustomerDemos { get; set; }

        public DbSet<CustomerDemographic> CustomerDemographics { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<EmployeeTerritory> EmployeeTerritories { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Region> Regions { get; set; }

        public DbSet<Shipper> Shippers { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<Territory> Territories { get; set; }

        #endregion Properties
        
        #region Methods
        
        static NorthwindDbContext()
        {
            /*
            // Refer to <configuration><entityframework><contexts> section in Web.config or App.config
            //Database.SetInitializer<NorthwindDbContext>(null);
            //Database.SetInitializer<NorthwindDbContext>(new CreateDatabaseIfNotExists<NorthwindDbContext>());
             */            
        }

        public NorthwindDbContext()
            : base("Name=Northwind")
        {
            Setup();
        }

        //public NorthwindDbContext(string connectionString)
        //    : base(connectionString)
        //{
        //    Setup();
        //}

        //public NorthwindDbContext(ObjectContext objectContext, bool dbContextOwnsObjectContext)
        //    : base(objectContext, dbContextOwnsObjectContext)
        //{
        //    Setup();
        //}        

        //public NorthwindDbContext(DbConnection connection)
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

            modelBuilder.Configurations.Add(new CategoryConfiguration());
            modelBuilder.Configurations.Add(new CustomerCustomerDemoConfiguration());
            modelBuilder.Configurations.Add(new CustomerDemographicConfiguration());
            modelBuilder.Configurations.Add(new CustomerConfiguration());
            modelBuilder.Configurations.Add(new EmployeeConfiguration());
            modelBuilder.Configurations.Add(new EmployeeTerritoryConfiguration());
            modelBuilder.Configurations.Add(new OrderDetailConfiguration());
            modelBuilder.Configurations.Add(new OrderConfiguration());
            modelBuilder.Configurations.Add(new ProductConfiguration());
            modelBuilder.Configurations.Add(new RegionConfiguration());
            modelBuilder.Configurations.Add(new ShipperConfiguration());
            modelBuilder.Configurations.Add(new SupplierConfiguration());
            modelBuilder.Configurations.Add(new TerritoryConfiguration());
        }
        
        #endregion Methods
    }
}
