namespace Group5API.Models
{
    public class TeamMember
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Major { get; set; }
        public string Year { get; set; }

        public TeamMember() { }

        public TeamMember(int id, string name, string email, string major, string year)
        {
            Id = id;
            Name = name;
            Email = email;
            Major = major;
            Year = year;
        }
    }
}
