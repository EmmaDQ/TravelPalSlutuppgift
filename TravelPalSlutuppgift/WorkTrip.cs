namespace TravelPalSlutuppgift
{
    public class WorkTrip : Travel
    {
        public string MeetingDetails { get; set; }

        public WorkTrip(string destination, Countrys country, int travelers, string meetingDetails, IUser user) : base(destination, country, travelers, user)
        {
            MeetingDetails = meetingDetails;
        }

        public override string GetInfo()
        {
            return "";
        }
    }
}
