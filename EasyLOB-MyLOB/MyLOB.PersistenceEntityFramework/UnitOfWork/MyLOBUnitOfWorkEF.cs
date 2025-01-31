using EasyLOB;
using EasyLOB.Persistence;

namespace MyLOB.Persistence
{
    public partial class MyLOBUnitOfWorkEF : UnitOfWorkEF, IMyLOBUnitOfWork
    {
        #region Methods

        public MyLOBUnitOfWorkEF(IAuthenticationManager authenticationManager)
            : base(new MyLOBDbContext(), authenticationManager)
        {
            Domain = "MyLOB";

            //MyLOBDbContext context = (MyLOBDbContext)base.context;
        }

        public override IGenericRepository<TEntity> GetRepository<TEntity>()
        {
            if (!Repositories.Keys.Contains(typeof(TEntity)))
            {
                var repository = new MyLOBGenericRepositoryEF<TEntity>(this);
                Repositories.Add(typeof(TEntity), repository);
            }

            return Repositories[typeof(TEntity)] as IGenericRepository<TEntity>;
        }
        
        #endregion Methods
    }
}

