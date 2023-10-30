namespace TravelPalSlutuppgift
{
    internal class Vacation : Travel
    {
        public bool IsAllInclusive { get; set; }

        public Vacation(string destination, Countrys country, int travelers, bool isAllInclusive, IUser user) : base(destination, country, travelers, user)
        {
            IsAllInclusive = isAllInclusive;
        }


        public override string GetInfo()
        {
            return "";
        }
    }
}
