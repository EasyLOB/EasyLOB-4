using Northwind.Data;
using FluentNHibernate.Mapping;

namespace Northwind.Persistence
{
    public class EmployeeMap : ClassMap<Employee>
    {
        public EmployeeMap()
        {
            #region Class

            Table("Employees");

            Id(x => x.EmployeeId)
                .Column("EmployeeID")
                .CustomSqlType("int")
                .GeneratedBy.Identity()
                .Not.Nullable();            

            Not.LazyLoad(); // GetById() EntityProxy => Entity

            #endregion Class

            #region Properties
            
            Map(x => x.LastName)
                .Column("LastName")
                .CustomSqlType("varchar")
                .Length(20)
                .Not.Nullable();
            
            Map(x => x.FirstName)
                .Column("FirstName")
                .CustomSqlType("varchar")
                .Length(10)
                .Not.Nullable();
            
            Map(x => x.Title)
                .Column("Title")
                .CustomSqlType("varchar")
                .Length(30);
            
            Map(x => x.TitleOfCourtesy)
                .Column("TitleOfCourtesy")
                .CustomSqlType("varchar")
                .Length(25);
            
            Map(x => x.BirthDate)
                .Column("BirthDate")
                .CustomSqlType("datetime");
            
            Map(x => x.HireDate)
                .Column("HireDate")
                .CustomSqlType("datetime");
            
            Map(x => x.Address)
                .Column("Address")
                .CustomSqlType("varchar")
                .Length(60);
            
            Map(x => x.City)
                .Column("City")
                .CustomSqlType("varchar")
                .Length(15);
            
            Map(x => x.Region)
                .Column("Region")
                .CustomSqlType("varchar")
                .Length(15);
            
            Map(x => x.PostalCode)
                .Column("PostalCode")
                .CustomSqlType("varchar")
                .Length(10);
            
            Map(x => x.Country)
                .Column("Country")
                .CustomSqlType("varchar")
                .Length(15);
            
            Map(x => x.HomePhone)
                .Column("HomePhone")
                .CustomSqlType("varchar")
                .Length(24);
            
            Map(x => x.Extension)
                .Column("Extension")
                .CustomSqlType("varchar")
                .Length(4);
            
            Map(x => x.Photo)
                .Column("Photo")
                .CustomSqlType("varbinary");
            
            Map(x => x.Notes)
                .Column("Notes")
                .CustomSqlType("varchar")
                .Length(1024);
            
            Map(x => x.ReportsTo)
                .Column("ReportsTo")
                .CustomSqlType("int");
            
            Map(x => x.PhotoPath)
                .Column("PhotoPath")
                .CustomSqlType("varchar")
                .Length(255);

            #endregion Properties

            #region Associations (FK)
                        
            References(x => x.EmployeeX)
                .Column("ReportsTo");

        #endregion Associations (FK)
            
            #region Collections (PK)

            HasMany(x => x.Employees)
                .KeyColumn("ReportsTo");

            HasMany(x => x.EmployeeTerritories)
                .KeyColumn("EmployeeId");

            HasMany(x => x.Orders)
                .KeyColumn("EmployeeId");

            #endregion Collections (PK)
        }
    }
}
