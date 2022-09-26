using Microsoft.AspNetCore.Mvc;

namespace FCITHelpDesk.Controllers
{
    public class CoursesController : Controller
    {
        public static List<string> getCourses()
        {
            return new List<string>()
            {
                "Programming Fundamentals",
                "Object Oriented Programming",
                "Data Structures & Algorithm",
                "Linear Algebra",
                "Intro To Computing",
                "Enterprise & Application Development",
                "Analysis Of Algorithm",
                "Sociology",
                "Computer Networks"
            };
        }
        public IActionResult Index()
        {
            if (Helper.loggedInUser == null)
                return View("Views/Welcome/Index.cshtml");

            ViewBag.Courses = getCourses(); 
            ViewBag.user = Helper.loggedInUser;
            return View();
        }
    }
}
