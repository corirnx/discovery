using System.Collections.Generic;

namespace Testing.iTextSharp.models
{
    internal class Customer
    {
        internal IAddress Company { get; set; }
        internal IEnumerable<IAddress> Contacts { get; set; }
    }
}
