namespace FCITHelpDesk.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Fname { get; set; }
        public string? Lname { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public char Is_admin { get; set; } // 'Y', 'N', 'R'
    }
}
