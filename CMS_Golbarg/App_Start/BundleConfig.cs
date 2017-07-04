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

            bundles.Add(new StyleBundle("~/adminlte_rtl/css").Include(                      
                      "~/Content/adminlte-rtl/bootstrap.css",
                      "~/Content/AdminLTE.css",
                      "~/Content/font-awesome.css",
                      "~/Content/ionicons.css",
                      "~/Content/skins/_all-skins.css",
                      "~/plugins/iCheck/flat/blue.css",
                      "~/plugins/morris/morris.css",
                      "~/plugins/jvectormap/jquery-jvectormap-1.2.2.css",
                      //"~/plugins/datepicker/datepicker3.css",
                      "~/plugins/daterangepicker/daterangepicker-bs3.css",
                      "~/plugins/bootstrap-jalali-datepicker/bootstrap-datepicker.css",
                      "~/plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.css",
                      "~/Content/mysite.css",
                      "~/Content/bootstrap-switch/bootstrap3/bootstrap-switch.css",
                      "~/plugins/datatables/dataTables.bootstrap.css",
                      "~/plugins/SmartWizard-master/css/smart_wizard.css",
                      "~/plugins/SmartWizard-master/css/smart_wizard_theme_arrows.css",
                      "~/plugins/SmartWizard-master/css/smart_wizard_theme_circles.css",
                      "~/plugins/SmartWizard-master/css/smart_wizard_theme_dots.css"
                      ));
            

            bundles.Add(new ScriptBundle("~/bundles/adminlte-rtl").Include(
                "~/Scripts/bootstrap.js",
                "~/Scripts/adminlte-rtl/raphael.js",
                //"~/plugins/morris/morris.js",
                "~/plugins/sparkline/jquery.sparkline.js",
                "~/plugins/jvectormap/jquery-jvectormap-1.2.2.js",
                "~/plugins/jvectormap/jquery-jvectormap-world-mill-en.js",
                "~/plugins/knob/jquery.knob.js",
                "~/Scripts/adminlte-rtl/moment.js",
                "~/plugins/daterangepicker/daterangepicker.js",
                //"~/plugins/datepicker/bootstrap-datepicker.js",
                "~/plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.all.js",
                "~/plugins/slimScroll/jquery.slimscroll.min.js",
                "~/plugins/fastclick/fastclick.js",
                "~/Scripts/adminlte-rtl/app.js",
                //"~/Scripts/adminlte-rtl/pages/dashboard.js",
                "~/Scripts/adminlte-rtl/demo.js",
                "~/Scripts/bootstrap-switch.js",
                "~/Scripts/bootbox.js",
                //"~/Scripts/MdBootstrapPersianDateTimePicker/jalaali.js",
                //"~/Scripts/MdBootstrapPersianDateTimePicker/PersianDateTimePicker.js",
                "~/plugins/bootstrap-jalali-datepicker/bootstrap-datepicker.js",
                "~/plugins/bootstrap-jalali-datepicker/bootstrap-datepicker.fa.js",
                "~/plugins/dataTables/dataTables.bootstrap.js",
                "~/Scripts/dataTables/jquery.dataTables.js",
                "~/plugins/SmartWizard-master/js/jquery.smartWizard.js"
            ));
            bundles.Add(new ScriptBundle("~/bundles/bootbox").Include(
                    "~/Scripts/bootbox.js"
                    ));

            bundles.Add(new ScriptBundle("~/bundles/JformSlider").Include(
                "~/Scripts/jFormslider.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/adminlte-rtl_morris").Include(
                     "~/plugins/morris/morris.js",
                     "~/Scripts/adminlte-rtl/pages/dashboard.js"
                     ));

            bundles.Add(new ScriptBundle("~/bundles/adminlte-rtl_dataTables").Include(
                     "~/plugins/dataTables/dataTables.bootstrap.js",
                     "~/Scripts/dataTables/jquery.dataTables.js"
                     ));

            bundles.Add(new ScriptBundle("~/bundles/uiandjquery").Include(
                        "~/plugins/jQuery/jQuery-2.2.0.js",
                      "~/Scripts/adminlte-rtl/jquery-ui.js"));

            bundles.Add(new ScriptBundle("~/bundles/mdpersiandate").Include(
                        "~/Scripts/MdBootstrapPersianDateTimePicker/jalaali.js",
                        "~/Scripts/MdBootstrapPersianDateTimePicker/PersianDateTimePicker.js"
                        ));

            bundles.Add(new StyleBundle("~/Content/mdpersiandate").Include(
                     "~/Content/MdBootstrapPersianDateTimePicker/PersianDateTimePicker.css"));

        }
    }
}
