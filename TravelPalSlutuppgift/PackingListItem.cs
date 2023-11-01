namespace TravelPalSlutuppgift
{
    public interface PackingListItem
    {
        public string? Name { get; set; }
        public int Quantity { get; set; }

        public string GetInfo()
        {
            return "";
        }
    }
}
