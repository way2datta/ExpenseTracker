using System.Web.Mvc;
using System.Web.Routing;

namespace BeingDK.ExpenseTracker.Web.FrontEnd
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("Logout",
                            "logout/",
                            new { controller = "Account", action = "Logout" }
                            );

            routes.MapRoute("Home",
                     "home",
                     new { controller = "Home", action = "Index" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}