using Northwind.Data;
using FluentNHibernate.Mapping;

namespace Northwind.Persistence
{
    public class OrderMap : ClassMap<Order>
    {
        public OrderMap()
        {
            #region Class

            Table("Orders");

            Id(x => x.OrderId)
                .Column("OrderID")
                .CustomSqlType("int")
                .GeneratedBy.Identity()
                .Not.Nullable();            

            Not.LazyLoad(); // GetById() EntityProxy => Entity

            #endregion Class

            #region Properties
            
            Map(x => x.CustomerId)
                .Column("CustomerID")
                .CustomSqlType("varchar")
                .Length(5);
            
            Map(x => x.EmployeeId)
                .Column("EmployeeID")
                .CustomSqlType("int");
            
            Map(x => x.OrderDate)
                .Column("OrderDate")
                .CustomSqlType("datetime");
            
            Map(x => x.RequiredDate)
                .Column("RequiredDate")
                .CustomSqlType("datetime");
            
            Map(x => x.ShippedDate)
                .Column("ShippedDate")
                .CustomSqlType("datetime");
            
            Map(x => x.ShipVia)
                .Column("ShipVia")
                .CustomSqlType("int");
            
            Map(x => x.Freight)
                .Column("Freight")
                .CustomSqlType("money");
            
            Map(x => x.ShipName)
                .Column("ShipName")
                .CustomSqlType("varchar")
                .Length(40);
            
            Map(x => x.ShipAddress)
                .Column("ShipAddress")
                .CustomSqlType("varchar")
                .Length(60);
            
            Map(x => x.ShipCity)
                .Column("ShipCity")
                .CustomSqlType("varchar")
                .Length(15);
            
            Map(x => x.ShipRegion)
                .Column("ShipRegion")
                .CustomSqlType("varchar")
                .Length(15);
            
            Map(x => x.ShipPostalCode)
                .Column("ShipPostalCode")
                .CustomSqlType("varchar")
                .Length(10);
            
            Map(x => x.ShipCountry)
                .Column("ShipCountry")
                .CustomSqlType("varchar")
                .Length(15);

            #endregion Properties

            #region Associations (FK)
                        
            References(x => x.Customer)
                .Column("CustomerID");
                        
            References(x => x.Employee)
                .Column("EmployeeID");
                        
            References(x => x.Shipper)
                .Column("ShipVia");

        #endregion Associations (FK)
            
            #region Collections (PK)

            HasMany(x => x.OrderDetails)
                .KeyColumn("OrderId");

            #endregion Collections (PK)
        }
    }
}
