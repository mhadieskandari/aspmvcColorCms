using System.Web;
using System.Web.Optimization;

namespace CMS_Golbarg
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/DataTables/jquery.dataTables.js",
                        "~/Scripts/bootbox.js",
                        "~/Scripts/MdBootstrapPersianDateTimePicker/jquery.Bootstrap-PersianDateTimePicker.js",
                        "~/Scripts/MdBootstrapPersianDateTimePicker/jalaali.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/bootstrap-theme.css",
                      "~/Content/datatables/css/jquery.dataTables.css",
                      "~/Content/site.css",
                      "~/Content/MdBootstrapPersianDateTimePicker/jquery.Bootstrap-PersianDateTimePicker.css"));




            bundles.Add(new ScriptBundle("~/bundles/greatness").Include(
                      "~/Scripts/greatness_theme/jquery.js",
                      "~/Scripts/greatness_theme/jquery.easing.{version}.js",
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/greatness_theme/jquery.waypoints.js",
                      "~/Scripts/greatness_theme/owl.carousel.js",
                      "~/Scripts/greatness_theme/jquery.countTo.js",
                      "~/Scripts/greatness_theme/jquery.magnific-popup.js",
                      "~/Scripts/greatness_theme/magnific-popup-options.js",
                      "~/Scripts/greatness_theme/main.js"));


            bundles.Add(new StyleBundle("~/greatness/css").Include(
                     "~/Content/greatness_theme/animate.css",
                     "~/Content/greatness_theme/icomoon.css",
                     "~/Content/bootstrap.css",
                     "~/Content/greatness_theme/magnific-popup.css",
                     "~/Content/greatness_theme/owl.carousel.css",
                     "~/Content/greatness_theme/owl.theme.default.css",
                     "~/Content/greatness_theme/raleway.css",
                     "~/Content/greatness_theme/style.css"));





        }
    }
}
