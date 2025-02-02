using EasyLOB.Environment;
using System.Web.Optimization;

namespace EasyLOB
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            Bundle bundle;

            // Force Bundles in Debug Mode
            BundleTable.EnableOptimizations = true; // Bootstrap 4

            // CSS

            bundles.Add(new StyleBundle("~/content/z-css-4.css") // Bootstrap 4
                .Include("~/Content/bootstrap.css") // .css + .min.css
            );

            // Responsive Layout
            // https://help.syncfusion.com/aspnetmvc/menu/responsive-layout

            bundles.Add(new StyleBundle("~/content/z-syncfusion.css")
                .Include("~/Content/ej2/bootstrap.css")
                //.Include("~/Content/ej2/bootstrap4.css")
                //.Include("~/Content/ej2/fabric.css")
                //.Include("~/Content/ej2/highcontrast.css")
                //.Include("~/Content/ej2/material.css")
            );

            bundles.Add(new StyleBundle("~/content/z-easylob.css")
                .Include("~/Content/easylob/easylob.ej2.css")
                .Include("~/Content/easylob/easylob.ej2.syncfusion.bootstrap.css")
                //.Include("~/Content/easylob/easylob.ej2.syncfusion.bootstrap4.css")
                //.Include("~/Content/easylob/easylob.ej2.syncfusion.fabric.css")
                //.Include("~/Content/easylob/easylob.ej2.syncfusion.highcontrast.css")
                //.Include("~/Content/easylob/easylob.ej2.syncfusion.material.css")
            );

            // JavaScript

            // jQuery

            bundle = new Bundle("~/scripts/z-jquery.js");
            bundle.Orderer = new AsIsBundleOrderer();
            bundle
                .Include("~/Scripts/jquery-3.5.1.js") // .js + .min.js
                .Include("~/Scripts/jquery.easing.1.3.js")
                // Readonly.js
                // https://github.com/haggen/readonly
                .Include("~/Scripts/easylob/readonly.js")
                // jQuery.TabStop
                // https://github.com/HoffmannP/jquery.tabstop
                .Include("~/Scripts/easylob/jquery.tabstop.min.js");
            bundles.Add(bundle);

            // jQuery Globalize
            // Welcome to Globalize · So What'cha Want
            // http://johnnyreilly.github.io/globalize-so-what-cha-want

            bundle = new Bundle("~/scripts/z-globalize.js");
            bundle.Orderer = new AsIsBundleOrderer();
            bundle
                // CLDR
                .Include("~/Scripts/cldr.js")
                .Include("~/Scripts/cldr/event.js")
                .Include("~/Scripts/cldr/supplemental.js")
                .Include("~/Scripts/cldr/unresolved.js")
                // Globalize
                .Include("~/Scripts/globalize.js")
                .Include("~/Scripts/globalize/number.js")
                .Include("~/Scripts/globalize/plural.js")
                .Include("~/Scripts/globalize/currency.js")
                .Include("~/Scripts/globalize/date.js");
                //.Include("~/Scripts/globalize/message.js")
                //.Include("~/Scripts/globalize/relative-time.js")
                //.Include("~/Scripts/globalize/unit.js");
            bundles.Add(bundle);

            // jQuery Validate

            bundle = new Bundle("~/scripts/z-jquery-validate.js");
            bundle.Orderer = new AsIsBundleOrderer();
            bundle
                .Include("~/Scripts/jquery.validate.js") // .js + .min.js
                .Include("~/Scripts/jquery.validate.unobtrusive.js"); // .js + .min.js
            bundles.Add(bundle);

            // jQuery AJAX

            bundles.Add(new ScriptBundle("~/scripts/z-jquery-ajax.js")
                .Include("~/Scripts/jquery.unobtrusive-ajax.js") // .js + .min.js
            );

            // Bootstrap

            bundle = new Bundle("~/scripts/z-bootstrap.js");
            bundle.Orderer = new AsIsBundleOrderer();
            bundle
                .Include("~/Scripts/bootstrap.js") // .js + .min.js
                .Include("~/Scripts/respond.js") // .js + .min.js
                .Include("~/Scripts/respond.matchmedia.addListener.js"); // .js + .min.js
            bundles.Add(bundle);

            // Modernizr

            bundles.Add(new ScriptBundle("~/scripts/z-modernizr.js")
                .Include("~/Scripts/modernizr-{version}.js")
            );

            // Syncfusion

            bundle = new Bundle("~/scripts/z-syncfusion.js");
            bundle.Orderer = new AsIsBundleOrderer();
            bundle
                .Include("~/Scripts/ej2/ej2.min.js");
            bundles.Add(bundle);

            // EasyLOB

            bundle = new Bundle("~/scripts/z-easylob.js");
            bundle.Orderer = new AsIsBundleOrderer();
            bundle
                .Include("~/Scripts/easylob/easylob.ej2.js")
                .Include("~/Scripts/easylob/easylob.ej2.dictionary.js")
                .Include("~/Scripts/easylob/easylob.ej2.syncfusion.js");
            bundles.Add(bundle);
        }
    }
}
