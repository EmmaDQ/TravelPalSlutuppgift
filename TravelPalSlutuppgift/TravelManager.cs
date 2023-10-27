using System.Collections.Generic;

namespace TravelPalSlutuppgift
{
    internal class TravelManager
    {
        public static List<Travel> Travels { get; set; } = new()
            {
                new WorkTrip("Tokyo", Countrys.Japan, 2, "Big time boss meeting with high up clients"),
                new Vacation("Helsinki", Countrys.Finland, 1, true),

            };

        public void AddTravel(Travel location)
        {

        }


        public void RemoveTravel(Travel location)
        {

        }
    }
}
