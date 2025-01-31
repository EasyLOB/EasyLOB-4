using Northwind.Data;
using FluentNHibernate.Mapping;

namespace Northwind.Persistence
{
    public class SupplierMap : ClassMap<Supplier>
    {
        public SupplierMap()
        {
            #region Class

            Table("Suppliers");

            Id(x => x.SupplierId)
                .Column("SupplierID")
                .CustomSqlType("int")
                .GeneratedBy.Identity()
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
            
            Map(x => x.HomePage)
                .Column("HomePage")
                .CustomSqlType("varchar")
                .Length(1024);

            #endregion Properties
            
            #region Collections (PK)

            HasMany(x => x.Products)
                .KeyColumn("SupplierId");

            #endregion Collections (PK)
        }
    }
}
