using Northwind.Data;
using FluentNHibernate.Mapping;

namespace Northwind.Persistence
{
    public class RegionMap : ClassMap<Region>
    {
        public RegionMap()
        {
            #region Class

            Table("Region");

            Id(x => x.RegionId)
                .Column("RegionID")
                .CustomSqlType("int")
                .GeneratedBy.Assigned()
                .Not.Nullable();            

            Not.LazyLoad(); // GetById() EntityProxy => Entity

            #endregion Class

            #region Properties
            
            Map(x => x.RegionDescription)
                .Column("RegionDescription")
                .CustomSqlType("varchar")
                .Length(50)
                .Not.Nullable();

            #endregion Properties
            
            #region Collections (PK)

            HasMany(x => x.Territories)
                .KeyColumn("RegionId");

            #endregion Collections (PK)
        }
    }
}
