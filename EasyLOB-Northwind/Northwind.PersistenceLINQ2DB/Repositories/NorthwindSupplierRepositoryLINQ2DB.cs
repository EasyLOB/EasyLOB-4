using Northwind.Data;
using EasyLOB;
using System.Linq;

namespace Northwind.Persistence
{
    public class NorthwindSupplierRepositoryLINQ2DB : NorthwindGenericRepositoryLINQ2DB<Supplier>
    {
        #region Methods

        public NorthwindSupplierRepositoryLINQ2DB(INorthwindUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public override IQueryable<Supplier> Join(IQueryable<Supplier> query)
        {
            return
                from supplier in query
                select new Supplier
                {
                    SupplierId = supplier.SupplierId,
                    CompanyName = supplier.CompanyName,
                    ContactName = supplier.ContactName,
                    ContactTitle = supplier.ContactTitle,
                    Address = supplier.Address,
                    City = supplier.City,
                    Region = supplier.Region,
                    PostalCode = supplier.PostalCode,
                    Country = supplier.Country,
                    Phone = supplier.Phone,
                    Fax = supplier.Fax,
                    HomePage = supplier.HomePage
                };
        }

        #endregion Methods
    }
}

