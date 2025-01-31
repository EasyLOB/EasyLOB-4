using Northwind.Data;
using LinqToDB.Mapping;

namespace Northwind.Persistence
{
    public static partial class NorthwindLINQ2DBMap
    {
        public static void TerritoryMap(MappingSchema mappingSchema)
        {
            mappingSchema.GetFluentMappingBuilder().Entity<Territory>()
                .HasTableName("Territories")

                .Property(x => x.TerritoryId)
                    .IsPrimaryKey()
                    .HasColumnName("TerritoryID")
                    .HasDataType(LinqToDB.DataType.VarChar)
                    .HasLength(20)
                    .IsNullable(false)

                .Property(x => x.TerritoryDescription)
                    .HasColumnName("TerritoryDescription")
                    .HasDataType(LinqToDB.DataType.VarChar)
                    .HasLength(50)
                    .IsNullable(false)

                .Property(x => x.RegionId)
                    .HasColumnName("RegionID")
                    .HasDataType(LinqToDB.DataType.Int32)
                    .IsNullable(false)
            
                .Property(x => x.Region)
                    .IsNotColumn()

                .Property(x => x.EmployeeTerritories)
                    .IsNotColumn()
            
                .Property(x => x.LookupText)
                    .IsNotColumn()                    
                ;    
        }
    }
}
