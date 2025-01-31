namespace EasyLOB.Mvc
{
    public class BaseMvcControllerTask : BaseMvcController
    {
        #region Methods

        public BaseMvcControllerTask(IAuthorizationManager authorizationManager)
            : base(authorizationManager)
        {
        }

        //[HttpGet]
        //public virtual ActionResult Download(string filePath)
        //{
        //    string extension = System.IO.Path.GetExtension(filePath);
        //    ZFileTypes fileType = EasyLOBHelper.GetFileType(extension);

        //    return File(filePath, EasyLOBHelper.GetContentType(fileType), Path.GetFileName(filePath));
        //}

        protected virtual bool IsValid(ZOperationResult operationResult, IZValidatableObject entity)
        {
            entity.Validate(operationResult);

            return base.IsValid(operationResult, entity.GetType().Name);
        }

        #endregion Methods

        #region Methods Authorization

        protected bool IsTask(string task)
        {
            ZOperationResult operationResult = new ZOperationResult();

            return IsTask(task, operationResult);
        }

        protected bool IsTask(string task, ZOperationResult operationResult)
        {
            return AuthorizationManager.IsTask("", task, operationResult);
        }

        #endregion Methods Authorization
    }
}