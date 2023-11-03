using System.Collections.Generic;

namespace TravelPalSlutuppgift
{
    public class WorkTrip : Travel
    {
        public string MeetingDetails { get; set; }

        public WorkTrip(string destination, Countrys country, int travelers, string meetingDetails, IUser user, List<PackingListItem> pack) : base(destination, country, travelers, user, pack)
        {
            MeetingDetails = meetingDetails;
        }

        public override string GetInfo()
        {
            return "";
        }
    }
}
