namespace FCITHelpDesk.Models
{
    public class Contribution
    {
        public Contribution(int contrib_id, string? fname, string? lname, string? title,string? path,  string? course, string? type, string? link, DateTime? date)
        {
            this.contrib_id = contrib_id;
            this.fname = fname;
            this.lname = lname;
            this.title = title;
            this.path = path;
            this.course = course;
            this.type = type;
            this.path = path;
            this.date = date;
        }

        public int contrib_id { get; set; }
        public string? fname { get; set; }
        public string? lname { get; set; }
        public string? title { get; set; }
        public string? path { get; set; }
        public string? course { get; set; }
        public string? type { get; set; }
        public string? link { get; set; }
        public DateTime? date { get; set; }


    }
}
