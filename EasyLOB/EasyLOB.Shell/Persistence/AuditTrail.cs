using EasyLOB.AuditTrail;
using EasyLOB.AuditTrail.Data;
using EasyLOB.Data;
using System;
using System.Linq;

namespace EasyLOB.Shell
{
    partial class Program
    {
        private static void PersistenceAuditTrailDemo()
        {
            Console.WriteLine("\nPersistence AuditTrail Demo\n");

            IAuditTrailUnitOfWork unitOfWork = EasyLOBHelper.GetService<IAuditTrailUnitOfWork>();
            Console.WriteLine(unitOfWork.GetType().FullName + " with " + unitOfWork.DBMS.ToString() + "\n");

            PersistenceAuditTrailData<AuditTrailConfiguration>(unitOfWork);
            PersistenceAuditTrailData<AuditTrailLog>(unitOfWork);
        }

        private static void PersistenceAuditTrailData<TEntity>(IAuditTrailUnitOfWork unitOfWork)
            where TEntity : class, IZDataModel
        {
            IGenericRepository<TEntity> repository = unitOfWork.GetRepository<TEntity>();
            TEntity entity = repository.Query().FirstOrDefault();
            Console.WriteLine(typeof(TEntity).Name + ": " + repository.CountAll());
        }
    }
}