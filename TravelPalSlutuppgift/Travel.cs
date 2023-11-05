using System;
using System.Collections.Generic;

namespace TravelPalSlutuppgift
{
    public class Travel
    {
        public string DestinationCity { get; set; }
        public Countrys Country { get; set; }
        public int Travelers { get; set; }
        public List<PackingListItem> PackingList { get; set; } = new();
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TravelDays { get; set; }
        public IUser User { get; set; }


        public Travel(string destination, Countrys country, int travelers, IUser user, List<PackingListItem> pack)
        {
            DestinationCity = destination;
            Country = country;
            Travelers = travelers;
            User = user;
            PackingList = pack;
        }


        public virtual string? GetInfo()
        {

            return PackingList.ToString();


        }

        private int CalculateTravelDays()
        {
            /*int daysTraveling = StartDate - EndDate;
            TravelDays = daysTraveling;*/
            return 0;
        }
    }
}
