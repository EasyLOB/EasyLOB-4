using EasyLOB.Identity.Resources;
using EasyLOB.Library;
using System.IO;
using System.Web.Mvc;

namespace EasyLOB.Mvc
{
    public class BaseMvcController : BaseMvc
    {
        #region Properties

        protected IAuthorizationManager AuthorizationManager { get; }

        #endregion Properties

        #region Methods

        public BaseMvcController(IAuthorizationManager authorizationManager)
        {
            AuthorizationManager = authorizationManager;
        }

        [HttpGet]
        public virtual ActionResult Download(string filePath)
        {
            string extension = System.IO.Path.GetExtension(filePath);
            ZFileTypes fileType = EasyLOBHelper.GetFileType(extension);

            return File(filePath, EasyLOBHelper.GetContentType(fileType), Path.GetFileName(filePath));
        }

        #endregion Methods

        #region Methods Authentication

        protected virtual bool IsUserAdministrator()
        {
            return AuthorizationManager.AuthenticationManager.IsAdministrator;
        }

        protected virtual bool IsUserInRole(string role)
        {
            return AuthorizationManager.AuthenticationManager.Roles.Contains(role);
        }

        protected virtual bool IsUserInRole(ZOperationResult operationResult, string role)
        {
            bool result = AuthorizationManager.AuthenticationManager.Roles.Contains(role);
            operationResult.AddOperationWarning("",
                string.Format(SecurityIdentityResources.OperationAuthorizedRole, role));

            return result;
        }

        #endregion Methods Authentication
    }
}