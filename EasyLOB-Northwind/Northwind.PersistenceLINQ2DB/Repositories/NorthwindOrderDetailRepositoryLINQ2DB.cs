using Northwind.Data;
using EasyLOB;
using System.Linq;

namespace Northwind.Persistence
{
    public class NorthwindOrderDetailRepositoryLINQ2DB : NorthwindGenericRepositoryLINQ2DB<OrderDetail>
    {
        #region Methods

        public NorthwindOrderDetailRepositoryLINQ2DB(INorthwindUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public override IQueryable<OrderDetail> Join(IQueryable<OrderDetail> query)
        {
            return
                from orderDetail in query
                join order in UnitOfWork.GetQuery<Order>() on orderDetail.OrderId equals order.OrderId // INNER JOIN
                join product in UnitOfWork.GetQuery<Product>() on orderDetail.ProductId equals product.ProductId // INNER JOIN
                select new OrderDetail
                {
                    OrderId = orderDetail.OrderId,
                    ProductId = orderDetail.ProductId,
                    UnitPrice = orderDetail.UnitPrice,
                    Quantity = orderDetail.Quantity,
                    Discount = orderDetail.Discount,
                    Order = order,
                    Product = product
                };
        }

        #endregion Methods
    }
}

