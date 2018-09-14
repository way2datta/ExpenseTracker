using System.Web.Mvc;
using System.Web.Routing;

namespace BeingDK.ExpenseTracker.Web.FrontEnd
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}