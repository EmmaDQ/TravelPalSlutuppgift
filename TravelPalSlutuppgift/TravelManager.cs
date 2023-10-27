using System.Collections.Generic;

namespace TravelPalSlutuppgift
{
    internal class TravelManager
    {
        public List<Travel> Travels { get; set; } = new List<Travel>()
            {
                new Travel("Tokyo", Countrys.Japan, 2),
                new Travel("Helsinki", Countrys.Finland, 1),

            };

        public void AddTravel(Travel location)
        {

        }


        public void RemoveTravel(Travel location)
        {

        }
    }
}
