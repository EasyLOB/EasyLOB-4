using Northwind.Data;
using LinqToDB.Mapping;

namespace Northwind.Persistence
{
    public static partial class NorthwindLINQ2DBMap
    {
        public static void EmployeeMap(MappingSchema mappingSchema)
        {
            mappingSchema.GetFluentMappingBuilder().Entity<Employee>()
                .HasTableName("Employees")

                .Property(x => x.EmployeeId)
                    .IsPrimaryKey()
                    .IsIdentity()
                    .HasColumnName("EmployeeID")
                    .HasDataType(LinqToDB.DataType.Int32)
                    .IsNullable(false)

                .Property(x => x.LastName)
                    .HasColumnName("LastName")
                    .HasDataType(LinqToDB.DataType.VarChar)
                    .HasLength(20)
                    .IsNullable(false)

                .Property(x => x.FirstName)
                    .HasColumnName("FirstName")
                    .HasDataType(LinqToDB.DataType.VarChar)
                    .HasLength(10)
                    .IsNullable(false)

                .Property(x => x.Title)
                    .HasColumnName("Title")
                    .HasDataType(LinqToDB.DataType.VarChar)
                    .HasLength(30)
                    .IsNullable(true)

                .Property(x => x.TitleOfCourtesy)
                    .HasColumnName("TitleOfCourtesy")
                    .HasDataType(LinqToDB.DataType.VarChar)
                    .HasLength(25)
                    .IsNullable(true)

                .Property(x => x.BirthDate)
                    .HasColumnName("BirthDate")
                    .HasDataType(LinqToDB.DataType.DateTime)
                    .IsNullable(true)

                .Property(x => x.HireDate)
                    .HasColumnName("HireDate")
                    .HasDataType(LinqToDB.DataType.DateTime)
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

                .Property(x => x.HomePhone)
                    .HasColumnName("HomePhone")
                    .HasDataType(LinqToDB.DataType.VarChar)
                    .HasLength(24)
                    .IsNullable(true)

                .Property(x => x.Extension)
                    .HasColumnName("Extension")
                    .HasDataType(LinqToDB.DataType.VarChar)
                    .HasLength(4)
                    .IsNullable(true)

                .Property(x => x.Photo)
                    .HasColumnName("Photo")
                    .HasDataType(LinqToDB.DataType.Binary)
                    .IsNullable(true)

                .Property(x => x.Notes)
                    .HasColumnName("Notes")
                    .HasDataType(LinqToDB.DataType.VarChar)
                    .HasLength(1024)
                    .IsNullable(true)

                .Property(x => x.ReportsTo)
                    .HasColumnName("ReportsTo")
                    .HasDataType(LinqToDB.DataType.Int32)
                    .IsNullable(true)

                .Property(x => x.PhotoPath)
                    .HasColumnName("PhotoPath")
                    .HasDataType(LinqToDB.DataType.VarChar)
                    .HasLength(255)
                    .IsNullable(true)
            
                .Property(x => x.EmployeeX)
                    .IsNotColumn()

                .Property(x => x.Employees)
                    .IsNotColumn()

                .Property(x => x.EmployeeTerritories)
                    .IsNotColumn()

                .Property(x => x.Orders)
                    .IsNotColumn()
            
                .Property(x => x.LookupText)
                    .IsNotColumn()                    
                ;    
        }
    }
}
