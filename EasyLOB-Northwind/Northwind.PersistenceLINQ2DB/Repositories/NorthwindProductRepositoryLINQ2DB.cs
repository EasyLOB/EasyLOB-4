using Northwind.Data;
using EasyLOB;
using System.Linq;

namespace Northwind.Persistence
{
    public class NorthwindProductRepositoryLINQ2DB : NorthwindGenericRepositoryLINQ2DB<Product>
    {
        #region Methods

        public NorthwindProductRepositoryLINQ2DB(INorthwindUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public override IQueryable<Product> Join(IQueryable<Product> query)
        {
            return
                from product in query
                from category in UnitOfWork.GetQuery<Category>().Where(x => x.CategoryId == product.CategoryId).DefaultIfEmpty() // LEFT JOIN
                from supplier in UnitOfWork.GetQuery<Supplier>().Where(x => x.SupplierId == product.SupplierId).DefaultIfEmpty() // LEFT JOIN
                select new Product
                {
                    ProductId = product.ProductId,
                    ProductName = product.ProductName,
                    SupplierId = product.SupplierId,
                    CategoryId = product.CategoryId,
                    QuantityPerUnit = product.QuantityPerUnit,
                    UnitPrice = product.UnitPrice,
                    UnitsInStock = product.UnitsInStock,
                    UnitsOnOrder = product.UnitsOnOrder,
                    ReorderLevel = product.ReorderLevel,
                    Discontinued = product.Discontinued,
                    Category = category,
                    Supplier = supplier
                };
        }

        #endregion Methods
    }
}

