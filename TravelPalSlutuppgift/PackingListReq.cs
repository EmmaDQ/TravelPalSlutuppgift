namespace TravelPalSlutuppgift
{
    internal class PackingListReq : PackingListItem
    {
        public string Name { get; set; }
        public bool Required { get; set; }



        public PackingListReq(string name, bool required)
        {
            Name = name;
            Required = required;

        }
    }
}