using System.Web.Mvc;

namespace ORA.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            if (Session != null)
            {
                return View();
            }
            return RedirectToAction("Login", "Login");
        }
    }
}