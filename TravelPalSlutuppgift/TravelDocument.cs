namespace TravelPalSlutuppgift
{
    internal class TravelDocument
    {
        public string? Name { get; set; }

        public bool IsRequired { get; set; }

        public TravelDocument(string name, bool isRequired)
        {
            Name = name;
            IsRequired = isRequired;
        }


        public string GetInfo()
        {
            return "";
        }
    }
}
