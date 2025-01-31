using Northwind.Data;
using EasyLOB;
using System.Linq;

namespace Northwind.Persistence
{
    public class NorthwindOrderRepositoryLINQ2DB : NorthwindGenericRepositoryLINQ2DB<Order>
    {
        #region Methods

        public NorthwindOrderRepositoryLINQ2DB(INorthwindUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public override IQueryable<Order> Join(IQueryable<Order> query)
        {
            return
                from order in query
                from customer in UnitOfWork.GetQuery<Customer>().Where(x => x.CustomerId == order.CustomerId).DefaultIfEmpty() // LEFT JOIN
                from employee in UnitOfWork.GetQuery<Employee>().Where(x => x.EmployeeId == order.EmployeeId).DefaultIfEmpty() // LEFT JOIN
                from shipper in UnitOfWork.GetQuery<Shipper>().Where(x => x.ShipperId == order.ShipVia).DefaultIfEmpty() // LEFT JOIN
                select new Order
                {
                    OrderId = order.OrderId,
                    CustomerId = order.CustomerId,
                    EmployeeId = order.EmployeeId,
                    OrderDate = order.OrderDate,
                    RequiredDate = order.RequiredDate,
                    ShippedDate = order.ShippedDate,
                    ShipVia = order.ShipVia,
                    Freight = order.Freight,
                    ShipName = order.ShipName,
                    ShipAddress = order.ShipAddress,
                    ShipCity = order.ShipCity,
                    ShipRegion = order.ShipRegion,
                    ShipPostalCode = order.ShipPostalCode,
                    ShipCountry = order.ShipCountry,
                    Customer = customer,
                    Employee = employee,
                    Shipper = shipper
                };
        }

        #endregion Methods
    }
}

