namespace TravelPalSlutuppgift
{
    internal class PackingListQuant : PackingListItem
    {
        public string Name { get; set; }
        public int Quantity { get; set; }

        public PackingListQuant(string name, int quantity)
        {
            Name = name;
            Quantity = quantity;
        }
    }
}