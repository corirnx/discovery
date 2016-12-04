using iTextSharp.text;

namespace Discovery.iTextSharp.infrastructure.helper
{
    internal static class Layout
    {
        internal static Font GetBaseFont()
        {
            return FontFactory.GetFont("Segoe UI", 12.0f, BaseColor.BLACK);
        }

        internal static Font GetSmallestFont()
        {
            return FontFactory.GetFont("Segoe UI", 6.0f, BaseColor.BLACK);
        }
    }
}
