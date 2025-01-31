using System.Web.Mvc.Ajax;

namespace EasyLOB
{
    public static partial class AppHelper
    {
        #region Properties

        private static AjaxOptions _ajaxOptions;

        public static AjaxOptions AjaxOptions
        {
            get
            {
                if (_ajaxOptions == null)
                {
                    _ajaxOptions = new AjaxOptions
                    {
                        HttpMethod = "POST",
                        InsertionMode = InsertionMode.Replace,
                        OnFailure = "zAjaxFailure",
                        OnSuccess = "zAjaxSuccess",
                        UpdateTargetId = "Ajax"
                    };
                }

                return _ajaxOptions;
            }
        }

        #endregion Properties

        #region Methods

        public static void Login()
        {
        }

        public static void Logout()
        {
            EasyLOBHelper.GetService<IEnvironmentManager>().SessionAbandon();
        }

        public static void Title(out string documentTitle, out string pageTitle,
            string controller, string action, string task)
        {
            documentTitle = AppName +
                (!string.IsNullOrEmpty(AppVersion) ? " " + AppVersion : "") +
                (!string.IsNullOrEmpty(task) ? AppDefaults.TitleSeparator + task : "");
            pageTitle = task;
        }

        public static void Title(out string documentTitle, out string pageTitle,
            string entitySingular, string entityPlural,
            string action, string actionResource,
            bool isMasterDetail = false)
        {
            documentTitle = "";
            pageTitle = "";

            if (action == "search")
            {
                documentTitle = entityPlural;
                if (!isMasterDetail)
                {
                    pageTitle = entityPlural;
                }
            }
            else
            {
                documentTitle = entitySingular + AppDefaults.TitleSeparator + actionResource;
                pageTitle = documentTitle;
            }

            documentTitle = AppName +
                (!string.IsNullOrEmpty(AppVersion) ? " " + AppVersion : "") +
                (!string.IsNullOrEmpty(documentTitle) ? AppDefaults.TitleSeparator + documentTitle : "");
        }

        #endregion Methods
    }
}