using System.Web.Mvc;

namespace BeingDK.ExpenseTracker.Web.FrontEnd.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}