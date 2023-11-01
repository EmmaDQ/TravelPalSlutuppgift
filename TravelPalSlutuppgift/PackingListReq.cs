namespace TravelPalSlutuppgift
{
    internal class PackingListReq : PackingListItem
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public bool Required { get; set; }

        public PackingList(string name, int quantity)
        {
            Name = name;
            Quantity = quantity;
        }

        public PackingList(string name, bool required)
        {
            Name = name;
            Required = required;

        }
    }
}