namespace TravelPalSlutuppgift
{
    internal interface PackingListItem
    {
        public string? Name { get; set; }

        public string GetInfo()
        {
            return "";
        }
    }
}
