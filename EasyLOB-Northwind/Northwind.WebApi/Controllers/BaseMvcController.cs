using EasyLOB.Identity.Resources;
using EasyLOB.Library;
using Syncfusion.EJ.Export;
using Syncfusion.JavaScript.Models;
using Syncfusion.XlsIO;
using System.Collections;
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
            : base(authorizationManager.AuthenticationManager)
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

        #region Methods Syncfusion

        protected void ExportToExcel(string gridModel, IEnumerable data, string theme, string fileName)
        {
            GridProperties gridProperties = SyncfusionGrid.ModelToObject(gridModel);

            ExcelExport export = new ExcelExport();
            IWorkbook excel = export.Export(gridProperties, data, fileName, ExcelVersion.Excel2013, false, false, theme, true);
            excel.ActiveSheet.DeleteRow(1, 1);
            excel.SaveAs(fileName, ExcelSaveType.SaveAsXLS, System.Web.HttpContext.Current.Response, ExcelDownloadType.Open);
            //excel.SaveAs(fileName, ExcelSaveType.SaveAsXLS, Controller.Response, ExcelDownloadType.Open);
        }

        #endregion Methods Syncfusion
    }
}