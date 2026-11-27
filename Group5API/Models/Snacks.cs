namespace Group5API.Models
{
    public class Snacks
    {
        public int ID { get ; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string favSnack { get; set; }

        public Snacks() { }

        public Snacks(int id, string firstname, string lastname, string favsnack)
        {
            ID = id;
            firstName = firstname;
            lastName = lastname;
            favSnack = favsnack;
        } 

    }
}
