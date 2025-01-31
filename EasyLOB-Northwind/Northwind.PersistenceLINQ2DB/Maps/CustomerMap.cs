using Northwind.Data;
using LinqToDB.Mapping;

namespace Northwind.Persistence
{
    public static partial class NorthwindLINQ2DBMap
    {
        public static void CustomerMap(MappingSchema mappingSchema)
        {
            mappingSchema.GetFluentMappingBuilder().Entity<Customer>()
                .HasTableName("Customers")

                .Property(x => x.CustomerId)
                    .IsPrimaryKey()
                    .HasColumnName("CustomerID")
                    .HasDataType(LinqToDB.DataType.VarChar)
                    .HasLength(5)
                    .IsNullable(false)

                .Property(x => x.CompanyName)
                    .HasColumnName("CompanyName")
                    .HasDataType(LinqToDB.DataType.VarChar)
                    .HasLength(40)
                    .IsNullable(false)

                .Property(x => x.ContactName)
                    .HasColumnName("ContactName")
                    .HasDataType(LinqToDB.DataType.VarChar)
                    .HasLength(30)
                    .IsNullable(true)

                .Property(x => x.ContactTitle)
                    .HasColumnName("ContactTitle")
                    .HasDataType(LinqToDB.DataType.VarChar)
                    .HasLength(30)
                    .IsNullable(true)

                .Property(x => x.Address)
                    .HasColumnName("Address")
                    .HasDataType(LinqToDB.DataType.VarChar)
                    .HasLength(60)
                    .IsNullable(true)

                .Property(x => x.City)
                    .HasColumnName("City")
                    .HasDataType(LinqToDB.DataType.VarChar)
                    .HasLength(15)
                    .IsNullable(true)

                .Property(x => x.Region)
                    .HasColumnName("Region")
                    .HasDataType(LinqToDB.DataType.VarChar)
                    .HasLength(15)
                    .IsNullable(true)

                .Property(x => x.PostalCode)
                    .HasColumnName("PostalCode")
                    .HasDataType(LinqToDB.DataType.VarChar)
                    .HasLength(10)
                    .IsNullable(true)

                .Property(x => x.Country)
                    .HasColumnName("Country")
                    .HasDataType(LinqToDB.DataType.VarChar)
                    .HasLength(15)
                    .IsNullable(true)

                .Property(x => x.Phone)
                    .HasColumnName("Phone")
                    .HasDataType(LinqToDB.DataType.VarChar)
                    .HasLength(24)
                    .IsNullable(true)

                .Property(x => x.Fax)
                    .HasColumnName("Fax")
                    .HasDataType(LinqToDB.DataType.VarChar)
                    .HasLength(24)
                    .IsNullable(true)

                .Property(x => x.CustomerCustomerDemos)
                    .IsNotColumn()

                .Property(x => x.Orders)
                    .IsNotColumn()
            
                .Property(x => x.LookupText)
                    .IsNotColumn()                    
                ;    
        }
    }
}
