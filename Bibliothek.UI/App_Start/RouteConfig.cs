using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Bibliothek.UI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
               name: "Kategori",
               url: "kategori",
               defaults: new
               {
                   controller = "Product",
                   action = "Index"
               });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { area = "Web", controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "Bibliothek.UI.Areas.Web.Controllers" }
            ).DataTokens.Add("area", "Web");
        }
    }
}
