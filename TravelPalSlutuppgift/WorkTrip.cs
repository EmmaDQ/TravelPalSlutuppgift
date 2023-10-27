namespace TravelPalSlutuppgift
{
    internal class WorkTrip : Travel
    {
        public string MeetingDetails { get; set; }

        public WorkTrip(string destination, Countrys country, int travelers, string meetingDetails) : base(destination, country, travelers)
        {
            MeetingDetails = meetingDetails;
        }

        public override string GetInfo()
        {
            return "";
        }
    }
}
