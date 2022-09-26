using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FCITHelpDesk.Controllers
{
    public class WelcomeController : Controller
    {
        // GET: HomeController
        public ActionResult Index()
        {
            return View();
        }
    }
}
