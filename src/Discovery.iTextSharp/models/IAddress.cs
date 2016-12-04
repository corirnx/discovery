namespace Testing.iTextSharp.models
{
    internal interface IAddress
    {
        long Number { get; set; }
        string Name { get; set; }
        string Mail { get; set; }
        string Phone { get; set; }
        string Fax { get; set; }
        string Website { get; set; }
        string Country { get; set; }
        string Street { get; set; }
        string Postal { get; set; }
    }
}
