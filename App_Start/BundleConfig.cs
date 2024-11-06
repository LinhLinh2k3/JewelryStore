using System.Web.Optimization;

namespace WebApplication
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //Hỗ trợ CDN
            bundles.UseCdn = true;

            //Bypass những css đã minified (thu gọn)
            bundles.IgnoreList.Clear();

            //=====Thư viện=====//
            ////css
            bundles.Add(new StyleBundle("~/assets/css").Include("~/Content/style.css"));
            bundles.Add(new StyleBundle("~/assets/css/bootstrap", "https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css").Include("~/Content/bootstrap/bootstrap.css"));
            bundles.Add(new StyleBundle("~/assets/css/animate.css", "https://cdnjs.cloudflare.com/ajax/libs/animate.css/4.1.1/animate.min.css").Include("~/Content/animate.css/animate.css"));
            bundles.Add(new StyleBundle("~/assets/css/jquery-ui", "https://cdnjs.cloudflare.com/ajax/libs/jqueryui/1.13.2/themes/base/jquery-ui.min.css").Include("~/Content/jquery-ui/jquery-ui.css"));
            bundles.Add(new StyleBundle("~/assets/css/fontawesome", "https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.2/css/all.min.css").Include("~/Content/fontawesome/css/all.css"));
            bundles.Add(new StyleBundle("~/assets/css/slick-carousel", "https://cdnjs.cloudflare.com/ajax/libs/slick-carousel/1.8.1/slick.css").Include("~/Content/slick-carousel/slick.css"));
            bundles.Add(new StyleBundle("~/assets/css/nice-select", "https://cdnjs.cloudflare.com/ajax/libs/jquery-nice-select/1.1.0/css/nice-select.css").Include("~/Content/jquery-nice-select/css/nice-select.css"));
            bundles.Add(new StyleBundle("~/assets/css/pe-icon-7-stroke", "https://cdn.jsdelivr.net/npm/pixeden-stroke-7-icon@1.2.3/pe-icon-7-stroke/dist/pe-icon-7-stroke.min.css").Include("~/Content/pe-icon-7-stroke/css/pe-icon-7-stroke"));
            bundles.Add(new StyleBundle("~/assets/css/toastr", "https://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/toastr.min.css").Include("~/Content/toastr/toastr.min.css"));

            ////javascript
            bundles.Add(new ScriptBundle("~/assets/js").Include("~/Scripts/main.js"));
            bundles.Add(new ScriptBundle("~/assets/js/bootstrap", "https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js").Include("~/Scripts/bootstrap/bootstrap.js"));
            bundles.Add(new ScriptBundle("~/assets/js/jquery", "https://code.jquery.com/jquery-3.7.1.min.js").Include("~/Scripts/jquery/jquery-{version}.js"));
            bundles.Add(new ScriptBundle("~/assets/js/jquery-ui", "https://cdnjs.cloudflare.com/ajax/libs/jqueryui/1.13.2/jquery-ui.min.js").Include("~/Content/jquery-ui/jquery-ui.js"));
            bundles.Add(new ScriptBundle("~/assets/js/jqueryval", "https://cdnjs.cloudflare.com/ajax/libs/jquery-validate/1.19.5/jquery.validate.min.js").Include("~/Scripts/jqueryval/jquery.validate*"));
            bundles.Add(new ScriptBundle("~/assets/js/modernizr", "https://cdn.jsdelivr.net/npm/modernizr@3.13.0/lib/cli.min.js").Include("~/Scripts/modernizr/lib/cli.js", "~/Scripts/modernizr/lib/build.js", "~/Scripts/modernizr/lib/metadata.js", "~/Scripts/modernizr/lib/options.js"));
            bundles.Add(new ScriptBundle("~/assets/js/slick-carousel", "https://cdnjs.cloudflare.com/ajax/libs/slick-carousel/1.8.1/slick.min.js").Include("~/Content/slick-carousel/slick.js"));
            bundles.Add(new ScriptBundle("~/assets/js/nice-select", "https://cdnjs.cloudflare.com/ajax/libs/jquery-nice-select/1.1.0/js/jquery.nice-select.min.js").Include("~/Content/jquery-nice-select/js/jquery.nice-select.js"));
            bundles.Add(new ScriptBundle("~/assets/js/countdown").Include("~/Scripts/countdown/countdown.min.js"));
            bundles.Add(new ScriptBundle("~/assets/js/image-zoom", "https://cdnjs.cloudflare.com/ajax/libs/jquery-zoom/1.7.21/jquery.zoom.min.js").Include("~/Scripts/zoom/jquery.zoom.js"));
            bundles.Add(new ScriptBundle("~/assets/js/image-loaded", "https://unpkg.com/imagesloaded@5/imagesloaded.pkgd.min.js").Include("~/Scripts/imageloaded/imagesloaded.pkgd.js"));
            bundles.Add(new ScriptBundle("~/assets/js/google-map").Include("~/Scripts/google-map.js"));
            bundles.Add(new ScriptBundle("~/assets/js/toastr", "https://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/toastr.min.js").Include("~/Scripts/toastr/toastr.min.js"));

            //Nén file (optimize files)
            BundleTable.EnableOptimizations = true;
        }
    }
}
