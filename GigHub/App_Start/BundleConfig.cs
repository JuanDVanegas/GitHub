using System.Web.Optimization;

namespace GigHub
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                        "~/Scripts/app/services/attendanceService.js",
                        "~/Scripts/app/controllers/gigsController.js",
                        "~/Scripts/app/services/followingService.js",
                        "~/Scripts/app/controllers/gigDetailsController.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/underscore-min.js",
                        "~/Scripts/moment-with-locales.js",
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/respond.js",
                        "~/Scripts/bootbox.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // para la producción, use la herramienta de compilación disponible en https://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));


            bundles.Add(new ScriptBundle("~/js/kendo").Include(
                "~/Scripts/kendo/jszip.min.js"
                , "~/Scripts/kendo/kendo.all.min.js"
                , "~/Scripts/kendo/kendo.aspnetmvc.min.js"
                , "~/Scripts/kendo/kendo.modernizr.custom.js"
                , "~/Scripts/kendo/cultures/kendo.culture.es-CO.min.js"
            ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/animate.css",
                      "~/Content/kendo/kendo.common-material.css",
                      "~/Content/kendo/kendo.mobile.all.css",
                      "~/Content/kendo/kendo.material.css"));
        }
    }
}
