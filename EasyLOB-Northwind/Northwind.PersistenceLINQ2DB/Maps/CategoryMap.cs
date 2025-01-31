using Northwind.Data;
using LinqToDB.Mapping;

namespace Northwind.Persistence
{
    public static partial class NorthwindLINQ2DBMap
    {
        public static void CategoryMap(MappingSchema mappingSchema)
        {
            mappingSchema.GetFluentMappingBuilder().Entity<Category>()
                .HasTableName("Categories")

                .Property(x => x.CategoryId)
                    .IsPrimaryKey()
                    .IsIdentity()
                    .HasColumnName("CategoryID")
                    .HasDataType(LinqToDB.DataType.Int32)
                    .IsNullable(false)

                .Property(x => x.CategoryName)
                    .HasColumnName("CategoryName")
                    .HasDataType(LinqToDB.DataType.VarChar)
                    .HasLength(15)
                    .IsNullable(false)

                .Property(x => x.Description)
                    .HasColumnName("Description")
                    .HasDataType(LinqToDB.DataType.VarChar)
                    .HasLength(1024)
                    .IsNullable(true)

                .Property(x => x.Picture)
                    .HasColumnName("Picture")
                    .HasDataType(LinqToDB.DataType.Binary)
                    .IsNullable(true)

                .Property(x => x.Products)
                    .IsNotColumn()
            
                .Property(x => x.LookupText)
                    .IsNotColumn()                    
                ;    
        }
    }
}
