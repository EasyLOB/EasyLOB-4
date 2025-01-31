using Northwind.Data;
using LinqToDB.Mapping;

namespace Northwind.Persistence
{
    public static partial class NorthwindLINQ2DBMap
    {
        public static void EmployeeTerritoryMap(MappingSchema mappingSchema)
        {
            mappingSchema.GetFluentMappingBuilder().Entity<EmployeeTerritory>()
                .HasTableName("EmployeeTerritories")

                .Property(x => x.EmployeeId)
                    .IsPrimaryKey(1)
                    .HasColumnName("EmployeeID")
                    .HasDataType(LinqToDB.DataType.Int32)
                    .IsNullable(false)

                .Property(x => x.TerritoryId)
                    .IsPrimaryKey(2)
                    .HasColumnName("TerritoryID")
                    .HasDataType(LinqToDB.DataType.VarChar)
                    .HasLength(20)
                    .IsNullable(false)
            
                .Property(x => x.Employee)
                    .IsNotColumn()
            
                .Property(x => x.Territory)
                    .IsNotColumn()
            
                .Property(x => x.LookupText)
                    .IsNotColumn()                    
                ;    
        }
    }
}
