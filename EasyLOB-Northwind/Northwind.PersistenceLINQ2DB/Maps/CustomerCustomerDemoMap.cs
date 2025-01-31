using Northwind.Data;
using LinqToDB.Mapping;

namespace Northwind.Persistence
{
    public static partial class NorthwindLINQ2DBMap
    {
        public static void CustomerCustomerDemoMap(MappingSchema mappingSchema)
        {
            mappingSchema.GetFluentMappingBuilder().Entity<CustomerCustomerDemo>()
                .HasTableName("CustomerCustomerDemo")

                .Property(x => x.CustomerId)
                    .IsPrimaryKey(1)
                    .HasColumnName("CustomerID")
                    .HasDataType(LinqToDB.DataType.VarChar)
                    .HasLength(5)
                    .IsNullable(false)

                .Property(x => x.CustomerTypeId)
                    .IsPrimaryKey(2)
                    .HasColumnName("CustomerTypeID")
                    .HasDataType(LinqToDB.DataType.VarChar)
                    .HasLength(10)
                    .IsNullable(false)
            
                .Property(x => x.CustomerDemographic)
                    .IsNotColumn()
            
                .Property(x => x.Customer)
                    .IsNotColumn()
            
                .Property(x => x.LookupText)
                    .IsNotColumn()                    
                ;    
        }
    }
}
