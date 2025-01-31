using Northwind.Data;
using FluentNHibernate.Mapping;

namespace Northwind.Persistence
{
    public class ShipperMap : ClassMap<Shipper>
    {
        public ShipperMap()
        {
            #region Class

            Table("Shippers");

            Id(x => x.ShipperId)
                .Column("ShipperID")
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
            
            Map(x => x.Phone)
                .Column("Phone")
                .CustomSqlType("varchar")
                .Length(24);

            #endregion Properties
            
            #region Collections (PK)

            HasMany(x => x.Orders)
                .KeyColumn("ShipVia");

            #endregion Collections (PK)
        }
    }
}
