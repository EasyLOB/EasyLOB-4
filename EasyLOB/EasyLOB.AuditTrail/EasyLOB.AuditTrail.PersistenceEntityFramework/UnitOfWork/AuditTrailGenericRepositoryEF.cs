﻿using EasyLOB.Data;
using EasyLOB.Persistence;

namespace EasyLOB.AuditTrail.Persistence
{
    public class AuditTrailGenericRepositoryEF<TEntity> : GenericRepositoryEF<TEntity>, IAuditTrailGenericRepository<TEntity>
        where TEntity : class, IZDataModel
    {
        #region Methods

        public AuditTrailGenericRepositoryEF(IAuditTrailUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            Context = (unitOfWork as AuditTrailUnitOfWorkEF).Context;
        }

        #endregion Methods

        #region Methods IDispose

        private bool disposed = false;

        protected override void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    if (Context != null)
                    {
                        Context.Dispose();
                        Context = null;
                    }
                }

                disposed = true;

                base.Dispose(disposing);
            }
        }

        #endregion Methods IDispose
    }
}

