using iTextSharp.text;
using iTextSharp.text.pdf;

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

        internal static PdfPCell GetSmallesCell(string phrase)
        {
            var cell = GetCell(3, BaseColor.WHITE);
            cell.Phrase = new Phrase(phrase) { Font = GetSmallestFont() };
            cell.Phrase.Font.Size = 6f;

            return cell;
        }

        internal static PdfPCell GetCell(int colspan, BaseColor borderColor)
        {
            return new PdfPCell
            {
                Colspan = colspan,
                HorizontalAlignment = Element.ALIGN_LEFT,
                VerticalAlignment = Element.ALIGN_MIDDLE,
                BorderColor = borderColor
            };
        }

        internal static PdfPHeaderCell GetHeaderCell(string content)
        {
            return new PdfPHeaderCell
            {
                Colspan = 1,
                HorizontalAlignment = Element.ALIGN_LEFT,
                VerticalAlignment = Element.ALIGN_MIDDLE,
                BorderColor = BaseColor.WHITE,
                BorderColorBottom = BaseColor.GRAY,
                Phrase = new Phrase(content) { Font = GetBaseFont() }
            };
        }
    }
}
