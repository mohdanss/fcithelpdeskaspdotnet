using Microsoft.AspNetCore.Mvc;
using FCITHelpDesk.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace FCITHelpDesk.Controllers
{
    public class ContributionController : Controller
    {
        //GET: ContributionController
        public List<string> getCourses()
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
        public ActionResult Index()
        {
            if (Helper.loggedInUser == null)
                return View("Views/Welcome/Index.cshtml");

            ViewBag.Courses = getCourses();
            ViewBag.user = Helper.loggedInUser;
            return View();
        }


        [Obsolete]
        private Microsoft.AspNetCore.Hosting.IHostingEnvironment Environment;

        [Obsolete]
        public ContributionController(Microsoft.AspNetCore.Hosting.IHostingEnvironment _environment)
        {
            Environment = _environment;
        }

        [Obsolete]
        [HttpPost]
        public IActionResult Index(IFormCollection data, IFormFile contribution_file)
        {


            //string wwwPath = this.Environment.WebRootPath;
            //string contentPath = this.Environment.ContentRootPath;

            string filePath = Path.Combine(this.Environment.WebRootPath, "Data");
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }


            string fileName = Path.GetFileName(contribution_file.FileName);
            using (FileStream stream = new FileStream(Path.Combine(filePath, fileName), FileMode.Create))
            {
                contribution_file.CopyTo(stream);
                ViewBag.Message = "Thank Your for D Contribution ❤";
            }

            string title = data["title"];
            string course = data["selectCourse"];
            string type = data["theItems"];
            string link = data["contrib_link"];
            DateTime date = DateTime.Now;



            //Console.WriteLine(fileName);
            //Console.WriteLine(Helper.loggedInUser.Id);
            //Console.WriteLine(title);
            //Console.WriteLine(course);
            //Console.WriteLine(type);
            //Console.WriteLine(date);
            //Console.WriteLine(link);

            AddContribution(Helper.loggedInUser.Fname, Helper.loggedInUser.Lname, title, fileName, course, type, link, date);

            ViewBag.Courses = getCourses();
            ViewBag.User = Helper.loggedInUser;
            return View();
        }

        [NonAction]
        public void AddContribution(string? fname, string? lname, string title, string path, string course, string type, string link, DateTime date)
        {
            SqlConnection conn = new(Helper.connectionString);
            try
            {
                conn.Open();

                string query = @"INSERT INTO contribution (fname, lname, title, path, course, type, link, date) VALUES(@fname, @lname, @title, @path, @course, @type, @link, @date)";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@fname", fname);
                cmd.Parameters.AddWithValue("@lname", lname);
                cmd.Parameters.AddWithValue("@title", title);
                cmd.Parameters.AddWithValue("@path", path);
                cmd.Parameters.AddWithValue("@course", course);
                cmd.Parameters.AddWithValue("@type", type);
                cmd.Parameters.AddWithValue("@link", link);
                cmd.Parameters.AddWithValue("@date", date);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }


    }
}
