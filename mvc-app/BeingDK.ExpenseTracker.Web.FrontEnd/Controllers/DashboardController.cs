using System.Web.Mvc;

namespace BeingDK.ExpenseTracker.Web.FrontEnd.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}