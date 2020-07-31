using System.Web;
using System.Web.Optimization;

namespace PsiSeniorGestaoPessoas.Site
{
    public class BundleConfig
    {
        // Para obter mais informações sobre o agrupamento, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-3.5.1.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.validate.min.js",
                "~/Scripts/jquery.validate.unobtrusive.min.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.bundle.min.js",
                "~/Scripts/bootstrap-select.js",
                "~/Scripts/respond.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/datatables").Include(
                "~/Scripts/DataTables/media/js/jquery.dataTables.min.js",
                "~/Scripts/DataTables/media/js/dataTables.bootstrap4.min.js",
                "~/Scripts/DataTables/extensions/Buttons/js/dataTables.buttons.min.js",
                "~/Scripts/DataTables/extensions/Buttons/js/buttons.flash.min.js",
                       "~/Scripts/jszip.min.js",
                       "~/Scripts/pdfmake.min.js",
                       "~/Scripts/vfs_fonts.js",
                "~/Scripts/DataTables/extensions/Buttons/js/buttons.html5.min.js",
                "~/Scripts/DataTables/extensions/Buttons/js/buttons.print.min.js",
                "~/Scripts/DataTables/dataTables.bootstrap.min.js",
                "~/Scripts/DataTables/extensions/Responsive/jsdataTables.responsive.min.js",
                "~/Scripts/DataTables/extensions/RowGroup/js/dataTables.rowsGroup.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
                "~/Scripts/jquery.maskedinput.min.js",
                "~/Scripts/respond.min.js",
                "~/Scripts/moment.min.js*",
                "~/Scripts/moment-with-locales.min.js",
                "~/Scripts/numeral/numeral.min.js",
                "~/Scripts/DataTables/datetime-moment.js",
                "~/Scripts/jquery.priceformat.min.js",
                "~/Scripts/fontawesome/all.min.js",
                "~/Scripts/site.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/bootstrap-select.min.css",
                "~/Content/fontawesome-all.min.css",
                "~/Content/DataTables/media/css/jquery.dataTables.min.css",
                "~/Content/DataTables/extensions/Buttons/css/buttons.dataTables.min.css",
                "~/Content/site.css"));
        }
    }
}
