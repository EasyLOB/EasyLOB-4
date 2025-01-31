using Northwind.Data;
using FluentNHibernate.Mapping;

namespace Northwind.Persistence
{
    public class TerritoryMap : ClassMap<Territory>
    {
        public TerritoryMap()
        {
            #region Class

            Table("Territories");

            Id(x => x.TerritoryId)
                .Column("TerritoryID")
                .CustomSqlType("varchar")
                .GeneratedBy.Assigned()
                .Length(20)
                .Not.Nullable();            

            Not.LazyLoad(); // GetById() EntityProxy => Entity

            #endregion Class

            #region Properties
            
            Map(x => x.TerritoryDescription)
                .Column("TerritoryDescription")
                .CustomSqlType("varchar")
                .Length(50)
                .Not.Nullable();
            
            Map(x => x.RegionId)
                .Column("RegionID")
                .CustomSqlType("int")
                .Not.Nullable();

            #endregion Properties

            #region Associations (FK)
                        
            References(x => x.Region)
                .Column("RegionID");

        #endregion Associations (FK)
            
            #region Collections (PK)

            HasMany(x => x.EmployeeTerritories)
                .KeyColumn("TerritoryId");

            #endregion Collections (PK)
        }
    }
}
