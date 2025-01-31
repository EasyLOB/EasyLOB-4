using Northwind.Data;
using EasyLOB;
using System.Linq;

namespace Northwind.Persistence
{
    public class NorthwindCustomerDemographicRepositoryLINQ2DB : NorthwindGenericRepositoryLINQ2DB<CustomerDemographic>
    {
        #region Methods

        public NorthwindCustomerDemographicRepositoryLINQ2DB(INorthwindUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public override IQueryable<CustomerDemographic> Join(IQueryable<CustomerDemographic> query)
        {
            return
                from customerDemographic in query
                select new CustomerDemographic
                {
                    CustomerTypeId = customerDemographic.CustomerTypeId,
                    CustomerDesc = customerDemographic.CustomerDesc
                };
        }

        #endregion Methods
    }
}

