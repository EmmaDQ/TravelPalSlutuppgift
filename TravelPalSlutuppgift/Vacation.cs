using System;

namespace TravelPalSlutuppgift
{
    internal class Vacation : Travel
    {
        public bool IsAllInclusive { get; set; }

        public Vacation(string destination, Countrys country, int travelers, DateTime start, DateTime end, int traveldays, bool isAllInclusive) : base(destination, country, travelers, start, end, traveldays)
        {
            IsAllInclusive = isAllInclusive;
        }


        public override string GetInfo()
        {
            return "";
        }
    }
}
