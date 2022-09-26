using Microsoft.AspNetCore.Mvc;

namespace FCITHelpDesk.Controllers
{
    public class AvailableCoursesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
