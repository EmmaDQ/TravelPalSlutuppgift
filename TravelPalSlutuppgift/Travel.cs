using System;


namespace TravelPalSlutuppgift
{
    internal class Travel
    {
        public string DestinationCity { get; set; }
        public Countrys Country { get; set; }
        public int Travelers { get; set; }
        public System.Collections.Generic.List<PackingListItem> PackingList { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TravelDays { get; set; }


        public Travel(string destination, Countrys country, int travelers)
        {
            DestinationCity = destination;
            Country = country;
            Travelers = travelers;

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
