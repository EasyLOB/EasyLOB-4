using System.Web.Http;

namespace EasyLOB
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            // !!!

            // Syncfusion Report Viewer
            config.Routes.MapHttpRoute(
                name: "SyncfusionReportViewer",
                routeTemplate: "syncfusion/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional });
            //config.Routes.MapHttpRoute(
            //    name: "SyncfusionReportViewerRDL",
            //    routeTemplate: "api/{controller}/{action}/{id}",
            //    constraints: new { controller = @"^RDL" },
            //    defaults: new { id = RouteParameter.Optional });
            //config.Routes.MapHttpRoute(
            //    name: "SyncfusionReportViewerRDL",
            //    routeTemplate: "api/rdlapi/{action}/{id}",
            //    defaults: new { id = RouteParameter.Optional });
            //config.Routes.MapHttpRoute(
            //    name: "SyncfusionReportViewerRDLC",
            //    routeTemplate: "api/rdlcapi/{action}/{id}",
            //    defaults: new { id = RouteParameter.Optional });

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
