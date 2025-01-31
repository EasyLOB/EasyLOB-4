using Northwind.Data;
using EasyLOB;
using System.Linq;

namespace Northwind.Persistence
{
    public class NorthwindCategoryRepositoryLINQ2DB : NorthwindGenericRepositoryLINQ2DB<Category>
    {
        #region Methods

        public NorthwindCategoryRepositoryLINQ2DB(INorthwindUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public override IQueryable<Category> Join(IQueryable<Category> query)
        {
            return
                from category in query
                select new Category
                {
                    CategoryId = category.CategoryId,
                    CategoryName = category.CategoryName,
                    Description = category.Description,
                    Picture = category.Picture
                };
        }

        #endregion Methods
    }
}

