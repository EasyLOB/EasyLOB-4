using EasyLOB;

namespace Northwind.Data
{
    public partial class CategoryViewModel
    {
        #region Methods

        // !!!
        public override bool Validate(ZOperationResult operationResult) // IZValidatableObject
        {           
            return PresentationHelper.ZViewModelValidate(operationResult, typeof(Category), this);
        }

        #endregion Methods
    }
}
