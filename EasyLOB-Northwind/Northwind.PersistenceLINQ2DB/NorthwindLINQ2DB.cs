using Northwind.Data;
using LinqToDB;
using LinqToDB.Data;

namespace Northwind.Persistence
{
    public class NorthwindLINQ2DB : DataConnection
    {
        #region Methods
    
        public NorthwindLINQ2DB()
            : base("Northwind")
        {
            NorthwindLINQ2DBMap.CategoryMap(MappingSchema);
            NorthwindLINQ2DBMap.CustomerCustomerDemoMap(MappingSchema);
            NorthwindLINQ2DBMap.CustomerDemographicMap(MappingSchema);
            NorthwindLINQ2DBMap.CustomerMap(MappingSchema);
            NorthwindLINQ2DBMap.EmployeeMap(MappingSchema);
            NorthwindLINQ2DBMap.EmployeeTerritoryMap(MappingSchema);
            NorthwindLINQ2DBMap.OrderDetailMap(MappingSchema);
            NorthwindLINQ2DBMap.OrderMap(MappingSchema);
            NorthwindLINQ2DBMap.ProductMap(MappingSchema);
            NorthwindLINQ2DBMap.RegionMap(MappingSchema);
            NorthwindLINQ2DBMap.ShipperMap(MappingSchema);
            NorthwindLINQ2DBMap.SupplierMap(MappingSchema);
            NorthwindLINQ2DBMap.TerritoryMap(MappingSchema);
        }

        public ITable<Category> Category
        {
            get { return GetTable<Category>(); }
        }

        public ITable<CustomerCustomerDemo> CustomerCustomerDemo
        {
            get { return GetTable<CustomerCustomerDemo>(); }
        }

        public ITable<CustomerDemographic> CustomerDemographic
        {
            get { return GetTable<CustomerDemographic>(); }
        }

        public ITable<Customer> Customer
        {
            get { return GetTable<Customer>(); }
        }

        public ITable<Employee> Employee
        {
            get { return GetTable<Employee>(); }
        }

        public ITable<EmployeeTerritory> EmployeeTerritory
        {
            get { return GetTable<EmployeeTerritory>(); }
        }

        public ITable<OrderDetail> OrderDetail
        {
            get { return GetTable<OrderDetail>(); }
        }

        public ITable<Order> Order
        {
            get { return GetTable<Order>(); }
        }

        public ITable<Product> Product
        {
            get { return GetTable<Product>(); }
        }

        public ITable<Region> Region
        {
            get { return GetTable<Region>(); }
        }

        public ITable<Shipper> Shipper
        {
            get { return GetTable<Shipper>(); }
        }

        public ITable<Supplier> Supplier
        {
            get { return GetTable<Supplier>(); }
        }

        public ITable<Territory> Territory
        {
            get { return GetTable<Territory>(); }
        }

        #endregion Methods
    }
}