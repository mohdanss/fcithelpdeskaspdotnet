using Microsoft.AspNetCore.Mvc;
using FCITHelpDesk.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace FCITHelpDesk.Controllers
{
    public class CourseController : Controller
    {
        [NonAction]
        public List<Contribution> getContribs(int id)
        {
            List<Contribution> contributions = new List<Contribution>();
            
            SqlConnection conn = new(Helper.connectionString);
            try
            {
                conn.Open();


                String query = @"SELECT * FROM contribution where course=@course";
                SqlCommand cmd = new(query, conn);

                cmd.Parameters.AddWithValue("@course", Helper.Courses[id]);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    contributions.Add(new Contribution(
                        reader.GetInt32(0),
                        reader.GetString(1),
                        reader.GetString(2),
                        reader.GetString(3),
                        reader.GetString(4),
                        reader.GetString(5),
                        reader.GetString(6),
                        reader.GetString(7),
                        reader.GetDateTime(8)
                    ));
                }
                return contributions;
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

        public IActionResult Index(int courseId)
        {
            if (Helper.loggedInUser == null)
                return View("Views/Welcome/Index.cshtml");

            ViewBag.contribs = getContribs(courseId);
            ViewBag.courseName = CoursesController.getCourses()[courseId];
            ViewBag.user = Helper.loggedInUser;
            return View();
        }

        public FileResult ShowMedia(string? path)
        {
            return File("~/Data/" + path, "*/*");
        }
        public FileResult DownloadMedia(string? path)
        {
            return File("~/Data/" + path, "*/*", path);
        }
    }
}
