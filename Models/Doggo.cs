namespace SecondMVC.Models
{
    public class Doggo : DB_SaveableObject
    {
        public string name { get; set; }
        public string color { get; set; }
        public int age { get; set; }
    }
}
