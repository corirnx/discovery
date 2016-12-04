namespace Discovery.iTextSharp.models
{
    internal class Article
    {
        internal long Number { get; set; }
        internal string DisplayName { get; set; }
        internal string Producer { get; set; }
        internal decimal Price { get; set; }
        internal decimal TaxInPercent { get; set; }
        internal int Amount { get; set; }
    }
}
