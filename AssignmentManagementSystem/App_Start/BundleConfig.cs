using System.Web;
using System.Web.Optimization;

namespace AssignmentManagementSystem
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.bundle.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Adminlte/plugins/fontawesome-free/css/all.min.css",
                      "~/Adminlte/plugins/tempusdominus-bootstrap-4/css/tempusdominus-bootstrap-4.min.css",
                      "~/Adminlte/plugins/icheck-bootstrap/icheck-bootstrap.min.css",
                      "~/Adminlte/plugins/jqvmap/jqvmap.min.css",
                      "~/Adminlte/plugins/jqvmap/jqvmap.min.css",
                      "~/Adminlte/plugins/overlayScrollbars/css/OverlayScrollbars.min.css",
                      "~/Adminlte/plugins/daterangepicker/daterangepicker.css",
                      "~/Adminlte/plugins/summernote/summernote-bs4.css",
                      "~/Adminlte/css/adminlte.min.css",
                      "~/Content/site.css"));
            bundles.Add(new ScriptBundle("~/Adminlte/js").Include(
           "~/Adminlte/js/adminlte.min.js",
           "~/Adminlte/plugins/bootstrap/js/bootstrap.bundle.min.js",
           "~/Adminlte/plugins/chart.js/Chart.min.js",
           "~/Adminlte/plugins/sparklines/sparkline.js",
           "~/Adminlte/plugins/jqvmap/jquery.vmap.min.js",
           "~/Adminlte/plugins/jqvmap/maps/jquery.vmap.usa.js",
           "~/Adminlte/plugins/jquery-knob/jquery.knob.min.js",
           "~/Adminlte/plugins/moment/moment.min.js",
           "~/Adminlte/plugins/daterangepicker/daterangepicker.js",
           "~/Adminlte/plugins/tempusdominus-bootstrap-4/js/tempusdominus-bootstrap-4.min.js",
           "~/Adminlte/plugins/summernote/summernote-bs4.min.js",
           "~/Adminlte/plugins/overlayScrollbars/js/jquery.overlayScrollbars.min.js"));
        }
    }
}
