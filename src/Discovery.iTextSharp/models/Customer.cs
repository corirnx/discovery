using System.Collections.Generic;

namespace Discovery.iTextSharp.models
{
    public class Customer
    {
        public BaseAddress Company { get; set; }
        public IEnumerable<BaseAddress> Contacts { get; set; }
    }
}
