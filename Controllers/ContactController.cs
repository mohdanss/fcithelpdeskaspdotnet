using Microsoft.AspNetCore.Mvc;
using FCITHelpDesk.Models;
using System.Data;
using System.Data.SqlClient;

namespace FCITHelpDesk.Controllers
{
    public class ContactController : Controller
    {
        // GET: HomeController1
        public IActionResult Index()
        {
            if (Helper.loggedInUser == null)
                return View("Views/Welcome/Index.cshtml");

            ViewBag.user = Helper.loggedInUser;
            return View();
        }

        [HttpPost]
        public IActionResult Index(IFormCollection form)
        {
            string fname = form["fname"].ToString().Trim();
            string lname = form["lname"].ToString().Trim();
            string messageType = form["selectPurpose"].ToString().Trim().ToLower();
            string message = form["desc"].ToString().Trim();

            // inserting into the database...
            SqlConnection conn = new(Helper.connectionString);
            try
            {
                conn.Open();

                string query = @"INSERT INTO contacts (fname, lname, type, message, date) VALUES(@fname, @lname, @messageType, @message, @dateMessaged)";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@fname", fname);
                cmd.Parameters.AddWithValue("@lname", lname);
                cmd.Parameters.AddWithValue("@messageType", messageType);
                cmd.Parameters.AddWithValue("@message", message);
                cmd.Parameters.AddWithValue("@dateMessaged", DateTime.Now);

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

            ViewBag.User = Helper.loggedInUser;
            return View();

        }

    }
}
