using EasyLOB.Data;
using EasyLOB.Library;
using EasyLOB.Persistence;
using Raven.Client;
using Raven.Client.Document;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

// Install-Package RavenDB.Client

// Working with document identifiers
// https://ravendb.net/docs/article-page/3.0/csharp/client-api/document-identifiers/working-with-document-ids

// Global identifier generation conventions
// https://ravendb.net/docs/article-page/3.0/csharp/client-api/configuration/conventions/identifier-generation/global

// Working with document identifiers
// https://ravendb.net/docs/article-page/3.0/csharp/client-api/document-identifiers/working-with-document-ids#identity-ids

namespace EasyLOB.Persistence
{
    public abstract class UnitOfWorkRavenDB : IUnitOfWork
    {
        #region Properties

        public IAuthenticationManager AuthenticationManager { get; }

        public ZDatabaseLogger DatabaseLogger { get; set; }

        public ZDBMS DBMS
        {
            get { return ZDBMS.RavenDB; }
        }

        public string Domain { get; protected set; }

        public IDictionary<Type, object> Repositories { get; }

        #endregion Properties

        #region Properties RavenDB

        public IDocumentStore DocumentStore { get; protected set; }

        public IDocumentSession DocumentSession { get; protected set; }

        #endregion Properties RavenDB

        #region Methods

        public UnitOfWorkRavenDB(string url, string databaseName,
            IAuthenticationManager authenticationManager)
        {
            DocumentStore = new DocumentStore
            {
                Url = url,
                DefaultDatabase = databaseName
            };
            AuthenticationManager = authenticationManager;

            // Key = entity/1
            //DocumentStore.Conventions
            //    .DocumentKeyGenerator = (dbname, commands, entity) => _documentStore.Conventions.GetTypeTagName(entity.GetType()) + "/";

            // Identity = Id
            //DocumentStore.Conventions
            //    .FindIdentityProperty = property => property.Name == "Id";

            // entity/1 instead of entities/1
            DocumentStore.Conventions
                .FindTypeTagName = type => type.Name;

            DocumentStore.Initialize();

            DocumentSession = DocumentStore.OpenSession();

            DatabaseLogger = ZDatabaseLogger.None;
            Domain = "";
            Repositories = new Dictionary<Type, object>();
        }

        public virtual void Dispose()
        {
        }

        public virtual bool BeginTransaction(ZOperationResult operationResult, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            return operationResult.Ok;
        }

        public virtual bool CommitTransaction(ZOperationResult operationResult)
        {
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
            return DocumentSession.Query<TEntity>();
        }

        public virtual IGenericRepository<TEntity> GetRepository<TEntity>()
            where TEntity : class, IZDataModel
        {
            throw new NotImplementedException("abstract class RavenDB UnitOfWork.GetRepository()");
        }

        public virtual bool RollbackTransaction(ZOperationResult operationResult)
        {
            return operationResult.Ok;
        }

        public virtual bool Save(ZOperationResult operationResult)
        {
            try
            {
                DocumentSession.SaveChanges();
            }
            catch (Exception exception)
            {
                operationResult.ParseExceptionRavenDB(exception);
            }

            return operationResult.Ok;
        }

        public void SetIsolationLevel(IsolationLevel isolationLevel)
        {
            //throw new NotImplementedException("abstract class MongoDB UnitOfWork.SetIsolationLevel()");
        }

        #endregion Methods

        #region Methods SQL

        public virtual int SQLCommand(string sql)
        {
            throw new NotSupportedException();
        }

        public virtual IEnumerable<TEntity> SQLQuery<TEntity>(string sql)
        {
            throw new NotSupportedException();
        }

        #endregion Methods SQL

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