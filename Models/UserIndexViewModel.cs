namespace SecondMVC.Models
{
    public class UserIndexViewModel
    {
        public List<User> userList { get; set; }
        public List<string> roles { get; set; }
        public int userCount { get
            {
                return userList.Count();
            } }
        public string mostCommonName { get
            {
                return userList.Select(u => u.name.Split(" ")[0])
                        .GroupBy(g => g)
                        .OrderByDescending(e => e.Count())
                        .First()
                        .Key;
            } }
        public int mostCommonNameOccurrence { get
            {
                return userList.Select(u => u.name.Split(" ")[0])
                        .GroupBy(g => g)
                        .OrderByDescending(e => e.Count())
                        .First()
                        .Count();
            } }
        public UserIndexViewModel()
        {
            var lista = new List<User>();
            var rnd = new Random();
            for (int i = 0; i < rnd.Next(10, 2000); i++)
            {
                lista.Add(new User());
            }
            userList = lista;
            roles = new List<string>();
            roles.Add("Lecturer");
            roles.Add("Traffic Management");
            roles.Add("Programmer");
            roles.Add("Management");
            roles.Add("Arm swinger");
        }
    }
}
