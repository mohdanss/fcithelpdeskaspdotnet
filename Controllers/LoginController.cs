using Microsoft.AspNetCore.Mvc;
using FCITHelpDesk.Models;
using System.Data;
using System.Data.SqlClient;

namespace FCITHelpDesk.Controllers
{
    public class LoginController : Controller
    {
        
        public List<User> Get_all_users_from_db()
        {
            SqlConnection conn = new(Helper.connectionString);
            try
            {
                conn.Open();
                string query = "select * from Users";
                SqlDataAdapter adapter = new(query, conn);

                SqlCommand cmd = new(query, conn);

                SqlDataReader dr = cmd.ExecuteReader();

                List<User> users = new();

                while (dr.Read())
                {
                    User user = new()
                    {
                        Id = Convert.ToInt32(dr["id"]),
                        Fname = dr["fname"].ToString().Trim(),
                        Lname = dr["lname"].ToString().Trim(),
                        Email = dr["email"].ToString().Trim(),
                        Password = dr["password"].ToString().Trim(),
                        Is_admin = Convert.ToChar(dr["is_admin"].ToString().Trim())
                    };

                    users.Add(user);
                }

                dr.Close();
                return users;
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
        public IActionResult Index()
        {
            List<User> all_users_in_db = this.Get_all_users_from_db();
            return View(all_users_in_db);
        }

        // verify the login using data from the form...
        [HttpPost]
        public void VerifyLogin(IFormCollection form)
        {
            List<User> users = Get_all_users_from_db();
            string email = form["loginid"].ToString().Trim() + "@pucit.edu.pk";
            email = email.ToLower();
            String password = form["password"].ToString().Trim();

            Console.WriteLine(users.Count());

            foreach (User user in users)
            {
                Console.WriteLine(user.Email);
                Console.WriteLine(user.Password);
                if (email.Equals(user.Email) && password.Equals(user.Password))
                {
                    Helper.loggedInUser = user;
                    Console.WriteLine("Authenticated: " + user.Lname);
                    Response.Redirect("/Home");
                    return;
                }
            }
           Response.Redirect("/Login");
        }
    }
}
