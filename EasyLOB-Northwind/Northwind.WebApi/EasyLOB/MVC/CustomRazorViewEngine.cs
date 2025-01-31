using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

// A Look at the Razor View Engine in ASP.NET MVC
// Dino Esposito
// https://www.simple-talk.com/dotnet/asp.net/a-look-at-the-razor-view-engine-in-asp.net-mvc

/*
As you can see, locations are not fully qualified paths but contain up to three placeholders.
The placeholder {0} refers to the name of the view, as it is being invoked from the controller method.
The placeholder {1} refers to the controller name as it is used in the URL.
Finally, the controller {2}, if specified, refers to the area name.

AreaMasterLocationFormats
    ~/Areas/{2}/Views/{1}/{0}.cshtml
    ~/Areas/{2}/Views/Shared/{0}.cshtml
    ~/Areas/{2}/Views/{1}/{0}.vbhtml
    ~/Areas/{2}/Views/Shared/{0}.vbhtml

AreaPartialViewLocationFormats
    ~/Areas/{2}/Views/{1}/{0}.cshtml
    ~/Areas/{2}/Views/{1}/{0}.vbhtml
    ~/Areas/{2}/Views/Shared/{0}.cshtml
    ~/Areas/{2}/Views/Shared/{0}.vbhtml

AreaViewLocationFormats
    ~/Areas/{2}/Views/{1}/{0}.cshtml
    ~/Areas/{2}/Views/{1}/{0}.vbhtml
    ~/Areas/{2}/Views/Shared/{0}.cshtml
    ~/Areas/{2}/Views/Shared/{0}.vbhtml

MasterLocationFormats
    ~/Views/{1}/{0}.cshtml
    ~/Views/Shared/{0}.cshtml
    ~/Views/{1}/{0}.vbhtml
    ~/Views/Shared/{0}.vbhtml

PartialViewLocationFormats
    ~/Views/{1}/{0}.cshtml
    ~/Views/{1}/{0}.vbhtml
    ~/Views/Shared/{0}.cshtml
    ~/Views/Shared/{0}.vbhtml

ViewLocationFormats
    ~/Views/{1}/{0}.cshtml
    ~/Views/{1}/{0}.vbhtml
    ~/Views/Shared/{0}.cshtml
    ~/Views/Shared/{0}.vbhtml

FileExtensions
    .cshtml
    .vbhtml
*/

// Adding a Custom Directory to Razor View Engine’s Partial View Locations in ASP.Net MVC3
// Leon Amarant
// http://www.leonamarant.com/2011/02/17/adding-a-custom-directory-to-razor-view-engine-partial-view-locations-in-asp-net-mvc3

namespace EasyLOB
{
    public class CustomRazorViewEngine : RazorViewEngine
    {
        // private static string[] CustomPartialViewLocationFormats = new[] {
        //     "~/Views/" + AppHelper.AppPath + "/{1}/{0}.cshtml",
        //     "~/Views/Shared/" + AppHelper.AppPath + "/{0}.cshtml"
        //};

        // private static string[] CustomViewLocationFormats = new[] {
        //     "~/Views/" + AppHelper.AppPath + "/{1}/{0}.cshtml",
        //     "~/Views/Shared/" + AppHelper.AppPath + "/{0}.cshtml"
        // };

        public CustomRazorViewEngine()
        {
            //base.PartialViewLocationFormats = base.PartialViewLocationFormats.Union(CustomPartialViewLocationFormats).ToArray();
            //base.ViewLocationFormats = base.ViewLocationFormats.Union(CustomViewLocationFormats).ToArray();

            List<string> locations = new List<string>();

            locations.Clear();
            foreach (string path in AppHelper.AppPath)
            {
                locations.Add("~/Views/" + path + "/{1}/{0}.cshtml");
                locations.Add("~/Views/" + path + "/{0}.cshtml");
                //locations.Add("~/Views/Shared/" + path + "/{0}.cshtml");
            }
            base.PartialViewLocationFormats = base.PartialViewLocationFormats.Union(locations.ToArray()).ToArray();

            locations.Clear();
            foreach (string path in AppHelper.AppPath)
            {
                locations.Add("~/Views/" + path + "/{1}/{0}.cshtml");
                locations.Add("~/Views/" + path + "/{0}.cshtml");
                //locations.Add("~/Views/Shared/" + path + "/{0}.cshtml");
            }
            base.ViewLocationFormats = base.ViewLocationFormats.Union(locations.ToArray()).ToArray();
        }
    }
}