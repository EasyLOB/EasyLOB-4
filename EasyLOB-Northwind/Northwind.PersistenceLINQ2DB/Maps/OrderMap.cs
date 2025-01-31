using Northwind.Data;
using LinqToDB.Mapping;

namespace Northwind.Persistence
{
    public static partial class NorthwindLINQ2DBMap
    {
        public static void OrderMap(MappingSchema mappingSchema)
        {
            mappingSchema.GetFluentMappingBuilder().Entity<Order>()
                .HasTableName("Orders")

                .Property(x => x.OrderId)
                    .IsPrimaryKey()
                    .IsIdentity()
                    .HasColumnName("OrderID")
                    .HasDataType(LinqToDB.DataType.Int32)
                    .IsNullable(false)

                .Property(x => x.CustomerId)
                    .HasColumnName("CustomerID")
                    .HasDataType(LinqToDB.DataType.VarChar)
                    .HasLength(5)
                    .IsNullable(true)

                .Property(x => x.EmployeeId)
                    .HasColumnName("EmployeeID")
                    .HasDataType(LinqToDB.DataType.Int32)
                    .IsNullable(true)

                .Property(x => x.OrderDate)
                    .HasColumnName("OrderDate")
                    .HasDataType(LinqToDB.DataType.DateTime)
                    .IsNullable(true)

                .Property(x => x.RequiredDate)
                    .HasColumnName("RequiredDate")
                    .HasDataType(LinqToDB.DataType.DateTime)
                    .IsNullable(true)

                .Property(x => x.ShippedDate)
                    .HasColumnName("ShippedDate")
                    .HasDataType(LinqToDB.DataType.DateTime)
                    .IsNullable(true)

                .Property(x => x.ShipVia)
                    .HasColumnName("ShipVia")
                    .HasDataType(LinqToDB.DataType.Int32)
                    .IsNullable(true)

                .Property(x => x.Freight)
                    .HasColumnName("Freight")
                    .HasDataType(LinqToDB.DataType.Decimal)
                    .IsNullable(true)

                .Property(x => x.ShipName)
                    .HasColumnName("ShipName")
                    .HasDataType(LinqToDB.DataType.VarChar)
                    .HasLength(40)
                    .IsNullable(true)

                .Property(x => x.ShipAddress)
                    .HasColumnName("ShipAddress")
                    .HasDataType(LinqToDB.DataType.VarChar)
                    .HasLength(60)
                    .IsNullable(true)

                .Property(x => x.ShipCity)
                    .HasColumnName("ShipCity")
                    .HasDataType(LinqToDB.DataType.VarChar)
                    .HasLength(15)
                    .IsNullable(true)

                .Property(x => x.ShipRegion)
                    .HasColumnName("ShipRegion")
                    .HasDataType(LinqToDB.DataType.VarChar)
                    .HasLength(15)
                    .IsNullable(true)

                .Property(x => x.ShipPostalCode)
                    .HasColumnName("ShipPostalCode")
                    .HasDataType(LinqToDB.DataType.VarChar)
                    .HasLength(10)
                    .IsNullable(true)

                .Property(x => x.ShipCountry)
                    .HasColumnName("ShipCountry")
                    .HasDataType(LinqToDB.DataType.VarChar)
                    .HasLength(15)
                    .IsNullable(true)
            
                .Property(x => x.Customer)
                    .IsNotColumn()
            
                .Property(x => x.Employee)
                    .IsNotColumn()
            
                .Property(x => x.Shipper)
                    .IsNotColumn()

                .Property(x => x.OrderDetails)
                    .IsNotColumn()
            
                .Property(x => x.LookupText)
                    .IsNotColumn()                    
                ;    
        }
    }
}
