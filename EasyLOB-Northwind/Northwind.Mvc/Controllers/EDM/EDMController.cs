using EasyLOB.Extensions.Edm;
using EasyLOB.Library;
using System.Web.Mvc;

namespace EasyLOB.Mvc
{
    [Authorize]
    public class EDMController : Controller
    {
        #region Properties

        public IEdmManager EDMManager;

        #endregion Properties

        #region Methods

        public EDMController(IEdmManager edmManager)
        {
            EDMManager = edmManager;
        }

        [HttpGet]
        public ActionResult Read(string entityName, int id, string acronym)
        {            
            ZFileTypes fileType = EasyLOBHelper.GetFileType(acronym);
            byte[] file = EDMManager.ReadFile(entityName, id, fileType);
            string extension = EasyLOBHelper.GetFileExtension(fileType);

            return File(file, EasyLOBHelper.GetContentType(fileType), entityName + "-" + id.ToString().Trim() + extension);
        }

        #endregion Methods
    }
}