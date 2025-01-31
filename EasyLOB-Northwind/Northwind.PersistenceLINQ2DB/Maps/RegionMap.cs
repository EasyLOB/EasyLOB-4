using Northwind.Data;
using LinqToDB.Mapping;

namespace Northwind.Persistence
{
    public static partial class NorthwindLINQ2DBMap
    {
        public static void RegionMap(MappingSchema mappingSchema)
        {
            mappingSchema.GetFluentMappingBuilder().Entity<Region>()
                .HasTableName("Region")

                .Property(x => x.RegionId)
                    .IsPrimaryKey()
                    .HasColumnName("RegionID")
                    .HasDataType(LinqToDB.DataType.Int32)
                    .IsNullable(false)

                .Property(x => x.RegionDescription)
                    .HasColumnName("RegionDescription")
                    .HasDataType(LinqToDB.DataType.VarChar)
                    .HasLength(50)
                    .IsNullable(false)

                .Property(x => x.Territories)
                    .IsNotColumn()
            
                .Property(x => x.LookupText)
                    .IsNotColumn()                    
                ;    
        }
    }
}
