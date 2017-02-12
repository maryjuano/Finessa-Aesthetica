using System.Web;
using System.Web.Optimization;

namespace FinessaAesthetica
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/dist/css").Include(
                       "~/dist/css/metro-bootstrap.min.css",
                       "~/dist/css/site-template.css"));

            bundles.Add(new ScriptBundle("~/dist/js").Include(
                     "~/dist/js/jQuery-2.1.4.min.js",
                     "~/dist/js/bootstrap.min.js",
                    "~/dist/js/helpers.js",
                     "~/dist/js/app.js"));
        }
    }
}
