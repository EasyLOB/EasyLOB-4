using Northwind.Data;
using LinqToDB.Mapping;

namespace Northwind.Persistence
{
    public static partial class NorthwindLINQ2DBMap
    {
        public static void CustomerDemographicMap(MappingSchema mappingSchema)
        {
            mappingSchema.GetFluentMappingBuilder().Entity<CustomerDemographic>()
                .HasTableName("CustomerDemographics")

                .Property(x => x.CustomerTypeId)
                    .IsPrimaryKey()
                    .HasColumnName("CustomerTypeID")
                    .HasDataType(LinqToDB.DataType.VarChar)
                    .HasLength(10)
                    .IsNullable(false)

                .Property(x => x.CustomerDesc)
                    .HasColumnName("CustomerDesc")
                    .HasDataType(LinqToDB.DataType.VarChar)
                    .HasLength(1024)
                    .IsNullable(true)

                .Property(x => x.CustomerCustomerDemos)
                    .IsNotColumn()
            
                .Property(x => x.LookupText)
                    .IsNotColumn()                    
                ;    
        }
    }
}
