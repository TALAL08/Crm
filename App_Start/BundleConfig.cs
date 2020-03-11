using System.Web;
using System.Web.Optimization;

namespace Crm
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/lib").Include(
            //             "~/Scripts/jquery-{version}.js",
            //             "~/Scripts/bootstrap.js",
            //             "~/Scripts/respond.js",
            //             "~/Scripts/bootbox.js",
            //             "~/scripts/datatables/jquery.datatables.js",
            //             "~/scripts/datatables/datatables.bootstrap.js",
            //             "~/Scripts/Typeahead.bundle.js",
            //             "~/Scripts/toastr.js"
            //             ));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.validate*"));

            //// Use the development version of Modernizr to develop with and learn from. Then, when you're
            //// ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));



            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/bootstrap.css",
            //          "~/Content/site.css",
            //          "~/content/datatables/css/datatables.bootstrap.css",
            //          "~/Content/Typeahead.css",
            //          "~/Content/toastr.css",
            //          "~/Content/bootstrap-style.css",
            //          "~/css/theme.css"));


            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(

                                    "~/Scripts/jquery-{version}.js",
                                     "~/scripts/datatables/jquery.datatables.js",
                                     "~/Scripts/Typeahead.bundle.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(

                "~/Scripts/bootstrap.js",
                  "~/Scripts/respond.js",
                 "~/Scripts/bootbox.js",
                 "~/scripts/datatables/datatables.bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/Typeahead.css",
                       "~/content/datatables/css/datatables.bootstrap.css",
                      "~/css/theme.css",

                      "~/Content/Site.css"));
        }
    }
}


