using FCITHelpDesk.Models;
using System;

namespace FCITHelpDesk.Controllers
{
    public class Helper
    {
        public static string connectionString = @"Data Source=ANC;Initial Catalog=fcithelpdesk;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public static User? loggedInUser = null;
        //public static User? loggedInUser = new() { Id = 1, Fname = "Muhammad", Lname = "Ans", Email = "BITF19M024", Is_admin = 'Y', Password = "123456" };
        public static List<string> Courses = new List<string>()
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
}
