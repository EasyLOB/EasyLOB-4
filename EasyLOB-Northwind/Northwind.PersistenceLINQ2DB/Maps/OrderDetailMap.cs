using Northwind.Data;
using LinqToDB.Mapping;

namespace Northwind.Persistence
{
    public static partial class NorthwindLINQ2DBMap
    {
        public static void OrderDetailMap(MappingSchema mappingSchema)
        {
            mappingSchema.GetFluentMappingBuilder().Entity<OrderDetail>()
                .HasTableName("Order Details")

                .Property(x => x.OrderId)
                    .IsPrimaryKey(1)
                    .HasColumnName("OrderID")
                    .HasDataType(LinqToDB.DataType.Int32)
                    .IsNullable(false)

                .Property(x => x.ProductId)
                    .IsPrimaryKey(2)
                    .HasColumnName("ProductID")
                    .HasDataType(LinqToDB.DataType.Int32)
                    .IsNullable(false)

                .Property(x => x.UnitPrice)
                    .HasColumnName("UnitPrice")
                    .HasDataType(LinqToDB.DataType.Decimal)
                    .IsNullable(false)

                .Property(x => x.Quantity)
                    .HasColumnName("Quantity")
                    .HasDataType(LinqToDB.DataType.Int16)
                    .IsNullable(false)

                .Property(x => x.Discount)
                    .HasColumnName("Discount")
                    .HasDataType(LinqToDB.DataType.Single)
                    .IsNullable(false)
            
                .Property(x => x.Order)
                    .IsNotColumn()
            
                .Property(x => x.Product)
                    .IsNotColumn()
            
                .Property(x => x.LookupText)
                    .IsNotColumn()                    
                ;    
        }
    }
}
