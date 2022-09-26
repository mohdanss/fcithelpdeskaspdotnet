using Microsoft.AspNetCore.Mvc;
using FCITHelpDesk.Models;
using System.Data;
using System.Data.SqlClient;

namespace FCITHelpDesk.Controllers
{
    public class RegisterController : Controller
    {
        // GET: HomeController1
        public IActionResult Index()
        {
            ErrorViewModel evm = new();
            return View(evm);
        }

        [HttpPost]
        public void RegisterUser(IFormCollection form)
        {
            string fname = form["fname"].ToString().Trim();
            string lname = form["lname"].ToString().Trim();
            string email = form["roll"].ToString().Trim().ToLower();
            string password = form["password"].ToString().Trim();
            string password1 = form["password1"].ToString().Trim();
            string joinas = form["joinas"].ToString().Trim();

            email = email.ToLower() + "@pucit.edu.pk";
            char is_admin = 'N';
            if (joinas == "Admin") // if user request as registeration as Admin, set it to 'R' request, that'll either be approved or user will set to a normal user by the admin
                is_admin = 'R';

            // inserting into the database...
            SqlConnection conn = new(Helper.connectionString);
            try
            {
                conn.Open();

                Console.WriteLine(123);
                // insert into user table
                string query = @"INSERT INTO users(fname, lname, email, password, is_admin) VALUES(@fname, @lname, @email, @password, @is_admin)";
                Console.WriteLine(456);


                SqlDataAdapter adapter = new (query, conn);

                SqlCommand cmd = new(query, conn);


                cmd.Parameters.AddWithValue("@fname", fname);
                cmd.Parameters.AddWithValue("@lname", lname);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@is_admin", is_admin);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (SqlException ex)
            {

                Console.WriteLine(ex.Message);
                throw ex;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
            Response.Redirect("/Login");
        }
    }
}
