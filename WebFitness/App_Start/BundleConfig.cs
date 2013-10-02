using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace WebFitness
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Scripts/admin/base/bootstrap-typeahead.js",
                        "~/Scripts/admin/base/bootstrap.min.js",
                        "~/Scripts/admin/base/bootstrap-wysiwyg.js"));

            bundles.Add(new ScriptBundle("~/bundles/charts").Include(
                        "~/Scripts/admin/base/excanvas.min.js",
                        "~/Scripts/admin/base/jquery.flot.js",
                        "~/Scripts/admin/base/jquery.flot.orderbars.js",
                        "~/Scripts/admin/base/jquery.flot.pie.js",
                        "~/Scripts/admin/base/jquery.flot.resize.js",
                        "~/Scripts/admin/base/jquery.flot.time.js"));

            bundles.Add(new ScriptBundle("~/bundles/calendar").Include(
                        "~/Scripts/admin/base/fullcalendar.js"));

            bundles.Add(new StyleBundle("~/Content/themes/base/avocado").Include(
                        "~/Content/themes/base/avocado.css"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/css/bootstrap-responsive.css",
                        "~/Content/themes/base/css/bootstrap.min.css",
                        "~/Content/themes/base/css/chosen.css",
                        "~/Content/themes/base/css/fullcalendar.css",
                        "~/Content/themes/base/css/photoswipe.css",
                        "~/Content/themes/base/css/prism.css"));

            BundleTable.EnableOptimizations = true;
        }
    }
}