using Northwind.Data;
using EasyLOB;
using EasyLOB.Persistence;

namespace Northwind.Persistence
{
    public partial class NorthwindUnitOfWorkLINQ2DB : UnitOfWorkLINQ2DB, INorthwindUnitOfWork
    {
        #region Methods

        public NorthwindUnitOfWorkLINQ2DB(IAuthenticationManager authenticationManager)
            : base(new NorthwindLINQ2DB(), authenticationManager)
        {
            Domain = "Northwind";

            Repositories.Add(typeof(Category), new NorthwindCategoryRepositoryLINQ2DB(this));            
            Repositories.Add(typeof(CustomerCustomerDemo), new NorthwindCustomerCustomerDemoRepositoryLINQ2DB(this));            
            Repositories.Add(typeof(CustomerDemographic), new NorthwindCustomerDemographicRepositoryLINQ2DB(this));            
            Repositories.Add(typeof(Customer), new NorthwindCustomerRepositoryLINQ2DB(this));            
            Repositories.Add(typeof(Employee), new NorthwindEmployeeRepositoryLINQ2DB(this));            
            Repositories.Add(typeof(EmployeeTerritory), new NorthwindEmployeeTerritoryRepositoryLINQ2DB(this));            
            Repositories.Add(typeof(OrderDetail), new NorthwindOrderDetailRepositoryLINQ2DB(this));            
            Repositories.Add(typeof(Order), new NorthwindOrderRepositoryLINQ2DB(this));            
            Repositories.Add(typeof(Product), new NorthwindProductRepositoryLINQ2DB(this));            
            Repositories.Add(typeof(Region), new NorthwindRegionRepositoryLINQ2DB(this));            
            Repositories.Add(typeof(Shipper), new NorthwindShipperRepositoryLINQ2DB(this));            
            Repositories.Add(typeof(Supplier), new NorthwindSupplierRepositoryLINQ2DB(this));            
            Repositories.Add(typeof(Territory), new NorthwindTerritoryRepositoryLINQ2DB(this));            

            //NorthwindLINQ2DB connection = (NorthwindLINQ2DB)base.Connection;
        }

        public override IGenericRepository<TEntity> GetRepository<TEntity>()
        {
            if (!Repositories.Keys.Contains(typeof(TEntity)))
            {
                var repository = new NorthwindGenericRepositoryLINQ2DB<TEntity>(this);
                Repositories.Add(typeof(TEntity), repository);
            }

            return Repositories[typeof(TEntity)] as IGenericRepository<TEntity>;
        }

        #endregion Methods
    }
}

