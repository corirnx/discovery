using System;
using System.Collections.Generic;

namespace Discovery.iTextSharp.models
{
    public class Bill
    {
        public long Number { get; set; }
        public DateTime Date { get; set; }
        public Customer Customer { get; set; }
        public IEnumerable<Article> Articles { get; set; }
    }
}
