using Northwind.Data;
using LinqToDB.Mapping;

namespace Northwind.Persistence
{
    public static partial class NorthwindLINQ2DBMap
    {
        public static void ProductMap(MappingSchema mappingSchema)
        {
            mappingSchema.GetFluentMappingBuilder().Entity<Product>()
                .HasTableName("Products")

                .Property(x => x.ProductId)
                    .IsPrimaryKey()
                    .IsIdentity()
                    .HasColumnName("ProductID")
                    .HasDataType(LinqToDB.DataType.Int32)
                    .IsNullable(false)

                .Property(x => x.ProductName)
                    .HasColumnName("ProductName")
                    .HasDataType(LinqToDB.DataType.VarChar)
                    .HasLength(40)
                    .IsNullable(false)

                .Property(x => x.SupplierId)
                    .HasColumnName("SupplierID")
                    .HasDataType(LinqToDB.DataType.Int32)
                    .IsNullable(true)

                .Property(x => x.CategoryId)
                    .HasColumnName("CategoryID")
                    .HasDataType(LinqToDB.DataType.Int32)
                    .IsNullable(true)

                .Property(x => x.QuantityPerUnit)
                    .HasColumnName("QuantityPerUnit")
                    .HasDataType(LinqToDB.DataType.VarChar)
                    .HasLength(20)
                    .IsNullable(true)

                .Property(x => x.UnitPrice)
                    .HasColumnName("UnitPrice")
                    .HasDataType(LinqToDB.DataType.Decimal)
                    .IsNullable(true)

                .Property(x => x.UnitsInStock)
                    .HasColumnName("UnitsInStock")
                    .HasDataType(LinqToDB.DataType.Int16)
                    .IsNullable(true)

                .Property(x => x.UnitsOnOrder)
                    .HasColumnName("UnitsOnOrder")
                    .HasDataType(LinqToDB.DataType.Int16)
                    .IsNullable(true)

                .Property(x => x.ReorderLevel)
                    .HasColumnName("ReorderLevel")
                    .HasDataType(LinqToDB.DataType.Int16)
                    .IsNullable(true)

                .Property(x => x.Discontinued)
                    .HasColumnName("Discontinued")
                    .HasDataType(LinqToDB.DataType.Boolean)
                    .IsNullable(false)
            
                .Property(x => x.Category)
                    .IsNotColumn()
            
                .Property(x => x.Supplier)
                    .IsNotColumn()

                .Property(x => x.OrderDetails)
                    .IsNotColumn()
            
                .Property(x => x.LookupText)
                    .IsNotColumn()                    
                ;    
        }
    }
}
