
using System.Collections.Generic;
using System.Linq;

namespace TravelPalSlutuppgift
{
    public class TravelManager
    {
        public static List<Travel> Travels { get; set; } = new()
            {
                new WorkTrip("Tokyo", Countrys.Japan, 2, "Big time boss meeting with high up clients", UserManager.Users.First(u => u.UserName == "kalle88")),
                new Vacation("Helsinki", Countrys.Finland, 1, true, UserManager.Users.First(u => u.UserName == "kawaii")),
            };

        public static void AddTravel(Travel location)
        {
            Travels.Add(location);
        }


        public static void RemoveTravel(Travel location)
        {
            Travels.Remove(location);
        }
    }
}
