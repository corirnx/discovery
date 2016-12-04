namespace Discovery.iTextSharp.models
{
    public class Article
    {
        public long Number { get; set; }
        public string DisplayName { get; set; }
        public string Producer { get; set; }
        public decimal Price { get; set; }
        public decimal TaxInPercent { get; set; }
        public int Amount { get; set; }
    }
}
