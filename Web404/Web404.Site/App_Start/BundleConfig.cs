using System.Web;
using System.Web.Optimization;

namespace Web404.Site.App_Start
{
    public class BundleConfig
    {
           // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/default")
				.Include(
					"~/Scripts/d3.v3.js",
					"~/Scripts/site.js",
					"~/Scripts/bootstrap.js",
					"~/Scripts/rainbow.js",
					"~/Scripts/language/javascript.js",
					"~/Scripts/language/csharp.js",
					"~/Scripts/language/html.js"
				));

            bundles.Add(
				new StyleBundle("~/Content/Styles")
					.Include("~/Content/post.css")
					.Include("~/Content/bootstrap.css")
					.Include("~/Content/site.css")
					.Include("~/Content/rainbow.css")
				);

		}
    }
}