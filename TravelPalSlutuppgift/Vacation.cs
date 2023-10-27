namespace TravelPalSlutuppgift
{
    internal class Vacation : Travel
    {
        public bool IsAllInclusive { get; set; }

        public Vacation(string destination, Countrys country, int travelers, bool isAllInclusive) : base(destination, country, travelers)
        {
            IsAllInclusive = isAllInclusive;
        }


        public override string GetInfo()
        {
            return "";
        }
    }
}
