using EasyLOB;
using EasyLOB.Persistence;

namespace Northwind.Persistence
{
    public partial class NorthwindUnitOfWorkEF : UnitOfWorkEF, INorthwindUnitOfWork
    {
        #region Methods

        public NorthwindUnitOfWorkEF(IAuthenticationManager authenticationManager)
            : base(new NorthwindDbContext(), authenticationManager)
        {
            Domain = "Northwind";

            //NorthwindDbContext context = (NorthwindDbContext)base.context;
        }

        public override IGenericRepository<TEntity> GetRepository<TEntity>()
        {
            if (!Repositories.Keys.Contains(typeof(TEntity)))
            {
                var repository = new NorthwindGenericRepositoryEF<TEntity>(this);
                Repositories.Add(typeof(TEntity), repository);
            }

            return Repositories[typeof(TEntity)] as IGenericRepository<TEntity>;
        }
        
        #endregion Methods
    }
}

