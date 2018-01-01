using System.Web;
using System.Web.Optimization;

namespace ControlB
{
    public class BundleConfig
    {
        // Para obtener más información sobre Bundles, visite http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            // css de componentes Kendo MVC
            bundles.Add(new StyleBundle("~/bundles/kendo/css").Include(
                    "~/Content/kendo/2016.1.112/kendo.common-bootstrap.min.css",
                    "~/Content/kendo/2016.1.112/kendo.mobile.all.min.css",
                      "~/Content/kendo/2016.1.112/kendo.dataviz.min.css",
                      "~/Content/kendo/2016.1.112/kendo.bootstrap.min.css",
                      "~/Content/kendo/2016.1.112/kendo.dataviz.bootstrap.min.css"
                    ));

            // css básico bootstrap
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css"
                      ));

            // css de la plantilla
            bundles.Add(new StyleBundle("~/Css/plantillaBasica").Include(
                      "~/Content/admindesigns/assets/fonts/css.css",
                      "~/Content/admindesigns/assets/skin/default_skin/css/theme.css",
                      "~/Content/admindesigns/assets/admin-tools/admin-forms/css/admin-forms.css",
                      "~/Content/admindesigns/assets/admin-tools/admin-plugins/admin-modal/adminmodal.css",
                      "~/Content/admindesigns/assets/fonts/icomoon/icomoon.css",
                      "~/Content/admindesigns/terceros/sweetalert/dist/sweetalert.css",
                      "~/Content/admindesigns/personalScripts/misEstilos.css"
                      ));

            // Scripts genericos
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery.validate.min.js",
                "~/Scripts/jquery.unobtrusive-ajax.min.js",
                "~/Scripts/jquery-{version}.js"
                        ));

            // Scripts de la plantilla
            bundles.Add(new ScriptBundle("~/JS/plantillaBasica").Include(
             "~/Content/admindesigns/assets/js/main.js",
             "~/Content/admindesigns/assets/js/demo.js"
             , "~/Content/admindesigns/terceros/sweetalert/dist/sweetalert.min.js"
                   ));

            // Scripts kendo
            bundles.Add(new ScriptBundle("~/bundles/kendo/js").Include(
                      "~/Scripts/kendo/2016.1.112/kendo.custom.2016-06-23-0247.min.js",
                      "~/Scripts/kendo/2016.1.112/kendo.aspnetmvc.min.js",

                      //"~/Scripts/kendo/2016.1.112/cultures/kendo.culture.es.modified.min.js",
                      "~/Scripts/kendo/2016.1.112/cultures/kendo.culture.es-CO.min.js",
                      "~/Scripts/kendo/2016.1.112/messages/kendo.messages.es-ES.min.js",
                      "~/Scripts/kendo/2016.1.112/messages/kendo.messages.es-ES.modified.min.js",
                      
                      "~/Scripts/kendo.modernizr.custom.js",

                       "~/Scripts/kendo/2016.1.112/kendo.drawing.min.js",
                      "~/Scripts/kendo/2016.1.112/kendo.dataviz.core.min.js",
                      "~/Scripts/kendo/2016.1.112/kendo.dataviz.themes.min.js",
                      "~/Scripts/kendo/2016.1.112/kendo.dataviz.chart.min.js"
                      ));

        }
    }
}
