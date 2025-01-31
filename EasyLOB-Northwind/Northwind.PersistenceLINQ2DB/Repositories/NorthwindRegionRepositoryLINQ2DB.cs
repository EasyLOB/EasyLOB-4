using Northwind.Data;
using EasyLOB;
using System.Linq;

namespace Northwind.Persistence
{
    public class NorthwindRegionRepositoryLINQ2DB : NorthwindGenericRepositoryLINQ2DB<Region>
    {
        #region Methods

        public NorthwindRegionRepositoryLINQ2DB(INorthwindUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public override IQueryable<Region> Join(IQueryable<Region> query)
        {
            return
                from region in query
                select new Region
                {
                    RegionId = region.RegionId,
                    RegionDescription = region.RegionDescription
                };
        }

        #endregion Methods
    }
}

