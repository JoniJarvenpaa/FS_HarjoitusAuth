namespace SecondMVC.Models
{
    public class User
    {
        private static List<string> firstNames = new List<string>()
        {
            "Joni", // 0
            "Mika", // 1
            "Jalmari", // 2
            "Juhani" // 3
        };
        private static List<string> lastNames = new List<string>()
        { 
            "Järvenpää",
            "Virolainen"
        };
        public string name { get; set; }
        public string role { get; set; }
        public bool isAdmin { get; set; }

        public User()
        { 
            var rnd = new Random();
            var fname = firstNames[rnd.Next(firstNames.Count())];
            var lname = lastNames[rnd.Next(lastNames.Count())];
            name = fname + " " + lname; // $"{fname} {lname}"
            role = "Programmer";
            if (rnd.Next(100) > 85) { isAdmin = true; }
        }
    }
}
