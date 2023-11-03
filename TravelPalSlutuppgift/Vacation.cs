using System.Collections.Generic;

namespace TravelPalSlutuppgift
{
    internal class Vacation : Travel
    {
        public bool IsAllInclusive { get; set; }

        public Vacation(string destination, Countrys country, int travelers, bool isAllInclusive, IUser user, List<PackingListItem> pack) : base(destination, country, travelers, user, pack)
        {
            IsAllInclusive = isAllInclusive;
        }


        public override string GetInfo()
        {
            return "";
        }
    }
}
