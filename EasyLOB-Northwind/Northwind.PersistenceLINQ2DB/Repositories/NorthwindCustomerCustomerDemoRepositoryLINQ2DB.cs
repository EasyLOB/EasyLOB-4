using Northwind.Data;
using EasyLOB;
using System.Linq;

namespace Northwind.Persistence
{
    public class NorthwindCustomerCustomerDemoRepositoryLINQ2DB : NorthwindGenericRepositoryLINQ2DB<CustomerCustomerDemo>
    {
        #region Methods

        public NorthwindCustomerCustomerDemoRepositoryLINQ2DB(INorthwindUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public override IQueryable<CustomerCustomerDemo> Join(IQueryable<CustomerCustomerDemo> query)
        {
            return
                from customerCustomerDemo in query
                join customerDemographic in UnitOfWork.GetQuery<CustomerDemographic>() on customerCustomerDemo.CustomerTypeId equals customerDemographic.CustomerTypeId // INNER JOIN
                join customer in UnitOfWork.GetQuery<Customer>() on customerCustomerDemo.CustomerId equals customer.CustomerId // INNER JOIN
                select new CustomerCustomerDemo
                {
                    CustomerId = customerCustomerDemo.CustomerId,
                    CustomerTypeId = customerCustomerDemo.CustomerTypeId,
                    CustomerDemographic = customerDemographic,
                    Customer = customer
                };
        }

        #endregion Methods
    }
}

