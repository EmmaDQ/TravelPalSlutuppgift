namespace TravelPalSlutuppgift
{
    public interface PackingListItem
    {
        public string? Name { get; set; }

        public string GetInfo()
        {
            return "";
        }
    }
}
