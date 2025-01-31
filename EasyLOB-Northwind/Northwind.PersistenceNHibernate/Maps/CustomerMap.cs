using Northwind.Data;
using FluentNHibernate.Mapping;

namespace Northwind.Persistence
{
    public class CustomerMap : ClassMap<Customer>
    {
        public CustomerMap()
        {
            #region Class

            Table("Customers");

            Id(x => x.CustomerId)
                .Column("CustomerID")
                .CustomSqlType("varchar")
                .GeneratedBy.Assigned()
                .Length(5)
                .Not.Nullable();            

            Not.LazyLoad(); // GetById() EntityProxy => Entity

            #endregion Class

            #region Properties
            
            Map(x => x.CompanyName)
                .Column("CompanyName")
                .CustomSqlType("varchar")
                .Length(40)
                .Not.Nullable();
            
            Map(x => x.ContactName)
                .Column("ContactName")
                .CustomSqlType("varchar")
                .Length(30);
            
            Map(x => x.ContactTitle)
                .Column("ContactTitle")
                .CustomSqlType("varchar")
                .Length(30);
            
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
            
            Map(x => x.Phone)
                .Column("Phone")
                .CustomSqlType("varchar")
                .Length(24);
            
            Map(x => x.Fax)
                .Column("Fax")
                .CustomSqlType("varchar")
                .Length(24);

            #endregion Properties
            
            #region Collections (PK)

            HasMany(x => x.CustomerCustomerDemos)
                .KeyColumn("CustomerId");

            HasMany(x => x.Orders)
                .KeyColumn("CustomerId");

            #endregion Collections (PK)
        }
    }
}
