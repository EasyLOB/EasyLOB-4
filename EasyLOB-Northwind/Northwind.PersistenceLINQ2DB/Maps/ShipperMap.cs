using Northwind.Data;
using LinqToDB.Mapping;

namespace Northwind.Persistence
{
    public static partial class NorthwindLINQ2DBMap
    {
        public static void ShipperMap(MappingSchema mappingSchema)
        {
            mappingSchema.GetFluentMappingBuilder().Entity<Shipper>()
                .HasTableName("Shippers")

                .Property(x => x.ShipperId)
                    .IsPrimaryKey()
                    .IsIdentity()
                    .HasColumnName("ShipperID")
                    .HasDataType(LinqToDB.DataType.Int32)
                    .IsNullable(false)

                .Property(x => x.CompanyName)
                    .HasColumnName("CompanyName")
                    .HasDataType(LinqToDB.DataType.VarChar)
                    .HasLength(40)
                    .IsNullable(false)

                .Property(x => x.Phone)
                    .HasColumnName("Phone")
                    .HasDataType(LinqToDB.DataType.VarChar)
                    .HasLength(24)
                    .IsNullable(true)

                .Property(x => x.Orders)
                    .IsNotColumn()
            
                .Property(x => x.LookupText)
                    .IsNotColumn()                    
                ;    
        }
    }
}
