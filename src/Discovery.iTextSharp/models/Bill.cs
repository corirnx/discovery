using System;
using System.Collections.Generic;

namespace Testing.iTextSharp.models
{
    internal class Bill
    {
        internal long Number { get; set; }
        internal DateTime Date { get; set; }
        internal Customer Customer { get; set; }
        internal IEnumerable<Article> Articles { get; set; }
    }
}
