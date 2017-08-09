using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace EventReg.UI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Admin",
                url: "admin/{*path}",
                defaults: new { controller = "Home", action = "Admin", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "App",
                url: "{customer}/app/{*path}",
                defaults: new { controller = "Home", action = "App", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{*path}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
