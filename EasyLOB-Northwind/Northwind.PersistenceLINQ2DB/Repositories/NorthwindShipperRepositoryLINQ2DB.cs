using Northwind.Data;
using EasyLOB;
using System.Linq;

namespace Northwind.Persistence
{
    public class NorthwindShipperRepositoryLINQ2DB : NorthwindGenericRepositoryLINQ2DB<Shipper>
    {
        #region Methods

        public NorthwindShipperRepositoryLINQ2DB(INorthwindUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public override IQueryable<Shipper> Join(IQueryable<Shipper> query)
        {
            return
                from shipper in query
                select new Shipper
                {
                    ShipperId = shipper.ShipperId,
                    CompanyName = shipper.CompanyName,
                    Phone = shipper.Phone
                };
        }

        #endregion Methods
    }
}

