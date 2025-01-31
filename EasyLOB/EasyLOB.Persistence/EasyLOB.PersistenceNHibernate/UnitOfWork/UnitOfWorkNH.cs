using EasyLOB.Data;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

// Install-Package NHibernate
// Install-Package FluentNHibernate

namespace EasyLOB.Persistence
{
    public abstract class UnitOfWorkNH : IUnitOfWork
    {
        #region Properties

        public IAuthenticationManager AuthenticationManager { get; }

        public ZDatabaseLogger DatabaseLogger { get; set; }

        public ZDBMS DBMS
        {
            get { return Session.GetDBMS(); }
        }

        public string Domain { get; protected set; }

        public IDictionary<Type, object> Repositories { get; }

        #endregion Properties

        #region Properties NHibernate

        public ISession Session { get; protected set; }

        public ITransaction Transaction { get; protected set; }

        #endregion Properties NHibernate

        #region Methods

        public UnitOfWorkNH(ISession session,
            IAuthenticationManager authenticationManager)
        {
            Session = session;
            AuthenticationManager = authenticationManager;

            DatabaseLogger = ZDatabaseLogger.None;
            Domain = "";
            Repositories = new Dictionary<Type, object>();
        }

        public virtual bool BeginTransaction(ZOperationResult operationResult, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            try
            {
                if (PersistenceHelper.IsTransaction)
                {
                    if (Transaction == null || !Transaction.IsActive)
                    {
                        if (Transaction != null)
                        {
                            Transaction.Dispose();
                        }

                        Transaction = Session.BeginTransaction(isolationLevel);
                    }
                }
            }
            catch (Exception exception)
            {
                operationResult.ParseExceptionNHibernate(exception);
            }

            return operationResult.Ok;
        }

        public virtual bool CommitTransaction(ZOperationResult operationResult)
        {
            try
            {
                if (PersistenceHelper.IsTransaction)
                {
                    if (Transaction != null)
                    {
                        Transaction.Commit();
                    }
                }
            }
            catch (Exception exception)
            {
                operationResult.ParseExceptionNHibernate(exception);
            }

            return operationResult.Ok;
        }

        public IZProfile GetProfile<TEntity>()
            where TEntity : class, IZDataModel
        {
            return GetRepository<TEntity>().Profile;
        }

        public virtual IQueryable<TEntity> GetQuery<TEntity>()
            where TEntity : class, IZDataModel
        {
            return GetRepository<TEntity>().Query();
        }

        public virtual IGenericRepository<TEntity> GetRepository<TEntity>()
            where TEntity : class, IZDataModel
        {
            throw new NotImplementedException("abstract class NHibernate UnitOfWork.GetRepository()");

            //if (!Repositories.Keys.Contains(typeof(TEntity)))
            //{
            //    var repository = new GenericRepository<TEntity>(Session);
            //    Repositories.Add(typeof(TEntity), repository);
            //}

            //return Repositories[typeof(TEntity)] as IGenericRepository<TEntity>;
        }

        public virtual bool RollbackTransaction(ZOperationResult operationResult)
        {
            try
            {
                if (PersistenceHelper.IsTransaction)
                {

                    if (Transaction != null)
                    {
                        Transaction.Rollback();
                    }
                }
            }
            catch (Exception exception)
            {
                operationResult.ParseExceptionNHibernate(exception);
            }

            return operationResult.Ok;
        }

        public virtual bool Save(ZOperationResult operationResult)
        {
            try
            {
                Session.Flush();
            }
            catch (Exception exception)
            {
                operationResult.ParseExceptionNHibernate(exception);
            }

            return operationResult.Ok;
        }

        public void SetIsolationLevel(IsolationLevel isolationLevel)
        {
            ZDBMS dbms = AdoNetHelper.GetDBMS(Session.Connection.ConnectionString);
            string sql = AdoNetHelper.SqlGetIsolationLevel(dbms, isolationLevel);
            if (!string.IsNullOrEmpty(sql))
            {
                SQLCommand(sql);
            }
        }

        #endregion Methods

        #region Methods SQL

        public virtual int SQLCommand(string sql)
        {
            return Session.CreateQuery(sql).ExecuteUpdate();
        }

        public virtual IEnumerable<TEntity> SQLQuery<TEntity>(string sql)
        {
            return Session.CreateSQLQuery(sql).List<TEntity>().ToList<TEntity>();
        }

        #endregion Methods SQL

        #region Methods IDispose

        private bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    if (Transaction != null)
                    {
                        Transaction.Dispose();
                        Transaction = null;
                    }
                }

                disposed = true;
            }
        }

        #endregion Methods IDispose

        #region Triggers

        public virtual bool BeforeCreate(ZOperationResult operationResult, object entity)
        {
            return operationResult.Ok;
        }

        public virtual bool AfterCreate(ZOperationResult operationResult, object entity)
        {
            return operationResult.Ok;
        }

        public virtual bool BeforeDelete(ZOperationResult operationResult, object entity)
        {
            return operationResult.Ok;
        }

        public virtual bool AfterDelete(ZOperationResult operationResult, object entity)
        {
            return operationResult.Ok;
        }

        public virtual bool BeforeUpdate(ZOperationResult operationResult, object entity)
        {
            return operationResult.Ok;
        }

        public virtual bool AfterUpdate(ZOperationResult operationResult, object entity)
        {
            return operationResult.Ok;
        }

        #endregion Triggers
    }
}