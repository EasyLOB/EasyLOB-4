using Northwind.Data;
using FluentNHibernate.Mapping;

namespace Northwind.Persistence
{
    public class EmployeeTerritoryMap : ClassMap<EmployeeTerritory>
    {
        public EmployeeTerritoryMap()
        {
            #region Class

            Table("EmployeeTerritories");

            CompositeId()
                .KeyProperty(x => x.EmployeeId, "EmployeeID")
                .KeyProperty(x => x.TerritoryId, "TerritoryID");

            Not.LazyLoad(); // GetById() EntityProxy => Entity

            #endregion Class

            #region Properties

            #endregion Properties

            #region Associations (FK)
                        
            References(x => x.Employee)
                .Column("EmployeeID");
                        
            References(x => x.Territory)
                .Column("TerritoryID");

        #endregion Associations (FK)
        }
    }
}
