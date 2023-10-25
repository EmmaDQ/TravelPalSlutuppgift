using System;

namespace TravelPalSlutuppgift
{
    internal class Travel
    {
        public string Destination { get; set; }
        public Countrys Country { get; set; }
        public int Travelers { get; set; }

        //public List <PackingListItem> packingList = new List<PackingListItem> ();
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TravelDays { get; set; }


        public Travel(string destination, Countrys country, int travelers, DateTime start, DateTime end, int traveldays)
        {
            Destination = destination;
            Country = country;
            Travelers = travelers;
            StartDate = start;
            EndDate = end;
            TravelDays = traveldays;
        }


        public virtual string GetInfo()
        {
            return "";
        }

        private int CalculateTravelDays()
        {
            return 0;
        }
    }
}
