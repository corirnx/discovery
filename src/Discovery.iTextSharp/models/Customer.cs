using System.Collections.Generic;

namespace Discovery.iTextSharp.models
{
    internal class Customer
    {
        internal IAddress Company { get; set; }
        internal IEnumerable<IAddress> Contacts { get; set; }
    }
}
