using System;

namespace TravelPalSlutuppgift
{
    internal class WorkTrip : Travel
    {
        public string MeetingDetails { get; set; }

        public WorkTrip(string destination, Countrys country, int travelers, DateTime start, DateTime end, int traveldays, string meetingDetails) : base(destination, country, travelers, start, end, traveldays)
        {
            MeetingDetails = meetingDetails;
        }

        public override string GetInfo()
        {
            return "";
        }
    }
}
