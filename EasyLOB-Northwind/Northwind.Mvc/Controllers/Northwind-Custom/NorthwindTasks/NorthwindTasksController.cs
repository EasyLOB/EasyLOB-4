using EasyLOB;
using EasyLOB.Mvc;
using Northwind.Persistence;

namespace Northwind.Mvc
{
    public partial class NorthwindTasksController : BaseMvcControllerTask
    {
        #region Properties

        protected INorthwindUnitOfWork UnitOfWork { get; }

        #endregion Properties

        #region Methods

        public NorthwindTasksController(INorthwindUnitOfWork unitOfWork,
            IAuthorizationManager authorizationManager)
            : base(authorizationManager)
        {
            UnitOfWork = unitOfWork;
        }

        protected override bool IsValid(ZOperationResult operationResult, IZValidatableObject entity)
        {
            bool result = base.IsValid(operationResult, entity);

            if (!result)
            {
                operationResult.Clear(); // Html.BeginForm() + Html.ValidationSummary()
            }

            return result;
        }

        #endregion Methods
    }
}
 