namespace TravelPalSlutuppgift
{
    internal class User : IUser
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public Countrys Location { get; set; }


        public User(string username, string password, Countrys country)
        {
            UserName = username;
            Password = password;
            Location = country;

        }
    }
}
