namespace Discovery.iTextSharp.models
{
    internal class BaseAddress : IAddress
    {
        public string Country { get; set; }
        public string Fax { get; set; }
        public string Location { get; set; }
        public string Mail { get; set; }
        public string Name { get; set; }
        public long Number { get; set; }
        public string Phone { get; set; }
        public string Postal { get; set; }
        public string Street { get; set; }
        public string Website { get; set; }
    }
}
