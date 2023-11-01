using System;
using System.Collections.Generic;

namespace TravelPalSlutuppgift
{
    public class Travel
    {
        public string DestinationCity { get; set; }
        public Countrys Country { get; set; }
        public int Travelers { get; set; }
        public static List<PackingListItem> PackingList { get; set; } = new()
        {
            new PackingListReq("Passport", true ),
            new PackingListQuant("Toothbrush", 1),
            new PackingListQuant("Charger", 1),
        };
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TravelDays { get; set; }
        public IUser User { get; set; }


        public Travel(string destination, Countrys country, int travelers, IUser user)
        {
            DestinationCity = destination;
            Country = country;
            Travelers = travelers;
            User = user;
        }


        public virtual string GetInfo()
        {
            return "";
        }

        private int CalculateTravelDays()
        {
            /*int daysTraveling = StartDate - EndDate;
            TravelDays = daysTraveling;*/
            return 0;
        }
    }
}
