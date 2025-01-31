using EasyLOB.Identity;
using EasyLOB.Identity.Data;
using EasyLOB.Data;
using System;
using System.Linq;

namespace EasyLOB.Shell
{
    partial class Program
    {
        private static void PersistenceIdentityDemo()
        {
            Console.WriteLine("\nPersistence Identity Demo\n");

            IIdentityUnitOfWork unitOfWork = EasyLOBHelper.GetService<IIdentityUnitOfWork>();
            Console.WriteLine(unitOfWork.GetType().FullName + " with " + unitOfWork.DBMS.ToString() + "\n");

            PersistenceIdentityData<Role>(unitOfWork);
            PersistenceIdentityData<UserClaim>(unitOfWork);
            PersistenceIdentityData<UserLogin>(unitOfWork);
            PersistenceIdentityData<UserRole>(unitOfWork);
            PersistenceIdentityData<User>(unitOfWork);
        }

        private static void PersistenceIdentityData<TEntity>(IIdentityUnitOfWork unitOfWork)
            where TEntity : ZDataModel
        {
            IGenericRepository<TEntity> repository = unitOfWork.GetRepository<TEntity>();
            TEntity entity = repository.Query().FirstOrDefault();
            Console.WriteLine(typeof(TEntity).Name + ": " + repository.CountAll());
        }
    }
}