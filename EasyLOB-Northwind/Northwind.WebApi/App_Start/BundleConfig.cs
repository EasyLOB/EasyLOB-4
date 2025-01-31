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
            //BundleTable.EnableOptimizations = true;

            // CSS

            bundles.Add(new StyleBundle("~/content/z-css.css")
                .Include("~/Content/bootstrap.css") // .css + .min.css
                .Include("~/Content/bootstrap-theme.css") // .css + .min.css
            );

            // Responsive Layout
            // https://help.syncfusion.com/aspnetmvc/menu/responsive-layout

            bundles.Add(new StyleBundle("~/content/z-syncfusion.css")
                .Include("~/Content/ej/web/ej.widgets.core.min.css") // .min.css
                .Include("~/Content/ej/web/responsive-css/ej.responsive.css") // .css
                .Include("~/Content/ej/web/responsive-css/ejgrid.responsive.css") // .css
            );

            bundles.Add(new StyleBundle("~/content/z-syncfusion-theme.css")
                .Include("~/Content/ej/web/ej.widgets.core.bootstrap.min.css") // .min.css
                .Include("~/Content/ej/web/bootstrap-theme/ej.theme.min.css") // .min.css
            );

            bundles.Add(new StyleBundle("~/content/z-easylob.css")
                .Include("~/Content/easylob/easylob.css")
            );

            // JavaScript

            // Bootstrap

            bundle = new Bundle("~/scripts/z-bootstrap.js");
            bundle.Orderer = new AsIsBundleOrderer();
            bundle
                .Include("~/Scripts/bootstrap.js") // .js + .min.js
                .Include("~/Scripts/respond.js") // .js + .min.js
                .Include("~/Scripts/respond.matchmedia.addListener.js"); // .js + .min.js
            bundles.Add(bundle);

            // jQuery

            bundle = new Bundle("~/scripts/z-jquery.js");
            bundle.Orderer = new AsIsBundleOrderer();
            bundle
                // 1st
                .Include("~/Scripts/jquery-{version}.js") // .js + .min.js
                .Include("~/Scripts/jquery.easing.{version}.js")
                // 2nd
                .Include("~/Scripts/jquery.validate.js") // .js + .min.js
                .Include("~/Scripts/jquery.validate.unobtrusive.js") // .js + .min.js
                // 3rd
                .Include("~/Scripts/globalize/globalize.js")
                .Include("~/Scripts/globalize/cultures/globalize.culture.en-US.js")
                .Include("~/Scripts/globalize/cultures/globalize.culture.pt-BR.js")
                // Readonly.js
                // https://github.com/haggen/readonly
                .Include("~/Scripts/easylob/readonly.js")
                // jQuery.TabStop
                // https://github.com/HoffmannP/jquery.tabstop
                .Include("~/Scripts/easylob/jquery.tabstop.min.js");
            bundles.Add(bundle);

            // jQuery AJAX

            bundles.Add(new ScriptBundle("~/scripts/z-jquery-ajax.js")
                .Include("~/Scripts/jquery.unobtrusive-ajax.js") // .js + .min.js
            );

            // Modernizr

            bundles.Add(new ScriptBundle("~/scripts/z-modernizr.js")
                .Include("~/Scripts/modernizr-{version}.js")
            );

            // Syncfusion

            bundle = new Bundle("~/scripts/z-syncfusion.js");
            bundle.Orderer = new AsIsBundleOrderer();
            bundle
                // http://www.jsviews.com/#download
                .Include("~/Scripts/easylob/ej/jsrender.js") // .js + .min.js
                .Include("~/Scripts/ej/web/ej.web.all.min.js")
                .Include("~/Scripts/ej/common/ej.globalize.min.js")
                .Include("~/Scripts/ej/common/ej.unobtrusive.min.js")
                // en-US
                .Include("~/Scripts/ej/i18n/ej.culture.en-US.min.js")
                .Include("~/Scripts/easylob/ej/l10n/ej.datepicker.localetexts.en-US.js")
                .Include("~/Scripts/easylob/ej/l10n/ej.datetimepicker.localetexts.en-US.js")
                .Include("~/Scripts/easylob/ej/l10n/ej.excelfilter.localetexts.en-US.js")
                .Include("~/Scripts/easylob/ej/l10n/ej.grid.localetexts.en-US.js")
                .Include("~/Scripts/easylob/ej/l10n/ej.pager.localetexts.en-US.js")
                .Include("~/Scripts/easylob/ej/l10n/ej.reportviewer.localetexts.en-US.js")
                .Include("~/Scripts/easylob/ej/l10n/ej.uploadbox.localetexts.en-US.js")
                // pt-BR
                .Include("~/Scripts/easylob/ej/i18n/ej.culture.pt-BR.js") // .js + .min.js
                .Include("~/Scripts/easylob/ej/l10n/ej.datepicker.localetexts.pt-BR.js")
                .Include("~/Scripts/easylob/ej/l10n/ej.datetimepicker.localetexts.pt-BR.js")
                .Include("~/Scripts/easylob/ej/l10n/ej.excelfilter.localetexts.pt-BR.js")
                .Include("~/Scripts/easylob/ej/l10n/ej.grid.localetexts.pt-BR.js")
                .Include("~/Scripts/easylob/ej/l10n/ej.pager.localetexts.pt-BR.js")
                .Include("~/Scripts/easylob/ej/l10n/ej.reportviewer.localetexts.pt-BR.js")
                .Include("~/Scripts/easylob/ej/l10n/ej.uploadbox.localetexts.pt-BR.js");
            bundles.Add(bundle);

            // EasyLOB

            bundle = new Bundle("~/scripts/z-easylob.js");
            bundle.Orderer = new AsIsBundleOrderer();
            bundle
                .Include("~/Scripts/easylob/easylob.js")
                .Include("~/Scripts/easylob/easylob.dictionary.js")
                .Include("~/Scripts/easylob/easylob.syncfusion.js")
                .Include("~/Scripts/easylob/jquery.validate.globalize.js");
            bundles.Add(bundle);
        }
    }
}
