using Northwind;
using Northwind.Data;
using System;
using System.Linq;

namespace EasyLOB
{
    public static partial class ShellHelper
    {
        private static void PersistenceNorthwindDemo()
        {
            Console.WriteLine("\nPersistence Northwind Demo\n");

            IUnitOfWork unitOfWork = (IUnitOfWork)EasyLOBHelper.GetService<INorthwindUnitOfWork>();
            Console.WriteLine(unitOfWork.GetType().FullName + " with " + unitOfWork.DBMS.ToString() + "\n");

            PersistenceNorthwindData<Category>(unitOfWork);
            PersistenceNorthwindData<CustomerCustomerDemo>(unitOfWork);
            PersistenceNorthwindData<CustomerDemographic>(unitOfWork);
            PersistenceNorthwindData<Customer>(unitOfWork);
            PersistenceNorthwindData<Employee>(unitOfWork);
            PersistenceNorthwindData<EmployeeTerritory>(unitOfWork);
            PersistenceNorthwindData<OrderDetail>(unitOfWork);
            PersistenceNorthwindData<Order>(unitOfWork);
            PersistenceNorthwindData<Product>(unitOfWork);
            PersistenceNorthwindData<Region>(unitOfWork);
            PersistenceNorthwindData<Shipper>(unitOfWork);
            PersistenceNorthwindData<Supplier>(unitOfWork);
            PersistenceNorthwindData<Territory>(unitOfWork);
        }

        private static void PersistenceNorthwindData<TEntity>(IUnitOfWork unitOfWork)
            where TEntity : class, IZDataModel
        {
            IGenericRepository<TEntity> repository = unitOfWork.GetRepository<TEntity>();
            TEntity entity = repository.Query().FirstOrDefault();
            Console.WriteLine(typeof(TEntity).Name + ": " + repository.CountAll());
        }
    }
}