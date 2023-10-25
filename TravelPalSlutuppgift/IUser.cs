namespace TravelPalSlutuppgift
{
    internal interface IUser
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public Countrys Location { get; set; }

    }
}
