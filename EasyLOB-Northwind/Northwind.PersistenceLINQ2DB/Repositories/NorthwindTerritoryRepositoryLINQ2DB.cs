using Northwind.Data;
using EasyLOB;
using System.Linq;

namespace Northwind.Persistence
{
    public class NorthwindTerritoryRepositoryLINQ2DB : NorthwindGenericRepositoryLINQ2DB<Territory>
    {
        #region Methods

        public NorthwindTerritoryRepositoryLINQ2DB(INorthwindUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public override IQueryable<Territory> Join(IQueryable<Territory> query)
        {
            return
                from territory in query
                join region in UnitOfWork.GetQuery<Region>() on territory.RegionId equals region.RegionId // INNER JOIN
                select new Territory
                {
                    TerritoryId = territory.TerritoryId,
                    TerritoryDescription = territory.TerritoryDescription,
                    RegionId = territory.RegionId,
                    Region = region
                };
        }

        #endregion Methods
    }
}

